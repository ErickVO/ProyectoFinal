using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StudioEA.BLL;
using StudioEA.Entidades;

namespace StudioEA.UI.Registros
{
    /// <summary>
    /// Interaction logic for RUsuarios.xaml
    /// </summary>
    public partial class RUsuarios : Window
    {
        Usuarios usuario = new Usuarios();
        public RUsuarios()
        {
            InitializeComponent();
            this.DataContext = usuario;
            UsuarioIdTextBox.Text = "0";
            NombresTextBox.Focus();
        }

        private void Limpiar()
        {
            UsuarioIdTextBox.Text = "0";
            NombresTextBox.Text = string.Empty;
            NombreUsuarioTextBox.Text = string.Empty;
            ContrasenaTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            NombresTextBox.Focus();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool ExisteEnBaseDatos()
        {
            Usuarios usuarios = UsuariosBLL.Buscar(usuario.UsuarioId);
            return (usuarios != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (Convert.ToInt32(UsuarioIdTextBox.Text) == 0)
                paso = UsuariosBLL.Guardar(usuario);
            else
            {
                if (!ExisteEnBaseDatos())
                {
                    MessageBox.Show("No se puede modificar un usuario que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    paso = UsuariosBLL.Modificar(usuario);
                }
            }
            if (paso)
                Limpiar();

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Usuarios usuarioAnterior = UsuariosBLL.Buscar(Convert.ToInt32(UsuarioIdTextBox.Text));

            if (usuarioAnterior != null)
            {
                usuario = usuarioAnterior;
                Actualizar();
            }
            else
            {
                MessageBox.Show("Usuario no encontrado");
                Limpiar();
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuariosBLL.Eliminar(Convert.ToInt32(UsuarioIdTextBox.Text)))
            {
                MessageBox.Show("Usuario eliminado");
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se puede eliminar un usuario que no existe");
            }
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = usuario;
        }
    }
}
