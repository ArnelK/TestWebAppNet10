---
description: "Initializes AgentOS 2 in the current repository."
when_to_use: "Only once per repository setup or when a deep architectural reset is required."
---

# /init (Framework Unfolding)

You (the Orchestrator) must now initialize the AgentOS 2 framework for this project.

## 1. Materialization
Ensure the following directory structure exists:
- `./.agents/architecture/`
- `./.claude/architecture/` (if using Claude Code)

## 2. Global Workflow Sync
Verify access to the global workflows:
- `~/.gemini/antigravity/global_workflows/init.md`

## 3. Execution
Trigger the initialization workflow. 
1. Perform a deep repository scan to identify the tech-stack.
2. Initialize [tech-stack.md](./.agents/architecture/tech-stack.md).
3. Initialize [system-map.md](./.agents/architecture/system-map.md).
4. Use `askuserquestion` to verify the findings with the Architect.
