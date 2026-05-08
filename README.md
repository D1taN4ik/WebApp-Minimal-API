# Веб-приложение ASP.NET Core Minimal API

Консольное веб-приложение на **ASP.NET Core (Minimal API)**, демонстрирующее работу с Entity Framework Core, Dependency Injection, конфигурацией через JSON и REST-эндпоинтами. Разработано в рамках практического задания по серверной разработке на .NET.

## 🚀 Технологии
- **Framework:** .NET 9 | ASP.NET Core
- **Архитектура:** Minimal API
- **ORM:** Entity Framework Core
- **База данных:** SQLite
- **DI:** Встроенный контейнер `IServiceCollection`
- **Конфигурация:** `appsettings.json` + `IConfiguration`
- **Язык:** C# 12

## 📦 Структура проекта
```
WebApp/
├── Models/
│   └── User.cs                 # Модель данных (сущность)
├── Data/
│   └── AppDbContext.cs         # Контекст EF Core
├── Services/
│   ├── IDataService.cs         # Интерфейс сервиса
│   └── DataService.cs          # Реализация сервиса
├── appsettings.json            # Конфигурация приложения
├── Program.cs                  # Точка входа и настройка DI
└── WebApp.csproj               # Файл проекта
```

## ⚙️ Установка и запуск

### 1. Требования
- [.NET 9.0](https://dotnet.microsoft.com/download)
- Git (для клонирования репозитория)
- Любой HTTP-клиент (браузер, `curl`, Thunder Client, Postman)

### 2. Инструкции
```bash
# Клонируйте репозиторий
git clone https://github.com/d1tan4ik/webapp-minimal-api.git
cd webapp

# Восстановите зависимости
dotnet restore

# Запустите приложение
dotnet run
```
> 💡 Приложение автоматически создаст файл БД `app.db` и заполнит его 3 тестовыми записями при первом запуске.

## 🔌 API Endpoints

### `GET /api/data`
Возвращает данные пользователей из БД, обработанные кастомным сервисом (сортировка по имени, преобразование регистра).
**Пример запроса:**
```bash
curl http://localhost:5197/api/data
```
**Пример ответа:**
```json
{
  "appName": "UserManagementAPI",
  "version": "1.0",
  "users": [
    { "id": 3, "name": "ALICE", "age": 29, "email": "alice@example.com" },
    { "id": 2, "name": "BOB", "age": 41, "email": "bob@example.com" },
    { "id": 1, "name": "TOM", "age": 37, "email": "tom@example.com" }
  ]
}
```

### `GET /api/config`
Возвращает пользовательские настройки из `appsettings.json`.
**Пример запроса:**
```bash
curl http://localhost:5197/api/config
```
**Пример ответа:**
```json
{
  "appName": "UserManagementAPI",
  "version": "1.0",
  "maxItems": 100
}
```

## ⚙️ Конфигурация
Настройки хранятся в `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=app.db"
  },
  "AppName": "UserManagementAPI",
  "Version": "1.0",
  "MaxItems": 100
}
```
Значения читаются через `IConfiguration` в рантайме. Строка подключения привязана к `AddDbContext<AppDbContext>()`.

## 👤 Автор
- **ФИО:** Должиков Юрий Алексеевич
- **Группа:** ББСО-01-24
