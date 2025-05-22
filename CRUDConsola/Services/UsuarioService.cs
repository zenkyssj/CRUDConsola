using CRUDConsola.Core;
using CRUDConsola.Data;
using CRUDConsola.Models;
using CRUDConsola.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CRUDConsola.Services
{
    class UsuarioService
    {
        public static void CreateUser()
        {
            int id = 0; 
            string nombre = string.Empty; 
            string apellido = string.Empty; 
            string email = string.Empty; 
            int edad = 0; 

            try
            {
                do
                {
                    Console.WriteLine("Ingrese el nombre del usuario:");
                    nombre = Console.ReadLine() ?? string.Empty; // Fix: Use null-coalescing operator to ensure a non-null value  

                    Console.WriteLine("Ingrese el apellido del usuario:");
                    apellido = Console.ReadLine() ?? string.Empty; // Fix: Use null-coalescing operator to ensure a non-null value

                } while (!Validador.ValidarNombreApellido(nombre, apellido));


                do
                {
                    Console.WriteLine("Ingrese el email del usuario:");
                    email = Console.ReadLine() ?? string.Empty; // Fix: Use null-coalescing operator to ensure a non-null value
                } while (!Validador.ValidarEmail(email));

                do
                {
                    Console.WriteLine("Ingrese la edad del usuario:");
                    edad = int.Parse(Console.ReadLine() ?? "0"); // Fix: Use null-coalescing operator to ensure a non-null value
                } while (!Validador.ValidarEdad(edad));

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            
            id = UsuarioStorage.GetNextUserID(); 

            Usuario newUser = new Usuario(id: id, nombre: nombre, apellido: apellido, email: email, edad: edad, fechaRegistro: DateTime.Now);
            UsuarioStorage.AddUser(newUser); 

        }

        public static void ReadUsers()
        {
            int opcion = 0;

            UsuarioStorage.MostrarUsuariosGuardados();

            do
            {
                Console.WriteLine("\n\t¿Desea buscar por ID o Email?");
                Console.WriteLine("1) ID\n2) Email\n3) Salir");
                opcion = int.Parse(Console.ReadLine() ?? "0"); // Fix: Use null-coalescing operator to ensure a non-null value

                switch (opcion)
                {
                    case 1:
                        BuscarUsuario.BuscarPorID();
                        break;

                    case 2:
                        BuscarUsuario.BuscarPorEmail();
                        break;

                    case 3:
                        Program.MostrarMenu();
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (true);



        }

        public static void UpdateUser()
        {
            
        }

        public static void DeleteUser()
        {
            // Implementar la lógica para eliminar un usuario
        }


    }
}
