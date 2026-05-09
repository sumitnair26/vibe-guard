# Coding Standards

## Java
- Java 21 — use records for immutable DTOs, sealed classes where applicable
- No raw types — always use generics; never use `Object` where a type is known
- `final` on all fields that are not mutated after construction
- No `null` returns — use `Optional<T>` for values that may be absent

## Architecture
- Controllers handle HTTP only — no business logic; delegate to services immediately
- Services contain all business logic — no `HttpServletRequest` / response concerns
- Repositories are Spring Data JPA interfaces only — no SQL in services or controllers
- DTOs are plain records or classes with validation annotations — never expose JPA entities directly
- Custom exceptions extend `RuntimeException`; throw them from services, catch in `GlobalExceptionHandler`

## Naming
- Classes: `PascalCase` (e.g. `UserService`, `CreateUserRequest`)
- Methods, variables: `camelCase`
- Constants: `UPPER_SNAKE_CASE`
- Packages: `lowercase.dotted` (e.g. `com.example.app.service`)
- REST endpoints: `kebab-case` (e.g. `/reset-password`)
- Test classes: `<ClassName>Test` (unit) / `<ClassName>IT` (integration)

## Error handling
- Throw typed custom exceptions from services (e.g. `ResourceNotFoundException`)
- `GlobalExceptionHandler` (`@RestControllerAdvice`) maps exceptions to `ProblemDetail` responses
- Never return raw stack traces or 500 messages — always map to a structured response

## Imports & style
- No wildcard imports (`import java.util.*` is banned)
- Lombok is NOT allowed — write explicit constructors, getters, builders
- Group order: Java built-ins → Spring → third-party → internal — blank line between groups
