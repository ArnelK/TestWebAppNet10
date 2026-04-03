# Workforce Workflow: /init (System Discovery)

This workflow initializes a new repository for AgentOS 2 by identifying its core technologies and architecture.

1. **Deep Repository Scan**
   Search for project-specific files (e.g., `*.sln`, `*.csproj`, `package.json`, `Dockerfile`, `docker-compose.yml`, `*.config`).
2. **Framework & Language Detection**
   Analyze files to identify:
   - Backend Framework (e.g., .NET 10 FastEndpoints, Node.js)
   - Frontend Framework (e.g., Angular 21, React)
   - Database Type (e.g., PostgreSQL, MSSQL, EF Core versions)
   - Infrastructure (e.g., Docker, Jenkins, Kafka)
3. **Drafting the Tech-Stack**
   Populate [tech-stack.md](./.agents/architecture/tech-stack.md) with the findings.
4. **Hybrid Verification (Architect Review)**
   Use the `askuserquestion` tool to present the findings to the human Architect. 
   *Sample Question:* "I have identified .NET 10 and Kafka as your core technologies. Are there any specific versioning rules or structural constraints I should be aware of?"
5. **Finalize Knowledge Init**
   Once verified, finalize the document and establish the baseline for subsequent swarming.
