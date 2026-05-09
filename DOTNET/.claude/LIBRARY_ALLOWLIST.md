# Library Allowlist

## Approved NuGet packages

- `MediatR` — CQRS commands/queries/notifications
- `FluentValidation` + `FluentValidation.AspNetCore` — input validation
- `Microsoft.EntityFrameworkCore` + `Npgsql.EntityFrameworkCore.PostgreSQL` — ORM + PostgreSQL
- `Microsoft.EntityFrameworkCore.Tools` — EF migrations CLI
- `Microsoft.AspNetCore.Authentication.JwtBearer` — JWT bearer auth
- `Microsoft.Extensions.Configuration.Abstractions` — typed config (IOptions<T>)
- `Serilog.AspNetCore` + `Serilog.Sinks.Console` — structured logging
- `Mapster` — object mapping (use only in Application layer mappers)

## Dev / test only

- `xunit` + `xunit.runner.visualstudio` — test framework
- `FluentAssertions` — readable test assertions
- `NSubstitute` — mocking
- `Microsoft.AspNetCore.Mvc.Testing` — integration test WebApplicationFactory
- `Testcontainers.PostgreSql` — real DB for integration tests

## Explicitly banned

- `AutoMapper` → use `Mapster` or write explicit mapping methods
- `Newtonsoft.Json` → use `System.Text.Json` (built-in)
- `Dapper` → use EF Core; raw SQL only via `FromSqlRaw` when EF is insufficient
- `RestSharp` / `HttpClient` wrappers → use `IHttpClientFactory` + typed `HttpClient`
- `Moq` → use `NSubstitute`
- Any library NOT listed above — ask before adding
