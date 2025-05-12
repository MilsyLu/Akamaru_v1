using DAL;
using Entity;


namespace BLL
{
    public class ServiciosMunicipio : IServicios<Municipio>
    {
        private readonly RepositorioMunicipios repoMuni;

        public ServiciosMunicipio()
        {
            repoMuni = new RepositorioMunicipios(RutasDeArchivos.RUTA_MUNICIPIOS);
        }

        public List<Municipio> Readee()
        {
            return repoMuni.Readee();
        }

        public string Createe(Municipio entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... la especie no puede ser nula");
                }

                return repoMuni.Createe(entity);
            }
            catch (Exception ex)
            {
                return $"Error al guardar especie: {ex.Message}";
            }
        }

        public string Updatee(Municipio entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException("Error... la especie no puede ser nula");
                }

                return repoMuni.Updatee(entity);
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

                return repoMuni.Deletee(id);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar especie: {ex.Message}";
            }
        }
    }
}
