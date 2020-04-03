using StudioEA.UI.Consultas;
using StudioEA.UI.Registros;
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

namespace StudioEA.UI.Menu
{
    /// <summary>
    /// Interaction logic for VentanaPrincipal.xaml
    /// </summary>
    public partial class VentanaPrincipal : Window
    {
        public VentanaPrincipal()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            RUsuarios ru = new RUsuarios();
            ru.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            RClientes rc = new RClientes();
            rc.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            RFotografos rf = new RFotografos();
            rf.Show();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            RegistroCategorias rc = new RegistroCategorias();
            rc.Show();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            RegistroArticulos ra = new RegistroArticulos();
            ra.Show();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            RegistroEventos re = new RegistroEventos();
            re.Show();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            RegistroCompras rc = new RegistroCompras();
            rc.Show();
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            RVentas rv = new RVentas();
            rv.Show();
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            cUsuarios cu = new cUsuarios();
            cu.Show();
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            cClientes cc = new cClientes();
            cc.Show();
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            cFotografos cf = new cFotografos();
            cf.Show();
        }

        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
            ConsultaCategorias cc = new ConsultaCategorias();
            cc.Show();
        }

        private void MenuItem_Click_12(object sender, RoutedEventArgs e)
        {
            ConsultaArticulos ca = new ConsultaArticulos();
            ca.Show();
        }

        private void MenuItem_Click_13(object sender, RoutedEventArgs e)
        {
            ConsultaEventos ce = new ConsultaEventos();
            ce.Show();
        }

        private void MenuItem_Click_14(object sender, RoutedEventArgs e)
        {
            ConsultaCompras cco = new ConsultaCompras();
            cco.Show();
        }

        private void MenuItem_Click_15(object sender, RoutedEventArgs e)
        {
            cVentas cv = new cVentas();
            cv.Show();
        }
    }
}
