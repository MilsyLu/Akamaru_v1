using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ENTITY;

namespace DAL
{
    public class RazaDbRepository : IRepository<Raza>
    {
        private readonly DbContext context;

        public RazaDbRepository()
        {
            context = new DbContext();
        }

        public string Guardar(Raza raza)
        {
            using (var connection = context.CreateConnection())
            {
                var command = new SqlCommand("INSERT INTO razas (nombre) VALUES (@nombre)", connection);
                command.Parameters.AddWithValue("@nombre", raza.Nombre);

                connection.Open();
                command.ExecuteNonQuery();
                return "Raza guardada exitosamente.";
            }
        }

        public List<Raza> Consultar()
        {
            var lista = new List<Raza>();
            using (var connection = context.CreateConnection())
            {
                var command = new SqlCommand("SELECT * FROM razas", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Raza
                    {
                        Id = (int)reader["id"],
                        Nombre = reader["nombre"].ToString()
                    });
                }
            }
            return lista;
        }

        public Raza BuscarId(int id)
        {
            using (var connection = context.CreateConnection())
            {
                var command = new SqlCommand("SELECT * FROM razas WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Raza
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
                var command = new SqlCommand("DELETE FROM razas WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                int filas = command.ExecuteNonQuery();

                return filas > 0 ? "Raza eliminada correctamente." : "No se encontró la especie.";
            }
        }

        public Raza BuscarPorNombre(string nombre)
        {
            using (var connection = context.CreateConnection())
            {
                var command = new SqlCommand("SELECT * FROM razas WHERE nombre = @nombre", connection);
                command.Parameters.AddWithValue("@nombre", nombre);

                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Raza
                    {
                        Id = (int)reader["id"],
                        Nombre = reader["nombre"].ToString()
                    };
                }
            }
            return null;
        }

        public string Modificar(Raza entity)
        {
            throw new NotImplementedException();
        }
    }
}
