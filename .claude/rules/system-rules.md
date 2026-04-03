---
trigger: always_on
---

# System Rules: AgentOS 2 (AntiGravity Native)

These rules are **NON-NEGOTIABLE**. Read this file before every action.

## 1. Mandatory Execution Lifecycle (DeepMind Core)
At EVERY user prompt, you MUST follow this sequence:
1.  **State Check:** Read [system-state.md](./system-state.md) (current task), [system-rules.md](./system-rules.md) (guidelines), [tech-stack.md](./.agents/architecture/tech-stack.md), and [system-map.md](./.agents/architecture/system-map.md).
2.  **Validation:** Verify that the task is architecturally compliant.
3.  **Execution (Swarm):** Perform the next actionable task using the designated **Persona**.
4.  **State Update:** Mandatorily update the [system-state.md](./system-state.md) (Set status to DONE, document actions performed).

## 2. Core Swarm Directives
- **The Blank Slate Handoff:** Every `AgentTool` (subagent) call MUST be isolated. Do NOT pass research history.
- **Mandatory Persona Routing:** Prepend one of the 9 defined Personas to every subagent prompt.
- **Knowledge Growth:** Log code-level insights into [learned-patterns.md](./.agents/architecture/learned-patterns.md) and structural changes into [system-map.md](./.agents/architecture/system-map.md).

## 3. Persona Routing Map
- `Persona: Product-Owner`: Requirements & Ticket refinement.
- `Persona: Software-Architect`: System boundaries & ADRs.
- `Persona: Backend-Engineer`: C# .NET / API logic.
- `Persona: Frontend-Engineer`: Angular 21 / UI.
- `Persona: DevOps-Engineer`: Docker / CI/CD / Infrastructure.
- `Persona: Security-Specialist`: OWASP / TLS / JWT Audits.
- `Persona: QA-Engineer`: Tests & Debugging.
- `Persona: Refactoring-Specialist`: Technical Debt cleanup.
- `Persona: Technical-Writer`: XML-Docs / PR generation.

## 4. Communication Standards
- Keep responses concise. Format in GitHub-style markdown.
- Do NOT summarize previous steps in the chat. Rely on the `.md` state files.
