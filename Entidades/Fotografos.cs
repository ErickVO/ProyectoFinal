using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudioEA.Entidades
{
    public class Fotografos
    {
        [Key]
        public int FotografoId { get; set; }
        public int UsuarioId { get; set; }
        public String Nombre { get; set; }
        public String Cedula { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public String Celular { get; set; }
        public String Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public decimal Sueldo { get; set; }

        [ForeignKey("FotografoId")]
        public List<Ventas> Ventas { get; set; }

        public Fotografos()
        {
            FotografoId = 0;
            UsuarioId = 0;
            Nombre = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Sexo = string.Empty;
            FechaNacimiento = DateTime.Now;
            Sueldo = 0;
            Ventas = new List<Ventas>();
        }
    }
}
