# Library Allowlist

## Approved libraries

- `react` ^18 — UI
- `react-native` — core mobile primitives
- `expo` — managed workflow, device APIs
- `expo-router` ^3 — file-based navigation (replaces React Navigation setup boilerplate)
- `@react-navigation/native` — navigation core (peer dep of expo-router)
- `zod` — schema validation and type inference
- `axios` — HTTP requests (in services only)
- `@tanstack/react-query` — server state, caching, async data
- `date-fns` — date formatting and manipulation
- `expo-secure-store` — secure token storage
- `expo-constants` — app config / environment values
- `expo-status-bar` — status bar control

## Dev / tooling only

- `typescript` — language
- `@types/react`, `@types/react-native` — type definitions
- `jest` — unit tests
- `@testing-library/react-native` — component tests
- `expo-dev-client` — custom dev builds

## Explicitly banned

- `moment.js` → use `date-fns`
- `lodash` → use native JS or inline helpers
- `redux` / `@reduxjs/toolkit` → use React Query + Context
- `styled-components` / `emotion` → use `StyleSheet.create()`
- `axios` in components → HTTP calls in `src/services/` only
- `react-router-dom` → use `expo-router`
- Any library NOT listed above — ask before adding
