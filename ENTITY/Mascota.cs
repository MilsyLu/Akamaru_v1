using System;

namespace ENTITY
{
    public class Mascota : NamedEntity
    {
        public Propietario propietario { get; set; }
        public Raza raza { get; set; }
        public int Edad { get; set; }

        public Mascota()
        {
            // Inicializamos las propiedades para evitar valores nulos.
            propietario = null;
            raza = null;
        }

        public void AsignarPropietario(Propietario propietario)
        {
            // Solo asignamos si propietario es null
            if (this.propietario == null)
            {
                this.propietario = propietario;
            }
        }

        public void AsignarRaza(Raza raza)
        {
            // Solo asignamos si raza es null
            if (this.raza == null)
            {
                this.raza = raza;
            }
        }

        public override string ToString()
        {
            return $"{Id};{Nombre};{Edad};{raza?.Id};{propietario?.Id}";
        }
    }
}
