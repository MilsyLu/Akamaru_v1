using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    class ServiciosDepartamento : IServicios<Departamento>
    {
        private readonly RepositorioDepartamentos repoDepart;

        public ServiciosDepartamento()
        {
            repoDepart = new RepositorioDepartamentos(RutasDeArchivos.RUTA_DEPARTAMENTOS);
        }

        public List<Departamento> Readee()
        {
            return repoDepart.Readee();
        }

        public string Createe(Departamento entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... la especie no puede ser nula");
                }

                return repoDepart.Createe(entity);
            }
            catch (Exception ex)
            {
                return $"Error al guardar especie: {ex.Message}";
            }
        }

        public string Updatee(Departamento entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... la especie no puede ser nula");
                }

                return repoDepart.Updatee(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar especie: {ex.Message}";
            }
        }

        public string Deletee(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("Error... el id debe ser mayor a cero");
                }

                return repoDepart.Deletee(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar especie: {ex.Message}";
            }
        }

        //public Departamento BuscarId(int id)
        //{
        //    var especieBuscada = re().FirstOrDefault<Especie>(x => x.Id == id);
        //    return especieBuscada;
        //}
    }
}
