using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTITY;

namespace BLL
{
    public class PropietarioService : IService<Propietario>
    {
        private readonly PropietarioRepository repoPropietario;

        public PropietarioService()
        {
            repoPropietario = new PropietarioRepository(Archivos.ARC_PROPIETARIO);
        }

        public List<Propietario> Consultar()
        {
            return repoPropietario.Consultar();
        }

        public string Guardar(Propietario entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el propietario no puede ser nulo");
                }

                if (string.IsNullOrEmpty(entity.Cedula))
                {
                    throw new ArgumentException("Error... la cédula no puede estar vacía");
                }

                if (string.IsNullOrEmpty(entity.Nombre))
                {
                    throw new ArgumentException("Error... el nombre no puede estar vacío");
                }

                return repoPropietario.Guardar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al guardar propietario: {ex.Message}";
            }
        }

        public string Modificar(Propietario entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... el propietario no puede ser nulo");
                }

                return repoPropietario.Modificar(entity);
            }
            catch (Exception ex)
            {
                return $"Error al modificar propietario: {ex.Message}";
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

                return repoPropietario.Eliminar(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar propietario: {ex.Message}";
            }
        }

        public Propietario BuscarId(int id)
        {
            var propietarioBuscado = Consultar().FirstOrDefault<Propietario>(x => x.Id == id);
            return propietarioBuscado;
        }

        public Propietario BuscarPorCedula(string cedula)
        {
            var propietarioBuscado = Consultar().FirstOrDefault<Propietario>(x => x.Cedula == cedula);
            return propietarioBuscado;
        }
    }
}