using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudioEA.UI.Registros;
using StudioEA.Entidades;
using StudioEA.BLL;
using StudioEA.UI.Menu;

namespace StudioEA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Usuarios> Lista = new List<Usuarios>();
        public static int UsuarioId;

        public MainWindow()
        {
            InitializeComponent();
            RUsuarios ru = new RUsuarios();
            RClientes rc = new RClientes();

            rc.Show();
            ru.Show();
        }


        private void IngresarButton_Click_1(object sender, RoutedEventArgs e)
        {
            VentanaPrincipal VentanaP = new VentanaPrincipal();

            Lista = UsuariosBLL.GetList(p => true);
            bool paso = false;
            foreach (var item in Lista)
            {
                if ((item.NombreUsuario == UsuarioTextBox.Text) && (item.Contrasena == ContrasenaBox.Password))
                {
                    UsuarioId = item.UsuarioId;
                    VentanaP.Show();
                    paso = true;
                    this.Close();
                    break;
                }
            }
            if (paso == false)
            {
                MessageBox.Show("Nombre de usuario o Contraseña incorrecto", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                UsuarioTextBox.Text = string.Empty;
                ContrasenaBox.Password = string.Empty;
                UsuarioTextBox.Focus();
            }
        }
    }
}
