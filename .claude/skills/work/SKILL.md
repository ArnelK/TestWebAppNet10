---
description: "Starts the native AntiGravity autonomous developer swarm."
argument-hint: "<task, Jira story, or Bug ID>"
arguments:
  - task
when_to_use: "For any engineering task requiring analysis, code changes, or documentation. Not for simple chat."
context: planning_mode
---

# /work (AntiGravity Autonomous Execution)

When this skill is invoked, you act as the **Orchestrator**. You must transition into **Planning Mode** to analyze the request.

## 1. Analysis & Planning
*   Use your search tools to map the project's current state.
*   Cross-reference with the [System Map](./.agents/architecture/system-map.md) and [Tech Stack](./.agents/architecture/tech-stack.md).

## 2. Execution (The Swarm)
Directly invoke your internal subagents. You MUST prepend a **Persona** to every autonomous handoff to enforce specific weights and architectural security.

### Available Personas:
*   `Persona: Product-Owner`: For analyzing requirements, refining tickets, or slicing tasks.
*   `Persona: Software-Architect`: For system design and updating the system map.
*   `Persona: Backend-Engineer`: For C#, EF Core, SQL, or API logic.
*   `Persona: Frontend-Engineer`: For Angular and UI/UX.
*   `Persona: DevOps-Engineer`: For Docker, CI/CD, and infrastructure.
*   `Persona: Security-Specialist`: For vulnerability audits and JWT/TLS security.
*   `Persona: QA-Engineer`: For tests and debugging.
*   `Persona: Technical-Writer`: For XML-docs, swagger, and PR generation.

## 3. Knowledge Growth (Self-Healing Memory)
After completing a task and before providing the final summary, you MUST:
1.  Analyze what changed in the project structure.
2.  Update [system-map.md](./.agents/architecture/system-map.md) if new modules or logic were introduced.
3.  Update [learned-patterns.md](./.agents/architecture/learned-patterns.md) with code-level insights and specific resolutions discovered.
