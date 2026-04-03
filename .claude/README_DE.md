# 🤖 AgentOS 2 (AntiGravity Edition)

**Zweck:** Ein deterministisches, projektübergreifendes Multi-Agenten-Betriebssystem für Enterprise-Entwicklungsprozesse, powered by AntiGravity.

AgentOS 2 ist das Standard-Framework zur Integration von großen Sprachmodellen in sichere, strukturierte und autonome Ausführungsumgebungen. Es löst die gängigen Probleme naiver Interaktionen (Speicherverlust, fehlerhafte Code-Ausführungen durch Kontext-Überlastung) durch eine strikte Orchestrierungs-Architektur. Entworfen als Drop-In Lösung, kann es nahtlos in jedes Repository der Organisation (z.B. C# .NET, Angular) eingebettet werden.

---

## 🏗️ Globale Einstiegspunkte (Leitsystem)

Damit das System korrekt aktiviert wird, MÜSSEN folgende Einstiegspunkte im Root-Verzeichnis existieren:

- **`.claudemd`**: Konfiguriert die legacy Claude Code CLI, sodass alle Skills und Regeln geladen werden.
- **`system-rules.md`**: Definitive Root-Level Gesetze für AntiGravity (DeepMind Native).
- **`system-state.md`**: Das persistente Task-Tracking-Bordbuch für die AntiGravity-Engine.

---

## 🎯 Kern-Features des Frameworks

1. **Coordinator-Worker Hierarchie (`/work`)**
   Die K.I. agiert als Schwarm-System unter Nutzung des nativen `planning_mode` von AntiGravity. Ein "Coordinator" analysiert Aufgaben und teilt sie in präzise Sub-Tasks auf. Die harte Trennung zwischen *Planung* und *Ausführung* isoliert Fehler und verhindert unkontrollierten Aktionismus.
2. **Autonomes Wissens-Management (AntiGravity System)**
   Das Framework nutzt das native AntiGravity Knowledge System. Es scannt Sitzungsergebnisse auf erfolgreich getroffene Architekturentscheidungen und sichert diese in der globalen Knowledge-Base (`.agents/architecture/`). Relevantes Kontextwissen akkumuliert sich somit kontinuierlich für das gesamte Team.
3. **Kontext-Sicherheit (Blank Slate Handoff)**
   Um hohe API-Kosten und Halluzinationen zu vermeiden, arbeitet AgentOS 2 mit extrem schlanken Kontext-Übergaben. Worker (Subagents) erhalten ausschließlich harte technische Spezifikationen und keinen redundanten Verlauf («Context Bloat Vermeidung»).
4. **Persona-Basierte Ausführung**
   Jeder Task wird an eine spezialisierte Persona geroutet (z.B. `Backend-Engineer`, `Security-Specialist`, `DevOps-Engineer`), um höchste Ergebnisqualität und Architektur-Konformität zu garantieren.

---

## 🚀 Installation & Rollout

AgentOS 2 ist ein modulares Framework, das isoliert im `.agents/` Verzeichnis des jeweiligen Repositories agiert.

1. **Integrieren:** Kopiere den `.agents` Ordner in das Root-Verzeichnis deines Ziel-Projekts.
2. **Starten:** Starte AntiGravity im Root-Verzeichnis.
3. **Ausführen:** Nutze den Skill `/work <aufgabe>`, um eine strukturierte, sichere Schwarm-Ausführung zu initiieren.

---

## 🛠️ Workflow-Ausführung (SOPs)

AgentOS 2 beinhaltet standardisierte Workflows zur Automatisierung komplexer Abläufe. Diese können durch direkte Anweisung an AntiGravity oder (falls konfiguriert) über Slash-Commands getriggert werden:

- **`/init`**: Führt einen Deep-Scan des Repositories durch, erkennt Kern-Technologien und füllt die `tech-stack.md` (Hybrid Auto-Init).
- **`/feature`**: Führt den kompletten Swarm-Zyklus aus (Coordinator -> Persona Routing -> Subagent Execution -> Knowledge Growth).
- **`/security-audit`**: Aktiviert den `Security-Specialist`, um die letzten Änderungen auf Schwachstellen (OWASP) zu prüfen.

---

## 📚 Architektur & Standards

Die internen Mechanismen und theoretischen Grundlagen, die der Stabilität von AgentOS 2 zugrunde liegen, sind in den Systemrichtlinien dokumentiert.

👉 **Alle architektonischen Entscheidungen, Handoff-Strategien und Security-Baselines findest du im Kern-Dokument: [ARCHITECTURE.md](ARCHITECTURE.md)**
