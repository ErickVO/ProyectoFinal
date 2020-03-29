﻿using StudioEA.BLL;
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
    /// Interaction logic for RegistroArticulos.xaml
    /// </summary>
    public partial class RegistroArticulos : Window
    {

        Articulos articulos = new Articulos();

        public RegistroArticulos()
        {
            InitializeComponent();
            this.DataContext = articulos;
            ArticuloIdTextBox.Text = "0";
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = articulos;
        }

        private void Limpiar()
        {
            ArticuloIdTextBox.Text = "0";
            UsuarioIdTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
            CategoriasTextBox.Text = string.Empty;
            StockTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            CostoTextBox.Text = string.Empty;
            articulos.ComprasDetalle = new List<ComprasDetalle>();
            articulos = new Articulos();
            Cargar();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Articulos a = ArticulosBLL.Buscar(articulos.ArticuloId);

            return (a != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

            bool paso = false;

            if (articulos.ArticuloId == 0)
            {
                paso = ArticulosBLL.Guardar(articulos);
            }
            else
            {
                if (ExisteEnLaBaseDeDatos())
                {
                    paso = ArticulosBLL.Modificar(articulos);
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
            if (ArticulosBLL.Eliminar(articulos.ArticuloId))
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
            Articulos a = ArticulosBLL.Buscar(articulos.ArticuloId);

            if (a != null)
            {
                articulos = a;
                Cargar();
            }
            else
            {
                MessageBox.Show("No se encontro", "ERROR");
            }
        }
    }
}