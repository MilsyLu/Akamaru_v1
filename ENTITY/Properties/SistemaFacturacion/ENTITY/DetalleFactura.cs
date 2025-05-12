// ENTITY/DetalleFactura.cs
using System;

namespace ENTITY
{
    public class DetalleFactura
    {
        public int IdDetalle { get; set; }
        public int IdFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public string ReferenciaProducto { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal ValorItemVendido { get; set; }

        public DetalleFactura()
        {
        }

        public DetalleFactura(int idDetalle, int idFactura, DateTime fechaFactura, string referenciaProducto,
                             string nombreProducto, int cantidad, decimal precioUnitario)
        {
            IdDetalle = idDetalle;
            IdFactura = idFactura;
            FechaFactura = fechaFactura;
            ReferenciaProducto = referenciaProducto;
            NombreProducto = nombreProducto;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            CalcularValorItemVendido();
        }

        public void CalcularValorItemVendido()
        {
            ValorItemVendido = PrecioUnitario * Cantidad;
        }

        public override string ToString()
        {
            return $"{IdDetalle};{IdFactura};{FechaFactura:dd/MM/yyyy};{ReferenciaProducto};{NombreProducto};{Cantidad};{PrecioUnitario};{ValorItemVendido}";
        }
    }
}