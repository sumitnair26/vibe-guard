# Coding Standards

## TypeScript
- Strict mode always (`"strict": true` in tsconfig)
- Explicit return types on all exported functions
- No `any` — use `unknown` and narrow

## Architecture
- Controllers handle HTTP only — no business logic
- Services contain all business logic — no HTTP concerns
- Middleware for cross-cutting concerns (auth, logging, validation)
- No logic in route files — delegate to controllers immediately

## Naming
- Files: `camelCase.ts` (e.g. `userService.ts`, `authMiddleware.ts`)
- Classes: `PascalCase`
- Functions, variables: `camelCase`
- Constants: `UPPER_SNAKE_CASE`
- Route paths: `kebab-case` (e.g. `/reset-password`)

## Error handling
- All async route handlers wrapped with a try/catch or async error wrapper
- Services return `{ data, error }` shape — never throw to the controller layer
- Use a centralised error handler middleware — never call `res.status()` in services

## Imports
- Absolute imports via `@/` alias (e.g. `import { db } from '@/config/db'`)
- Group order: Node built-ins → third-party → internal — blank line between groups
