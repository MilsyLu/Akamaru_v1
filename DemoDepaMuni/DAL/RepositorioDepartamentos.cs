using Entity;

namespace DAL
{
    public class RepositorioDepartamentos : FormatoRepositorio<Departamento>
    {
        
        public RepositorioDepartamentos(string ruta) : base(ruta)
        {
        }

        public override List<Departamento> Readee()
        {
            try
            {
                List<Departamento> lista = new List<Departamento>();

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

        public override Departamento Mappear(string datos)
        {
            Departamento departamento = new Departamento();
            departamento.id = datos.Split(';')[0];
            departamento.nombre = datos.Split(';')[1];
            return departamento;
        }
    }
}
