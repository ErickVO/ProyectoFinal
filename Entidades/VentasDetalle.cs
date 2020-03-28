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
        public int CantidadArticulo { get; set; }
        public int EventoId { get; set; }
        public decimal Monto { get; set; }

        public VentasDetalle()
        {
            VentasDetalleId = 0;
            VentaId = 0;
            ArticuloId = 0;
            CantidadArticulo = 0;
            EventoId = 0;
            Monto = 0;
        }
    }
}
