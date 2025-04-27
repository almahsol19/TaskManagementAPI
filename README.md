# Task Management API

This project is a Task Management API developed with ASP.NET Core.

## Prerequisites

Before you run the project, ensure you have the following installed:
- .NET 8 or higher
-  Visual Studio Code

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

    The API will start on `https://localhost:7260`.

## Seed Data

The application automatically seeds the database with some initial users and tasks for testing. If you'd like to reset the data, you can stop the application and restart it, as the in-memory database will be cleared.

## API Endpoints

### Auth

- `POST /api/Auth/login` - Logs in a user. Returns an auth token.

### Tasks

- `POST /api/Tasks` - Creates a new task. Requires `title`, `description`, and `userId`.
- `GET /api/Tasks/{id}` - Retrieves a task by its ID.
- `GET /api/Tasks/user/{userId}` - Retrieves all tasks assigned to a specific user.

## Testing

- **Swagger UI**: Navigate to `https://localhost:7260/swagger` for interactive testing.


## Notes

- The in-memory database is used for testing. The data will be reset every time the application restarts.
- Authentication is handled using basic username/password verification.


