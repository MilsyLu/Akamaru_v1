using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class FormatoEntidades
    {
        public string id { get; set; }
        public string nombre { get; set; }

        public abstract string ToString();
    }
}
