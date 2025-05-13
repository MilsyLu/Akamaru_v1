using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ENTITY;

namespace DAL
{
    public class EspecieDbRepository : IRepository<Especie>
    {
        private readonly DbContext context;

        public EspecieDbRepository()
        {
            context = new DbContext();
        }

        public string Guardar(Especie especie)
        {
            using (var connection = context.CreateConnection())
            {
                var command = new SqlCommand("INSERT INTO especies (nombre) VALUES (@nombre)", connection);
                command.Parameters.AddWithValue("@nombre", especie.Nombre);

                connection.Open();
                command.ExecuteNonQuery();
                return "Especie guardada exitosamente.";
            }
        }

        public List<Especie> Consultar()
        {
            var lista = new List<Especie>();
            using (var connection = context.CreateConnection())
            {
                var command = new SqlCommand("SELECT * FROM especies", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Especie
                    {
                        Id = (int)reader["id"],
                        Nombre = reader["nombre"].ToString()
                    });
                }
            }
            return lista;
        }

        public Especie BuscarId(int id)
        {
            using (var connection = context.CreateConnection())
            {
                var command = new SqlCommand("SELECT * FROM especies WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Especie
                    {
                        Id = (int)reader["id"],
                        Nombre = reader["nombre"].ToString()
                    };
                }
            }
            return null;
        }

        public string Eliminar(int id)
        {
            using (var connection = context.CreateConnection())
            {
                var command = new SqlCommand("DELETE FROM especies WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                int filas = command.ExecuteNonQuery();

                return filas > 0 ? "Especie eliminada correctamente." : "No se encontró la especie.";
            }
        }

        public Especie BuscarPorNombre(string nombre)
        {
            using (var connection = context.CreateConnection())
            {
                var command = new SqlCommand("SELECT * FROM especies WHERE nombre = @nombre", connection);
                command.Parameters.AddWithValue("@nombre", nombre);

                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Especie
                    {
                        Id = (int)reader["id"],
                        Nombre = reader["nombre"].ToString()
                    };
                }
            }
            return null;
        }

        public string Modificar(Especie entity)
        {
            throw new NotImplementedException();
        }
    }
}
