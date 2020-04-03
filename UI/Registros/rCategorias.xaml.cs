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
    /// Interaction logic for RegistroCategorias.xaml
    /// </summary>
    public partial class RegistroCategorias : Window
    {
        Categorias categorias = new Categorias();

        public RegistroCategorias()
        {
            InitializeComponent();
            CategoriaIdTextBox.Text = "0";
            this.DataContext = categorias;
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = categorias;
        }

        private void Limpiar()
        {
            CategoriaIdTextBox.Text = "0";
            UsuarioIdTextBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
            categorias = new Categorias();
            Cargar();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();            
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Categorias c = CategoriasBLL.Buscar(categorias.CategoriaId);

            return (c != null);
        }


        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

            bool paso = false;

            if (categorias.CategoriaId == 0)
            {
                paso = CategoriasBLL.Guardar(categorias);
            }
            else
            {
                if (ExisteEnLaBaseDeDatos())
                {
                    paso = CategoriasBLL.Modificar(categorias);
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
            if (CategoriasBLL.Eliminar(categorias.CategoriaId))
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

            Categorias c = CategoriasBLL.Buscar(categorias.CategoriaId);

            if (c != null)
            {
               categorias = c;
                Cargar();
            }
            else
            {
                MessageBox.Show("No se encontro", "ERROR");
            }
        }

        
    }
}
