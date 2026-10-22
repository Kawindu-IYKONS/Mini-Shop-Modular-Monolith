# Mini Shop - Modular Monolith

A simple backend application for a Mini Shop built with **ASP.NET Core 10** using the Modular Monolith architecture.

The application contains three main modules: **Users, Products, and Orders**. Each module manages its own data and business logic. The application uses in-memory storage, dependency injection, DTOs, and centralized exception handling.

## Technologies Used

- C#
- ASP.NET Core 10
- REST API
- Swagger / OpenAPI
- Dependency Injection
- In-memory data storage
- Data Annotations for DTO validation

## How to Run the Project

### Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/) with ASP.NET and web development support
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

### Steps

1. Clone the repository to your local machine.

   ```bash
   git clone <repository-url>
   ```

2. Open the solution (`.sln`) file in Visual Studio.

3. Set `Mini_Shop` as the startup project if it is not already selected.

4. Build the solution using **Build → Build Solution**.

5. Start the application by clicking **Start** or pressing **F5**.

6. If Visual Studio pauses at a breakpoint or stops when an exception is thrown during debugging, press **F5** again to continue execution. This may happen when debugging Exceptions; check the actual HTTP response to determine whether the API request succeeded or failed.

7. Once the application starts, open the Swagger UI using the HTTPS URL shown in the browser or Visual Studio output. It usually looks like:

   ```text
   https://localhost:<port>/swagger
   ```

   Replace `<port>` with the actual port assigned to your application.

You can now use Swagger UI to test the API endpoints.

### Running from the Terminal (Optional)

Open a terminal in the directory containing the project file (`.csproj`) and run:

```bash
dotnet restore
dotnet run
```

Open the Swagger URL displayed in the terminal.

## Project Structure

```text
Mini_Shop/
├── Controllers/
│   └── MainController.cs
│
├── Modules/
│   ├── Orders/
│   │   ├── DataStore/
│   │   │   └── OrderDataStore.cs
│   │   ├── Dtos/
│   │   │   ├── CreateOrderDto.cs
│   │   │   └── GetOrderDto.cs
│   │   └── Services/
│   │       ├── IOrderServices.cs
│   │       └── OrderServices.cs
│   │
│   ├── Products/
│   │   ├── DataStore/
│   │   │   └── ProductDataStore.cs
│   │   ├── Dtos/
│   │   │   ├── CreateProductDto.cs
│   │   │   └── GetProductDto.cs
│   │   └── Services/
│   │       ├── IProductServices.cs
│   │       └── ProductServices.cs
│   │
│   └── Users/
│       ├── DataStore/
│       ├── Dtos/
│       └── Services/
│
├── Exceptions/
│   ├── BusinessValidationException.cs
│   ├── DuplicateEmailException.cs
│   ├── GlobalExceptionHandler.cs
│   └── NotFoundException.cs
│
├── Program.cs
└── Mini_Shop.csproj
```

*Note: This tree shows the main files and folders. Update it if your actual project structure differs.*

## API Modules

### Users Module

Responsible for creating users and retrieving user information. It handles user-related data and email uniqueness validation.

### Products Module

Responsible for creating products, retrieving products, and managing stock. Product prices use `decimal` to represent monetary values.

### Orders Module

Responsible for creating orders and retrieving orders by user ID. Before creating an order, it checks the user and product and requests the product service to reduce stock.

## Why Modular Monolith?

The application is organized into separate modules so that each module owns its business logic and data access responsibilities.

The modules communicate through service interfaces, such as `IUserServices` and `IProductServices`, instead of directly manipulating another module's data store. Data store and entity classes are marked `internal` to limit access outside the current assembly.

**Important limitation:** Because all modules are currently in the same project and assembly, `internal` does not prevent one module from accessing another module's internal classes. The boundary is therefore supported by the design and coding conventions, rather than fully enforced by the compiler. Separate projects/assemblies and architecture tests could enforce these boundaries more strongly.

## Exception Handling and Validation

- DTO validation attributes such as `[Required]` and `[Range]` validate incoming request data.
- `NotFoundException` represents resources that cannot be found.
- `DuplicateEmailException` handles duplicate email registration.
- `BusinessValidationException` handles business rule violations.
- `GlobalExceptionHandler` converts handled Exceptions into appropriate HTTP responses.

## Modular Monolith vs. Microservices

In this project, modules communicate through in-process C# service calls using dependency injection. They share the same application process and deployment.

If the Orders module became a separate microservice, it would need a communication mechanism such as HTTP REST, gRPC, or messaging. It could also have its own database and deployment lifecycle. Microservices offer independent deployment and scaling, but introduce additional complexity such as network failures, latency, and distributed transaction management.

## Assumptions and Limitations

- **In-memory storage:** Data is stored in memory and is lost when the application restarts.
- **Synchronous order processing:** User verification, product verification, and stock reduction occur during the order request.
- **Single controller:** `MainController` exposes the API routes for the modules.
- **Auto-incrementing IDs:** IDs are generated in memory for simplicity.
- **Single application:** All modules run within the same ASP.NET Core application.

Question
All modules are in one project. Does `internal` really stop the Orders module from using `ProductDataStore`? If not, what would actually enforce the boundary?

Answer
No. Since all modules are in the same project and assembly, internal does not prevent the Orders module from accessing ProductDataStore.To enforce the boundary, we can separate modules into different projects/assemblies and expose only public interfaces for communication.
