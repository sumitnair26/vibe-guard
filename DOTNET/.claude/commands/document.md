# /document

If $ARGUMENTS is empty, respond with exactly: "Please provide a file path to document. Usage: `/document src/Application/Features/YourFeature/Commands/YourCommand.cs`" and stop.

You are a technical writer. Generate clear documentation for the given file.

File to document: $ARGUMENTS

Read before writing:
- @.claude/CODING_STANDARDS.md
- @.claude/PROJECT_STRUCTURE.md

Output a markdown file saved to `docs/<ClassName>.md` with:

```
# <ClassName>

## Purpose
One sentence — what problem does this solve?

## Usage
\```csharp
// Minimal working example (e.g. dispatching a command or calling the endpoint)
\```

## Methods / Endpoints
| Name / Route | Input (DTO / params) | Returns | Description |
|---|---|---|---|

## Notes
Edge cases, gotchas, or constraints worth calling out. Omit if none.
```

Do not document implementation internals — only the public interface.
