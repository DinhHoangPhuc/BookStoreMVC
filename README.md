# BookStore

An online bookstore built with ASP.NET Core MVC, featuring user authentication, role-based authorization, and Stripe payment integration.

## Features

- User Authentication and Authorization with Identity
- Role-based access control (Admin and Customer roles)
- Shopping cart functionality
- Secure payment processing with Stripe
- Book category management
- Responsive design

## Tech Stack

- ASP.NET Core MVC
- Entity Framework Core
- Microsoft SQL Server
- Bootstrap
- Stripe Payment Gateway
- Identity Framework

## Project Structure

```
BookStore/
├── Areas/
│   ├── Admin/         # Admin panel views and controllers
│   ├── Customer/      # Customer facing views and controllers
│   └── Identity/      # Authentication related components
├── Controllers/       # Application controllers
├── Data/             # Database context and configurations
├── Models/           # Domain models
├── Repository/       # Data access layer
├── ViewModels/       # View specific models
└── Views/            # Application views
```

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later
- SQL Server
- Visual Studio 2022 (recommended) or VS Code

### Installation

1. Clone the repository
```bash
git clone https://github.com/DinhHoangPhuc/BookStoreMVC.git
```

2. Update the connection string in `appsettings.json`

3. Apply database migrations
```bash
dotnet ef database update
```

4. Run the application
```bash
dotnet run
```

## Configuration

- Update `appsettings.json` with your SQL Server connection string
- Configure Stripe API keys in the `appsettings.json`
- Set up email service configuration if required

## Contributing

1. Fork the repository
2. Create a new branch
3. Commit your changes
4. Push to the branch
5. Open a pull request

## License

This project is licensed under the MIT License - see the LICENSE file for details