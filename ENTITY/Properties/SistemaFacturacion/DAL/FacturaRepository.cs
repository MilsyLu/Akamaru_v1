// DAL/FacturaRepository.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ENTITY;

namespace DAL
{
    public class FacturaRepository
    {
        private readonly string rutaArchivo;
        private readonly string rutaDetalles;

        public FacturaRepository(string rutaArchivo, string rutaDetalles)
        {
            this.rutaArchivo = rutaArchivo;
            this.rutaDetalles = rutaDetalles;

            if (!File.Exists(rutaArchivo))
            {
                File.Create(rutaArchivo).Close();
            }

            if (!File.Exists(rutaDetalles))
            {
                File.Create(rutaDetalles).Close();
            }
        }

        public string Guardar(Factura factura)
        {
            try
            {
                // Guardar la factura
                using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
                {
                    writer.WriteLine(factura.ToString());
                }

                // Guardar los detalles
                using (StreamWriter writer = new StreamWriter(rutaDetalles, true))
                {
                    foreach (var detalle in factura.Detalles)
                    {
                        writer.WriteLine(detalle.ToString());
                    }
                }

                return "Factura guardada exitosamente";
            }
            catch (Exception ex)
            {
                return $"Error al guardar la factura: {ex.Message}";
            }
        }

        public List<Factura> ConsultarFacturas()
        {
            List<Factura> facturas = new List<Factura>();
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
                                facturas.Add(MapearFactura(linea));
                            }
                        }
                    }
                }
                return facturas;
            }
            catch (Exception)
            {
                return facturas;
            }
        }

        public List<DetalleFactura> ConsultarDetalles()
        {
            List<DetalleFactura> detalles = new List<DetalleFactura>();
            try
            {
                if (File.Exists(rutaDetalles))
                {
                    using (StreamReader reader = new StreamReader(rutaDetalles))
                    {
                        string linea;
                        while ((linea = reader.ReadLine()) != null)
                        {
                            if (!string.IsNullOrEmpty(linea))
                            {
                                detalles.Add(MapearDetalle(linea));
                            }
                        }
                    }
                }
                return detalles;
            }
            catch (Exception)
            {
                return detalles;
            }
        }

        public List<Factura> ConsultarFacturasConDetalles()
        {
            var facturas = ConsultarFacturas();
            var detalles = ConsultarDetalles();

            foreach (var factura in facturas)
            {
                factura.Detalles = detalles.Where(d => d.IdFactura == factura.IdFactura).ToList();
            }

            return facturas;
        }

        private Factura MapearFactura(string linea)
        {
            string[] datos = linea.Split(';');
            return new Factura
            {
                IdFactura = int.Parse(datos[0]),
                FechaFactura = DateTime.ParseExact(datos[1], "dd/MM/yyyy", null),
                ValorTotal = decimal.Parse(datos[2])
            };
        }

        private DetalleFactura MapearDetalle(string linea)
        {
            string[] datos = linea.Split(';');
            return new DetalleFactura
            {
                IdDetalle = int.Parse(datos[0]),
                IdFactura = int.Parse(datos[1]),
                FechaFactura = DateTime.ParseExact(datos[2], "dd/MM/yyyy", null),
                ReferenciaProducto = datos[3],
                NombreProducto = datos[4],
                Cantidad = int.Parse(datos[5]),
                PrecioUnitario = decimal.Parse(datos[6]),
                ValorItemVendido = decimal.Parse(datos[7])
            };
        }
    }
}