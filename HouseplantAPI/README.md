
# 🌱 Houseplant API

A simple ASP.NET Core Web API for managing houseplants and their categories.

## 🛠️ Tech Stack

- **ASP.NET Core 9** (Minimal APIs)
- **Entity Framework Core 9**
- **SQLite**
- **C#**



## 📋 What is it?

This API allows you to create, read, update, and delete houseplants, each associated with a category (e.g., Foliage, Flowering, Succulent, Cacti).


## 🚀 How to Run

1. **Clone the repository**
2. Open a terminal in the project directory.
3. Run database migrations (if needed):

   ```pwsh
   dotnet ef database update
   ```

4. Start the API:

   ```pwsh
   dotnet run
   ```

5. The API will be available at `https://localhost:5001` or `http://localhost:5000` by default.


## 📚 Endpoints

All endpoints are under `/houseplant`.

| Method | Endpoint              | Description                   |
|--------|-----------------------|-------------------------------|
| GET    | /houseplant           | List all houseplants          |
| GET    | /houseplant/{id}      | Get a houseplant by ID        |
| POST   | /houseplant           | Create a new houseplant       |
| PUT    | /houseplant/{id}      | Update an existing houseplant |
| DELETE | /houseplant/{id}      | Delete a houseplant           |



## 💡 Example Requests

**Create a houseplant:**

```http
POST /houseplant
Content-Type: application/json

{
  "name": "Monstera",
  "leaves": 5,
  "categoryId": 1
}
```

**Get all houseplants:**

```http
GET /houseplant
```

---

## 📦 Packages Used

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Sqlite


