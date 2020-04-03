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

namespace StudioEA.UI.Registros
{
    /// <summary>
    /// Interaction logic for RVentas.xaml
    /// </summary>
    public partial class RVentas : Window
    {
        Ventas venta = new Ventas(); 
        
        public RVentas()
        {
            InitializeComponent();
            this.DataContext = venta;
            VentaIdTextBox.Text = "0";
            EventoIdTextBox.Text = "0";
            /*FotografoIdTextBox.Text = "0";
            UsuarioIdTextBox.Text = "0";
            CantidadTextBox.Text = "0";
            PrecioArticuloTextBox.Text = "0";
            PrecioEventoTextBox.Text = "0";*/
        }

        private void Limpiar()
        {
           /* VentaIdTextBox.Text = "0";
            EventoIdTextBox.Text = "0";
            FotografoIdTextBox.Text = "0";
            UsuarioIdTextBox.Text = "0";
            CantidadTextBox.Text = "0";
            PrecioArticuloTextBox.Text = "0";
            PrecioEventoTextBox.Text = "0";*/
            venta = new Ventas();
            Actualizar();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = venta;
        }
        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            /*if (EventoIdTextBox.Text == null || EventoIdTextBox.Text == "0")
            {
                EventoIdTextBox.Text = "0";
            }
            venta.VentasDetalle.Add(new VentasDetalle(venta.VentaId,Convert.ToInt32(ArticuloIdTextBox.Text), 
                    Convert.ToInt32(CantidadTextBox.Text),
                    Convert.ToDecimal(PrecioArticuloTextBox.Text),
                    Convert.ToInt32(EventoIdTextBox.Text),
                    Convert.ToDecimal(PrecioEventoTextBox.Text),
                    Convert.ToDecimal(MontoTextBox.Text))
             );

            venta.MontoTotal += Convert.ToDecimal(MontoTextBox.Text);
            MontoTotalTextBox.Text = Convert.ToString(venta.MontoTotal);

            Actualizar();
            ArticuloIdTextBox.Clear();
            CantidadTextBox.Clear();
            EventoIdTextBox.Clear();
            MontoTextBox.Clear();
            ArticuloIdTextBox.Focus();*/
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
          /*  if (DetalleDataGrid.Items.Count > 1 && DetalleDataGrid.SelectedIndex < DetalleDataGrid.Items.Count - 1)
            {
                venta.VentasDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);

                Actualizar();
            }*/
        }

        private bool existeEnLaBasedeDatos()
        {
            Ventas ventas = VentasBLL.Buscar(venta.VentaId);
            return (ventas != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (VentaIdTextBox.Text == "0")
                paso = VentasBLL.Guardar(venta);
            else
            {
                if (!existeEnLaBasedeDatos())
                {
                    paso = VentasBLL.Modificar(venta);
                }
                else
                {
                    MessageBox.Show("No se Puede Modificar una Venta que no existe!");
                    return;
                }
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado");
            }
            else
            {
                MessageBox.Show("La Venta no se pudo guardar");
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Ventas VentaAnterior = VentasBLL.Buscar(Convert.ToInt32(VentaIdTextBox.Text));

            if (VentaAnterior != null)
            {
                venta = VentaAnterior;
                Actualizar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Venta no encontrada");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (VentasBLL.Eliminar(venta.VentaId))
            {
                MessageBox.Show("Venta Eliminada");
                Limpiar();
            }
            else
                MessageBox.Show("No se pudo eliminar una venta que no existe");
        }

        private void LlenaCampoArticulos(Articulos articulos)
        {
           // PrecioArticuloTextBox.Text = Convert.ToString(articulos.Precio);
        }

        private void LlenaCampoEventos(Eventos eventos)
        {
           // PrecioEventoTextBox.Text = Convert.ToString(eventos.Precio);
        }

        private void ArticuloIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           /* if (!string.IsNullOrWhiteSpace(ArticuloIdTextBox.Text))
            {
                int id;
                Articulos articulo = new Articulos();
                int.TryParse(ArticuloIdTextBox.Text, out id);

                articulo = ArticulosBLL.Buscar(id);
                if (articulo != null)
                {
                    LlenaCampoArticulos(articulo);
                }
                else
                {
                    PrecioArticuloTextBox.Text = "0";
                }
            }*/
        }

        private void EventoIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           /* if (!string.IsNullOrWhiteSpace(EventoIdTextBox.Text))
            {
                int id;
                Eventos evento = new Eventos();
                int.TryParse(EventoIdTextBox.Text, out id);

                evento = EventosBLL.Buscar(id);
                if (evento != null)
                {
                    LlenaCampoEventos(evento);
                    decimal Monto, Precio = Convert.ToDecimal(PrecioEventoTextBox.Text);

                    Monto = Precio;
                    MontoTextBox.Text = Convert.ToString(Monto);
                }
                else
                {
                    PrecioEventoTextBox.Text = "0";
                }
            }*/
        }

       
        private void CantidadTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           /* if (!string.IsNullOrWhiteSpace(PrecioArticuloTextBox.Text) && !string.IsNullOrWhiteSpace(CantidadTextBox.Text))
            {
                decimal Monto, Precio = Convert.ToDecimal(PrecioArticuloTextBox.Text);
                decimal Cantidad = Convert.ToDecimal(CantidadTextBox.Text);

                Monto = Precio * Cantidad;
                MontoTextBox.Text = Convert.ToString(Monto);

            }*/
        }
    }
}
