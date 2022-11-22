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
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for MenuProveedores.xaml
    /// </summary>
    public partial class MenuProveedores : Window
    {
        public MenuProveedores()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            btnCancelar.IsEnabled = false;
            btnGuardar.IsEnabled = false;

            HabilitarCampos(false);
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiezaCampos();
            HabilitarCampos(true);

            btnGuardar.IsEnabled = true;
            btnCancelar.IsEnabled = true;
            HabilitarBotones(false);
        }

        
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiezaCampos();
            HabilitarCampos(false);
            btnGuardar.IsEnabled = false;
            btnCancelar.IsEnabled = false;
            HabilitarBotones(true);
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Guardar el Proveedor?", "Alta Proveedor", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Proveedor prov = new Proveedor();
                prov.CUIT = txtCuit.Text;
                prov.RazonSocial = txtRazonSocial.Text;
                prov.Direccion = txtDireccion.Text;
                prov.Telefono = txtTelefono.Text;

                MessageBox.Show("CUIT: " + prov.CUIT + Environment.NewLine +
                    "Razon Social: " + prov.RazonSocial + Environment.NewLine +
                    "Direccion: " + prov.Direccion + Environment.NewLine +
                    "Telefono: " + prov.Telefono, "Proveedor Agregado", MessageBoxButton.OK, MessageBoxImage.Information);

                LimpiezaCampos();
                HabilitarCampos(false);
                btnCancelar.IsEnabled = false;
                btnGuardar.IsEnabled = false;
                HabilitarBotones(true);
            }
            else {
                LimpiezaCampos();
                HabilitarCampos(false);
                btnCancelar.IsEnabled = false;
                btnGuardar.IsEnabled = false;
                HabilitarBotones(true);
            }
        }

        private void LimpiezaCampos()
        {
            txtCuit.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }

        private void HabilitarCampos(bool isEnabled)
        {
            txtCuit.IsEnabled = isEnabled;
            txtRazonSocial.IsEnabled = isEnabled;
            txtDireccion.IsEnabled = isEnabled;
            txtTelefono.IsEnabled = isEnabled;
        }

        private void HabilitarBotones(bool enabled)
        {
            btnNuevo.IsEnabled = enabled;
            btnModificar.IsEnabled = enabled;
            btnEliminar.IsEnabled = enabled;
            btnPrimero.IsEnabled = enabled;
            btnAnterior.IsEnabled = enabled;
            btnSiguiente.IsEnabled = enabled;
            btnUltimo.IsEnabled = enabled;
        }
    }
}
