using CRUDConsola.Core.Services;
using CRUDConsola.Core.Utils;
using CRUDConsola.Data;
using CRUDConsola.Core.Models;

namespace CRUDConsola.ConsoleApp
{
    public class Program
    {
        private static UserServices _userServices = new UserServices(); // Create an instance of UserServices

        public static void Main(string[] args)
        {
            do
            {
                MostrarMenu();
                Console.Clear();
            } while (true);
        }

        public static void MostrarMenu()
        {
            Console.Clear();
            int opcion = 0;

            Console.WriteLine("\n1. Crear usuario");
            Console.WriteLine("2. Mostrar usuarios");
            Console.WriteLine("3. Actualizar usuario.");
            Console.WriteLine("4. Eliminar usuario.");
            Console.WriteLine("5. Salir");
            Console.Write("\nSeleccione una opción: ");

            opcion = int.Parse(Console.ReadLine() ?? "0");

            switch (opcion)
            {
                case 1:
                    CreateUser(); 
                    break;
                case 2:
                    ReadUsers(); 
                    break;
                case 3:
                    UpdateUser(); 
                    break;
                case 4:
                    DeleteUser();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }

        public static void CreateUser()
        {
            int id = 0;
            string nombre = string.Empty;
            string apellido = string.Empty;
            string email = string.Empty;
            int edad = 0;
            DateTime fechaRegistro = DateTime.Now;

            Console.Write("Ingrese el nombre: ");
            nombre = Console.ReadLine() ?? string.Empty;

            Console.Write("Ingrese el apellido: ");
            apellido = Console.ReadLine() ?? string.Empty;

            do
            {
                Console.Write("Ingrese el email: ");
                email = Console.ReadLine() ?? string.Empty;
            } while (!Validador.ValidarEmail(email));

            do
            {
                Console.Write("Ingrese la edad: ");
                string input = Console.ReadLine() ?? "0";
                if (int.TryParse(input, out edad) && edad > 0)
                {
                    break;
                }
                Console.WriteLine("Edad inválida. Intente de nuevo.");
            } while (true);

            _userServices.CreateUser(nombre, apellido, email, edad, fechaRegistro);
        }

        public static void ReadUsers()
        {
            List<Usuario> usuarios = _userServices.ReadUsers();
            if (usuarios.Count == 0)
            {
                Console.WriteLine("No hay usuarios registrados.");
            }
            else
            {
                Console.WriteLine("\nUsuarios registrados:");
                foreach (var usuario in usuarios)
                {
                    Console.WriteLine($"ID: {usuario.Id}, Nombre: {usuario.Nombre}, Apellido: {usuario.Apellido}, Email: {usuario.Email}, Edad: {usuario.Edad}, Fecha de Registro: {usuario.FechaRegistro}");
                }
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        public static void UpdateUser()
        {
            int id;

            do
            {
                Console.WriteLine("Ingrese el ID del usuario a actualizar: ");
                id = int.Parse(Console.ReadLine() ?? "0");

            } while (!Validador.ValidarID(id));

            Console.WriteLine("Ingrese los nuevos datos del usuario (deje en blanco para no modificar):");
            Console.Write("Nuevo nombre: ");
            string nuevoNombre = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Nuevo apellido: ");
            string nuevoApellido = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Nuevo email: ");
            string nuevoEmail;

            do
            {
                nuevoEmail = Console.ReadLine() ?? string.Empty;
            } while (!Validador.ValidarEmail(nuevoEmail));

            Console.WriteLine("Nueva edad: ");
            int nuevaEdad = int.Parse(Console.ReadLine() ?? "0");

            // TODO: Implementar la lógica para actualizar el usuario con los nuevos datos

            _userServices.UpdateUser(id);

        }

        public static void DeleteUser()
        {
            int id;
            do
            {
                Console.WriteLine("Ingrese el ID del usuario a eliminar: ");
                id = int.Parse(Console.ReadLine() ?? "0");
            } while (!Validador.ValidarID(id));
            _userServices.DeleteUser(id);

            Console.WriteLine("Usuario eliminado correctamente.");
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

}