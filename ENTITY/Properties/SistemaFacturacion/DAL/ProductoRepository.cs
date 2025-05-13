// DAL/ProductoRepository.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ENTITY;

namespace DAL
{
    public class ProductoRepository
    {
        private readonly string rutaArchivo;

        public ProductoRepository(string rutaArchivo)
        {
            this.rutaArchivo = rutaArchivo;
            //if (!File.Exists(rutaArchivo))
            //{
            //    File.Create(rutaArchivo).Close();
            //}
        }

        public string Guardar(Producto producto)
        {
            try
            {
                // Verificar si ya existe un producto con la misma referencia
                var productos = Consultar();
                if (productos.Any(p => p.Referencia == producto.Referencia))
                {
                    return $"Error: Ya existe un producto con la referencia {producto.Referencia}";
                }

                using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
                {
                    writer.WriteLine(producto.ToString());
                }
                return "Producto guardado exitosamente";
            }
            catch (Exception ex)
            {
                return $"Error al guardar el producto: {ex.Message}";
            }
        }

        public List<Producto> Consultar()
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                if (File.Exists(rutaArchivo))
                {
                    using (StreamReader reader = new StreamReader(rutaArchivo))
                    {
                        string linea;
                        while ((linea = reader.ReadLine()) != null)
                        {
                            if (!string.IsNullOrEmpty(linea))
                            {
                                productos.Add(MapearProducto(linea));
                            }
                        }
                    }
                }
                return productos;
            }
            catch (Exception)
            {
                return productos;
            }
        }

        public string Modificar(Producto producto)
        {
            try
            {
                var productos = Consultar();
                var productoExistente = productos.FirstOrDefault(p => p.Referencia == producto.Referencia);

                if (productoExistente == null)
                {
                    return $"Error: No existe un producto con la referencia {producto.Referencia}";
                }

                // Eliminar el producto existente y agregar el modificado
                productos.Remove(productoExistente);
                productos.Add(producto);

                // Reescribir el archivo
                using (StreamWriter writer = new StreamWriter(rutaArchivo, false))
                {
                    foreach (var p in productos)
                    {
                        writer.WriteLine(p.ToString());
                    }
                }
                return "Producto modificado exitosamente";
            }
            catch (Exception ex)
            {
                return $"Error al modificar el producto: {ex.Message}";
            }
        }

        private Producto MapearProducto(string linea)
        {
            string[] datos = linea.Split(';');
            return new Producto
            {
                Referencia = datos[0],
                Nombre = datos[1],
                Existencias = int.Parse(datos[2]),
                StockMinimo = int.Parse(datos[3]),
                PrecioUnitario = decimal.Parse(datos[4]),
                Estado = datos[5]
            };
        }
    }
}