.PHONY: help dev-up dev-down migrate test build clean

help:
	@echo "Available commands:"
	@echo "  make dev-up      - Start development environment"
	@echo "  make dev-down    - Stop development environment"
	@echo "  make migrate     - Run database migrations"
	@echo "  make test        - Run all tests"
	@echo "  make build       - Build all projects"
	@echo "  make clean       - Clean all build artifacts"

dev-up:
	docker-compose -f docker-compose.dev.yml up -d
	@echo "Waiting for PostgreSQL to be ready..."
	@sleep 5
	@echo "Development environment is ready!"
	@echo "PostgreSQL: localhost:5432"
	@echo "Redis: localhost:6379"

dev-down:
	docker-compose -f docker-compose.dev.yml down

migrate:
	cd backend && dotnet ef database update -p src/Effortly.Infrastructure -s src/Effortly.API

test:
	cd backend && dotnet test

build:
	cd backend && dotnet build

clean:
	cd backend && dotnet clean
	find . -type d -name "bin" -exec rm -rf {} + 2>/dev/null || true
	find . -type d -name "obj" -exec rm -rf {} + 2>/dev/null || true
