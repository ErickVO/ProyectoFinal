using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudioEA.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public String NombreUsuario { get; set; }
        public String Contrasena { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;
            NombreUsuario = string.Empty;
            Contrasena = string.Empty;
        }
    }
}
