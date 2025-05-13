using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTITY;

namespace BLL
{
    public class EspecieService : IService<Especie>
    {
        private readonly IRepository<Especie> repoEspecie;


        public EspecieService()
        {
            repoEspecie = new EspecieDbRepository();
        }

        public List<Especie> Consultar()
        {
            return repoEspecie.Consultar();
        }

        public string Guardar(Especie entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... la especie no puede ser nula");
                }

                return repoEspecie.Guardar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al guardar especie: {ex.Message}";
            }
        }

        public string Modificar(Especie entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... la especie no puede ser nula");
                }

                return repoEspecie.Modificar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar especie: {ex.Message}";
            }
        }

        public string Eliminar(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("Error... el id debe ser mayor a cero");
                }

                return repoEspecie.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar especie: {ex.Message}";
            }
        }

        public Especie BuscarId(int id)
        {
            var especieBuscada = Consultar().FirstOrDefault<Especie>(x => x.Id == id);
            return especieBuscada;
        }

        public Especie BuscarPorNombre(string nombre)
        {
            return Consultar().FirstOrDefault(e =>
                e.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

    }

}
