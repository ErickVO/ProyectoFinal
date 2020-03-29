using StudioEA.BLL;
using StudioEA.Entidades;
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

namespace StudioEA.UI.Registros
{
    /// <summary>
    /// Interaction logic for RegistroEventos.xaml
    /// </summary>
    public partial class RegistroEventos : Window
    {
        Eventos eventos = new Eventos();

        public RegistroEventos()
        {
            InitializeComponent();
            this.DataContext = eventos;
            EventoIdTextBox.Text = "0";
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = eventos;
        }

        private void Limpiar()
        {
            EventoIdTextBox.Text = "0";
            UsuarioIdTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
            LugarTextBox.Text = string.Empty;
            FechaInicioDatePicker.Text = string.Empty;
            FechaFinDatePicker.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
               
            eventos = new Eventos();
            Cargar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Eventos e = EventosBLL.Buscar(eventos.EventoId);

            return (e != null);
        }


        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (eventos.EventoId == 0)
            {
                paso = EventosBLL.Guardar(eventos);
            }
            else
            {
                if (ExisteEnLaBaseDeDatos())
                {
                    paso = EventosBLL.Modificar(eventos);
                }
                else
                {
                    MessageBox.Show("No Existe en la base de datos", "ERROR");
                    return;
                }

                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Guardado!!", "Exito");
                }
                else
                {
                    MessageBox.Show("No se pudo Guardar", "ERROR");
                }
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (EventosBLL.Eliminar(eventos.EventoId))
            {
                Limpiar();
                MessageBox.Show("Eliminado", "EXITO");
            }
            else
            {
                MessageBox.Show("No se pudo eliminar", "Error");
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Eventos ev = EventosBLL.Buscar(eventos.EventoId);

            if (ev != null)
            {
                eventos = ev;
                Cargar();
            }
            else
            {
                MessageBox.Show("No se encontro", "ERROR");
            }
        }



    }
}
