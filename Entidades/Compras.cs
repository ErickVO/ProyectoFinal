using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudioEA.Entidades
{
    public class Compras
    {
        [Key]
        public int ComprasId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("ComprasId")]
        public List<ComprasDetalle> ComprasDetalle { get; set; }

        public Compras()
        {
            ComprasId = 0;
            UsuarioId = 0;
            Fecha = DateTime.Now;
        }
    }
}
