// ENTITY/Factura.cs
using System;
using System.Collections.Generic;

namespace ENTITY
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal ValorTotal { get; set; }
        public List<DetalleFactura> Detalles { get; set; }

        public Factura()
        {
            Detalles = new List<DetalleFactura>();
        }

        public Factura(int idFactura, DateTime fechaFactura)
        {
            IdFactura = idFactura;
            FechaFactura = fechaFactura;
            ValorTotal = 0;
            Detalles = new List<DetalleFactura>();
        }

        public void CalcularValorTotal()
        {
            ValorTotal = 0;
            foreach (var detalle in Detalles)
            {
                ValorTotal += detalle.ValorItemVendido;
            }
        }

        public override string ToString()
        {
            return $"{IdFactura};{FechaFactura:dd/MM/yyyy};{ValorTotal}";
        }
    }
}