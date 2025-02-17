## Overview
RentApp is a rental service application that allows users to rent cars and books. It follows the **SOLID** principles for maintainability and scalability. The project is structured into multiple layers, including API, Services, Repository, and Validator.

## Installation
1. Clone the repository:
   ```sh
   git clone https://github.com/your-repo/RentApp.git
   ```
2. Navigate to the project directory:
   ```sh
   cd RentApp
   ```
3. Restore dependencies:
   ```sh
   dotnet restore
   ```
4. Update the database connection string in `appsettings.json`.
5. Run the application:
   ```sh
   dotnet run --project RentApp.Api
   ```
6. Open Swagger UI to test endpoints: `https://localhost:<port>/swagger`

## API Endpoints
### User Endpoints
- **GET** `/api/user` - Get all users
- **GET** `/api/user/{id}` - Get user by ID
- **POST** `/api/user` - Create a user
- **DELETE** `/api/user/{id}` - Delete user

### Book Endpoints
- **GET** `/api/book` - Get all books
- **POST** `/api/book` - Create book

### RideCar Endpoints
- **GET** `/api/ridecar` - Get all rides
- **POST** `/api/ridecar` - Create ride

## SOLID Principles in RentApp
### 1. **Single Responsibility Principle (SRP)**
- Controllers only handle HTTP requests.
- Services contain business logic.
- Repositories interact with the database.
- Validators ensure input correctness.

### 2. **Open/Closed Principle (OCP)**
- New discount types (e.g., `DiscountCustomer`, `EngineDiscount`) can be added without modifying existing code.

### 3. **Liskov Substitution Principle (LSP)**
- `DiscountableCustomer` and `NonDiscountableCustomer` follow LSP, allowing interchangeable usage.

### 4. **Interface Segregation Principle (ISP)**
- Separate interfaces like `IUserService`, `IBookService` ensure each service has only relevant methods.

### 5. **Dependency Inversion Principle (DIP)**
- Uses dependency injection to decouple components (`IUserRepository`, `IValidator<User>`, etc.).

## Pricing Logic
- **Base Price:** ₹150 per book.
- **Final Price Calculation:**
  ```csharp
  totalPrice = BasePrice * Quantity;
  totalPrice -= discountCalculator.ApplyDiscount(customerType);
  ```

## License
This project is open-source and available under the [MIT License](LICENSE).
