# Swarm Workflow: /feature (Strategic Execution)

The core development cycle for AgentOS 2, emphasizing **Swarm Intelligence** and **Automated Growth**.

1. **Strategic Planning (Coordinator Mode)**
   Perform a deep repository analysis of the task and identify all affected files. Transition into AntiGravity's `planning_mode`.
2. **Persona Assignment (Routing)**
   The Orchestrator defines which **Persona** is required for the task. (e.g., `Persona: Backend-Engineer`).
3. **Execution Phase (Blank Slate Handoff)**
   Invoke the `AgentTool` (Subagent) with the designated Persona and the distilled specification. The Worker MUST NOT receive the previous history to avoid **Context Bloat**.
4. **Knowledge Distillation (Self-Healing Memory)**
   After the Worker reports SUCCESS, the orchestrator MUST:
   - Identify structural changes for the [System Map](./.agents/architecture/system-map.md).
   - Identify code-level patterns for [Learned Patterns](./.agents/architecture/learned-patterns.md).
5. **Final Verification & Walkthrough**
   Generate a `walkthrough.md` that summarizes the changes and the architectural growth.
