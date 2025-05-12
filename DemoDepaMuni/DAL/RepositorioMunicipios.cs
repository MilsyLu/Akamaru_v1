using Entity;

namespace DAL
{
    public class RepositorioMunicipios : FormatoRepositorio<Municipio>
    {
        public RepositorioMunicipios(string ruta) : base(ruta)
        {
        }

        public override List<Municipio> Readee()
        {
            try
            {
                List<Municipio> lista = new List<Municipio>();

                if (File.Exists(ruta))
                {
                    StreamReader sr = new StreamReader(ruta);
                    while (!sr.EndOfStream)
                    {
                        lista.Add(Mappear(sr.ReadLine()));
                    }
                    sr.Close();
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override Municipio Mappear(string datos)
        {
            Municipio municipio = new Municipio();
            municipio.id = datos.Split(';')[0];
            municipio.nombre = datos.Split(';')[1];
            return municipio;
        }
    }
}
