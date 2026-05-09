# Library Allowlist

## Approved libraries

- `express` ^4 — HTTP server and routing
- `zod` — schema validation and type inference
- `axios` — outbound HTTP requests (in services only)
- `date-fns` — date formatting and manipulation
- `bcryptjs` — password hashing
- `jsonwebtoken` — JWT signing and verification
- `dotenv` — environment variable loading

## Dev / tooling only

- `typescript` — language
- `ts-node` / `tsx` — TypeScript execution
- `@types/express`, `@types/node`, `@types/bcryptjs`, `@types/jsonwebtoken` — type definitions
- `vitest` — unit tests
- `supertest` — HTTP integration tests
- `@types/supertest` — type definitions

## Explicitly banned

- `moment.js` → use `date-fns`
- `lodash` → use native JS or inline helpers
- `passport` → implement auth middleware directly with `jsonwebtoken`
- `mongoose` / `sequelize` → use the approved ORM listed in PROJECT_DETAILS.md
- `axios` in controllers/routes → HTTP calls in `src/services/` only
- Any library NOT listed above — ask before adding
