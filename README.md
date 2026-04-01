# 🛒 Shopping Cart API

## Overview

This is a minimal ASP.NET Core Web API implementing a shopping cart service.

---

## Architecture

The solution is structured into three layers:

- **ShoppingCart.Api**
  - Controllers, middleware, HTTP layer

- **ShoppingCart.Core**
  - Business logic, interfaces, models, DTOs, mappers, exceptions

- **ShoppingCart.Data**
  - EF Core, DbContext, domains, configurations, repositories, migrations

---

## Technologies

- ASP.NET Core Web API
- .NET 8
- Entity Framework Core 8.x
- SQLite

---

## 🚀 How to run

### 1. Clone the repository

```bash
git clone https://github.com/viktor-stojkovski/ShoppingCart.git
```

#### 1.1 Navigate to the solution root directory and open command prompt

### 2. Run the API

```bash
dotnet run --project ShoppingCart.Api
```

### 3. Database initialization

On application startup:

- EF Core migrations are applied automatically
- SQLite database is created (in the ShoppingCart.Api project root, only for demo purposes)
- Products dummy data is seeded using EF Core

No manual setup is required.

### 4. Open swagger API explorer

When API has started and DB migrations finished explore it on:
<http://localhost:5243/swagger/index.html>

---

## Endpoints

### Cart

- `POST /api/cart/add-item` → add item (also creates active cart for user if not exists)
- `GET /api/cart/{userId}` → get active cart
- `PUT /api/cart/item` → update item quantity
- `DELETE /api/cart/item` → remove item
- `POST /api/cart/checkout` → checkout cart

---

## Design considerations & features

- Add/update/remove cart items
- Automatic cart creation
- Cart is treated as an aggregate root
- **DDD used where appropriate** CartItems are managed through Cart (no separate repository)
- CartItems are not exposed to Products, can lead to excessive coupling if not careful
- Stock is validated on write and finalized on checkout
- **Separation of concerns & SRP** through layered architecture (API, Core, Data)
- **Dependency Injection (DI)** for services and repositories
- **Encapsulation of business logic** within the service layer (controllers remain thin)
- **DTO usage** to decouple domain entities from API contracts
- **Global error handling** via middleware
- **Transactional consistency** using EF Core transactions
- **Clean and maintainable code structure** aligned with real-world backend practices

---

## Error handling

Custom exceptions, mapped via middleware to proper HTTP responses.

---

## Health checks

Endpoint:

```
/health
```

Verifies:
- API is running
- Database connection is available
