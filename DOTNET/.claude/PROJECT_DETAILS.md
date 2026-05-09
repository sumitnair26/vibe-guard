# Project Details

## Project
[Replace this line with a one-sentence description of your API]

## Stack
- .NET 8 + ASP.NET Core Web API
- Clean Architecture (Api / Application / Domain / Infrastructure)
- EF Core 8 + PostgreSQL — persistence and migrations
- MediatR — CQRS command/query dispatching
- JWT Bearer — stateless authentication
- FluentValidation — request validation
- [Add your auth provider here, e.g. Auth0, Keycloak, Azure AD B2C]

## Key architectural decisions
- Clean Architecture: strict layer dependency direction (Api → Application → Domain ← Infrastructure)
- All business logic in Application layer MediatR handlers — controllers are thin dispatchers
- Domain entities never leave the Domain layer — always map to DTOs/response models before returning
- EF migrations managed in `Infrastructure/Persistence/Migrations/`
- Typed configuration via `IOptions<T>` bound in `appsettings.json` — no raw `IConfiguration` in business code
- `ProblemDetails` (RFC 9457) for all error responses via global exception middleware

## Environment variables
- Bound via `appsettings.json` + `appsettings.{Environment}.json` + environment variables
- Define all config in typed `Options` classes under `Infrastructure` or `Application`
- Secrets (DB password, JWT secret) via environment variables or secrets manager — never hardcoded
