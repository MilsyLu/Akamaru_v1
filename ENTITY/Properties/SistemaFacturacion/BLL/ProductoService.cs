// BLL/ProductoService.cs
using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using ENTITY;

namespace BLL
{
    public class ProductoService : IService<Producto>
    {
        private readonly ProductoRepository repoProducto;

        public ProductoService()
        {
            repoProducto = new ProductoRepository(Archivos.ARC_PRODUCTOS);
        }

        public string Guardar(Producto producto)
        {
            try
            {
                // Validaciones
                string mensajeValidacion = ValidarProducto(producto);
                if (!string.IsNullOrEmpty(mensajeValidacion))
                {
                    return mensajeValidacion;
                }

                return repoProducto.Guardar(producto);
            }
            catch (Exception ex)
            {
                return $"Error al guardar producto: {ex.Message}";
            }
        }

        public string Modificar(Producto producto)
        {
            try
            {
                // Validaciones
                string mensajeValidacion = ValidarProducto(producto);
                if (!string.IsNullOrEmpty(mensajeValidacion))
                {
                    return mensajeValidacion;
                }

                return repoProducto.Modificar(producto);
            }
            catch (Exception ex)
            {
                return $"Error al modificar producto: {ex.Message}";
            }
        }

        public List<Producto> Consultar()
        {
            return repoProducto.Consultar();
        }

        public List<Producto> ConsultarPorEstado(string estado)
        {
            return repoProducto.Consultar().Where(p => p.Estado.Equals(estado, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Producto> ConsultarPorNombre(string nombre)
        {
            return repoProducto.Consultar().Where(p => p.Nombre.Contains(nombre)).ToList();
        }

        public Producto BuscarPorReferencia(string referencia)
        {
            return repoProducto.Consultar().FirstOrDefault(p => p.Referencia == referencia);
        }

        private string ValidarProducto(Producto producto)
        {
            // Validar campos vacíos
            if (string.IsNullOrEmpty(producto.Referencia))
                return "Error: La referencia del producto no puede estar vacía";

            if (string.IsNullOrEmpty(producto.Nombre))
                return "Error: El nombre del producto no puede estar vacío";

            if (producto.Existencias < 0)
                return "Error: Las existencias deben ser un valor numérico positivo";

            if (producto.StockMinimo < 0)
                return "Error: El stock mínimo debe ser un valor numérico positivo";

            if (producto.PrecioUnitario <= 0)
                return "Error: El precio unitario debe ser un valor numérico positivo";

            if (string.IsNullOrEmpty(producto.Estado))
                return "Error: El estado del producto no puede estar vacío";

            // Validar estado
            if (!producto.Estado.Equals("activo", StringComparison.OrdinalIgnoreCase) &&
                !producto.Estado.Equals("inactivo", StringComparison.OrdinalIgnoreCase))
                return "Error: El estado del producto solo puede ser 'activo' o 'inactivo'";

            return string.Empty;
        }
    }
}