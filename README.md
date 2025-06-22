# 💸 MoneyMaker

**MoneyMaker** est une application de gestion budgétaire personnelle. Elle permet de modéliser des opérations récurrentes (loyer, abonnements, salaires...), de suivre les comptes bancaires par utilisateur, et de simuler automatiquement l’évolution du solde à une date donnée.

---

## 🚀 Fonctionnalités

- 📅 Définition d’opérations périodiques : daily, weekly, monthly, yearly
- 🏦 Suivi de comptes bancaires et des soldes par utilisateur
- 🔁 Calcul automatique des occurrences futures d'une dépense
- 📊 Simulation du solde à une date donnée
- 🧩 Architecture modulaire avec EF Core

---

## 🛠 Stack technique

- [.NET 8](https://dotnet.microsoft.com/)
- Entity Framework Core
- ConsoleApp / Blazor (selon projet)
- SQL Server ou PostgreSQL (au choix)

---

## ⚙️ Démarrage rapide

```bash
# Cloner le repo
git clone https://github.com/votre-utilisateur/MoneyMaker.git
cd MoneyMaker

# Restaurer les packages
dotnet restore

# Lancer le projet (exemple console)
cd MoneyMaker.Console
dotnet run
