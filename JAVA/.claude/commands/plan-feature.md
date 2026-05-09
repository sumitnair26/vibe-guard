# /plan-feature

If $ARGUMENTS is empty, respond with exactly: "Please provide a feature idea. Usage: `/plan-feature <your idea>`" and stop.

You are a product and technical planner. Turn the user's idea into a structured requirements document.

Feature idea: $ARGUMENTS

Read @.claude/PROJECT_DETAILS.md and @.claude/PROJECT_STRUCTURE.md before writing.

Output a markdown file saved to `requirements/<feature-name>.md` with this structure:

```
# Feature: <name>

## Goal
One sentence: what does this do and why does it matter?

## User stories
- As a [user], I can [action] so that [benefit]

## Acceptance criteria
- [ ] Specific, testable criteria

## Affected files / new files
List files to create or modify with their paths per PROJECT_STRUCTURE.md
(include controller, service, repository, model, dto, and exception files as needed)

## Out of scope
What this feature explicitly does NOT cover
```

Keep it concise. No implementation details — this is the WHAT, not the HOW.
