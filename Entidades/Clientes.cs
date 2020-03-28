using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudioEA.Entidades
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public String Cedula { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public String Celular { get; set; }
        public String Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }

        [ForeignKey("ClienteId")]
        public List<Ventas> Ventas { get; set; }

        public Clientes()
        {
            ClienteId = 0;
            UsuarioId = 0;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Sexo = string.Empty;
            FechaNacimiento = DateTime.Now;
            Ventas = new List<Ventas>();
        }
    }
}
