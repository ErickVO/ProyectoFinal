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
    /// Interaction logic for cFotografos.xaml
    /// </summary>
    public partial class cFotografos : Window
    {
        public cFotografos()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Fotografos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://Todo
                        listado = FotografosBLL.GetList(u => true);
                        break;
                    case 1:
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            listado = FotografosBLL.GetList(c => c.FotografoId == id);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un ID valido");
                        }
                        break;
                    case 2:
                        try
                        {

                            listado = FotografosBLL.GetList(c => c.Nombre.Contains(CriterioTextBox.Text));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un Critero valido");
                        }
                        break;
                    case 3:
                        try
                        {

                            listado = FotografosBLL.GetList(c => c.Cedula.Contains(CriterioTextBox.Text));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un Critero valido");
                        }
                        break;
                    case 4:
                        try
                        {

                            listado = FotografosBLL.GetList(c => c.Sexo.Contains(CriterioTextBox.Text));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un Critero valido");
                        }
                        break;
                }

            }
            else
            {
                listado = FotografosBLL.GetList(c => true);
            }

            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = listado;
        }
    }
}
