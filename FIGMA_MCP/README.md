# Figma MCP Integration

Connect your Figma Desktop app to AI coding agents via the **Model Context Protocol (MCP)** — giving your agent real-time access to your design files without manual export steps.

---

## Why Connect Figma via MCP?

| Benefit | Details |
|---|---|
| **Design-to-code accuracy** | Agent reads exact colors, spacing, typography, and component names directly from your Figma file — no guessing from screenshots |
| **No manual exports** | Skip the copy-paste loop. Changes in Figma are immediately available to the agent on the next prompt |
| **Component awareness** | Agent understands your design system (variants, props, auto-layout rules) and generates code that matches it |
| **Faster iteration** | Point the agent at a frame ID and get production-ready components in one shot |
| **Single source of truth** | Design token drift between Figma and code is eliminated because both sides read the same file |

---

## Prerequisites

- [Figma Desktop app](https://www.figma.com/downloads/) installed and running
- An AI coding agent that supports MCP (Claude Code, Cursor, VS Code Copilot, Codex, etc.)

The Figma Desktop app exposes a local MCP server at `http://127.0.0.1:3845/mcp` while it is open.

---

## Setup Instructions

### Claude Code (Recommended)

**Via plugin (one command):**

```bash
claude plugin install figma@claude-plugins-official
```

**Or manually:**

```bash
claude mcp add --transport http figma-desktop http://127.0.0.1:3845/mcp
```

> **Tip — make it global:** Add `--scope user` so the server is available in every project, not just the current one:
>
> ```bash
> claude mcp add --scope user --transport http figma-desktop http://127.0.0.1:3845/mcp
> ```

**Useful MCP management commands:**

```bash
claude mcp list              # List all configured servers
claude mcp get figma-desktop # Get details for this server
claude mcp remove figma-desktop # Remove the server
```

---

### Cursor

**Via agent chat:**

```
/add-plugin figma
```

**Or manually via `mcp.json`:**

1. Open **Cursor → Settings → Cursor Settings**
2. Click **Tools & MCP → +**
3. Add the following and save:

```json
{
  "mcpServers": {
    "Figma Desktop": {
      "url": "http://127.0.0.1:3845/mcp"
    }
  }
}
```

---

### VS Code

1. Press `⌘ Shift P` and search for **MCP: Add Server**
2. Select **HTTP**
3. Paste `http://127.0.0.1:3845/mcp` and press **Enter**
4. Set the Server ID to `Figma MCP` and press **Enter**
5. Choose **Global** (all workspaces) or **Workspace** (current project only)
6. Open the agent chat with `⌥⌘B` or `⌃⌘I` and switch to **Agent mode**
7. Type `#get_design_context` to confirm the tools are available

`settings.json` snippet:

```json
{
  "servers": {
    "Figma Desktop": {
      "type": "http",
      "url": "http://127.0.0.1:3845/mcp"
    }
  }
}
```

---

### Codex

1. Open your terminal and run `codex`
2. Run `/plugins`
3. Search for **Figma**
4. Press **Enter** to install

---

### Other Agents (SSE-compatible)

Any editor or tool that supports **Server-Sent Events (SSE)** can connect. Check your editor's documentation for MCP/SSE support, then add:

```json
{
  "mcpServers": {
    "Figma Desktop": {
      "url": "http://127.0.0.1:3845/mcp"
    }
  }
}
```

---

## Verifying the Connection

Once configured, open your agent's chat and run:

```
#get_design_context
```

If the Figma MCP tools appear in the response, the connection is working.

---

## Notes

- The Figma Desktop app **must be running** for the MCP server to be available at `http://127.0.0.1:3845/mcp`.
- Local scope (default) means the MCP server is only configured for the current project directory. Use `--scope user` in Claude Code to avoid reconfiguring per project.
- The integration is read-only — agents can inspect your designs but cannot modify your Figma files.
