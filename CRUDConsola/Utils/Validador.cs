using CRUDConsola.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDConsola.Utils
{
    internal class Validador
    {
        public static bool ValidarEmail(string email)
        {
            // Validar que el email contenga un '@' y un '.'
            if (email.Contains("@") && email.Contains("."))
            {
                return true;
            }
            else
            {
                Console.WriteLine("El email no es válido.\n");
                return false;
            }
        }

        public static bool ValidarEdad(int edad)
        {
            if (edad > 0 && edad < 100)
            {
                return true;
            }
            else
            {
                Console.WriteLine("La edad no es válida.");
                return false;
            }
        }

        public static bool ValidarNombreApellido(string nombre, string apellido)
        {
            // Validar que el nombre y apellido no esten vacios
            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(apellido))
            {
                return true;
            }
            else
            {
                Console.WriteLine("El nombre o apellido no son válidos.");
                return false;
            }          
        }

        public static bool ValidarID(int id)
        {
            if (id > 0 && id <= UsuarioStorage.GetNextUserID() - 1)
            {
                
                return true;
            }
            else
            {
                Console.WriteLine("ID no válido.\n");
                return false;
            }
        }
    }
}
