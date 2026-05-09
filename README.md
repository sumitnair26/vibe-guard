# 🛡️ vibe-guard

> **VIBE code fast. Ship with guardrails.**  
> A Claude Code agent setup that enforces your coding standards, folder structure, and library rules — automatically — on every single generation.

---

## The Problem

VIBE coding is fast. But Claude doesn't know:
- Which libraries your team has approved
- Where files should live in your project
- Your coding standards and patterns
- How your project is structured

So you get fast code that's wrong for *your* project.

**vibe-guard fixes this.**

---

## How It Works

You define your rules once across 4 files. Claude reads them automatically on every command. You just pass in a requirements doc and get guardrail-compliant code back.

```
Your Idea
    ↓
/plan-feature "user can reset password via email"
    ↓  generates → requirements/password-reset.md
/implement @requirements/password-reset.md
    ↓  generates → code that follows YOUR rules
/review src/auth/passwordReset.ts
    ↓  checks → standards + library + structure compliance
/document src/auth/passwordReset.ts
    ↓  generates → docs
Done ✅
```

No hallucinated libraries. No files in the wrong place. No style violations.

---

## Quickstart

### 1. Install Claude Code

```bash
npm install -g @anthropic-ai/claude-code
```

### 2. Clone this repo into your project

Pick the template that matches your stack:

```bash
# React (Vite + TypeScript)
cp -r vibe-guard/REACT/.claude your-project/.claude

# Node.js (Express + TypeScript)
cp -r vibe-guard/NODE/.claude your-project/.claude

# React Native (Expo + TypeScript)
cp -r vibe-guard/REACT_NATIVE/.claude your-project/.claude

# NestJS (TypeScript)
cp -r vibe-guard/NEST/.claude your-project/.claude
```

### 3. Fill in your 4 guardrail files

```
.claude/
├── CODING_STANDARDS.md     ← Your style rules, patterns, conventions
├── LIBRARY_ALLOWLIST.md    ← ONLY these libraries may be used
├── PROJECT_DETAILS.md      ← What your project is and its architecture
└── PROJECT_STRUCTURE.md    ← Where every type of file must live
```

> **Tip:** Keep each file under 50 lines. Dense bullet points, not paragraphs. Claude reads these on every command — brevity = fewer tokens.

### 4. Start VIBE coding with guardrails

```bash
cd your-project
claude
```

Then use the built-in commands:

```
/plan-feature "describe your feature idea"
/implement @requirements/your-feature.md
/review src/path/to/file.ts
/document src/path/to/file.ts
/debug "describe the bug or paste error"
```

---

## The 4 Guardrail Files

### `CODING_STANDARDS.md`
Your style guide. Examples of what to put here:
```markdown
- Use TypeScript strict mode always
- Functional components only, no class components
- Error handling: always use Result<T, E> pattern
- Naming: PascalCase components, camelCase functions, UPPER_SNAKE constants
- No inline styles — use CSS modules
```

### `LIBRARY_ALLOWLIST.md`
The only libraries Claude is allowed to use:
```markdown
## Approved Libraries
- react ^18
- zod (validation only)
- axios (HTTP only)
- date-fns (date utils)

## Explicitly Banned
- moment.js (use date-fns)
- lodash (use native JS)
- any library not listed above
```

### `PROJECT_DETAILS.md`
What your project is:
```markdown
## Project
E-commerce platform for B2B wholesale buyers.

## Stack
Next.js 14 App Router, TypeScript, PostgreSQL, Prisma

## Key Decisions
- Server components by default, client only when needed
- Auth via NextAuth.js
- All DB access through service layer, never direct in components
```

### `PROJECT_STRUCTURE.md`
Where files must live:
```markdown
src/
├── app/          ← Next.js routes only
├── components/   ← Reusable UI components
├── services/     ← Business logic + DB calls
├── lib/          ← Utilities and helpers
├── types/        ← TypeScript types and interfaces
└── hooks/        ← Custom React hooks only

requirements/     ← Feature requirement docs (.md)
docs/             ← Generated documentation
```

---

## The 5 Built-in Skills (`/commands`)

| Command | What it does |
|---|---|
| `/plan-feature` | Turns a rough idea into a structured requirements `.md` |
| `/implement` | Reads a requirements `.md` → writes guardrail-compliant code |
| `/review` | Audits a file against all 4 guardrail files |
| `/document` | Generates documentation for existing code |
| `/debug` | Diagnoses and fixes bugs without introducing new libraries |

### Adding your own skills

Create any `.md` file in `.claude/commands/` and it becomes a `/command`:

```markdown
# .claude/commands/write-tests.md

Write tests for: $ARGUMENTS

- Use Vitest (from @.claude/LIBRARY_ALLOWLIST.md)
- Follow patterns in @.claude/CODING_STANDARDS.md
- Place test files next to source per @.claude/PROJECT_STRUCTURE.md
- Aim for edge cases, not just happy path
```

Then use it:
```
/write-tests src/services/userService.ts
```

---

## Token Cost

Each command loads only what it needs — not all 4 files every time.

| Command | Files loaded | ~Tokens |
|---|---|---|
| `/plan-feature` | PROJECT_DETAILS + PROJECT_STRUCTURE | ~500 |
| `/implement` | All 4 | ~1,500–3,000 |
| `/review` | All 4 | ~800–1,200 |
| `/document` | CODING_STANDARDS + PROJECT_STRUCTURE | ~600 |
| `/debug` | CODING_STANDARDS + LIBRARY_ALLOWLIST | ~600 |

At Claude Sonnet pricing this is **cents per feature**, not dollars.

---

## Folder Structure

Four ready-to-use templates live in this repo:

```
vibe-guard/
├── REACT/                         ← React + Vite + TypeScript template
│   ├── .claude/
│   │   ├── CLAUDE.md
│   │   ├── CODING_STANDARDS.md
│   │   ├── LIBRARY_ALLOWLIST.md
│   │   ├── PROJECT_DETAILS.md
│   │   ├── PROJECT_STRUCTURE.md
│   │   └── commands/
│   │       ├── implement.md
│   │       ├── plan-feature.md
│   │       ├── review.md
│   │       ├── document.md
│   │       └── debug.md
│   ├── src/                       ← Scaffold: components, pages, hooks, services …
│   ├── requirements/
│   └── docs/
│
├── NODE/                          ← Node.js + Express + TypeScript template
│   ├── .claude/
│   │   ├── CLAUDE.md
│   │   ├── CODING_STANDARDS.md
│   │   ├── LIBRARY_ALLOWLIST.md
│   │   ├── PROJECT_DETAILS.md
│   │   ├── PROJECT_STRUCTURE.md
│   │   └── commands/
│   │       ├── implement.md
│   │       ├── plan-feature.md
│   │       ├── review.md
│   │       ├── document.md
│   │       └── debug.md
│   ├── src/                       ← Scaffold: routes, controllers, services, middleware …
│   ├── requirements/
│   └── docs/
│
├── REACT_NATIVE/                  ← React Native + Expo + TypeScript template
│   ├── .claude/
│   │   ├── CLAUDE.md
│   │   ├── CODING_STANDARDS.md
│   │   ├── LIBRARY_ALLOWLIST.md
│   │   ├── PROJECT_DETAILS.md
│   │   ├── PROJECT_STRUCTURE.md
│   │   └── commands/
│   │       ├── implement.md
│   │       ├── plan-feature.md
│   │       ├── review.md
│   │       ├── document.md
│   │       └── debug.md
│   ├── app/                       ← Expo Router file-based routes
│   ├── src/                       ← Scaffold: components, hooks, services, context …
│   ├── requirements/
│   └── docs/
│
└── NEST/                          ← NestJS + TypeScript template
    ├── .claude/
    │   ├── CLAUDE.md
    │   ├── CODING_STANDARDS.md
    │   ├── LIBRARY_ALLOWLIST.md
    │   ├── PROJECT_DETAILS.md
    │   ├── PROJECT_STRUCTURE.md
    │   └── commands/
    │       ├── implement.md
    │       ├── plan-feature.md
    │       ├── review.md
    │       ├── document.md
    │       └── debug.md
    ├── src/                       ← Scaffold: modules, common filters, guards, pipes …
    ├── requirements/
    └── docs/
```

---

## Why This Works

Claude Code's `CLAUDE.md` is automatically injected into every session — it's the agent's persistent memory. The `/commands` folder turns prompt patterns into reusable, invokable skills. Together they give you a consistent, rule-following coding agent without any manual copy-pasting of context between sessions.

The guardrail files aren't prompts. They're **contracts** — and Claude treats them that way.

---

## Contributing

PRs welcome! Ideas for new skills/commands especially appreciated.

1. Fork the repo
2. Add your command to `.claude/commands/`
3. Update this README with what it does
4. Open a PR

---

## License

MIT

---

**Built for developers who VIBE code but refuse to YOLO ship.**
