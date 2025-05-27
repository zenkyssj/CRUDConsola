using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDConsola.Core.Models
{
    internal class Usuario
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _email;
        private int _edad;
        private DateTime _fechaRegistro;


        public int Id { get { return _id; } private set { _id = value;} }
        public string Nombre { get { return _nombre; } private set { _nombre = value; } }
        public string Apellido { get { return _apellido; } private set { _apellido = value; } }
        public string Email { get { return _email; } private set { _email = value; } }
        public int Edad { get { return _edad; } private set { _edad = value; } }
        public DateTime FechaRegistro { get { return _fechaRegistro; } private set { _fechaRegistro = value; } }

        public Usuario(int id, string nombre, string apellido, string email, int edad, DateTime fechaRegistro)
        {
            _id = id;
            _nombre = nombre;
            _apellido = apellido;
            _email = email;
            _edad = edad;
            _fechaRegistro = fechaRegistro;

        }

        



    }
}
