# AgentOS 2 Architecture & Standards (AntiGravity Edition)

This document specifies the system architecture of **AgentOS 2**, powered by the AntiGravity engine. The framework integrates Large Language Models into deterministic, reliable, and cost-efficient Enterprise development workflows.

## 1. The "Context Bloat" Problem (Blank Slate Handoff)
Artificial Intelligence rapidly degrades in accuracy when large amounts of incremental chat context are dragged along (Context Bloat). AgentOS 2 enforces a strict separation between "Planning" and "Execution" using AntiGravity's native `planning_mode`.

The `/work` skill implements the **Blank Slate Handoff** pattern.
*   **Orchestrator (AntiGravity):** The main instance analyzes the request, maps the project structure, and develops an implementation plan.
*   **Swarm (Subagents):** Instead of executing the plan itself, the Orchestrator delegates the work to isolated "Subagents".
*   **The Handoff:** Every Subagent starts with a "Blank Slate". The Orchestrator passes strictly the **Persona** and the **Compressed Specification**. This reduces token costs, strictly isolates errors, and ensures a 100% focus rate on the modification.

## 2. Knowledge Management (The Enterprise Best Practice)
AgentOS 2 enforces a strict separation between *high-level architectural onboarding* and *low-level AI execution patterns*:

*   **`tech-stack.md` (Hybrid Init):** Contains the core technological rules. It is initially auto-populated by the `/init` process via system scans. For any major structural uncertainty or tech-stack shifts, the system defaults to the `askuserquestion` tool to verify with the Architect before finalizing.
*   **`system-map.md` (Human Onboarding Artifact):** Continuously maps the project structure and main business logic. After 6 months of continuous operation, this document serves as a complete onboarding manual for human developers and as a fundamental discussion ground for Software Architects (Domain Models).
*   **`learned-patterns.md` (AI Execution Engine):** Strictly for machine-level solutions (e.g., "build this handler using scaffold", "push kafka message like this"). This prevents technical execution details from polluting high-level human architectural documents.

## 3. Deterministic System Lockdown
AgentOS 2 waives error-prone, external utility scripts for process control. The administration of security boundaries is managed puristically via AntiGravity's native tool-gating and the "Model Context Protocol" (MCP).

*   **Marketplace Lockdown:** External plugins are restricted via system configuration.
*   **Internal Routing:** Only internally whitelisted MCP servers (`@internal`) are permitted, forcing interactions with company databases and Kafka instances to use secure, defined channels.
*   **Inherent Security:** All tool calls are validated through AntiGravity's XML-based reasoning loop before execution.

This minimalist setup guarantees that AgentOS 2 acts as a reliable, encapsulated operating system within any repository, establishing consistent and secure developer workflows.
