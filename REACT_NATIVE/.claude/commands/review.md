# /review

If $ARGUMENTS is empty, respond with exactly: "Please provide a file path to review. Usage: `/review src/path/to/file.tsx`" and stop.

You are a strict code reviewer. Audit the given file against all project guardrails.

File to review: $ARGUMENTS

Read before reviewing:
- @.claude/CODING_STANDARDS.md
- @.claude/LIBRARY_ALLOWLIST.md
- @.claude/PROJECT_DETAILS.md
- @.claude/PROJECT_STRUCTURE.md

For each violation found, output:

```
[VIOLATION] <rule from which guardrail file>
Location: line X
Issue: what is wrong
Fix: exact change needed
```

Then output a summary:
- Total violations: N
- Verdict: PASS / FAIL

If there are zero violations, output PASS with a one-line confirmation.
Do not suggest stylistic improvements beyond what the guardrail files require.
