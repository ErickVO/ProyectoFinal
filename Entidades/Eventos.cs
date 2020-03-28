using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudioEA.Entidades
{
   public class Eventos
    {
        [Key]
        public int EventosId { get; set; }
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Lugar { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Precio { get; set; }

        [ForeignKey("EventosId")]
        public List<VentasDetalle> VentasDetalle { get; set; }

        public Eventos()
        {
            EventosId = 0;
            UsuarioId = 0;
            Nombre = string.Empty;
            Lugar = string.Empty;
            FechaInicio = DateTime.Now;
            FechaFin = DateTime.Now;
            Precio = 0;

            VentasDetalle = new List<VentasDetalle>();
        }
    }
}
