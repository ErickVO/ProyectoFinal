using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudioEA.Entidades
{
    public class VentasDetalle
    {
        [Key]
        public int VentasDetalleId { get; set; }
        public int VentaId { get; set; }
        public int ArticuloId { get; set; }
        public String Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioArticulo { get; set; }
        public int EventoId { get; set; }
        public decimal PrecioEvento { get; set; }
        public decimal Monto { get; set; }

        public VentasDetalle()
        {
            VentasDetalleId = 0;
            VentaId = 0;
            ArticuloId = 0;
            Descripcion = string.Empty;
            Cantidad = 0;
            PrecioArticulo = 0;
            EventoId = 0;
            PrecioEvento = 0;
            Monto = 0;
        }

        public VentasDetalle(int ventaId, int articuloId, string descripcion, int cantidad, decimal precioArticulo, int eventoId, decimal precioEvento, decimal monto)
        {
            VentasDetalleId = 0;
            VentaId = ventaId;
            ArticuloId = articuloId;
            Descripcion = descripcion;
            Cantidad = cantidad;
            PrecioArticulo = precioArticulo;
            EventoId = eventoId;
            PrecioEvento = precioEvento;
            Monto = monto;
        }

        public VentasDetalle(int ventaId, int articuloId, string descripcion, int cantidad, decimal precioArticulo, decimal monto)
        {
            VentasDetalleId = 0;
            VentaId = ventaId;
            ArticuloId = articuloId;
            Descripcion = descripcion;
            Cantidad = cantidad;
            PrecioArticulo = precioArticulo;
            EventoId = 0;
            PrecioEvento = 0;
            Monto = monto;
        }
    }
}
