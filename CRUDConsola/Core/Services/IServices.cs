using CRUDConsola.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDConsola.Core.Services
{
    internal interface IServices
    {
        void CreateUser(string nombre, string apellido, string email, int edad, DateTime fechaRegistro);
        List<Usuario> ReadUsers();
        void UpdateUser(int id);
        void DeleteUser(int id);
      
    }
}
