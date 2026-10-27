# Government Workflow Management System

Original portfolio demonstration inspired by common enterprise workflow patterns. **Not affiliated with the State of Maryland or any government agency.** Uses fictional records only.

## Features
- Responsive Angular 18 dashboard with request counts
- Create department workflow requests
- Approve or reject requests
- ASP.NET Core 8 REST API
- EF Core + SQLite local persistence (no database installation needed)
- Labeled inputs, keyboard-focus styling, semantic tables and responsive layout

## Tech stack
Angular 18, TypeScript, HTML/CSS, ASP.NET Core Web API (.NET 8), Entity Framework Core, SQLite. An optional SQL Server schema reference is included in `database/`.

## Prerequisites
- .NET SDK 8
- Node.js 20.11.1 or 22.x compatible with Angular 18
- npm

## Run locally
Terminal 1:
```bash
cd backend
dotnet restore
dotnet run --urls http://localhost:5080
```
Terminal 2:
```bash
cd frontend
npm install
npm start
```
Open http://localhost:4200. The API listens on http://localhost:5080. On first launch, the backend creates `workflow.db` automatically.

## API
| Method | Path | Description |
| --- | --- | --- |
| GET | `/api/requests` | List requests |
| POST | `/api/requests` | Create request: `{ "title": "New laptop", "department": "IT", "description": "Demo" }` |
| PATCH | `/api/requests/{id}/status` | Update: `{ "status": "Approved" }` |

## Architecture
`Angular UI → ASP.NET Core Controllers → EF Core → SQLite`

## Scope and limitations
This is a **starter portfolio demo**, not a production-ready government application. It does not yet include authentication, authorization, audit history, migrations, CI/CD, deployment configuration, or automated test suites. Approve/reject operations are intentionally unsecured for local demonstration only. Do not deploy publicly without adding authentication, authorization, input validation, and security hardening. Accessibility patterns are included but WCAG 2.2 AA conformance has not been audited.

## Suggested next enhancements
1. Microsoft Entra ID / JWT auth and RBAC.
2. Approval history and audit trail.
3. SQL Server provider and EF migrations.
4. Unit and Playwright tests.
5. Azure App Service deployment and GitHub Actions.
6. Screenshots and a hosted demo.

## License
MIT; see LICENSE.
