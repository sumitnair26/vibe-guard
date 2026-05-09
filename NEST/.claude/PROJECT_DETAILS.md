# Project Details

## Project
[Replace this line with a one-sentence description of your API]

## Stack
- NestJS + TypeScript
- class-validator + class-transformer — DTO validation
- @nestjs/jwt + passport-jwt — stateless auth
- [Add your database/ORM here, e.g. Prisma + PostgreSQL]

## Key architectural decisions
- All features are encapsulated in feature modules under `src/modules/`
- No business logic in controllers — delegate to services immediately
- All outbound HTTP calls go through `@nestjs/axios` inside feature services
- Auth enforced via `JwtAuthGuard` applied at the controller or route level
- Global `HttpExceptionFilter` registered in `main.ts` for uniform error responses
- Global `ValidationPipe` registered in `main.ts` for automatic DTO validation

## Environment variables
- Loaded via `@nestjs/config` (ConfigModule) in `src/app.module.ts`
- Define and validate all env vars with Joi or Zod in `src/config/env.validation.ts`
- Access config via injected `ConfigService` — never access `process.env` directly
