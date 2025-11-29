# 🏢 Nexus Logistics: Distributed Enterprise Ecosystem

> **Project Status:** Active Development (Sprint 1)
> **Role:** Lead Software Engineer
> **Current Focus:** Infrastructure Orchestration & Core API Development

## 1. 🏗️ The Architectural Vision
Nexus Logistics is a **Distributed Microservices Ecosystem** designed to simulate high-scale enterprise logistics. Unlike monolithic "tutorial" apps, this system enforces strict separation of concerns through a **Polyrepo Strategy**.

The goal is to demonstrate **Full-Cycle Engineering** capability:
1.  **Build** the Core Logic (.NET 8 Clean Architecture).
2.  **Orchestrate** the Infrastructure (Docker & SQL Server).
3.  **Automate** the Assurance (Playwright E2E Tests).
4.  **Consume** via Multiple Clients (Flutter Mobile & Blazor Web).

## 2. 🧩 The 5 Pillars (Service Mesh)

| Prefix | Repository | Role | Tech Stack |
| :--- | :--- | :--- | :--- |
| **LOG** | `LogisticsCore` | **The Brain** | .NET 8 Web API, EF Core, SQL Server |
| **OPS** | `LogisticsOps` | **The Platform** | Docker Compose, GitHub Actions (CI/CD) |
| **QUA** | `LogisticsQuality`| **The Guardian** | Playwright .NET, xUnit (Automated QA) |
| **SEC** | `LogisticsAuth` | **The Bouncer** | ASP.NET Identity, JWT Provider |
| **MOB** | `LogisticsMobile` | **The Face** | Flutter (Dart), Dio Client |

---

## 3. 📅 Development Roadmap (Sprint 1)

### ✅ Completed
| Ticket | Feature | Tech Stack | Date Completed |
| :--- | :--- | :--- | :--- |
| **LOG-001** | **Domain Modeling** | C# (DDD), Enums, Interfaces | Nov 24, 2025 |
| **LOG-002** | **Infrastructure Layer** | EF Core, DbContext, SQL Connectors | Nov 25, 2025 |

### 🚧 In Progress (Week of Dec 1)
| Ticket | Feature | Objective | Scheduled |
| :--- | :--- | :--- | :--- |
| **OPS-001** | **SQL Orchestration** | Create `docker-compose.yml` to spin up SQL Server container. (Foundation) | **Dec 01** |
| **LOG-003** | **API Controllers** | Implement `ShipmentsController` (GET/POST) connected to Docker DB. | **Dec 01** |
| **LOG-004** | **Defensive Logic** | Implement Domain Validation (e.g., "Tracking Code cannot be empty"). | **Dec 02** |
| **OPS-002** | **Network Bridge** | Configure Docker Network for Mobile Emulator access. | **Dec 02** |
| **QUA-001** | **Quality Rig** | Initialize Playwright E2E Suite to automate API testing. | **Dec 03** |

---

## 4. 🛠️ Tech Stack & Decisions

### Why Polyrepo?
I chose a Polyrepo strategy to enforce strict decoupling. This simulates a real-world distributed team environment where API contracts must be respected, and "spaghetti code" coupling is physically impossible.

### Why Playwright over Python Scripts?
Originally considering Python for data ingestion, I pivoted to **Playwright .NET** to prioritize **Automated Integration Testing**. In a modern CI/CD pipeline, the ability to automatically verify system health is more valuable than ad-hoc scripting.

---

## 5. 🚀 Running the System (Local Dev)
*Prerequisites: Docker Desktop, .NET 8 SDK*

1. **Start Infrastructure:**

   ```bash
   docker-compose up -d

2. **Apply Migrations:**

Bash:
cd src/LogisticsCore
dotnet ef database update

3. **Launch API:**

Bash:
dotnet run
