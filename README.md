# Test technique – Decisios

Ce dépôt contient les éléments demandés dans le cadre du test technique pour **Decisios**.

## Contenu du dépôt

### 1. Programme console (Circus) 
- Simulation d’interactions entre un **spectateur**, des **dresseurs** et leurs **singes**
- Utilisation du design pattern **Observer**
- Projet orienté console, écrit en C#.

### 2. API REST – ASP.NET Core (PersonApi)
- API de gestion des **personnes** avec les opérations CRUD.
- Utilisation de **Entity Framework Core** et base de données **SQLite**.
- Architecture : `Models`, `Services`, `Controllers`, `DTOs`

### 3. Tests unitaires – API (PersonApi.Tests)
- Projet `PersonApi.Tests` développé avec **xUnit**
- Tests sur tous les cas **CRUD**

---

## Lancer le projet API

### Prérequis
- .NET SDK 8.0 ou supérieur
- Entity Framework CLI :
```bash
dotnet tool install --global dotnet-ef
```

### Initialiser la base de données
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Lancer l’API
```bash
dotnet run
```

---

## Lancer les tests
```bash
dotnet test
```
