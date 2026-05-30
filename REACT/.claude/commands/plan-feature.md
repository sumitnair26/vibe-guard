# /plan-feature

If $ARGUMENTS is empty, respond with exactly the following block and stop:

---

## plan-feature — Generate a Frontend Requirements Document

To get started, I need a few things:

**1. Feature description** *(required)*
What does this feature do? Which user role performs it? What screens or forms are involved? Which API endpoints does it touch (if known)?

**2. Design reference** *(optional)*
Provide a Figma URL (e.g. `https://www.figma.com/...`) or a path to a screenshot/image file. Type `none` if there is no visual design reference yet.

**3. Backend REQ path** *(optional)*
If the backend team has provided an REQ `.md` file with API specs, paste the file path here. Type `none` if not available.

---

**Usage:** `/plan-feature "<feature description>" [figma-url-or-screenshot] [backend-req-path]`

**Example:** `/plan-feature "User login with email and password" https://www.figma.com/file/abc123 none`

---

You are a product and technical planner. Turn the user's idea into a structured frontend requirements document following the project's standard format.

Feature idea: $ARGUMENTS

---

## Step 0 — Collect Upfront Inputs

Check `$ARGUMENTS` for the following inputs. If the feature description is missing, stop and ask. If design reference or backend REQ path are missing, ask for them now and wait for the user to reply before proceeding.

> **To generate the requirements document, I need a few things:**
>
> 1. **Feature description** — What does this feature do? Which user role performs it? What screens or forms are involved? Which API endpoints does it touch (if known)?
> 2. **Design reference** *(optional)* — Provide either a Figma URL (e.g. `https://www.figma.com/...`) or a path to a screenshot/image file. Type "none" if this feature has no visual design reference yet.
> 3. **Backend REQ path** *(optional)* — If the backend team has provided an REQ `.md` file with API specs, paste the file path here. Type "none" if not available.

Rules:
- If `$ARGUMENTS` contains a feature description, skip asking for it.
- Design reference and backend REQ path are **optional** — if the user omits them or says "none", record as `Not provided` and continue. Do **not** block or re-ask.
- If all inputs are present in `$ARGUMENTS`, skip this step entirely.

**Design reference handling:**
- If a Figma URL is provided, fetch it to extract: layout, colors, typography, component structure, and spacing.
- If a screenshot path is provided, use the Read tool to load the image and analyze the same visual details.
- If neither is provided, omit the `## UI Design` section from the output.

---

## Step 1 — Read Project Cont₹₹ext

Read all four guardrail files before writing anything:

- `@.claude/PROJECT_DETAILS.md`
- `@.claude/PROJECT_STRUCTURE.md`
- `@.claude/CODING_STANDARDS.md`
- `@.claude/LIBRARY_ALLOWLIST.md`

Also read the backend REQ file if one was provided.

---

## Step 2 — Determine Document ID

Scan `requirements/REQ/` to find the highest existing `FR-[NNN]` number. The new document uses the next number in sequence. If the directory does not exist or is empty, start at `FR-001`.

---

## Step 3 — Write the Requirements Document

Save the output to `requirements/REQ/REQ-FR-[NNN]-FE-[kebab-case-feature-name].md` using the structure below.

Follow the `FEATURE_DOC_FORMAT.md` template exactly. Populate every section. Where information is genuinely unknown, use `[NEEDS CLARIFICATION: reason]`. Do not leave template placeholder text in the output.

---

## Output Format

```markdown
# REQ-FR-[NNN]-FE: [Feature Name] – React JS

---

## 1. Document Control

| Field | Value |
|-------|-------|
| Document Name | REQ-FR-[NNN]-FE: [Feature Name] |
| Functional Requirement ID | FR-[NNN]-FE |
| Derived From (Backend REQ) | [Backend REQ ID and name, or "Not provided"] |
| Parent Requirement | [Parent feature group if known, else "TBD"] |
| Version | 1.0 |
| Author | Development Team |
| Reviewers | Tech Lead, QA Lead, Product Manager |
| Status | Draft |
| Last Updated | [today's date] |

---

## 2. Overview

### 2.1 Purpose
This document defines the frontend functional requirements for **[Feature Name]** functionality. The UI shall allow **[actor]** to **[primary action]** via **[method — e.g. a form, table, modal]**.

### 2.2 Scope
- React JS frontend only
- [Core UI responsibility 1]
- [Core UI responsibility 2]
- [Core UI responsibility 3]

### 2.3 Out of Scope
- [Excluded concern 1] (handled by backend / separate REQ)
- [Excluded concern 2]

---

## 3. [Feature] Flow

- [What screen does the user come from?]
- [Any prerequisite steps, data, or state from previous screens]
- [What the user must do on this screen]
- [What happens after successful completion — next destination]
- [Data to store after success and why it is needed downstream]

---

## 4. Screen: [Screen Name]

### 4.1 Fields & Constraints

| Field | Required | Format | Notes |
|-------|----------|--------|-------|
| [Field 1] | Yes / No | [e.g. string, email, 6-digit numeric] | [Any constraint] |
| [Field 2] | Yes / No | [format] | |

### 4.2 Client-side Validation
- Inline validation displayed below each field
- Error text color: red
- Block form submission on any validation failure

### 4.3 Validation Messages
- "[Field] is required"
- "[Field] must be [format/constraint]"

---

## 5. API Integration Details

### 5.1 Overview
The frontend must interact with the following endpoints:

1. **[Action 1]** – `[METHOD] /api/v1/[resource]/[action]`
2. **[Action 2]** – `[METHOD] /api/v1/[resource]/[action]`

---

### 5.2 Endpoint 1: [Action Name]

**Endpoint:** `[METHOD] /api/v1/[resource]/[action]`

**Description:** [What this endpoint does and its business impact.]

**Authentication:** [Not required | Required — include `Authorization: Bearer <token>` header]

**Request Headers:**
```
Content-Type: application/json
```

**Request Body:**
```json
{
  "field1": "string",
  "field2": "string"
}
```

**Request Body Schema:**

| Field | Type | Required | Constraints | Description |
|-------|------|----------|-------------|-------------|
| field1 | string | Yes | [constraint] | [description] |

**Success Response (200 OK):**
```json
{
  "statusCode": 200,
  "message": "[Success message]",
  "data": {}
}
```

**Error Responses:**

| Status | Scenario | Response shape |
|--------|----------|----------------|
| 400 | Validation error | `{ statusCode, message, data: { errors: [{field, message}] } }` |
| 400 | [Business error] | `{ statusCode, message, data }` |
| 404 | Not found | `{ statusCode, message, data }` |
| 500 | Server error | `{ statusCode, message, data: null }` |

---

## 6. Frontend Integration Requirements

### 6.1 [Primary Flow]

**On Page Load:**
1. [What to display / auto-populate]
2. [Initial UI state — which buttons are enabled/disabled]

**On Submit / Primary Action:**
1. Run client-side validation
2. If validation fails: block submission, show inline errors
3. If validation passes:
   - Call `[METHOD] /api/v1/[resource]/[action]`
   - Show loading indicator; disable submit button during API call

**On Successful Response (200 OK):**
1. Clear any error messages
2. Show snackbar: "[Success message]"
3. Navigate to [Next Screen]
4. [Any state to persist / clear]

### 6.2 [Secondary Flow] *(if applicable)*

**On [Secondary Action] Click:**
1. Call `[METHOD] /api/v1/[resource]/[action]`
2. Show loading indicator; disable button during call

**On Success:**
1. Show snackbar: "[Success message]"
2. [Reset / clear relevant fields]

---

## 7. Error Handling

### 7.1 Client-Side Validation Errors
- Display inline below the relevant field, in red text
- Block form submission
- Messages: "[field] is required", "[field] must be [constraint]"

### 7.2 API Errors

| Error | Display Method | Message | UI Action |
|-------|---------------|---------|-----------|
| Validation (400) | Inline (red text) | From `data.errors[].message` | Block submit |
| [Business error] (400) | Snackbar | "[message]" | Stay on screen |
| Not found (404) | Snackbar | "[message]" | Stay on screen |
| Network error | Snackbar | "Network error. Please check your connection and try again." | Preserve inputs |
| Server error (500) | Snackbar | "An unexpected error occurred. Please try again later." | Stay on screen |

---

## 8. Navigation Rules

| Condition | Action |
|-----------|--------|
| Successful [primary action] | Navigate to [Next Screen] |
| Validation failure | Stay on same screen |
| API failure | Stay on same screen |
| [Specific error] | [Action] |

---

## 9. State Management Rules

- [What to store after success and where — React state, Context, TanStack Query]
- [What NOT to store — e.g. sensitive tokens in localStorage]
- [What to clear on success / error]
- [Data passed from previous screen and how it is accessed]

---

## 10. Security Requirements

- Do NOT store [sensitive value] in localStorage, sessionStorage, or persistent storage
- Do NOT log [sensitive value] in console or any logging system
- Do NOT expose [sensitive value] in URL parameters
- Validate input format client-side before API call
- [Other security constraints]

---

## 11. UX Recommendations

1. **Auto-focus** [primary input] on page load
2. **Loading states** — disable interactive elements during API calls
3. **Clear visual feedback** for success and error states
4. **Paste support** for [input type] from clipboard (if applicable)
5. **[Feature-specific UX note]**

---

## 12. UI Design
*(Include only when a Figma URL or screenshot was provided — omit this section otherwise)*

- **Layout**: [overall layout and structure]
- **Key components**: [list of UI components visible in the design]
- **Colors & typography**: [specific colors, font sizes, font weights]
- **Spacing & sizing**: [notable padding, margins, or dimensions]
- **States**: [interactive states — hover, active, empty, error, loading]
- **Reference**: [Figma URL or screenshot path]

---

## 13. Dependencies

### 13.1 Upstream Screens / Data
- **[Previous Screen]** — provides [field / token / ID] used here
- [Any context, store, or route state this screen reads on mount]

### 13.2 Downstream Screens / Data
- **[Next Screen]** — receives [field / token / ID] from this screen's success response

### 13.3 API Dependencies
- `[METHOD] /api/v1/[resource]/[action]` — [purpose]

---

## 14. Affected Files

List files to create or modify, placed according to `PROJECT_STRUCTURE.md`:

| Action | File path | Notes |
|--------|-----------|-------|
| Create | `src/pages/[FeaturePage].tsx` | Main page component |
| Create | `src/components/[Component].tsx` | [purpose] |
| Create | `src/services/[feature]Service.ts` | API calls |
| Create | `src/hooks/use[Feature].ts` | [purpose] |
| Modify | `src/routes/index.tsx` | Register new route |

---

## 15. Out of Scope

- [What this feature explicitly does NOT cover]
- [Concerns handled by backend / separate REQ]

---

## 16. Open Items / TBD

1. **[Item 1]**: [What needs to be decided]
2. **[Item 2]**: [Description]

---

## 17. Change Log

| Version | Date | Author | Changes |
|---------|------|--------|---------|
| 1.0 | [today's date] | Development Team | Initial draft |

---

**Document Status**: DRAFT
```

---

## Rules

- This document is the WHAT, not the HOW — no implementation details.
- Use `[NEEDS CLARIFICATION: reason]` for anything genuinely unknown rather than guessing.
- Only use libraries from `LIBRARY_ALLOWLIST.md`.
- Omit the `## 12. UI Design` section entirely if no design reference was provided.
- Keep all section numbers intact even if a section has minimal content.
