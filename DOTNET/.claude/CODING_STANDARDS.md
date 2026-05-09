# Coding Standards

## C# / .NET
- .NET 8 — use primary constructors, collection expressions, `required` members
- Nullable reference types enabled — no `#nullable disable`; handle nulls explicitly
- `record` types for immutable DTOs/value objects; `record class` or `record struct` as appropriate
- No magic strings — use `nameof()`, constants, or enums

## Architecture (Clean Architecture)
- `Api` layer: controllers + middleware only — no business logic; delegate to MediatR handlers
- `Application` layer: use cases (commands/queries via MediatR), interfaces, DTOs, validators
- `Domain` layer: entities, value objects, domain events — no infrastructure references
- `Infrastructure` layer: EF Core DbContext, repository implementations, external services
- Dependency direction: Api → Application → Domain ← Infrastructure

## Naming
- Classes, records, properties: `PascalCase`
- Methods, local variables: `camelCase` (locals) / `PascalCase` (methods)
- Private fields: `_camelCase`
- Constants: `PascalCase` (C# convention)
- REST endpoints: `kebab-case` (e.g. `/reset-password`)
- Test classes: `<ClassName>Tests` (unit) / `<ClassName>IntegrationTests` (integration)

## Error handling
- Throw typed domain exceptions from Application layer (e.g. `NotFoundException`)
- Global exception handler middleware maps exceptions to `ProblemDetails` (RFC 9457)
- Never expose stack traces or raw exception messages in API responses
- Use `FluentValidation` for input validation in command/query handlers

## Style
- File-scoped namespaces (`namespace Foo.Bar;`)
- One type per file; file name matches type name
- `using` directives at the top, sorted: System → Microsoft → third-party → internal
- No `var` for non-obvious types; use explicit types for clarity
