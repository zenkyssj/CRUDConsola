using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Core.Models;

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

            string folder = "Data";
            string filePath = Path.Combine(folder, "usuarios.json");

            try
            {
                Directory.CreateDirectory(folder);

                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }
                using (StreamWriter sw = new StreamWriter(filePath, true))
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

        public void MostrarUsuariosGuardados()
        {
            string folder = "Data";
            string filePath = Path.Combine(folder, "usuarios.json");

            if (File.Exists(filePath))
            {
                Console.WriteLine("\n\n\tUsuarios guardados:\n");

                var lineas = File.ReadAllLines(filePath);

                foreach (var linea in lineas)
                {
                    if (!string.IsNullOrEmpty(linea))
                    {
                        try
                        {
                            Usuario? usuario = JsonSerializer.Deserialize<Usuario>(linea);
                            if (usuario != null) 
                            {
                                Console.WriteLine($"ID: {usuario.Id} ");
                                Console.WriteLine($"Nombre: {usuario.Nombre} ");
                                Console.WriteLine($"Apellido: {usuario.Apellido} ");
                                Console.WriteLine($"Email: {usuario.Email} ");
                                Console.WriteLine($"Edad: {usuario.Edad} ");
                                Console.WriteLine($"Fecha de Registro: {usuario.FechaRegistro} ");
                                Console.WriteLine(new string('-', 30));
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error al deserializar el usuario: {e.Message}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No hay usuarios guardados.");
                Console.WriteLine("Pulse cualquier tecla para continuar...");
                Console.ReadKey();
                
            }
        }
        public Usuario? BuscarUsuarioPorId(int id)
        {
            string folder = "Data";
            string filePath = Path.Combine(folder, "usuarios.json");

            if (File.Exists(filePath))
            {
                var lineas = File.ReadAllLines(filePath);

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
            string folder = "Data";
            string filePath = Path.Combine(folder, "usuarios.json");

            if (File.Exists(filePath))
            {
                var lineas = File.ReadAllLines(filePath);
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
            string folder = "Data";
            string filePath = Path.Combine(folder, "usuarios.json");

            if (File.Exists(filePath))
            {
                var lineas = File.ReadAllLines(filePath);

                foreach (var linea in lineas)
                {
                    if (!string.IsNullOrEmpty(linea))
                    {
                        try
                        {
                            Usuario usuario = JsonSerializer.Deserialize<Usuario>(linea);
                            if (usuario != null && usuario.Id > maxId)
                            {
                                maxId = usuario.Id;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error al deserializar el usuario: {e.Message}");
                        }
                    }
                }
            }

            return maxId + 1;
        }

        public List<Usuario> GetUsers()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string folder = "Data";
            string filePath = Path.Combine(folder, "usuarios.json");
            if (File.Exists(filePath))
            {
                var lineas = File.ReadAllLines(filePath);
                foreach (var linea in lineas)
                {
                    if (!string.IsNullOrEmpty(linea))
                    {
                        try
                        {
                            Usuario? usuario = JsonSerializer.Deserialize<Usuario>(linea);
                            if (usuario != null)
                            {
                                usuarios.Add(usuario);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error al deserializar el usuario: {e.Message}");
                        }
                    }
                }
            }
            return usuarios;
        }

        public void DeleteUser(int id)
        {
            string folder = "Data";
            string filePath = Path.Combine(folder, "usuarios.json");
            if (File.Exists(filePath))
            {
                var lineas = File.ReadAllLines(filePath).ToList();
                bool userFound = false;
                for (int i = 0; i < lineas.Count; i++)
                {
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
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error al deserializar el usuario: {e.Message}");
                        }
                    }
                }
                if (userFound)
                {
                    File.WriteAllLines(filePath, lineas);
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
