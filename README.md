1. Project Overview & Context
This repository contains the central C# .NET 8 Web API for the Nexus Logistics Ecosystem (the overall distributed platform). The service is responsible for all core business logic, data persistence, and exposing RESTful endpoints for consumption by external clients (e.g., the Flutter Mobile App and Python Data Pipeline).

Key Design Principle: This service is decoupled from the database technology and the client-facing UI. It only communicates via abstract contracts (Interfaces).

Architecture Proof (Clean Architecture)
The repository is structured following the Onion/Clean Architecture pattern to maximize testability and enforce the Dependency Inversion Principle.

<img width="353" height="190" alt="image" src="https://github.com/user-attachments/assets/5cb83939-d8c9-4609-8e6a-6c1b43501a06" />

2. Technical Decisions & Features
Language & Runtime: C# 12 / .NET 10.0
Database: Microsoft SQL Server (via Docker).
Persistence: Entity Framework Core with Repository Pattern.
Optimization: AsNoTracking() is used on all read operations (GET requests) to optimize performance by bypassing the EF Change Tracker.
Domain Integrity: Domain entities enforce state validity via private setters and constructor validation (throwing exceptions on bad input).

API Documentation (Swagger)
The API is self-documenting via Swagger UI (OpenAPI). All endpoints require authentication (handled by the external LogisticsAuth service).

[Screenshot of the Swagger UI showing the available POST /shipments and GET /shipments/{id} endpoints]

3. Local Setup & Running the Service
The recommended way to run this service is via Docker Compose (See LogisticsOps Repo).

Prerequisites:
.NET 8 SDK
SQL Server (LocalDB or Docker Container)

Steps:
1. Clone: git clone [Your Repository URL]
2. Update Connection String: Modify appsettings.Development.json in the Logistics.API project to point to your local SQL Server instance.
3. Database Migration: Run the migration commands from the Logistics.API terminal (This creates the database schema):

**dotnet ef database update**

4. Run: dotnet run --project src/Logistics.API

4. Contributing & Feature Tracking
All feature development is tracked via ClickUp using prefixed Task IDs.
Tickets: Create a task in ClickUp (e.g., LOG-006: Add Shipments Search functionality).
Branches: Checkout a feature branch matching the ID: git checkout -b feat/LOG-006-search-feature
Commits: Start every commit message with the Ticket ID: feat(LOG-006): implement search query logic

Screenshots:
The Architecture: Open your VS solution and take a full-screen screenshot showing the 3 separate projects (Core, Infra, API) in the Solution Explorer.
The API: Run the API locally and navigate to the Swagger URL (localhost:5001/swagger/index.html) to capture the page showing the POST /Shipments endpoint.
