using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace DAL
{
    public class EspecieRepository : FileRepository<Especie>
    {
        public EspecieRepository(string ruta) : base(ruta)
        {
        }

        public override List<Especie> Consultar()
        {
            try
            {
                List<Especie> lista = new List<Especie>();

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

        public override Especie Mappear(string datos)
        {
            Especie especie = new Especie();
            especie.Id = int.Parse(datos.Split(';')[0]);
            especie.Nombre = datos.Split(';')[1];
            return especie;
        }

        public string Eliminar(int id)
        {
            try
            {
                var lista = Consultar();
                var especie = lista.FirstOrDefault(e => e.Id == id);

                if (especie == null)
                {
                    return "La especie no existe.";
                }

                lista.Remove(especie);

                using (StreamWriter sw = new StreamWriter(ruta, false))
                {
                    foreach (var item in lista)
                    {
                        sw.WriteLine($"{item.Id};{item.Nombre}");
                    }
                }

                return "Especie eliminada correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar la especie: {ex.Message}";
            }
        }

        public string Modificar(Especie especie)
        {
            try
            {
                var lista = Consultar();
                var especieExistente = lista.FirstOrDefault(e => e.Id == especie.Id);
                if (especieExistente == null)
                {
                    return "No se encontró la especie para modificar.";
                }

                especieExistente.Nombre = especie.Nombre;

                using (StreamWriter sw = new StreamWriter(ruta, false))
                {
                    foreach (var item in lista)
                    {
                        sw.WriteLine($"{item.Id};{item.Nombre}");
                    }
                }

                return "Especie modificada correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al modificar la especie: {ex.Message}";
            }
        }

    }

}
