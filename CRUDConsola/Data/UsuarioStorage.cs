using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using CRUDConsola.Core.Models;
using CRUDConsola.ConsoleApp;

namespace CRUDConsola.Data
{
    internal class UsuarioStorage
    {

        public static void AddUser(Usuario usuario)
        {
            SaveToFile(usuario);
        }

        private static void SaveToFile(Usuario usuario)
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
                Program.MostrarMenu();

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al guardar el usuario: {e.Message}");
            }

        }

        public static void MostrarUsuariosGuardados()
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
                Program.MostrarMenu();
            }
        }
        public static void BuscarUsuarioPorId(int id)
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
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error al deserializar el usuario: {e.Message}");
                        }
                    }
                }
            }
        }

        public static void BuscarUsuarioPorEmail(string email)
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
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error al deserializar el usuario: {e.Message}");
                        }
                    }
                }
            }
        }

        

        public static int GetNextUserID()
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


    }
}
