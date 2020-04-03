using StudioEA.BLL;
using StudioEA.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudioEA.UI.Consultas
{
    /// <summary>
    /// Interaction logic for ConsultaCompras.xaml
    /// </summary>
    public partial class ConsultaCompras : Window
    {
        public ConsultaCompras()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var Listado = new List<Compras>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://Todo
                        Listado = ComprasBLL.GetList(s => true);
                        break;
                    case 1:
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = ComprasBLL.GetList(c => c.CompraId == id);
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
                            Listado = ComprasBLL.GetList(c => c.UsuarioId == id);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un ID valido");
                        }
                        break;
                    case 3:
                        try
                        {
                            decimal monto = Convert.ToDecimal(CriterioTextBox.Text);
                            Listado = ComprasBLL.GetList(c => c.Monto == monto);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un Critero valido");
                        }
                        break;
               
                }

                if (DesdeDatePicker.SelectedDate != null && HastaDatePicker.SelectedDate != null)
                    Listado = Listado.Where(c => c.Fecha.Date >= DesdeDatePicker.SelectedDate.Value && c.Fecha.Date <= HastaDatePicker.SelectedDate.Value).ToList();

            }


            else
            {
                Listado = ComprasBLL.GetList(c => true);
            }

            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = Listado;
        }
    }
    }
