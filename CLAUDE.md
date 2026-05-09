# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What This Repo Is

**vibe-guard** is a Claude Code agent setup — a template of `.claude/` folder contents that developers copy into their own projects to enforce coding standards automatically on every generation.

The repo itself is the distributable template. The `REACT/` directory is an empty example target (a React project scaffold where users would paste the `.claude/` folder).

## Architecture

The system works by populating four "guardrail" files that Claude reads on every session, plus five slash commands that load only the relevant subset of those files:

```
.claude/
├── CLAUDE.md                  ← Auto-loaded every session (agent brain)
├── CODING_STANDARDS.md        ← Style rules, patterns, naming conventions
├── LIBRARY_ALLOWLIST.md       ← Approved deps + explicitly banned libs
├── PROJECT_DETAILS.md         ← Stack, architecture, key decisions
├── PROJECT_STRUCTURE.md       ← File placement rules
└── commands/
    ├── implement.md           ← /implement — reads requirements .md → code
    ├── plan-feature.md        ← /plan-feature — idea → requirements .md
    ├── review.md              ← /review — audits file against all 4 guardrails
    ├── document.md            ← /document — generates docs for existing code
    └── debug.md               ← /debug — diagnoses bugs, no new libraries
```

Generated outputs land in:
- `requirements/` — created by `/plan-feature`
- `docs/` — created by `/document`

## Slash Command Design Principle

Each command loads only the guardrail files it actually needs (not all four) to minimize token cost. When writing or modifying commands, reference guardrail files via `@.claude/FILENAME.md` syntax so Claude loads them inline.

| Command | Guardrail files used |
|---|---|
| `/plan-feature` | PROJECT_DETAILS + PROJECT_STRUCTURE |
| `/implement` | All 4 |
| `/review` | All 4 |
| `/document` | CODING_STANDARDS + PROJECT_STRUCTURE |
| `/debug` | CODING_STANDARDS + LIBRARY_ALLOWLIST |

## Adding New Commands

Create any `.md` file in `.claude/commands/` — it becomes a `/command` automatically. Use `$ARGUMENTS` as the placeholder for what the user passes after the command name. Reference guardrail files with `@.claude/FILENAME.md`.

## Guardrail File Guidelines

Keep each of the four guardrail files under 50 lines. Dense bullet points, not paragraphs — these are loaded on every command invocation.
