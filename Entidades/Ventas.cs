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
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("VentaId")]
        public List<VentasDetalle> VentasDetalle { get; set; }

        public Ventas()
        {
            VentaId = 0;
            ClienteId = 0;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            Fecha = DateTime.Now;
            Total = 0.0m;
            VentasDetalle = new List<VentasDetalle>();
        }

        public Ventas(int ventaId, int clienteId, string nombre, string apellido, DateTime fecha, decimal total, List<VentasDetalle> ventasDetalle)
        {
            VentaId = ventaId;
            ClienteId = clienteId;
            Nombres = nombre;
            Apellidos = apellido;
            Fecha = fecha;
            Total = total;
            VentasDetalle = ventasDetalle;
        }
    }
}
