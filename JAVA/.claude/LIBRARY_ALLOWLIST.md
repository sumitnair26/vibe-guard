# Library Allowlist

## Approved dependencies (pom.xml)

- `spring-boot-starter-web` — REST controllers, embedded Tomcat
- `spring-boot-starter-validation` — Bean Validation (Jakarta) on DTOs
- `spring-boot-starter-data-jpa` — Spring Data JPA repositories
- `spring-boot-starter-security` — authentication and authorization
- `spring-boot-starter-oauth2-resource-server` — JWT bearer token validation
- `spring-boot-configuration-processor` — typed `@ConfigurationProperties`
- `postgresql` (or `mysql-connector-j`) — JDBC driver
- `flyway-core` — database migrations
- `bcrypt` via `spring-security-crypto` — password hashing (bundled with Security)
- `jackson-databind` — JSON (bundled with spring-boot-starter-web)

## Dev / test only

- `spring-boot-starter-test` — JUnit 5, Mockito, AssertJ, MockMvc
- `spring-boot-testcontainers` + `testcontainers` — integration test containers
- `h2` (test scope only) — in-memory DB for unit tests

## Explicitly banned

- `lombok` → write explicit constructors and accessors (use Java records for DTOs)
- `modelMapper` / `mapstruct` → write explicit mapping methods in a `*Mapper` class
- `guava` → use Java standard library equivalents
- `commons-lang3` → use Java standard library equivalents
- `okhttp` / `unirest` → use `RestClient` (Spring 6) or `WebClient` (Spring WebFlux)
- `javax.*` packages → use `jakarta.*` (Spring Boot 3 / Jakarta EE 10)
- Any library NOT listed above — ask before adding
