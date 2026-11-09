# Features

| Route | Behavior |
| --- | --- |
| `/`, `/Admin` | Sample KPI cards, a seven-day revenue chart, fulfillment counts, and an orders table with a status filter. |
| `/Admin/Users` | Sample user metrics and the shared orders table with a status filter. |
| `/Admin/Roles` | Role Management heading and the shared orders table with a status filter. |
| `/counter` | Interactive Blazor Server counter. |
| `/weather` | Sample forecasts from the API with a fallback when the service is unavailable. |
| `/login`, `/register`, `/forgot-password` | Account screens with unavailable messages and disabled actions in the default setup. |
| Missing routes and server errors | Dedicated 404 and 500 pages. Unhandled exceptions use the 500 page outside Development. |

The shared shell provides desktop navigation and a mobile drawer. The dashboard pages use bundled sample orders. The API's `/orders` endpoint reads persisted rows from SQL Server.

The Admin routes currently expose sample views. Account authentication, access policies, and user and role management operations remain open work.
