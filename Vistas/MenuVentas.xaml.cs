using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClasesBase;
using System.Collections.ObjectModel;
using Microsoft.Win32;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for MenuVentas.xaml
    /// </summary>
    public partial class MenuVentas : Window
    {
        float total;
        int cantidad = 1 ;
        Venta vent = new Venta();
        string opciones;
        TrabajarVenta trabajarVent = new TrabajarVenta(); 
        public MenuVentas()
        {
            InitializeComponent();
        }

        private void LimpiezaCampos()
        {
         /*   txtFactura.Text = string.Empty;
            txtLegajo.Text = string.Empty; ;
            txtDNI.Text = string.Empty; ;
            txtCodigo.Text = string.Empty; ;
            txtPrecio.Text = string.Empty; ;
            txtCantidad.Text = string.Empty; ;
            txtImporte.Text = string.Empty; ;*/
        }

        //private void HabilitarCampos(bool isEnabled)
        //{
        //    txtFactura.IsEnabled = isEnabled;
        //    txtLegajo.IsEnabled = isEnabled;
        //    txtDNI.IsEnabled = isEnabled;
        //    txtCodigo.IsEnabled = isEnabled;
        //    txtPrecio.IsEnabled = isEnabled;
        //    txtCantidad.IsEnabled = isEnabled;
        //    txtImporte.IsEnabled = isEnabled;
        //}

        //private void HabilitarBotones(bool enabled)
        //{
        //    btnNuevo.IsEnabled = enabled;
        //    btnModificar.IsEnabled = enabled;
        //    btnEliminar.IsEnabled = enabled;
        //    btnPrimero.IsEnabled = enabled;
        //    btnAnterior.IsEnabled = enabled;
        //    btnSiguiente.IsEnabled = enabled;
        //    btnUltimo.IsEnabled = enabled;
        //}

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (Prod.SelectedItem!=null && datePicker1.SelectedDate != null)
            {
                DataRowView drv = Prod.SelectedItem as DataRowView;
                opciones = "cargar";
                if (opciones == "cargar")
                {
                    
                    vent.NroFactura = Convert.ToInt32(txtFactura.Text);
                    vent.FechaFactura = Convert.ToDateTime(datePicker1.SelectedDate);
                    vent.Legajo = txtLegajo.Text;
                    vent.DNI = txtDNI.Text;
                    vent.Importe = (cantidad * total);

                    if (trabajarVent.VentaEnTabla(vent.NroFactura) == false)
                    {
                        trabajarVent.cargarVenta(vent);
                        Comprobante cmp = new Comprobante(txtFactura.Text, txtLegajo.Text, txtDNI.Text, drv.Row["CodProducto"] as string, Convert.ToString(total), Convert.ToString(vent.Importe), Convert.ToString(cantidad), (DateTime)datePicker1.SelectedDate);
                        cmp.Show();
                    }
                    else
                    {
                        MessageBox.Show("No se pueden generar dos facturas con el mismo numero.");
                        LimpiezaCampos();
                    }
                }
            }
            else {
                textBlock1.Opacity = 1;
            }
        }

  


        private void listView1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
           DataRowView drv = Prod.SelectedItem as DataRowView;
            vent.CodProducto = drv.Row["CodProducto"] as string;
            string b;
            b = (drv.Row["Precio"] as string);
            vent.Precio = Convert.ToSingle(b);
            float k;
            k = Convert.ToSingle(drv.Row["Precio"]);
            total = k;
            totaltxt.Text = Convert.ToString(cantidad * total);

        }

        private void textBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char ch = e.Text[0];

            if ((Char.IsDigit(ch) || ch == '.'))
            {
                //Here TextBox1.Text is name of your TextBox
                if (ch == '.' && textBox1.Text.Contains('.'))
                    e.Handled = true;
            }
            else
                e.Handled = true;
        }



 

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            

            if (textBox1.Text != "")
            {
                cantidad = Convert.ToInt32(textBox1.Text);
                totaltxt.Text = Convert.ToString(cantidad * total);
            }
            else {
                cantidad = 1;
                totaltxt.Text = Convert.ToString(total);
            }
        }



        private void txtFactura_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char ch = e.Text[0];

            if ((Char.IsDigit(ch) || ch == '.'))
            {
                //Here TextBox1.Text is name of your TextBox
                if (ch == '.' && txtFactura.Text.Contains('.'))
                    e.Handled = true;
            }
            else
                e.Handled = true;
        }

        private void txtDNI_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char ch = e.Text[0];

            if ((Char.IsDigit(ch) || ch == '.'))
            {
                //Here TextBox1.Text is name of your TextBox
                if (ch == '.' && txtDNI.Text.Contains('.'))
                    e.Handled = true;
            }
            else
                e.Handled = true;
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            txtDNI.IsEnabled = true;
            txtFactura.IsEnabled = true;
            txtLegajo.IsEnabled = true;
            datePicker1.IsEnabled = true;
            textBox1.IsEnabled = true;
            Prod.IsEnabled = true;
            btnGuardar.IsEnabled = true;
        }

        //private void btnCancelar_Click(object sender, RoutedEventArgs e)
        //{
        //    LimpiezaCampos();
        //    HabilitarCampos(false);
        //    btnGuardar.IsEnabled = false;
        //    btnCancelar.IsEnabled = false;
        //    HabilitarBotones(true);
        //}
    }
}
