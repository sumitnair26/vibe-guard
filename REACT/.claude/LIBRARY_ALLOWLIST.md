# Library Allowlist

## Approved libraries

- `react` ^18 — UI
- `react-dom` ^18 — DOM rendering
- `react-router-dom` ^6 — client-side routing
- `zod` — schema validation and type inference
- `axios` — HTTP requests (in services only)
- `@tanstack/react-query` — server state, caching, async data
- `date-fns` — date formatting and manipulation
- `clsx` — conditional className merging

## Dev / tooling only

- `vite` — build tool
- `typescript` — language
- `@types/react`, `@types/react-dom` — type definitions
- `vitest` — unit tests
- `@testing-library/react`, `@testing-library/user-event` — component tests

## Explicitly banned

- `moment.js` → use `date-fns`
- `lodash` → use native JS or inline helpers
- `redux` / `@reduxjs/toolkit` → use React Query + Context
- `styled-components` / `emotion` → use CSS Modules
- `axios` in components → HTTP calls in `src/services/` only
- Any library NOT listed above — ask before adding
