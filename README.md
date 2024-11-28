# Bookstore Web API

This is a simple ASP.NET Core Web API for managing a bookstore inventory. The API allows users to perform basic CRUD (Create, Read, Update, Delete) operations on books and includes filtering, sorting, and pagination functionality.

### 1. Clone the Repository
```sh
git clone <repository-url>
cd BookstoreWebApplication
```

### 2. Run the Application
To start the application, use the following command:
```sh
dotnet run
```

Navigate to `https://localhost:5001/swagger` to access the Swagger UI and interact with the API.

### 3. API Endpoints

- **GET /api/books**: Retrieve all books, with optional filtering, sorting, and pagination.
- **GET /api/books/{id}**: Retrieve a specific book by ID.
- **POST /api/books**: Add a new book.
- **PUT /api/books/{id}**: Update an existing book by ID.
- **DELETE /api/books/{id}**: Delete a book by ID.

### Example Requests

- **Get all books, filtered by author**:
  ```
  GET /api/books?author=John
  ```

- **Get all books with pagination (page 2, 5 books per page)**:
  ```
  GET /api/books?pageNumber=2&pageSize=5
  ```
