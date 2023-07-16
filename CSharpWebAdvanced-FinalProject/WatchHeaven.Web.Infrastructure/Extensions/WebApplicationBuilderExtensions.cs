 namespace Microsoft.Extensions.DependencyInjection.Extensions
{
    using DependencyInjection;
    using System.Reflection;

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
    }
}
