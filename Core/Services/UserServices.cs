using Core.Models;
using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{

    public class UserServices : IUserServices
    {
        
        private UserStorage _userStorage = new UserStorage();

        public void CreateUser(string nombre, string apellido, string email, int edad, DateTime fechaRegistro)
        {
            int id = _userStorage.GetNextUserID();

            Usuario newUser = new Usuario(id: id, nombre: nombre, apellido: apellido, email: email, edad: edad, fechaRegistro: DateTime.Now);
            _userStorage.AddUser(newUser);
        }

        public List<Usuario> ReadUsers()
        {
            List<Usuario> usuarios = _userStorage.GetUsers();

            // Devolver el usuario en una lista  
            return usuarios;
        }

        public void UpdateUser(int id)
        {                

           
        }

        public void DeleteUser(int id)
        {
            _userStorage.DeleteUser(id);  
        }
    }
}
