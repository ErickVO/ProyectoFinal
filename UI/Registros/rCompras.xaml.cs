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
    /// Interaction logic for RegistroCompras.xaml
    /// </summary>
    public partial class RegistroCompras : Window
    {
        Compras compras = new Compras();

        public RegistroCompras()
        {
            InitializeComponent();
            this.DataContext = compras;
            CompraIdTextBox.Text = "0";
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = compras;
        }

        private void Limpiar()
        {
            CompraIdTextBox.Text = "0";
            UsuarioIdTextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;
            FechaDatePicker.Text = string.Empty;
            ArticuloIdTextBox.Text = string.Empty;
            CostoTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;

            compras.ComprasDetalle = new List<ComprasDetalle>();
            compras = new Compras();
            Cargar();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Compras c = ComprasBLL.Buscar(compras.CompraId);

            return (c != null);
        }

        private bool ExisteEnLaBaseDeDatosArticulos()
        {
            Articulos a = ArticulosBLL.Buscar(Convert.ToInt32(ArticuloIdTextBox.Text));

            return a != null;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (compras.CompraId == 0)
                paso = ComprasBLL.Guardar(compras);
            else
            {
                if (ExisteEnLaBaseDeDatos() && ExisteEnLaBaseDeDatosArticulos())
                {
                    paso = ComprasBLL.Modificar(compras);
                }
                else
                {
                    MessageBox.Show("No existe en la BLL", "ERROR");
                    return;
                }
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito");
            }
            else
            {
                MessageBox.Show("No se pudo guardar...", "ERROR");
            }

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ComprasBLL.Eliminar(compras.CompraId))
            {
                MessageBox.Show("Eliminado", "EXITO");
                Limpiar();
            }
            else
                MessageBox.Show("No se pudo eliminar...", "ERROR");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Compras c = ComprasBLL.Buscar(compras.CompraId);

            if (c != null)
            {
                compras = c;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Orden no encontrada", "ERROR");

            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            compras.ComprasDetalle.Add(new ComprasDetalle(compras.CompraId, Convert.ToInt32(ArticuloIdTextBox.Text),
               Convert.ToDecimal(CantidadTextBox.Text), Convert.ToDecimal(CostoTextBox.Text)));

              ArticulosBLL.StockSuma(Convert.ToInt32(ArticuloIdTextBox.Text), Convert.ToDecimal(CantidadTextBox.Text), Convert.ToDecimal(CostoTextBox.Text));
            


            Cargar();

          
            ArticuloIdTextBox.Clear();
            CantidadTextBox.Clear();
            CostoTextBox.Clear();
            
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count > 1 && DetalleDataGrid.SelectedIndex < DetalleDataGrid.Items.Count - 1)
            {
                compras.ComprasDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }

       

        private void CantidadTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal Monto, Costo, Cantidad;
            

            decimal.TryParse(CostoTextBox.Text, out Costo);
            decimal.TryParse(CantidadTextBox.Text, out Cantidad);
          
            Monto = Costo * Cantidad;

            MontoTextBox.Text = Convert.ToString(Monto);
        }



        
    }



}
