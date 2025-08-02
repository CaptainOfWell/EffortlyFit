# Contributing to Effortly

Thanks for your interest in contributing to **Effortly**!

This is a personal learning project meant to grow into a usable open-source fitness app. Beginners, students, and experienced developers are all welcome.

---

## ✨ Ways to Contribute

* **Code**: Help implement features or fix bugs
* **Documentation**: Improve setup instructions and guides
* **Testing**: Try the app and report issues
* **Ideas**: Discuss features in issues/discussions

---

## 🚀 Quick Start

1. **Create an Issue First** - Discuss your changes before coding
2. **Fork & Clone** the repository
3. **Create a Branch** - Use format: `type/issue-number-description`
4. **Make Changes** - Follow our simple guidelines below
5. **Submit PR** - Link to your issue and describe changes

---

## 📋 Development Setup

### Prerequisites
* **.NET 9 SDK** and **Flutter SDK**
* **Docker** (optional)

### Setup
```bash
# Backend
cd backend
cp .env.example .env
dotnet run

# Frontend
cd frontend/effortly_flutter
cp .env.example .env
flutter run
```

---

## 🌿 Branch & Commit Guidelines

### Branch Names
Start with a prefix and followed with the issue's number with a short description.

Here's how to think about the different prefixes:

| Prefix    | Description or example                                                                                         |
|-----------|----------------------------------------------------------------------------------------------------------------|
| feature/  | New functionality that users interact with (like adding AI workout generation)                                 |
| bugfix/   | Fixing broken functionality (like fixing a calendar sync crash)                                                |
| chore/    | Project maintenance, tooling, infrastructure (like adding templates, updating dependencies, configuring CI/CD) |
| docs/     | Pure documentation updates (like updating README or API docs)                                                  |
| refactor/ | Code changes that don't alter functionality (like reorganizing code structure)                                 |

Examples of a branch name:
- `feature/123-workout-generator`
- `bugfix/456-sync-crash`
- `docs/789-setup-guide`

---

## 🧪 Testing

- **Backend**: `dotnet test`
- **Frontend**: `flutter test`
- Test on multiple platforms when possible (Android, iOS, Web)

---

## 🔄 Pull Request Process

1. **Link to Issue**: Use `Closes #issue-number`
2. **Describe Changes**: What and why
3. **Self-Review**: Check your code first
4. **Be Patient**: Reviews take time on this learning project

---

## 🔐 Code Style

- Follow standard C#/Dart conventions
- Keep code readable and well-commented
- Avoid hardcoded values
- Handle errors appropriately

---

## 🆘 Getting Help

- **Questions**: Create an issue or discussion
- **Bugs**: Use GitHub Issues with reproduction steps
- Check existing [issues](https://github.com/CaptainOfWell/EffortlyFit/issues?q=is%3Aissue) first!

Don't hesitate to ask questions - this is a learning project for everyone.

---

## 🙏 Thanks

Contributors are recognized in README and release notes. Whether you're fixing a typo or building a feature, your input helps make Effortly better!

— The Effortly Maintainer