// BLL/FacturaService.cs
using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using ENTITY;

namespace BLL
{
    public class FacturaService : IService<Factura>
    {
        private readonly FacturaRepository repoFactura;
        private readonly ProductoService productoService;

        public FacturaService()
        {
            repoFactura = new FacturaRepository(Archivos.ARC_FACTURAS, Archivos.ARC_DETALLES);
            productoService = new ProductoService();
        }

        public string Guardar(Factura factura)
        {
            try
            {
                // Validar fecha de factura
                var facturas = repoFactura.ConsultarFacturas();
                if (facturas.Any())
                {
                    var ultimaFactura = facturas.OrderByDescending(f => f.FechaFactura).First();
                    if (factura.FechaFactura < ultimaFactura.FechaFactura)
                    {
                        return $"Error: La fecha de la factura debe ser igual o posterior a {ultimaFactura.FechaFactura:dd/MM/yyyy}";
                    }
                }

                // Calcular valor total
                factura.CalcularValorTotal();

                // Actualizar existencias de productos
                foreach (var detalle in factura.Detalles)
                {
                    var producto = productoService.BuscarPorReferencia(detalle.ReferenciaProducto);
                    if (producto != null)
                    {
                        producto.Existencias -= detalle.Cantidad;
                        productoService.Modificar(producto);
                    }
                }

                return repoFactura.Guardar(factura);
            }
            catch (Exception ex)
            {
                return $"Error al guardar factura: {ex.Message}";
            }
        }

        public string Modificar(Factura factura)
        {
            throw new NotImplementedException("La modificación de facturas no está implementada");
        }

        public List<Factura> Consultar()
        {
            return repoFactura.ConsultarFacturas();
        }

        public List<Factura> ConsultarConDetalles()
        {
            return repoFactura.ConsultarFacturasConDetalles();
        }

        public int ObtenerSiguienteIdFactura()
        {
            var facturas = repoFactura.ConsultarFacturas();
            if (!facturas.Any())
                return 1;

            return facturas.Max(f => f.IdFactura) + 1;
        }

        public int ObtenerSiguienteIdDetalle()
        {
            var detalles = repoFactura.ConsultarDetalles();
            if (!detalles.Any())
                return 1;

            return detalles.Max(d => d.IdDetalle) + 1;
        }

        public string ValidarDisponibilidadProducto(string referenciaProducto, int cantidad)
        {
            var producto = productoService.BuscarPorReferencia(referenciaProducto);

            if (producto == null)
                return "Error: El producto no existe";

            if (producto.Estado.Equals("inactivo", StringComparison.OrdinalIgnoreCase))
                return "Error: El producto está inactivo";

            if (producto.Existencias < cantidad)
                return $"Error: No hay suficientes existencias. Disponible: {producto.Existencias}";

            return string.Empty;
        }
    }
}
