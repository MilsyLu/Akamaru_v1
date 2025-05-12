// DAL/Archivos.cs
using System;
using System.IO;

namespace DAL
{
    public static class Archivos
    {
        public const string RUTA_DATOS = "Datos/";
        public const string ARC_PRODUCTOS = RUTA_DATOS + "productos.txt";
        public const string ARC_FACTURAS = RUTA_DATOS + "facturas.txt";
        public const string ARC_DETALLES = RUTA_DATOS + "detalles.txt";

        static Archivos()
        {
            if (!Directory.Exists(RUTA_DATOS))
            {
                Directory.CreateDirectory(RUTA_DATOS);
            }
        }
    }
}