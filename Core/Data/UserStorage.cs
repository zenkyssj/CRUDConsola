using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Core.Models;
using Core.Utils;

namespace Core.Data
{
    internal class UserStorage
    {

        public void AddUser(Usuario usuario)
        {
            SaveToFile(usuario);
        }

        private void SaveToFile(Usuario usuario)
        {
            string jsonUser = JsonSerializer.Serialize(usuario);


            try
            {
                Directory.CreateDirectory(Const.FOLDER);

                if (!File.Exists(Const.FILE_PATH))
                {
                    File.Create(Const.FILE_PATH).Close();
                }
                using (StreamWriter sw = new StreamWriter(Const.FILE_PATH, true))
                {
                    sw.WriteLine(jsonUser);
                }

                Console.WriteLine("Usuario guardado correctamente.");
                Console.WriteLine("Pulse cualquier tecla para continuar...");
                Console.ReadKey();
                

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al guardar el usuario: {e.Message}");
            }

        }

        public Usuario? BuscarUsuarioPorId(int id)
        {

            if (File.Exists(Const.FILE_PATH))
            {
                var lineas = File.ReadAllLines(Const.FILE_PATH);

                foreach (var linea in lineas)
                {
                    if (!string.IsNullOrEmpty(linea))
                    {
                        try
                        {
                            Usuario? usuario = JsonSerializer.Deserialize<Usuario>(linea);
                            if (usuario != null && usuario.Id == id) 
                            {
                                Console.WriteLine("\nUsuario encontrado.");
                                Console.WriteLine(new string('-', 30));
                                Console.WriteLine($"ID: {usuario.Id} ");
                                Console.WriteLine($"Nombre: {usuario.Nombre} ");
                                Console.WriteLine($"Apellido: {usuario.Apellido} ");
                                Console.WriteLine($"Email: {usuario.Email} ");
                                Console.WriteLine($"Edad: {usuario.Edad} ");
                                Console.WriteLine($"Fecha de Registro: {usuario.FechaRegistro} ");
                                Console.WriteLine(new string('-', 30));
                                return usuario;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error al deserializar el usuario: {e.Message}");
                        }
                    }
                }
            }
            return null;
        }

        public Usuario? BuscarUsuarioPorEmail(string email)
        {

            if (File.Exists(Const.FILE_PATH))
            {
                var lineas = File.ReadAllLines(Const.FILE_PATH);
                foreach (var linea in lineas)
                {
                    if (!string.IsNullOrEmpty(linea))
                    {
                        try
                        {
                            Usuario? usuario = JsonSerializer.Deserialize<Usuario>(linea);
                            if (usuario != null && usuario.Email == email)
                            {
                                Console.WriteLine("\nUsuario encontrado.");
                                Console.WriteLine(new string('-', 30));
                                Console.WriteLine($"ID: {usuario.Id} ");
                                Console.WriteLine($"Nombre: {usuario.Nombre} ");
                                Console.WriteLine($"Apellido: {usuario.Apellido} ");
                                Console.WriteLine($"Email: {usuario.Email} ");
                                Console.WriteLine($"Edad: {usuario.Edad} ");
                                Console.WriteLine($"Fecha de Registro: {usuario.FechaRegistro} ");
                                Console.WriteLine(new string('-', 30));
                                return usuario; 
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error al deserializar el usuario: {e.Message}");
                        }
                    }
                }
            }

            return null; 
        }

        

        public int GetNextUserID()
        {
            int maxId = 0;

            if (!File.Exists(Const.FILE_PATH)) return 0;
            
            var lineas = File.ReadAllLines(Const.FILE_PATH);

            foreach (var linea in lineas)
            {
                if (string.IsNullOrEmpty(linea)) return 0;
                
                try
                {
                    Usuario? usuario = JsonSerializer.Deserialize<Usuario>(linea);

                    if (usuario != null && usuario.Id > maxId) maxId = usuario.Id;

                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error al deserializar el usuario: {e.Message}");
                }
                
            }
            

            return maxId + 1;
        }

        public List<Usuario> GetUsers()
        {
            List<Usuario> usuarios = new List<Usuario>();

            if (!File.Exists(Const.FILE_PATH)) return null;
            
            var lineas = File.ReadAllLines(Const.FILE_PATH);

            foreach (var linea in lineas)
            {
                if (string.IsNullOrEmpty(linea)) return null;            
                {
                     try
                     {
                        Usuario? usuario = JsonSerializer.Deserialize<Usuario>(linea);

                        if (usuario != null) usuarios.Add(usuario);
                        
                     }
                     catch (Exception e)
                     {
                        Console.WriteLine($"Error al deserializar el usuario: {e.Message}");
                     }
                }
            }
            
            return usuarios;

            
        }

        public void DeleteUser(int id)
        {

            if (File.Exists(Const.FILE_PATH))
            {
                var lineas = File.ReadAllLines(Const.FILE_PATH).ToList();
                bool userFound = false;
                for (int i = 0; i < lineas.Count; i++)
                if (!string.IsNullOrEmpty(lineas[i]))
                    {
                        try
                        {
                            Usuario? usuario = JsonSerializer.Deserialize<Usuario>(lineas[i]);
                            if (usuario != null && usuario.Id == id)
                            {
                                lineas.RemoveAt(i);
                                userFound = true;
                                break;
                            }
                        }
                        catch (Exception e) { Console.WriteLine($"Error al deserializar el usuario: {e.Message}"); }
                    }
                if (userFound)
                {
                    File.WriteAllLines(Const.FILE_PATH, lineas);
                    Console.WriteLine("Usuario eliminado correctamente.");
                }
                else
                {
                    Console.WriteLine("Usuario no encontrado.");
                }
            }
            else
            {
                Console.WriteLine("No hay usuarios guardados.");
            }
            Console.WriteLine("Pulse cualquier tecla para continuar...");
            Console.ReadKey();
            
        
        }  
    }
}
