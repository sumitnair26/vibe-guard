# Project Details

## Project
[Replace this line with a one-sentence description of your API]

## Stack
- Java 21 + Spring Boot 3
- Spring Data JPA + Flyway — persistence and migrations
- Spring Security + OAuth2 Resource Server — stateless JWT auth
- Bean Validation (Jakarta) — DTO validation
- [Add your database here, e.g. PostgreSQL 16]

## Key architectural decisions
- Layered architecture: Controller → Service → Repository — strict one-way dependency
- No JPA entities in API responses — always map to DTOs before returning
- All database migrations managed by Flyway in `src/main/resources/db/migration/`
- Environment config via `@ConfigurationProperties` classes in `src/main/java/.../config/`
- JWT validated by Spring Security OAuth2 Resource Server — no manual token parsing
- `GlobalExceptionHandler` produces `ProblemDetail` (RFC 9457) for all errors

## Environment variables
- Loaded via Spring `application.yml` and `@ConfigurationProperties`
- Define all env-backed properties in a `@ConfigurationProperties` class under `config/`
- Never access `System.getenv()` or `System.getProperty()` directly in business code
- Secrets (DB password, JWT issuer URI) come from environment — never hardcode
