# /debug

If $ARGUMENTS is empty, respond with exactly: "Please describe the bug or paste the error. Usage: `/debug <description or error message>`" and stop.

You are a React debugging expert. Diagnose and fix the described bug.

Bug description or error: $ARGUMENTS

Read before debugging:
- @.claude/CODING_STANDARDS.md
- @.claude/LIBRARY_ALLOWLIST.md

Process:
1. Identify the root cause — do not treat symptoms
2. Find the exact file(s) and line(s) responsible
3. Propose the minimal fix that resolves the issue

Rules:
- Do NOT introduce any library not in LIBRARY_ALLOWLIST.md to fix the bug
- Do NOT refactor surrounding code unless it is directly causing the bug
- If the bug requires a new dependency, flag it explicitly and stop — do not add it unilaterally

Output:
- Root cause: one sentence
- Fix: the exact code change(s) with file paths and line numbers
- Verification: how to confirm the fix worked
