# Project Details

## Project
[Replace this line with a one-sentence description of your app]

## Stack
- React Native + Expo (managed workflow) + TypeScript
- Expo Router v3 — file-based navigation
- React Query — server state management
- Zod — runtime validation
- StyleSheet.create() — component scoped styles

## Key architectural decisions
- No global state library — server state via React Query, UI state via useState/Context
- All API calls go through `src/services/` — components never call `axios` directly
- Auth state lives in `src/context/AuthContext.tsx`; token stored in `expo-secure-store`
- Navigation guards implemented as layout components under `app/` using `expo-router`

## Environment variables
- Use `expo-constants` + `app.config.ts` `extra` field to expose env vars
- Access via `Constants.expoConfig.extra.MY_VAR`
- Define types in `src/types/env.d.ts`
