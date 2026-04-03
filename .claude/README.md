# 🤖 AgentOS 2 (AntiGravity Edition)

**Purpose:** A deterministic, project-agnostic multi-agent operating system for Enterprise development processes, powered by AntiGravity.

AgentOS 2 is the standard framework for integrating Large Language Models into secure, structured, and autonomous execution environments. It solves the common problems of naive interactions (memory loss, faulty code executions due to context overload) through a strict orchestration architecture. Designed as a Drop-In solution, it can seamlessly be embedded into any repository of the organization (e.g., C# .NET, Angular).

---

## 🏗️ Global Entry Points (Leitsystem)

For the system to activate correctly, the following entry points MUST exist at the repository root:

- **`.claudemd`**: Configures the legacy Claude Code CLI to load all skills and rules.
- **`system-rules.md`**: Definitiv root-level laws for AntiGravity (DeepMind Native).
- **`system-state.md`**: The persistent task-tracking ledger for the AntiGravity engine.

---

## 🎯 Core Framework Features

1. **Coordinator-Worker Hierarchy (`/work`)**
   The AI operates as a swarm system using AntiGravity's native `planning_mode`. A "Coordinator" analyzes tasks and breaks them down into precise sub-tasks. The hard separation between *Planning* and *Execution* isolates errors and prevents uncontrolled actions.
2. **Autonomous Knowledge Management (AntiGravity System)**
   The framework utilizes the native AntiGravity Knowledge System. It scans session outcomes for successfully made architectural decisions and writes them into the global knowledge base (`.agents/architecture/`). Relevant context knowledge thus accumulates continuously for the whole team.
3. **Context Security (Blank Slate Handoff)**
   To avoid high API costs and hallucinations, AgentOS 2 operates with extremely lean context handoffs. Workers (Subagents) receive exclusively hard technical specifications and no redundant history ("Context Bloat Avoidance").
4. **Persona-Based Execution**
   Every task is routed to a specialized Persona (e.g., `Backend-Engineer`, `Security-Specialist`, `DevOps-Engineer`) to ensure the highest possible output quality and architectural compliance.

---

## 🚀 Installation & Rollout

AgentOS 2 is a modular framework that operates isolated in the `.agents/` directory of the respective repository.

1. **Integrate:** Copy the `.agents` folder into the root directory of your target project.
2. **Start:** Start AntiGravity in the root directory.
3. **Execute:** Use the skill `/work <task>` to initiate a structured, secure swarm execution.

---

## 🛠️ Workflow Execution (SOPs)

AgentOS 2 includes standardized workflows to automate complex procedures. You can trigger these by asking AntiGravity to perform the specific workflow or using slash-commands if configured:

- **`/init`**: Performs a deep scan of the repository, detects core technologies, and populates the `tech-stack.md` (Hybrid Auto-Init).
- **`/feature`**: Executes the full Swarm cycle (Coordinator -> Persona Routing -> Subagent Execution -> Knowledge Growth).
- **`/security-audit`**: Activates the `Security-Specialist` to audit recent changes for vulnerabilities (OWASP).

---

## 📚 Architecture & Standards

The internal mechanisms and theoretical foundations underlying the stability of AgentOS 2 are documented in the system guidelines.

👉 **All architectural decisions, handoff strategies, and security baselines can be found in the core document: [ARCHITECTURE.md](ARCHITECTURE.md)**
