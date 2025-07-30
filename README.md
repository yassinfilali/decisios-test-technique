# Test technique – Decisios

Ce dépôt contient les éléments demandés dans le cadre du test technique pour **Decisios**.

## Contenu du dépôt

### 1. Programme console (C#)
- Simulation d’interactions entre un **spectateur**, des **dresseurs** et leurs **singes**
- Utilisation de **design patterns** Observer
- Projet orienté console, écrit en C#.

### 2. API REST – ASP.NET Core
- API de gestion des **personnes** avec les opérations CRUD.
- Utilisation de **Entity Framework Core** et base de donnée **SQLite**.
- Architecture :  `Models`, `Services`, `Controllers`, `DTOs`

### 3. Tests unitaires – API
- Projet `PersonApi.Tests` développé avec **xUnit**.
- Tests sur tous les cas CRUD
    
## Lancer le projet Test 
```bash
dotnet test


---

## Lancer le projet API

### Prérequis
- .NET SDK 8.0 ou supérieur
- Entity Framework CLI : `dotnet tool install --global dotnet-ef`

### Initialiser la base de données

```bash
# 1. Générer la migration (si pas déjà présente)
dotnet ef migrations add InitialCreate

# 2. Appliquer la migration à la base SQLite
dotnet ef database update

# 3. Lancer l’API
dotnet run
