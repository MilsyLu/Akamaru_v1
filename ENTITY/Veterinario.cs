using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Veterinario : BaseEntity
    {
        public string Nombre { get; set; }
        public string Especialidad { get; set; }

        public Veterinario()
        {
        }

        public Veterinario(int id, string nombre, string especialidad)
        {
            Id = id;
            Nombre = nombre;
            Especialidad = especialidad;
        }

        public override string ToString()
        {
            return $"{Id};{Nombre};{Especialidad}";
        }
    }
}