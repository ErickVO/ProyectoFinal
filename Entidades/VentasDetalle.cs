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
        public int ClienteId { get; set; }
        public int FotografoId { get; set; }
        public int ArticuloId { get; set; }
        public int CantidadArticulo { get; set; }
        public int EventoId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public decimal MontoTotal { get; set; }

        public VentasDetalle()
        {
            VentasDetalleId = 0;
            ClienteId = 0;
            FotografoId = 0;
            ArticuloId = 0;
            CantidadArticulo = 0;
            EventoId = 0;
            Fecha = DateTime.Now;
            Monto = 0;
            MontoTotal = 0;
        }
    }
}
