#!/bin/bash

# Backend Setup Script for Effortly
# Run from the root directory of your project

set -e  # exit immediately if a command fails

echo "🚀 Setting up Effortly Backend..."

# Ensure backend folder exists
mkdir -p backend
cd backend

# Create solution root structure
mkdir -p src tests

# Create solution
dotnet new sln -n Effortly

# Create projects
dotnet new webapi -n Effortly.API -o src/Effortly.API --use-minimal-apis
dotnet new classlib -n Effortly.Application -o src/Effortly.Application
dotnet new classlib -n Effortly.Domain -o src/Effortly.Domain
dotnet new classlib -n Effortly.Infrastructure -o src/Effortly.Infrastructure

# Create test projects
dotnet new xunit -n Effortly.Application.Tests -o tests/Effortly.Application.Tests
dotnet new xunit -n Effortly.Domain.Tests -o tests/Effortly.Domain.Tests
dotnet new xunit -n Effortly.API.IntegrationTests -o tests/Effortly.API.IntegrationTests

# Add projects to solution
dotnet sln add src/Effortly.API/Effortly.API.csproj
dotnet sln add src/Effortly.Application/Effortly.Application.csproj
dotnet sln add src/Effortly.Domain/Effortly.Domain.csproj
dotnet sln add src/Effortly.Infrastructure/Effortly.Infrastructure.csproj
dotnet sln add tests/Effortly.Application.Tests/Effortly.Application.Tests.csproj
dotnet sln add tests/Effortly.Domain.Tests/Effortly.Domain.Tests.csproj
dotnet sln add tests/Effortly.API.IntegrationTests/Effortly.API.IntegrationTests.csproj

# Add project references (Clean Architecture rules)
dotnet add src/Effortly.API/Effortly.API.csproj reference src/Effortly.Application/Effortly.Application.csproj
dotnet add src/Effortly.API/Effortly.API.csproj reference src/Effortly.Infrastructure/Effortly.Infrastructure.csproj
dotnet add src/Effortly.Application/Effortly.Application.csproj reference src/Effortly.Domain/Effortly.Domain.csproj
dotnet add src/Effortly.Infrastructure/Effortly.Infrastructure.csproj reference src/Effortly.Domain/Effortly.Domain.csproj

# Add test project references
dotnet add tests/Effortly.Application.Tests/Effortly.Application.Tests.csproj reference src/Effortly.Application/Effortly.Application.csproj
dotnet add tests/Effortly.Domain.Tests/Effortly.Domain.Tests.csproj reference src/Effortly.Domain/Effortly.Domain.csproj
dotnet add tests/Effortly.API.IntegrationTests/Effortly.API.IntegrationTests.csproj reference src/Effortly.API/Effortly.API.csproj

# Install essential NuGet packages
echo "📦 Installing NuGet packages..."

# API packages
dotnet add src/Effortly.API package Microsoft.EntityFrameworkCore.Design
dotnet add src/Effortly.API package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add src/Effortly.API package Swashbuckle.AspNetCore
dotnet add src/Effortly.API package Serilog.AspNetCore
dotnet add src/Effortly.API package FluentValidation.AspNetCore

# Application packages
dotnet add src/Effortly.Application package MediatR
dotnet add src/Effortly.Application package MediatR.Extensions.Microsoft.DependencyInjection
dotnet add src/Effortly.Application package FluentValidation
dotnet add src/Effortly.Application package AutoMapper

# Infrastructure packages
dotnet add src/Effortly.Infrastructure package Microsoft.EntityFrameworkCore.Sqlite
dotnet add src/Effortly.Infrastructure package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add src/Effortly.Infrastructure package System.IdentityModel.Tokens.Jwt
dotnet add src/Effortly.Infrastructure package Microsoft.EntityFrameworkCore.Tools

# Test packages
dotnet add tests/Effortly.Application.Tests package Moq
dotnet add tests/Effortly.Application.Tests package FluentAssertions
dotnet add tests/Effortly.Application.Tests package coverlet.collector
dotnet add tests/Effortly.API.IntegrationTests package Microsoft.AspNetCore.Mvc.Testing
dotnet add tests/Effortly.API.IntegrationTests package Testcontainers

echo "✅ Backend setup complete!"
echo ""
echo "Next steps:"
echo "1. Review the project structure"
echo "2. Implement domain entities (Workout, Exercise, User, Stats)"
echo "3. Set up your DbContext in Infrastructure"
echo "4. Wire up MediatR and validation in Application"
echo "5. Create your first API endpoint in Effortly.API"
