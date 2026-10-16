Mini Shop - Modular Monolith

A simple backend for a Mini Shop built with ASP.NET Core, following a Modular Monolith architecture. The application uses in-memory data storage and strict module boundaries to ensure clean architecture and encapsulation.

How to Run the Project

Ensure you have the .NET 8 SDK (or your specific version) installed.

Clone the repository to your local machine.

Open a terminal or command prompt in the project root directory.

Run the following command to start the application:

dotnet run


Open your web browser and navigate to the Swagger UI to test the endpoints:
https://localhost:<port>/swagger (Check your terminal for the exact port, e.g., 7131).

Folder Structure

The project is structured into independent modules under the Modulers directory, with a single entry point via the Controllers.

Mini_Shop/
├── Controllers/
│   └── MainController.cs        # Single entry point for all API routes
├── Modulers/
│   ├── Notifications/           # Stretch Goal: Listens to Order events
│   ├── Orders/
│   │   ├── Orders_Data_Store/   # Internal data storage for Orders
│   │   ├── Orders_DTOs/         # Request/Response objects
│   │   └── Orders_Services/     # Public interface and business logic
│   ├── Products/
│   │   ├── Products_Data_Store/
│   │   ├── Products_DTOs/
│   │   └── Products_Services/
│   └── Users/
│       ├── Users_Data_Store/
│       ├── Users_DTOs/
│       └── Users_Services/
├
│                  # Shared internal event bus for inter-module messaging
└── Program.cs                   # Application configuration and DI container


Why This Module Separation?

I separated the application into independent modules (Users, Products, Orders) to enforce strict bounded contexts and encapsulation. Each module is responsible only for its own data and business rules, acting almost like a mini-application. By keeping the DataStore and entity classes internal, I ensured that modules cannot secretly manipulate each other's data. They can only communicate through explicitly defined public service interfaces (e.g., IProductServices.ReduceStock). This separation makes the codebase highly maintainable, easy to test, and prevents "spaghetti code" where everything is tightly coupled.

Comparison with Microservices

If the "Orders" module were to become its own independent Microservice, the architecture would change significantly. Instead of communicating with Users and Products via direct, in-memory C# method calls (Dependency Injection), the Orders service would need to make network calls (like HTTP REST or gRPC) or use an external message broker (like RabbitMQ or Kafka) to verify users and reduce stock. The Orders service would also have its own physical database and be deployed on a separate server or container. While microservices offer independent scaling and deployment, they introduce complex challenges like network latency, handling partial failures, and managing distributed transactions—complexities we avoid in this modular monolith while still keeping the code cleanly separated.

Assumptions Made

In-Memory Storage: Since no database is used, all data is stored in memory arrays. I assumed it is acceptable that all data will be lost when the application restarts.

Synchronous Validation: Stock reduction and user verification are handled synchronously during the order placement request.

Single Controller: I assumed MainController should handle all routing logic using standard ASP.NET Core [Route] attributes to direct traffic to the injected module services.

IDs: Simple auto-incrementing integers are used for IDs across all modules for simplicity.
