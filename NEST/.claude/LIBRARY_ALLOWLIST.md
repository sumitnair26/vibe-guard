# Library Allowlist

## Approved libraries

- `@nestjs/core`, `@nestjs/common`, `@nestjs/platform-express` — NestJS framework
- `@nestjs/config` — environment configuration
- `@nestjs/jwt` — JWT signing and verification
- `@nestjs/passport` + `passport` + `passport-jwt` — auth strategy/guards
- `@nestjs/axios` — outbound HTTP requests (in services only)
- `class-validator` + `class-transformer` — DTO validation and transformation
- `bcryptjs` — password hashing
- `date-fns` — date formatting and manipulation

## Dev / tooling only

- `typescript` — language
- `ts-node` — TypeScript execution
- `@types/node`, `@types/bcryptjs`, `@types/passport-jwt` — type definitions
- `@nestjs/testing` — unit and e2e test utilities
- `jest` + `supertest` — test runner and HTTP integration tests
- `@types/jest`, `@types/supertest` — type definitions

## Explicitly banned

- `express` directly → use `@nestjs/platform-express` (NestJS wraps it)
- `moment.js` → use `date-fns`
- `lodash` → use native JS or inline helpers
- `passport` strategies other than `passport-jwt` — implement custom guards instead
- `mongoose` / `sequelize` → use the approved ORM listed in PROJECT_DETAILS.md
- `@nestjs/axios` in controllers — outbound HTTP in `src/modules/*/` services only
- Any library NOT listed above — ask before adding
