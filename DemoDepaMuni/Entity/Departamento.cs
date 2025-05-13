using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Departamento : FormatoEntidades
    {
        public override string ToString()
        {
            return $"{id} - {nombre}";
        }
    }
}
