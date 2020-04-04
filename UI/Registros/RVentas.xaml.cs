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
            PrecioETextBox.Text = "0";
            FechaDatePicker.SelectedDate = DateTime.Now;
        }

        private void Limpiar()
        {
            VentaIdTextBox.Text = "0";
            ClienteIdTextBox.Text = string.Empty;
            NombresTextBox.Text = string.Empty;
            ApellidosTextBox.Text = string.Empty;
            FechaDatePicker.SelectedDate = DateTime.Now;
            TotalTextBox.Text = string.Empty;
            ArticulosIdTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            PrecioATextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;
            EventoIdTextBox.Text = string.Empty;
            PrecioETextBox.Text = string.Empty;

            venta.VentasDetalle = new List<VentasDetalle>();
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

            if(string.IsNullOrWhiteSpace(EventoIdTextBox.Text)|| EventoIdTextBox.Text == "0")
            {
                venta.VentasDetalle.Add(new VentasDetalle(venta.VentaId, Convert.ToInt32(ArticulosIdTextBox.Text),
                DescripcionTextBox.Text, Convert.ToInt32(CantidadTextBox.Text), Convert.ToDecimal(PrecioATextBox.Text),
                Convert.ToDecimal(MontoTextBox.Text)));
            }
            else
            {
                venta.VentasDetalle.Add(new VentasDetalle(venta.VentaId, Convert.ToInt32(ArticulosIdTextBox.Text),
                DescripcionTextBox.Text, Convert.ToInt32(CantidadTextBox.Text), Convert.ToDecimal(PrecioATextBox.Text),
                Convert.ToInt32(EventoIdTextBox.Text), Convert.ToDecimal(PrecioETextBox.Text),
                Convert.ToDecimal(MontoTextBox.Text)));
            }
            
            ArticulosBLL.StockResta(Convert.ToInt32(ArticulosIdTextBox.Text), Convert.ToInt32(CantidadTextBox.Text));

            decimal total;
            decimal.TryParse(MontoTextBox.Text, out total);
            venta.Total += total;
            TotalTextBox.Text = Convert.ToString(venta.Total);

            Actualizar();

            ArticulosIdTextBox.Clear();
            DescripcionTextBox.Clear();
            CantidadTextBox.Clear();
            PrecioATextBox.Clear();
            MontoTextBox.Clear();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (VentaDetalleDataGrid.Items.Count > 1 && VentaDetalleDataGrid.SelectedIndex < VentaDetalleDataGrid.Items.Count - 1)
            {
                venta.VentasDetalle.RemoveAt(VentaDetalleDataGrid.SelectedIndex);

                Actualizar();
            }
        }

        private bool existeEnLaBasedeDatos()
        {
            Ventas ventas = VentasBLL.Buscar(Convert.ToInt32(VentaIdTextBox.Text));
            return (ventas != null);
        }

        private bool existeEnLaBasedeDatosActiculos()
        {
            Articulos articulo = ArticulosBLL.Buscar(Convert.ToInt32(ArticulosIdTextBox.Text));
            return (articulo != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (venta.VentaId == 0)
                paso = VentasBLL.Guardar(venta);
            else
            {
                if (!existeEnLaBasedeDatos() && existeEnLaBasedeDatosActiculos())
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
            Ventas VentaAnterior = VentasBLL.Buscar(venta.VentaId);

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


       
        private void CantidadTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            decimal Precio,Monto,cant;
            decimal.TryParse(PrecioATextBox.Text, out Precio);
            int Cantidad,id;
            int.TryParse(CantidadTextBox.Text, out Cantidad);
            int.TryParse(ArticulosIdTextBox.Text, out id);

            cant = ArticulosBLL.ObtenerCantidad(id);

            if (Cantidad > 0)
            {
                if(Cantidad <= cant)
                {
                    Monto = Precio * Cantidad;
                    MontoTextBox.Text = Convert.ToString(Monto);
                }
                else
                {
                    MessageBox.Show("No tiene tanta cantidad disponible");
                    CantidadTextBox.Clear();
                    MontoTextBox.Clear();
                    CantidadTextBox.Focus();
                }
                
            }
        }

        private void ClienteIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int Id;

            int.TryParse(ClienteIdTextBox.Text, out Id);

            if (Id > 0)
            {
                NombresTextBox.Text = ClientesBLL.ObtenerNombre(Id);
                ApellidosTextBox.Text = ClientesBLL.ObtenerApellido(Id);
            }
        }

        private void ArticulosIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int Id;
            int.TryParse(ArticulosIdTextBox.Text, out Id);

            if (Id > 0)
            {
                DescripcionTextBox.Text = ArticulosBLL.ObtenerDescripcion(Id);
                PrecioATextBox.Text = Convert.ToString(ArticulosBLL.ObtenerPrecio(Id));
            }
        }

        private void EventoIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool disponible = true;
            int id;
            int.TryParse(EventoIdTextBox.Text, out id);
            Eventos evento = EventosBLL.Buscar(id);

            if (id == 0 || string.IsNullOrWhiteSpace(EventoIdTextBox.Text))
            {
                EventoIdTextBox.Text = "0";
                PrecioETextBox.Text = "0";
            }
            if (id > 0)
            {
                if(disponible == EventosBLL.ObtenerDisponibilidad(id))
                {
                    PrecioETextBox.Text = Convert.ToString(EventosBLL.ObtenerPrecio(id));
                    if (evento.Disponible == true)
                    {
                        MontoTextBox.Text = Convert.ToString(Convert.ToDecimal(MontoTextBox.Text) + Convert.ToDecimal(PrecioETextBox.Text));
                        EventosBLL.CambiarDisponibilidad(id, disponible);
                    }
                }
                else
                {
                    MessageBox.Show("Evento ya fue utilizado");
                }
            }
        }
    }
}
