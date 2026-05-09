# Project Details

## Project
[Replace this line with a one-sentence description of your app]

## Stack
- React 18 + TypeScript (Vite)
- React Router v6 — client-side routing
- React Query — server state management
- Zod — runtime validation
- CSS Modules — component scoped styles

## Key architectural decisions
- No global state library — server state via React Query, UI state via useState/Context
- All API calls go through `src/services/` — components never call `axios` directly
- Auth state lives in `src/context/AuthContext.tsx`
- Route guards implemented as wrapper components in `src/components/`

## Environment variables
- Prefix all env vars with `VITE_` to expose to the browser
- Access via `import.meta.env.VITE_*`
- Define types in `src/types/env.d.ts`
