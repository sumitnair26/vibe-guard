# Project Details

## Project
[Replace this line with a one-sentence description of your API]

## Stack
- Node.js + TypeScript (Express 4)
- Zod — request validation
- jsonwebtoken — stateless auth
- [Add your database/ORM here, e.g. Prisma + PostgreSQL]

## Key architectural decisions
- No business logic in controllers — delegate to services immediately
- All outbound HTTP calls go through `src/services/` — never in routes or controllers
- Auth enforced via `src/middleware/auth.ts` — applied at the router level
- Centralised error handling via `src/middleware/errorHandler.ts`

## Environment variables
- Loaded via `dotenv` in `src/config/env.ts`
- Define and validate all env vars with Zod in `src/config/env.ts`
- Never access `process.env` directly outside of `src/config/`
