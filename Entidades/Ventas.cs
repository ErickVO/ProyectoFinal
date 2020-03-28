using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudioEA.Entidades
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public int FotografoId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoTotal { get; set; }

        [ForeignKey("VentaId")]
        public List<VentasDetalle> VentasDetalle { get; set; }

        public Ventas()
        {
            VentaId = 0;
            UsuarioId = 0;
            ClienteId = 0;
            FotografoId = 0;
            Fecha = DateTime.Now;
            MontoTotal = 0;
            VentasDetalle = new List<VentasDetalle>();
        }
    }
}
