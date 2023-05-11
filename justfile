default:
  just --list

add-db-migration service name:
  @cd backend/BookStore.{{ service }}
  dotnet ef migrations add {{ name }} -o Database/Migrations