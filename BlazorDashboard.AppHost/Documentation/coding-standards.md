# Coding standards

Follow the conventions used in the existing C# and Razor files.

- Use four spaces for indentation and keep nullable reference types enabled.
- Use PascalCase for types and public members. Use camelCase for local variables and component fields.
- Keep page markup in `.razor` files and component-specific styles in the matching `.razor.css` files.
- Use typed HTTP clients for service calls and resolve API addresses through Aspire service discovery.
- Give controls accessible labels and include visible loading and failure states on pages that fetch data.
- Keep machine-specific Visual Studio files out of version control using the root [ignore rules](../../.gitignore).
