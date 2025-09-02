#!/bin/bash

# Backend Setup Script for EffortlyFit
# Run from the root directory of your project

set -e  # exit immediately if a command fails

echo "🚀 Setting up EffortlyFit Backend..."

# Ensure backend folder exists
mkdir -p backend
cd backend

# Create solution root structure
mkdir -p src tests

# Create solution
dotnet new sln -n EffortlyFit

# Create projects
dotnet new webapi -n EffortlyFit.API -o src/EffortlyFit.API --use-minimal-apis
dotnet new classlib -n EffortlyFit.Application -o src/EffortlyFit.Application
dotnet new classlib -n EffortlyFit.Domain -o src/EffortlyFit.Domain
dotnet new classlib -n EffortlyFit.Infrastructure -o src/EffortlyFit.Infrastructure

# Create test projects
dotnet new xunit -n EffortlyFit.Application.Tests -o tests/EffortlyFit.Application.Tests
dotnet new xunit -n EffortlyFit.Domain.Tests -o tests/EffortlyFit.Domain.Tests
dotnet new xunit -n EffortlyFit.API.IntegrationTests -o tests/EffortlyFit.API.IntegrationTests

# Add projects to solution
dotnet sln add src/EffortlyFit.API/EffortlyFit.API.csproj
dotnet sln add src/EffortlyFit.Application/EffortlyFit.Application.csproj
dotnet sln add src/EffortlyFit.Domain/EffortlyFit.Domain.csproj
dotnet sln add src/EffortlyFit.Infrastructure/EffortlyFit.Infrastructure.csproj
dotnet sln add tests/EffortlyFit.Application.Tests/EffortlyFit.Application.Tests.csproj
dotnet sln add tests/EffortlyFit.Domain.Tests/EffortlyFit.Domain.Tests.csproj
dotnet sln add tests/EffortlyFit.API.IntegrationTests/EffortlyFit.API.IntegrationTests.csproj

# Add project references (Clean Architecture rules)
dotnet add src/EffortlyFit.API/EffortlyFit.API.csproj reference src/EffortlyFit.Application/EffortlyFit.Application.csproj
dotnet add src/EffortlyFit.API/EffortlyFit.API.csproj reference src/EffortlyFit.Infrastructure/EffortlyFit.Infrastructure.csproj
dotnet add src/EffortlyFit.Application/EffortlyFit.Application.csproj reference src/EffortlyFit.Domain/EffortlyFit.Domain.csproj
dotnet add src/EffortlyFit.Infrastructure/EffortlyFit.Infrastructure.csproj reference src/EffortlyFit.Domain/EffortlyFit.Domain.csproj

# Add test project references
dotnet add tests/EffortlyFit.Application.Tests/EffortlyFit.Application.Tests.csproj reference src/EffortlyFit.Application/EffortlyFit.Application.csproj
dotnet add tests/EffortlyFit.Domain.Tests/EffortlyFit.Domain.Tests.csproj reference src/EffortlyFit.Domain/EffortlyFit.Domain.csproj
dotnet add tests/EffortlyFit.API.IntegrationTests/EffortlyFit.API.IntegrationTests.csproj reference src/EffortlyFit.API/EffortlyFit.API.csproj

# Install essential NuGet packages
echo "📦 Installing NuGet packages..."

# API packages
dotnet add src/EffortlyFit.API package Microsoft.EntityFrameworkCore.Design
dotnet add src/EffortlyFit.API package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add src/EffortlyFit.API package Swashbuckle.AspNetCore
dotnet add src/EffortlyFit.API package Serilog.AspNetCore
dotnet add src/EffortlyFit.API package FluentValidation.AspNetCore

# Application packages
dotnet add src/EffortlyFit.Application package MediatR
dotnet add src/EffortlyFit.Application package MediatR.Extensions.Microsoft.DependencyInjection
dotnet add src/EffortlyFit.Application package FluentValidation
dotnet add src/EffortlyFit.Application package AutoMapper

# Infrastructure packages
dotnet add src/EffortlyFit.Infrastructure package Microsoft.EntityFrameworkCore.Sqlite
dotnet add src/EffortlyFit.Infrastructure package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add src/EffortlyFit.Infrastructure package System.IdentityModel.Tokens.Jwt
dotnet add src/EffortlyFit.Infrastructure package Microsoft.EntityFrameworkCore.Tools

# Test packages
dotnet add tests/EffortlyFit.Application.Tests package Moq
dotnet add tests/EffortlyFit.Application.Tests package FluentAssertions
dotnet add tests/EffortlyFit.Application.Tests package coverlet.collector
dotnet add tests/EffortlyFit.API.IntegrationTests package Microsoft.AspNetCore.Mvc.Testing
dotnet add tests/EffortlyFit.API.IntegrationTests package Testcontainers

echo "✅ Backend setup complete!"
echo ""
echo "Next steps:"
echo "1. Review the project structure"
echo "2. Implement domain entities (Workout, Exercise, User, Stats)"
echo "3. Set up your DbContext in Infrastructure"
echo "4. Wire up MediatR and validation in Application"
echo "5. Create your first API endpoint in EffortlyFit.API"