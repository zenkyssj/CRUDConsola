using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Services
{
    public interface IUserServices
    {

        void CreateUser(string nombre, string apellido, string email, int edad, DateTime fechaRegistro);
        List<Usuario> ReadUsers();
        void UpdateUser(int id);
        void DeleteUser(int id);
    }
}
