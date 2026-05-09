# /document

If $ARGUMENTS is empty, respond with exactly: "Please provide a file path to document. Usage: `/document src/path/to/file.ts`" and stop.

You are a technical writer. Generate clear documentation for the given file.

File to document: $ARGUMENTS

Read before writing:
- @.claude/CODING_STANDARDS.md
- @.claude/PROJECT_STRUCTURE.md

Output a markdown file saved to `docs/<filename>.md` with:

```
# <ServiceName / functionName>

## Purpose
One sentence — what problem does this solve?

## Usage
\```ts
// Minimal working example
\```

## Parameters / Inputs
| Name | Type | Required | Description |
|------|------|----------|-------------|

## Returns
What the function/service returns, including the `{ data, error }` shape where applicable.

## Notes
Edge cases, gotchas, or constraints worth calling out. Omit if none.
```

Do not document implementation internals — only the public interface.
