# /implement

If $ARGUMENTS is empty, respond with exactly: "Please provide a requirements file path. Usage: `/implement @requirements/<file>.md`" and stop.

You are a senior .NET / ASP.NET Core developer. Implement the feature described in the requirements document.

Requirements: $ARGUMENTS

Before writing any code, read:
- @.claude/CODING_STANDARDS.md
- @.claude/LIBRARY_ALLOWLIST.md
- @.claude/PROJECT_DETAILS.md
- @.claude/PROJECT_STRUCTURE.md

Rules:
- Only use libraries from LIBRARY_ALLOWLIST.md — never introduce unlisted NuGet packages
- Place every file exactly where PROJECT_STRUCTURE.md says it belongs
- Follow all patterns in CODING_STANDARDS.md without exception
- Controllers dispatch via `_mediator.Send()` only — zero business logic in controllers
- Use `record` types for command/query DTOs; annotate with FluentValidation validators
- Never return Domain entities from controllers — always map to response DTOs
- Add an EF Core migration for any schema change: `dotnet ef migrations add <Name> --project Infrastructure --startup-project Api`
- If a requirement is ambiguous, implement the simpler interpretation and note it

After implementing, list:
1. Files created
2. Files modified
3. Any requirement that could not be fulfilled and why
