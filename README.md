# CMS Microservices Case Study

This project demonstrates a Content Management System (CMS) using two microservices developed with .NET Core. The system includes the **UserService** for user management and the **ContentService** for content management, both containerized using Docker and connected to a PostgreSQL database. The microservices communicate with each other via RESTful APIs and are documented with Swagger for easy testing.

## Microservices Overview

### 1. **ContentService** (Port: 8080)
Handles the management of content, including adding, updating, deleting, and retrieving content details.

#### API Endpoints:
- **GET /contents** – List all contents
- **POST /contents** – Add a new content
- **GET /contents/{id}** – Get content details by ID
- **PUT /contents/{id}** – Update content by ID
- **DELETE /contents/{id}** – Delete content by ID

### 2. **UserService** (Port: 8081)
Manages user information, allowing for user creation, updates, deletion, and retrieval of user details.

#### API Endpoints:
- **GET /users** – List all users
- **POST /users** – Add a new user
- **GET /users/{id}** – Get user details by ID
- **PUT /users/{id}** – Update user by ID
- **DELETE /users/{id}** – Delete user by ID

## Development Setup

### Prerequisites:
- [Docker](https://www.docker.com/products/docker-desktop)

### Running the Services:
1. Clone this repository:
   ```bash
   git clone https://github.com/tyfndmrl/Merzigo.git
   cd cms-microservices
   ```

2. **Docker Setup**:
   Both microservices are containerized using Docker. You can start both services using Docker Compose.

   Run the following command to build and start the services:
   ```bash
   docker-compose up --build
   ```

   This will start:
   - **ContentService** on `http://localhost:8080`
   - **UserService** on `http://localhost:8081`

3. **Swagger Documentation**:
   - **ContentService** Swagger: `http://localhost:8080/swagger`
   - **UserService** Swagger: `http://localhost:8081/swagger`

   These URLs provide interactive documentation and allow you to test the APIs directly from the browser.

### PostgreSQL Configuration:
Each microservice uses a PostgreSQL database. The database connection settings can be configured in the respective `appsettings.json` files.
