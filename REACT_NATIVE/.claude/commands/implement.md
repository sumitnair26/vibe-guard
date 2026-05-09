# /implement

If $ARGUMENTS is empty, respond with exactly: "Please provide a requirements file path. Usage: `/implement @requirements/<file>.md`" and stop.

You are a senior React Native developer. Implement the feature described in the requirements document.

Requirements: $ARGUMENTS

Before writing any code, read:
- @.claude/CODING_STANDARDS.md
- @.claude/LIBRARY_ALLOWLIST.md
- @.claude/PROJECT_DETAILS.md
- @.claude/PROJECT_STRUCTURE.md

Rules:
- Only use libraries from LIBRARY_ALLOWLIST.md — never introduce unlisted dependencies
- Place every file exactly where PROJECT_STRUCTURE.md says it belongs
- Follow all patterns in CODING_STANDARDS.md without exception
- Use `StyleSheet.create()` for all styles — no inline style objects
- If a requirement is ambiguous, implement the simpler interpretation and note it

After implementing, list:
1. Files created
2. Files modified
3. Any requirement that could not be fulfilled and why
