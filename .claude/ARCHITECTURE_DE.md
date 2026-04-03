# AgentOS 2 Architektur & Standards (AntiGravity Edition)

Dieses Dokument spezifiziert die Systemarchitektur von **AgentOS 2**, betrieben durch die AntiGravity-Engine. Das Framework integriert große Sprachmodelle in deterministische, zuverlässige und kosteneffiziente Enterprise-Entwicklungsprozesse.

## 1. Das "Context Bloat" Problem (Blank Slate Handoff)
Künstliche Intelligenz degeneriert rapide in ihrer Genauigkeit, wenn große Mengen an inkrementellem Chat-Kontext mitgeführt werden (Context Bloat). AgentOS 2 erzwingt eine strikte Separierung zwischen "Planung" und "Ausführung" unter Nutzung des nativen `planning_mode` von AntiGravity.

Der Skill `/work` implementiert das **Blank Slate Handoff** Pattern.
*   **Orchestrator (AntiGravity):** Die Hauptinstanz analysiert die Aufgabe, kartografiert die Projektstruktur und entwickelt einen Implementierungsplan.
*   **Schwarm (Subagents):** Statt den Plan selbst auszuführen, delegiert der Orchestrator die Arbeit an isolierte "Subagents".
*   **Der Handoff:** Jeder Subagent startet mit einem "Blank Slate". Der Orchestrator übergibt ausschließlich die **Persona** und die **komprimierte Spezifikation**. Dies reduziert Token-Kosten, isoliert Fehler hart und garantiert eine 100%ige Fokus-Rate auf die Modifikation.

## 2. Wissens-Management (Die Enterprise Best Practice)
AgentOS 2 erzwingt eine scharfe Trennung zwischen *high-level Architektur für Menschen* und *low-level Execute-Patterns für KI*, um den Nutzen für beide Seiten zu maximieren:

*   **`tech-stack.md` (Hybrid Init):** Enthält die technologischen Grundregeln. Wird initial durch den `/init` Prozess via Code-Scan vorbefüllt. Bei Unklarheiten oder weitreichenden Infrastruktur-Änderungen nutzt das System zwingend das `askuserquestion` Tool zur Verifikation durch den Architekten.
*   **`system-map.md` (Human Onboarding Artefakt):** Kartografiert fortlaufend die Projektstruktur und Domain-Logik. Das explizite Ziel ist, dass dieses Dokument nach 6 Monaten Laufzeit so vollwertig ist, dass es neuen Entwicklern als komplettes Onboarding-Manual und Architekten als Diskussionsgrundlage dient.
*   **`learned-patterns.md` (KI Execution Engine):** Exklusiv für Laufzeit-Lösungen (z.B. "Implementiere diesen Handler mit Scaffold", "Push die Kafka-Message so"). Diese harte Trennung verhindert, dass maschineller Ausführungscode die sauberen Architektur-Dokumente für die Menschen verunreinigt.

## 3. Deterministischer System-Lockdown
AgentOS 2 verzichtet auf fehleranfällige, externe Utility-Skripte zur Prozesssteuerung. Die Steuerung der Sicherheitsgrenzen erfolgt puristisch über das native Tool-Gating von AntiGravity und das "Model Context Protocol" (MCP).

*   **Marketplace Lockdown:** Externe Plugins sind über die Systemkonfiguration eingeschränkt.
*   **Internes Routing:** Nur intern erlaubte MCP-Server (`@internal`) sind zugelassen, was Interaktionen mit Firmen-Datenbanken und Kafka-Instanzen absichert.
*   **Inhärente Sicherheit:** Alle Tool-Aufrufe werden durch den XML-basierten Reasoning-Loop von AntiGravity validiert.

Dieses minimalistische Setup garantiert, dass AgentOS 2 als zuverlässiges Betriebssystem innerhalb jedes Repositories agiert und konsistente, sichere Arbeitsabläufe etabliert.
