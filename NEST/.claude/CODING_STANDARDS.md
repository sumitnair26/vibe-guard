# Coding Standards

## TypeScript
- Strict mode always (`"strict": true` in tsconfig)
- Explicit return types on all exported methods
- No `any` — use `unknown` and narrow; use DTOs and interfaces

## Architecture
- Every feature lives in its own module under `src/modules/<feature>/`
- Controllers handle HTTP only — no business logic; delegate to services immediately
- Services contain all business logic and DB access — no HTTP concerns
- Use DTOs (with `class-validator`) for all request bodies and query params
- Guards for auth/authorization; Interceptors for logging/transform; Pipes for validation
- Never inject a service from another module without importing its module

## Naming
- Files: `kebab-case.type.ts` (e.g. `user.service.ts`, `auth.guard.ts`, `create-user.dto.ts`)
- Classes: `PascalCase` (e.g. `UserService`, `AuthGuard`)
- Methods, variables: `camelCase`
- Constants: `UPPER_SNAKE_CASE`
- Route paths: `kebab-case` (e.g. `/reset-password`)

## Error handling
- Throw `HttpException` subclasses from services (e.g. `NotFoundException`, `BadRequestException`)
- Use a global `HttpExceptionFilter` for consistent error response shape
- Never return raw errors or leak stack traces to the client

## Imports
- Absolute imports via `@/` alias (e.g. `import { UserService } from '@/modules/user/user.service'`)
- Group order: Node built-ins → third-party → NestJS → internal — blank line between groups
