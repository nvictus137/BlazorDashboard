# Requirements

## Local development

- Install the .NET 10 SDK.
- Use Visual Studio with SQL Server Data Tools to build the full solution and the SQL Server 2022 DACPAC.
- Make the Aspire CLI available for AppHost runs. The project references Aspire AppHost SDK `13.6.4` and uses the CLI bundle.
- Use SQL Server with the published database schema for the persisted Orders endpoint. Development defaults to `.\SQLEXPRESS2022`.
- Use a browser with JavaScript enabled for interactive filters, the counter, and mobile navigation.

See [configuration.md](configuration.md) for Aspire, standalone, and SQL Server setup.

## Template scope

- Provide a reusable dashboard shell and a shared overview component for Home and the Admin routes.
- Keep the example dashboards self-contained with bundled sample data.
- Demonstrate service discovery with Weather and SQL Server access with the Orders endpoint.
- Display dedicated HTTP error pages and clear account availability states.
- Require account service wiring and access policies before using the Admin screens for real administration.
