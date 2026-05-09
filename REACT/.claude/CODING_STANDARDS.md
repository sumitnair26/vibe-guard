# Coding Standards

## TypeScript
- Strict mode always (`"strict": true` in tsconfig)
- Explicit return types on all exported functions
- No `any` — use `unknown` and narrow

## Components
- Functional components only, no class components
- One component per file, filename matches component name (PascalCase)
- Props interface defined above the component: `interface ComponentNameProps {}`
- No inline styles — use CSS Modules (`.module.css`)

## State & side effects
- `useState` for local UI state only
- `useReducer` for multi-field form state
- Side effects in custom hooks, not directly in components
- No logic inside JSX — extract to named variables or functions

## Naming
- Components: `PascalCase`
- Functions, variables, hooks: `camelCase`
- Constants: `UPPER_SNAKE_CASE`
- CSS module classes: `camelCase`
- Files: match the export name exactly

## Error handling
- Async functions must handle errors with try/catch
- Services return `{ data, error }` shape — never throw to the component layer

## Imports
- Absolute imports via `@/` alias (e.g. `import { Button } from '@/components/Button'`)
- Group order: React → third-party → internal — blank line between groups
