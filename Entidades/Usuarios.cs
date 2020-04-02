using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudioEA.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public String Nombres { get; set; }
        public String NombreUsuario { get; set; }
        public String Contrasena { get; set; }
        public String Email { get; set; }


        public Usuarios()
        {
            UsuarioId = 0;
            Nombres = string.Empty;
            NombreUsuario = string.Empty;
            Contrasena = string.Empty;
            Email = string.Empty;
        }

        public Usuarios(int usuarioId, string nombres, string nombreUsuario, string contrasena, string email)
        {
            UsuarioId = usuarioId;
            Nombres = nombres;
            NombreUsuario = nombreUsuario;
            Contrasena = contrasena;
            Email = email;
        }
    }
}
