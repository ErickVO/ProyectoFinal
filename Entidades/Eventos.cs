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
        public int EventoId { get; set; }
        public int UsuarioId { get; set; }
        public int FotografoId { get; set; }
        public string Descripcion { get; set; }
        public string Lugar { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Precio { get; set; }

        /*[ForeignKey("EventoId")]
        public List<VentasDetalle> VentasDetalle { get; set; }*/

        public Eventos()
        {
            EventoId = 0;
            UsuarioId = 0;
            Descripcion = string.Empty;
            Lugar = string.Empty;
            FechaInicio = DateTime.Now;
            FechaFin = DateTime.Now;
            Precio = 0;

            //VentasDetalle = new List<VentasDetalle>();
        }
    }
}
