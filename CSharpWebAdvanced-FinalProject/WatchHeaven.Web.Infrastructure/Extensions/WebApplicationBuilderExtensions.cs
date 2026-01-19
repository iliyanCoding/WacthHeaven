 namespace Microsoft.Extensions.DependencyInjection.Extensions
{
    using DependencyInjection;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using System.Reflection;
    using WatchHeaven.Data.Model;
    using static WatchHeaven.Common.GeneralApplicationConstants;

    public static class WebApplicationBuilderExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, Type serviceType)
        {
            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);
            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("Invalid service type provided.");
            }

            Type[] serviceTypes = serviceAssembly
                .GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();

            foreach (Type st in serviceTypes)
            {
                Type? interfaceType = st.GetInterface($"I{st.Name}");

                if (interfaceType == null)
                {
                    throw new InvalidOperationException($"No interface is provided for the servce with name: {st.Name}");
                }

                services.AddScoped(interfaceType, st);
            }
        }

        public static IApplicationBuilder SeedAdmin(this IApplicationBuilder app, string email)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole<Guid>> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                if (!await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    IdentityRole<Guid> role = new IdentityRole<Guid>(AdminRoleName);
                    await roleManager.CreateAsync(role);
                }

                ApplicationUser? adminUser = await userManager.FindByEmailAsync(email);

                if (adminUser != null && !await userManager.IsInRoleAsync(adminUser, AdminRoleName))
                {
                    await userManager.AddToRoleAsync(adminUser, AdminRoleName);
                }
            })
            .GetAwaiter()
            .GetResult();

            return app;
        }
    }
}
