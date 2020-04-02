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
        public int ClienteId { get; set; }
        public String Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("VentaId")]
        public List<VentasDetalle> VentasDetalle { get; set; }

        public Ventas()
        {
            VentaId = 0;
            ClienteId = 0;
            Nombre = string.Empty;
            Fecha = DateTime.Now;
            Total = 0.0m;
            UsuarioId = 0;
            VentasDetalle = new List<VentasDetalle>();
        }

        public Ventas(int ventaId, int usuarioId, int clienteId,String nombre, DateTime fecha, decimal total, List<VentasDetalle> ventasDetalle)
        {
            VentaId = ventaId;
            UsuarioId = usuarioId;
            ClienteId = clienteId;
            Nombre = nombre;
            Fecha = fecha;
            Total = total;
            VentasDetalle = ventasDetalle;
        }
    }
}
