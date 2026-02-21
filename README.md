# ZooMonkeys Management System

Dieses Projekt ist eine Demo-Anwendung für die Verwaltung eines Zoos und seiner Affenpopulation. Der technologische Kern demonstriert die architektonische Migration von einem klassischen CRUD-Datenmodell hin zu einer strikten CQRS/Event-Sourcing-Architektur.

## Architektur-Philosophie: Sleepy Hollow & IODA (Ralf Westphal)

Die Architektur setzt Prinzipien von Ralf Westphal kompromisslos um, speziell das **IODA-Prinzip** (Integration, Operation, Data, API), die **Sleepy Hollow Architektur** und **AQ over CRUD** (Append/Query).

* **Sleepy Hollow (Die Domäne):** Die Domänenlogik ist "kopflos". Sie besteht ausschließlich aus C# Records und reinen Funktionen (Pure Functions). Sie besitzt keinerlei I/O-Abhängigkeiten (keine Datenbanken, keine APIs, keine DI-Container). Sie empfängt einen Command und den aktuellen Zustand und liefert ein deterministisches neues Event zurück.
* **IODA in Vertical Slices:** Die API-Schicht steuert die Integration. Ein FastEndpoint-Handler fungiert als Orchestrator:
    1. **A**PI: Nimmt den HTTP-Request entgegen.
    2. **D**ata: Lädt den bisherigen Event-Stream/Zustand aus der Datenbank.
    3. **O**peration: Ruft die reine Funktion der Domäne auf (ohne eigene Business-Logik-Entscheidungen im Handler).
    4. **D**ata: Speichert das resultierende Event in der Datenbank.
* **AQ over CRUD:** Zustände werden in der Datenbank nicht überschrieben. Alle Modifikationen werden als immutable Events an einen Stream gehängt (Marten DocumentStore auf PostgreSQL). Lesezugriffe (Queries) bedienen sich aus asynchron berechneten Projections.

## Projektstruktur

Das Repository erzwingt die Trennung durch eine reduzierte Zwei-Projekt-Struktur für das Backend.

* **`/TestWebAppNet10.API`**: Das ursprüngliche CRUD-Backend (Legacy-Referenz).
* **`/Backend/ZooMonkeys.Domain`**: Die Sleepy Hollow Domäne. Nur fachliche Typen (Commands, Events, State) und Pure Functions. Zero Dependencies.
* **`/Backend/ZooMonkeys.API`**: Die Infrastruktur- und API-Schicht. Kapselt FastEndpoints (Vertical Slices) und die Marten-PostgreSQL-Integration.
* **`/Frontend`**: Die Angular 21 Single Page Application, die über die native `resource` API mit den CQRS-Endpoints kommuniziert.

## Tech Stack (Stand Februar 2026)

**Backend:**
* .NET 10 (C# 14)
* FastEndpoints (Vertical Slice Architecture)
* Marten (Event Store & Projections)
* PostgreSQL
* Native AOT (Ahead-of-Time Compilation)

**Frontend:**
* Angular 21
* Zoneless Change Detection (`provideExperimentalZonelessChangeDetection`)
* 100% Standalone Components
* Native `resource` API für Datenabruf
* Signal Forms für Status-Mutationen

## Setup & Lokale Ausführung

Das Projekt ist vollständig containerisiert via Multi-Stage Dockerfiles (.NET AOT und Node/Nginx).

```bash
# Startet PostgreSQL, das .NET 10 Backend und das Angular Frontend
docker-compose up --build -d

Frontend UI: http://localhost:4200

Backend API: http://localhost:5149