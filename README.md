# ClubApp - .NET Web API with SQL Server using Docker Compose

This is a .NET 9 Web API project using Entity Framework Core and SQL Server, containerized with Docker Compose for local development.

## 📦 Requirements

- Docker & Docker Compose installed
- .NET 9 SDK (only if you want to run locally without Docker)

---

## 🚀 How to Run the Project

1. **Clone the repository** (if not already cloned):

```bash
git clone https://aclementecl@dev.azure.com/aclementecl/Club/_git/Club
cd ClubApp
```
2. **Create a .env file in the root directory using .env.example**

1. **Run Docker Compose to build and start containers**

```bash
docker compose up --build -d
```

4.	**Access the API**:
```
Open Swagger UI at: http://localhost:5175/swagger
```