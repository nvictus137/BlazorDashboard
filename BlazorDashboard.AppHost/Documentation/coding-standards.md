# Coding standards

- Use four spaces for indentation. Use PascalCase for types and public members and camelCase for local variables and fields.
- Keep nullable reference types enabled and represent optional services or content with nullable types.
- Keep route components focused on route metadata, page titles, and page-specific content. Place repeated dashboard markup and scoped styles with the shared component.
- Use Blazor's built-in `PageTitle` for browser titles. Use an interactive render mode on pages with Blazor event handlers, such as the orders filter.
- Use typed HTTP clients for service calls and pass cancellation tokens through asynchronous API and database operations.
- Await asynchronous event handlers. Render validation messages as text and label interactive controls.
- Put tables and stored procedures in the SQL database project. Keep the EF model aligned with the published schema.
- Keep machine-specific project settings and local database files out of Git. [Ignore rules](../../.gitignore)
