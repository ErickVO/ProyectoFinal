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
using StudioEA.Entidades;
using StudioEA.BLL;

namespace StudioEA.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cVentas.xaml
    /// </summary>
    public partial class cVentas : Window
    {
        public cVentas()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Ventas>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://Todo
                        listado = VentasBLL.GetList(u => true);
                        break;
                    case 1:
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            listado = VentasBLL.GetList(c => c.VentaId == id);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un ID valido");
                        }
                        break;
                    case 2:
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            listado = VentasBLL.GetList(c => c.ClienteId == id);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un ID valido");
                        }
                        break;
                    
                }

            }
            else
            {
                listado = VentasBLL.GetList(c => true);
            }

            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = listado;
        }
    }
}
