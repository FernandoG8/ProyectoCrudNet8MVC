# ASP.NET Core MVC (.NET 8): BlogCore y prácticas

Proyectos que construí en 2025 siguiendo el curso *Master en ASP.NET MVC - Entity Framework* (Udemy).
El proyecto principal es **BlogCore**; el resto son prácticas enfocadas en una técnica concreta.

## BlogCore

Blog con panel de administración, organizado en capas:

| Proyecto | Responsabilidad |
|---|---|
| `BlogCore` | Aplicación web MVC: áreas `Admin` y `Cliente`, vistas Razor |
| `BlogCore.Models` | Entidades (`Articulo`, `Categoria`, `Slider`, `ApplicationUser`) y view models |
| `BlogCore.Acceso.Datos` | `DbContext`, migraciones y repositorios |
| `BlogCore.Utilidades` | Constantes compartidas (roles) |

- **Patrón Repository + Unit of Work** (`ContenedorTrabajo`) sobre **Entity Framework Core** y **SQL Server**.
- **ASP.NET Core Identity** con roles (`Administrador`, `Registrado`, `Cliente`) y controladores protegidos con `[Authorize(Roles = ...)]`.
- Subida de imágenes para artículos y sliders, listado paginado e inicialización de la base de datos con datos semilla.

## Prácticas

| Carpeta | Qué practica |
|---|---|
| `ProyectoCrudNet8MVC` | CRUD con Entity Framework Core (Code First) |
| `ProyectoCrudNet8MVCAdminLTE` | El mismo CRUD con la plantilla AdminLTE |
| `agregar_identity_Proyecto_Existente` | Agregar Identity a un proyecto ya existente |
| `IdentityScaffold` | Scaffolding de las páginas de Identity |
| `ProyectoDatabaseFirst` | Database First: modelo generado desde una base existente |
| `DropDownsMVC` | Dropdowns anidados con jQuery |
| `CrudEntityFrameworkEstaViejo` | Primera versión del CRUD, en .NET Core 3.1 |

## Cómo ejecutarlo

Requisitos: .NET 8 SDK y SQL Server (o LocalDB).

```bash
cd BlogCore/BlogCore
# Ajusta la cadena de conexión "ConexionSQL" en appsettings.json
dotnet ef database update --project ../BlogCore.Acceso.Datos
dotnet run
```

**Stack:** C#, .NET 8, ASP.NET Core MVC, Entity Framework Core, SQL Server, ASP.NET Core Identity, Razor, Bootstrap.
