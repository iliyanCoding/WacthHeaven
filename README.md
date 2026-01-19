# WatchHeaven

A modern ASP.NET Core MVC web application for buying and selling luxury watches. WatchHeaven provides a platform for watch enthusiasts to browse, list, and manage watch listings with a clean, user-friendly interface.

## Features

- **User Authentication** - Secure registration and login powered by ASP.NET Core Identity
- **Watch Marketplace** - Browse watches by category, condition, brand, and price
- **Advanced Search & Filtering** - Find watches using multiple filter criteria and sorting options
- **Seller Dashboard** - Manage your listings, track active watches, and monitor sales
- **Favorites System** - Save watches to your favorites for quick access
- **Comments & Reviews** - Leave comments on watch listings
- **Admin Panel** - Administrative tools for managing users, listings, and site content
- **Real-time Updates** - SignalR integration for live notifications
- **Responsive Design** - Mobile-friendly Bootstrap UI

## Tech Stack

- **Framework:** ASP.NET Core 6.0 MVC
- **Database:** Microsoft SQL Server with Entity Framework Core 6.0
- **Authentication:** ASP.NET Core Identity
- **Real-time:** SignalR
- **Frontend:** Bootstrap 5, jQuery
- **Security:** Google reCAPTCHA integration

## Project Structure

```
WatchHeaven/
├── WatchHeaven.Web/                 # Main web application
│   ├── Controllers/                 # MVC Controllers
│   ├── Views/                       # Razor Views
│   ├── Areas/Admin/                 # Admin area
│   └── Hubs/                        # SignalR Hubs
├── WatchHeaven.Data/                # Data access layer
│   ├── Configuration/               # Entity configurations
│   └── Migrations/                  # EF Core migrations
├── WatchHeaven.Data.Model/          # Domain models
├── WatchHeaven.Services.Data/       # Business logic services
├── WatchHeaven.Services.Data.Models/# Service DTOs
├── WatchHeaven.Web.ViewModels/      # View models
├── WatchHeaven.Web.Infrastructure/  # Extensions and utilities
├── WatchHeaven.WebApi/              # REST API endpoints
└── WatchHeaven.Services.Tests/      # Unit tests
```

## Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later
- [SQL Server](https://www.microsoft.com/sql-server) (LocalDB, Express, or full edition)
- [Docker](https://www.docker.com/) (optional, for containerized SQL Server)

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/your-username/WatchHeaven.git
cd WatchHeaven/CSharpWebAdvanced-FinalProject
```

### 2. Configure the Database

Update the connection string in `WatchHeaven.Web/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=WatchHeaven;User Id=sa;Password=YourPassword;TrustServerCertificate=True"
  }
}
```

**Using Docker for SQL Server:**

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourPassword123!" \
  -p 1433:1433 --name sqlserver \
  -d mcr.microsoft.com/mssql/server:2022-latest
```

### 3. Apply Database Migrations

```bash
cd WatchHeaven.Web
dotnet ef database update
```

### 4. Run the Application

```bash
dotnet run --urls="http://localhost:5007"
```

The application will be available at `http://localhost:5007`

## Usage

### For Buyers
1. Register an account or log in
2. Browse watches using categories and filters
3. View watch details and seller information
4. Add watches to your favorites
5. Leave comments on listings

### For Sellers
1. Register and become a seller through the dashboard
2. Create watch listings with details and images
3. Manage your active listings
4. Edit or remove listings as needed

### For Administrators
1. Access the admin panel at `/Admin`
2. Manage user accounts and roles
3. Moderate listings and comments
4. View site statistics

## Watch Categories

- Chronograph
- Vintage
- Diving
- Pilot's
- Military
- Dress
- Smart
- Sport

## Running Tests

```bash
cd WatchHeaven.Services.Tests
dotnet test
```

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/new-feature`)
3. Commit your changes (`git commit -m 'Add new feature'`)
4. Push to the branch (`git push origin feature/new-feature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

For questions or feedback, please reach out at iliyan.programirane@gmail.com
