# Library App

## Description

Library App is a console-based application designed to manage library operations such as patron searches, loan management, and membership renewals. It uses a layered architecture with Application Core, Infrastructure, and Console layers to ensure modularity and maintainability.

## Project Structure

- `AccelerateDevGitHubCopilot.sln` - Solution file for the project.
- `README.md` - Documentation for the project.
- `.devcontainer/`
  - `devcontainer.json` - Configuration for the development container.
- `src/`
  - `Library.ApplicationCore/` - Core application logic and domain entities.
    - `Entities/` - Domain entities such as `Book`, `Loan`, and `Patron`.
    - `Enums/` - Enumerations used across the application.
    - `Interfaces/` - Interfaces defining contracts for repositories and services.
    - `Services/` - Core services implementing business logic.
    - `Library.ApplicationCore.csproj` - Project file for the Application Core layer.
  - `Library.Console/` - Console application for interacting with the library system.
    - `appSettings.json` - Configuration file for the console application.
    - `CommonActions.cs` - Enum defining common user actions.
    - `ConsoleApp.cs` - Main console application logic.
    - `ConsoleState.cs` - Enum defining application states.
    - `Json/` - Folder for JSON data files.
    - `Program.cs` - Entry point for the console application.
    - `Library.Console.csproj` - Project file for the Console layer.
  - `Library.Infrastructure/` - Infrastructure layer for data access and persistence.
    - `Data/` - Classes for JSON-based data storage and retrieval.
    - `Library.Infrastructure.csproj` - Project file for the Infrastructure layer.
- `tests/`
  - `UnitTests/` - Unit tests for the application.

## Key Classes and Interfaces

### Application Core
- `Entities/`
  - `Book` - Represents a book in the library.
  - `Loan` - Represents a loan of a book to a patron.
  - `Patron` - Represents a library patron.
- `Interfaces/`
  - `ILoanRepository` - Interface for loan data access.
  - `IPatronRepository` - Interface for patron data access.
  - `ILoanService` - Interface for loan-related business logic.
  - `IPatronService` - Interface for patron-related business logic.
- `Services/`
  - `LoanService` - Implements loan-related business logic.

### Console
- `ConsoleApp` - Main class for the console application.
- `CommonActions` - Enum defining user actions such as search, quit, and renew membership.
- `ConsoleState` - Enum defining application states such as `PatronSearch` and `LoanDetails`.

### Infrastructure
- `JsonData` - Handles loading and saving data to JSON files.
- `JsonPatronRepository` - Implements `IPatronRepository` for JSON-based patron data.
- `JsonLoanRepository` - Implements `ILoanRepository` for JSON-based loan data.

## Usage

1. Clone the repository:
   ```bash
   git clone <repository-url>
   cd <repository-folder>