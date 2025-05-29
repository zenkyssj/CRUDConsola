# CRUDConsola

Solucion que implementa un sistema de CRUD para usuarios utilizando tres proyectos

-**Core**: Biblioteca de clases que contiene el modelo, la capa de servicios y el manejo de almacenamiento de usuarios.
-**WebApi**: API REST desarrollada en ASP.NET Core (.NET 8) que expone endpoints para gestionar los usuarios.
-**ConsoleApp**: Aplicacion de consola (.NET 8) que permite interactuar con el sistema mediante un menu de opciones.

## Caracteristicas

- **WebApi:**
  - **POST /api/User**: Crea un usuario nuevo.
  - **GET /api/User/all**: Obtiene todos los usuarios.
  - **GET /api/User/{id}**: Obtiene un usuario especifico por su ID.
  - Validaciones basicas en campos obligatorios.
- **ConsoleApp:**
  - Menu interactivo para crear, mostrar, actualizar y eliminar usuarios.
  - Integracion directa con la capa de servicios del proyecto **Core**.
- **Core:**
  - Definicion del modelo 'Usuario'.
  - Implementacion de metodos de almacenamiento en archivo JSON.
  - Logica de negocio para gestionar usuarios.
 
## Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- C# 12.0

## Instalacion y Ejecucion

1. **Clonar el repositorio:**
   git clone https://github.com/zenkyssj/CRUDConsola/

2. **Restaurar dependencias:**

   Ejecuta el siguiente comando en la raiz de la solucion:
   dotnet restore

3. **Ejecutar los proyectos:**

   - Para iniciar la API Web:
     dotnet run --project WebApi/WebApi.csproj

   - Para ejecutar la aplicacion de consola:
     dotnet run --project ConsoleApp/ConsoleApp.csproj

## Uso

- **WebApi:**
  - Utiliza herramientas como __Postman__ o __Swagger__ (disponible con __Swashbuckle.AspNetCore__) para interactuar con los endpoints.
  - Ejemplo para crear un usuario (peticion POST a '/api/User'):
    {
      "Nombre": "Juan",
      "Apellido": "Perez",
      "Email": "juan.perez@ejemplo.com",
      "Edad": 30
    }

- **ConsoleApp:**
  -Ejecuta la aplicacoin y sigue las instrucciones en pantalla para gestionar los usuarios a traves del menú interactivo.
