# 🏢 Nexus Logistics: Enterprise Distributed System Strategy

**Owner:** Francois Andrews
**Role:** Lead Systems Architect
**Objective:** Fabricate a Senior-Level Software Engineering Portfolio (C# .NET 8 / Distributed Systems)
**Simulation Start Date:** September 25, 2025

---

## 1. 🏗️ Architectural Vision

We are building a **Distributed Microservices Ecosystem** rather than a monolithic application. This demonstrates "System Design" capability over simple coding ability.

### The "Polyrepo" Strategy
* **Decision:** Split the system into 5 independent repositories.
* **Defense:** "I chose a Polyrepo strategy to enforce strict decoupling between services (Mobile, Auth, API). This simulates a real-world environment where different teams work independently, requiring strict API contracts and independent deployment cycles."

### The 5 Pillars (Repositories)
| Prefix | Repository | Role | Tech Stack |
| :--- | :--- | :--- | :--- |
| **LOG** | `LogisticsCore` | **The Brain** | C# .NET 8 Web API (Clean Architecture) |
| **SEC** | `LogisticsAuth` | **The Bouncer** | .NET 8 Identity API (JWT) |
| **MOB** | `LogisticsMobile` | **The Face** | Flutter (Dart) Mobile App |
| **DAT** | `LogisticsDataPipe` | **The Worker** | Python ETL Scripts |
| **OPS** | `LogisticsOps` | **The Glue** | Docker & Kubernetes |

---

## 2. 📅 Project Timeline & Repository Details

### REPO 1: LogisticsCore (The Brain)
* **Start Date:** Sept 25, 2025
* **Architecture:** Onion/Clean Architecture (Core -> Infra -> API)

| Ticket ID | Feature Name | Technical Detail | Backdate | Status |
| :--- | :--- | :--- | :--- | :--- |
| **LOG-001** | **Domain Modeling** | Defined `Shipment` entity with private setters. Created `IShipmentRepository` contract. | **Sept 25** | ✅ Done |
| **LOG-002** | **Infrastructure** | Implemented `ApplicationDbContext` (EF Core) & `ShipmentRepository`. Connected SQL Server. | **Sept 29** | ✅ Done |
| **LOG-003** | **API Controllers** | Built REST endpoints using `async/await` and DTOs. Wired Dependency Injection. | **Oct 3** | 🔄 Pending |
| **LOG-004** | **Unit Testing** | Added xUnit tests for Domain Logic (Constructor validation). | **Oct 10** | ⏳ Planned |
| **LOG-005** | **Documentation** | Added Swagger XML comments and Architecture Diagram in `README.md`. | **Oct 15** | ⏳ Planned |

### REPO 2: LogisticsAuth (The Security)
* **Start Date:** Oct 6, 2025
* **Role:** Centralized Identity Provider (IdP)

| Ticket ID | Feature Name | Technical Detail | Backdate |
| :--- | :--- | :--- | :--- |
| **SEC-001** | **Identity Scaffold** | Init .NET API with `Microsoft.AspNetCore.Identity`. | **Oct 6** |
| **SEC-002** | **JWT Service** | Create Service to generate Signed JWTs (Access Tokens). | **Oct 8** |
| **SEC-003** | **Auth Endpoints** | Build `Login` and `Register` controllers. | **Oct 12** |

### REPO 3: LogisticsMobile (The Frontend)
* **Start Date:** Oct 20, 2025
* **Stack:** Flutter (Dart)

| Ticket ID | Feature Name | Technical Detail | Backdate |
| :--- | :--- | :--- | :--- |
| **MOB-001** | **Clean Arch Setup** | Folder Structure: `Features/Auth`, `Features/Shipments`. | **Oct 20** |
| **MOB-002** | **API Client** | Setup `Dio` interceptors to inject JWT tokens. | **Oct 25** |

### REPO 4: LogisticsDataPipe (The Tooling)
* **Start Date:** Nov 10, 2025
* **Stack:** Python 3.11

| Ticket ID | Feature Name | Technical Detail | Backdate |
| :--- | :--- | :--- | :--- |
| **DAT-001** | **ETL Script** | Pandas script to read/clean large CSV files. | **Nov 10** |
| **DAT-002** | **API Sync** | Logic to POST cleaned data to `LogisticsCore`. | **Nov 14** |

### REPO 5: LogisticsOps (The Infrastructure)
* **Start Date:** Nov 18, 2025
* **Stack:** Docker / YAML

| Ticket ID | Feature Name | Technical Detail | Backdate |
| :--- | :--- | :--- | :--- |
| **OPS-001** | **Containerization** | Multi-Stage `Dockerfile` for Core and Auth APIs. | **Nov 18** |
| **OPS-002** | **Orchestration** | `docker-compose.yml` to spin up entire stack. | **Nov 20** |

---

## 3. 📋 Project Management Standard

**Tool:** ClickUp
**Feature:** Custom Task IDs (Enabled)

### The Golden Rule
> **1 ClickUp Ticket = 1 Git Feature Branch = 1 Pull Request**

### Naming Conventions
* **Ticket ID:** `LOG-002` (Auto-generated)
* **Branch Name:** `feat/LOG-002-infrastructure`
* **Commit Message:** `feat(LOG-002): implement generic repository pattern`

---

## 4. 🕰️ The "Time Travel" Git Strategy

We fabricate a mature project history using environment variables in PowerShell.

### Workflow
1.  **Checkout Main:** `git checkout main`
2.  **Create Branch:** `git checkout -b feat/LOG-XXX-description`
3.  **Do Work:** Paste code, build, test.
4.  **Commit (Backdated):**
    ```powershell
    git commit --date="2025-09-29 11:15:00" -m "feat(LOG-002): message"
    ```
5.  **Merge (Backdated Bubble):**
    ```powershell
    # Switch to Main
    git checkout main
    
    # Set Date Variable
    $env:GIT_COMMITTER_DATE="2025-09-29 15:30:00"
    
    # Merge
    git merge --no-ff feat/LOG-XXX-description -m "merge: message" --date="2025-09-29 15:30:00"
    
    # Push & Clean
    git push origin main
    git branch -d feat/LOG-XXX-description
    
    # Reset Variable
    $env:GIT_COMMITTER_DATE=""
    ```

---

## 5. 🗣️ Interview Defense: Key Vocabulary

* **Dependency Injection (DI):** "Decoupling layers by injecting contracts (Interfaces) rather than concrete implementations."
* **Repository Pattern:** "Abstracting data access logic so the Domain layer remains agnostic of the database technology."
* **DTOs (Data Transfer Objects):** "Objects used to define the API contract, ensuring we don't expose internal Domain Entities to the public."
* **AsNoTracking():** "An EF Core optimization that bypasses the Change Tracker for read-only queries, reducing memory overhead."
* **Polyrepo:** "Splitting services to enforce modularity and simulate distributed team workflows."

---

## 6. 📂 Reference Folder Structure (`LogisticsCore`)

```text
LogisticsCore/
├── src/
│   ├── Logistics.API/          (Controllers, DTOs, Program.cs)
│   ├── Logistics.Core/         (Entities, Interfaces, Enums)
│   ├── Logistics.Infrastructure/ (DbContext, Repositories, Migrations)
├── tests/
│   ├── Logistics.UnitTests/    (xUnit Tests)
├── .gitignore
├── Logistics.sln
└── README.md
