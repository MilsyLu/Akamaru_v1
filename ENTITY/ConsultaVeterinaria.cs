using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class ConsultaVeterinaria : BaseEntity
    {
        public DateTime Fecha { get; set; }
        public Mascota Mascota { get;  set; }
        public Veterinario Veterinario { get;  set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }

        public ConsultaVeterinaria()
        {
        }

        public void AsignarMascota(Mascota mascota)
        {
            if (Mascota == null)
            {
                Mascota = mascota;
            }
        }

        public void AsignarVeterinario(Veterinario veterinario)
        {
            if (Veterinario == null)
            {
                Veterinario = veterinario;
            }
        }

        public override string ToString()
        {
            return $"{Id};{Fecha.ToString("yyyy-MM-dd")};{Mascota.Id};{Veterinario.Id};{Diagnostico};{Tratamiento}";
        }
    }
}