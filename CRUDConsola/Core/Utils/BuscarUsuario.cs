using CRUDConsola.Data;
using CRUDConsola.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDConsola.Core.Utils
{
    internal class BuscarUsuario
    {
        private static UserStorage _userStorage = new UserStorage();
        public static Usuario BuscarPorID(int id)
        {
            do
            {
                Console.WriteLine("Ingrese el ID del usuario:");
                id = int.Parse(Console.ReadLine() ?? "0");
            } while (!Validador.ValidarID(id));

            var usuario = _userStorage.BuscarUsuarioPorId(id);

            Console.WriteLine("Pulse cualquier tecla para continuar...");
            Console.ReadKey();

            return usuario;
        }

        public static Usuario BuscarPorEmail()
        {
            string email = string.Empty;
            do
            {
                Console.WriteLine("Ingrese el email del usuario:");
                email = Console.ReadLine() ?? string.Empty;
            } while (!Validador.ValidarEmail(email));

            var usuario = _userStorage.BuscarUsuarioPorEmail(email);
            

            Console.WriteLine("Pulse cualquier tecla para continuar...");
            Console.ReadKey();

            return usuario;
        }
    }
}
