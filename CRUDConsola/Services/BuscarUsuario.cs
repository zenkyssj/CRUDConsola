using CRUDConsola.Data;
using CRUDConsola.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDConsola.Services
{
    internal class BuscarUsuario
    {
        public static void BuscarPorID()
        {
            int id = 0;
            do
            {
                Console.WriteLine("Ingrese el ID del usuario:");
                id = int.Parse(Console.ReadLine() ?? "0"); 
            } while (!Validador.ValidarID(id));

            UsuarioStorage.BuscarUsuarioPorId(id);

            Console.WriteLine("Pulse cualquier tecla para continuar...");
            Console.ReadKey();
        }

        public static void BuscarPorEmail()
        {
            string email = string.Empty;
            do
            {
                Console.WriteLine("Ingrese el email del usuario:");
                email = Console.ReadLine() ?? string.Empty; 
            } while (!Validador.ValidarEmail(email));

            UsuarioStorage.BuscarUsuarioPorEmail(email);

            Console.WriteLine("Pulse cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
