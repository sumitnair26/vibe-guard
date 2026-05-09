# CLAUDE.md

This is the agent brain for this Node.js project. It is auto-loaded every session.

## Rules — always follow these

- Read @.claude/CODING_STANDARDS.md before writing any code.
- Only use libraries listed in @.claude/LIBRARY_ALLOWLIST.md.
- Place every file according to @.claude/PROJECT_STRUCTURE.md.
- Understand the project context in @.claude/PROJECT_DETAILS.md before planning.

## Available commands

| Command | Use it for |
|---|---|
| `/plan-feature "idea"` | Turn a rough idea into a structured requirements `.md` |
| `/implement @requirements/file.md` | Write guardrail-compliant code from a requirements doc |
| `/review src/path/to/file.ts` | Audit a file against all 4 guardrail files |
| `/document src/path/to/file.ts` | Generate documentation for existing code |
| `/debug "error or description"` | Diagnose and fix bugs without introducing new libraries |
