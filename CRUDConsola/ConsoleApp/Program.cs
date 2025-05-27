using CRUDConsola.Core.Services;
using CRUDConsola.Data;
using CRUDConsola.Core.Models;

namespace CRUDConsola.ConsoleApp
{
    public class Program
    {
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
            Console.WriteLine("4. Salir");
            Console.Write("\nSeleccione una opción: ");

            opcion = int.Parse(Console.ReadLine() ?? "0"); 

            switch (opcion)
            {
                case 1:
                    UsuarioService.CreateUser();
                    break;
                case 2:
                    UsuarioService.ReadUsers();
                    break;
                case 3:
                    UsuarioService.UpdateUser();
                    break;
                case 4:
                    Environment.Exit(0); 
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }

    }

}