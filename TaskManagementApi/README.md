# Task Management API

This project is a Task Management API developed with ASP.NET Core.

## Prerequisites

Before you run the project, ensure you have the following installed:
- .NET 8 or higher
- Visual Studio Code

## Setup

1. Clone the repository:
    ```bash
    git clone https://github.com/altabs/TaskManagementAPI.git
    cd TaskManagementAPI
    ```

2. Restore dependencies:
    ```bash
    dotnet restore
    ```

3. Run the project:
    ```bash
    dotnet run
    ```

    The API will start on `https://localhost:{port}`.

## Seed Data

The application automatically seeds the database with some initial users and tasks for testing.  
If you'd like to reset the data, simply stop and restart the application (the in-memory database will reset).

## API Endpoints

### Auth

- `POST /api/Auth/login` — Logs in a user and returns an auth token.

### Tasks

- `POST /api/Tasks` — Creates a new task. Requires `title`, `description`, and `userId`.
- `GET /api/Tasks/{id}` — Retrieves a task by its ID.
- `GET /api/Tasks/user/{userId}` — Retrieves all tasks assigned to a specific user.

## Testing the API

- **Swagger UI**: Navigate to `https://localhost:{port}/swagger` for interactive testing.
---

---
# Database Design Basics
 
## Database Design Basics filepath
    Database Design are located in the `Database Design` folder.

### SQL Queries
- **SQL UI** `https://onecompiler.com/mysql/43g2xxwdt`
    
### Get all tasks assigned to a user
    SELECT * 
    FROM tasks
    WHERE user_id = 2;

### Get all comments on a task
    SELECT * 
    FROM task_comments
    WHERE task_id = 1;
---

---
# Debugging & Code Fixing
The fix and explanation are located in the `Services\TaskService.cs` project

### Explanation of Changes:
Explanation of Changes:

1. Changed method return types to be properly asynchronous:

   1.1 Task<TaskItem?> for getting a single task.

   1.2 Task<List<TaskItem>> for getting all tasks.

2 Added await keywords when calling async Entity Framework methods (FirstOrDefaultAsync, ToListAsync).

3 Updated DbContext to the correct custom AppDbContext for better typing.

4. Wrapped database calls in try-catch blocks to provide basic error handling and logging in case of runtime issues.
---

---
# Docker
I didn't include the docker

---
# Creating Unit Test

## Running Unit Tests
Unit tests are located in the `TaskManagementApi.Tests` project.

### To run the tests:
cd TaskManagementApi.Tests
dotnet test 