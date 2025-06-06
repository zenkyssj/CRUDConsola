# CRUDConsola

Solucion que implementa un sistema de CRUD para usuarios utilizando tres proyectos

- **Core**:
  - Biblioteca de clases que contiene el modelo, DTOs, patron Repository, la capa de servicios y el manejo de almacenamiento de usuarios.
  - Incorpora el mapeo de objetos con _AutoMaper_.
  - Define la logica de validacion en los servicios.
    
- **WebApi**:
  - API REST desarrollada en ASP.NET Core (.NET 8) que expone endpoints para gestionar los usuarios.
  - Configura Entity Framework Core para trabajar con SQL Server.
  - Integra Swagger para la documentacion de la API.
    
- **ConsoleApp**:
  - Aplicacion de consola (.NET 8) que permite interactuar con el sistema mediante un menu de opciones.
  - Consumo de la capa de servicios para gestionar usuarios.

## Caracteristicas

- **WebApi:**
  - **POST /api/User**: Crea un usuario nuevo.
  - **GET /api/User/all**: Obtiene todos los usuarios.
  - **GET /api/User/{id}**: Obtiene un usuario especifico por su ID.
  - **PUT /api/User/{id}**: Actualiza la informacion de un usuario.
  - **DELETE /api/User/{id}**: Elimina un usuario.
  - Validaciones basicas en campos obligatorios.
- **ConsoleApp:**
  - Menu interactivo para crear, mostrar, actualizar y eliminar usuarios.
  - Integracion directa con la capa de servicios del proyecto **Core**.
- **Core:**
  - Modelo 'User' y DTOs ('UserDto', 'UserInsertDto', 'UserUpdateDto').
  - Servicio 'UserService' que implementa el patron Repository y el contrato definido en 'ICommonService'.
  - Validaciones para evitar duplicidad de emails.
  - Configuracion de _AutoMapper_ a traves de perfiles de mapeo.
 
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

   - **Para iniciar la API Web**:
     dotnet run --project WebApi/WebApi.csproj

   - **Para ejecutar la aplicacion de consola**:
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

## Configuracoin Adicional

- **Entity Framework Core:**
  Asegurate de tener configurado el _connection string_ en el archivo 'appsettings.json' de **Webpi** bajo la clave '"UserConnection"'.
