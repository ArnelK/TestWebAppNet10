# Audit Workflow: /security-audit (Vulnerability Scan)

Focused security and vulnerability scanning for the AgentOS 2 project.

1. **Security Context Loading**
   Analyze the most recent changes and search for potentially vulnerable components (e.g., API endpoints, Auth logic, Database queries).
2. **Persona Activation: Security-Specialist**
   Assign the `Persona: Security-Specialist` to perform the audit.
3. **OWASP Audit Phase**
   Check the implementation for:
   - SQL Injection / NoSQL Injection
   - Broken Authentication (JWT/Session logic)
   - Sensitive Data Exposure
   - XML External Entities (XXE)
   - Broken Access Control
4. **Architectural Gating**
   Identify if any security standards defined in the [Tech-Stack](./.agents/architecture/tech-stack.md) were bypassed.
5. **Mitigation Report**
   Generate a report (as a markdown artifact) that specifies identified risks and suggests fixes.
