using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class FormatoRepositorio<T> : IRepositorios<T>
    {
        protected string ruta;
        public FormatoRepositorio(string ruta)
        {
            this.ruta = ruta;
        }
        public string Createe(T entity)
        {
            try
            {
                StreamWriter sw = new StreamWriter(ruta, true);
                sw.WriteLine(entity.ToString());
                sw.Close();
                return "Agredado al archivo correctamente";
            }
            catch
            {
                return "Error al agregar al archivo";
            }
        }

        public string Updatee(T entity)
        {
            try
            {
                List<T> lista = Readee();
                File.Delete(ruta);
                foreach (var item in lista)
                {
                    if (!item.Equals(entity))
                    {
                        Createe(item);
                    }
                }
                Createe(entity);
                return "Actualizado correctamente";
            }
            catch(FileNotFoundException ex)
            {
                return $"Error al actualizar el archivo {ex.Message}";
            }
        }
        public abstract List<T> Readee();
        public abstract T Mappear(string datos);
        public string Deletee(int id)
        {
            try
            {
                List<T> lista = Readee();
                File.Delete(ruta);
                foreach (var item in lista)
                {
                    if (!GetId(item).Equals(id))
                    {
                        Createe(item);
                    }
                }
                return "Eliminado correctamente";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar: {ex.Message}";
            }
        }

        protected virtual int GetId(T entity)
        {
            var property = entity.GetType().GetProperty("Id");
            if (property != null)
            {
                return (int)property.GetValue(entity);
            }
            return 0;
        }
    }
}
