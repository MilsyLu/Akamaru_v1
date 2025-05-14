using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ENTITY;

namespace DAL
{
    public class VeterinarioDbRepository : IRepository<Veterinario>
    {
        private readonly DbContext context;

        public VeterinarioDbRepository()
        {
            context = new DbContext();
        }

        public string Guardar(Veterinario veterinario)
        {
            try
            {
                using (var connection = context.CreateConnection())
                {
                    var command = new SqlCommand(
                        "INSERT INTO veterinarios (nombre, especialidad) VALUES (@nombre, @especialidad);", 
                        connection);
                    
                    command.Parameters.AddWithValue("@nombre", veterinario.Nombre);
                    command.Parameters.AddWithValue("@especialidad", veterinario.Especialidad);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    
                    return rowsAffected > 0 ? "Veterinario guardado exitosamente." 
                                           : "No se pudo guardar el veterinario.";
                }
            }
            catch (SqlException ex)
            {
                return $"Error de base de datos: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Error inesperado: {ex.Message}";
            }
        }

        public List<Veterinario> Consultar()
        {
            var lista = new List<Veterinario>();
            
            try
            {
                using (var connection = context.CreateConnection())
                {
                    var command = new SqlCommand("SELECT * FROM veterinarios", connection);
                    connection.Open();
                    
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Veterinario(
                                id: (int)reader["id"],
                                nombre: reader["nombre"].ToString(),
                                especialidad: reader["especialidad"].ToString()
                            ));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Loggear el error (opcional)
                Console.WriteLine($"Error al consultar veterinarios: {ex.Message}");
            }
            
            return lista;
        }

        public string Modificar(Veterinario veterinario)
        {
            try
            {
                using (var connection = context.CreateConnection())
                {
                    var command = new SqlCommand(
                        "UPDATE veterinarios SET nombre = @nombre, especialidad = @especialidad WHERE id = @id", 
                        connection);
                    
                    command.Parameters.AddWithValue("@nombre", veterinario.Nombre);
                    command.Parameters.AddWithValue("@especialidad", veterinario.Especialidad);
                    command.Parameters.AddWithValue("@id", veterinario.Id);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    
                    return rowsAffected > 0 ? "Veterinario modificado correctamente." 
                                           : "No se encontró el veterinario con el ID especificado.";
                }
            }
            catch (SqlException ex)
            {
                return $"Error de base de datos: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Error inesperado: {ex.Message}";
            }
        }

        public string Eliminar(int id)
        {
            try
            {
                using (var connection = context.CreateConnection())
                {
                    var command = new SqlCommand(
                        "DELETE FROM veterinarios WHERE id = @id", 
                        connection);
                    
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    
                    return rowsAffected > 0 ? "Veterinario eliminado correctamente." 
                                           : "No se encontró el veterinario con el ID especificado.";
                }
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                return "No se puede eliminar el veterinario porque tiene registros relacionados.";
            }
            catch (SqlException ex)
            {
                return $"Error de base de datos: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Error inesperado: {ex.Message}";
            }
        }
    }
}