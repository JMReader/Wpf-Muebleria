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
    /// Interaction logic for MenuVendedores.xaml
    /// </summary>
    public partial class MenuVendedores : Window
    {
        TrabajarVendedor trabajarV = new TrabajarVendedor();
        string opciones; 

        public MenuVendedores()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            btnCancelar.IsEnabled = false;
            btnGuardar.IsEnabled = false;

            HabilitarCampos(false);
        }

        private void LimpiezaCampos()
        {
            txtLegajo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
        }

        private void HabilitarCampos(bool isEnabled)
        {
            txtLegajo.IsEnabled = isEnabled;
            txtNombre.IsEnabled = isEnabled;
            txtApellido.IsEnabled = isEnabled;
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

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiezaCampos();
            HabilitarCampos(true);
            opciones = "cargar";

            btnGuardar.IsEnabled = true;
            btnCancelar.IsEnabled = true;
            HabilitarBotones(false);
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (opciones == "cargar")
            {
                MessageBoxResult result = MessageBox.Show("¿Guardar el Vendedor?", "Alta Vendedor", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Vendedor vend = new Vendedor();
                    vend.Legajo = txtLegajo.Text;
                    vend.Nombre = txtNombre.Text;
                    vend.Apellido = txtApellido.Text;

                    if (trabajarV.VendedorEntabla(vend.Legajo) == false)
                    {
                        trabajarV.cargarVendedor(vend);

                        MessageBox.Show("Legajo: " + vend.Legajo + Environment.NewLine +
                            "Apellido: " + vend.Apellido + Environment.NewLine +
                            "Nombre: " + vend.Nombre, "Vendedor Agregado", MessageBoxButton.OK, MessageBoxImage.Information);
                        LimpiezaCampos();
                        HabilitarCampos(false);
                        btnCancelar.IsEnabled = false;
                        btnGuardar.IsEnabled = false;
                        HabilitarBotones(true);
                    }
                    else
                    {
                        MessageBox.Show("No se puede agregar un producto con la misma id de otro. Escoja otro id");
                        LimpiezaCampos();
                    }
                }
                else
                {
                    LimpiezaCampos();
                    HabilitarCampos(false);
                    btnCancelar.IsEnabled = false;
                    btnGuardar.IsEnabled = false;
                    HabilitarBotones(true);
                }
            }
            if (opciones == "eliminar")
            {
                MessageBoxResult result = MessageBox.Show("¿Eliminar el Vendedor?", "Alta Vendedor", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    string leg = txtLegajo.Text;

                    if (trabajarV.VendedorEntabla(leg) == true)
                    {
                        trabajarV.eliminarVendedor(leg);

                        MessageBox.Show("Eliminado con exito.");
                        LimpiezaCampos();
                        HabilitarCampos(false);
                        btnCancelar.IsEnabled = false;
                        btnGuardar.IsEnabled = false;
                        HabilitarBotones(true);
                    }
                    else
                    {
                        MessageBox.Show("No existe ningun vendedor con ese legajo, ingrese uno diferente.");
                        LimpiezaCampos();
                    }
                }
                else
                {
                    LimpiezaCampos();
                    HabilitarCampos(false);
                    btnCancelar.IsEnabled = false;
                    btnGuardar.IsEnabled = false;
                    HabilitarBotones(true);
                }

            }
            if (opciones == "editar")
            {
                MessageBoxResult result = MessageBox.Show("¿Desea modificar el vendedor?", "Alta Vendedor", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Vendedor vend = new Vendedor();
                    vend.Legajo = txtLegajo.Text;
                    vend.Nombre = txtNombre.Text;
                    vend.Apellido = txtApellido.Text;

                    if (trabajarV.VendedorEntabla(vend.Legajo) == true)
                    {
                        trabajarV.actualizarVendedor(vend);

                        MessageBox.Show("Vendedor modificado con exito");
                        LimpiezaCampos();
                        HabilitarCampos(false);
                        btnCancelar.IsEnabled = false;
                        btnGuardar.IsEnabled = false;
                        HabilitarBotones(true);
                    }
                    else
                    {
                        MessageBox.Show("No existe ningun vendedor con ese legajo, ingrese uno diferente.");
                        LimpiezaCampos();
                    }
                }
                else
                {
                    LimpiezaCampos();
                    HabilitarCampos(false);
                    btnCancelar.IsEnabled = false;
                    btnGuardar.IsEnabled = false;
                    HabilitarBotones(true);
                }
            }
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

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            LimpiezaCampos();
            HabilitarCampos(true);

            btnGuardar.IsEnabled = true;
            btnCancelar.IsEnabled = true;
            HabilitarBotones(false);
            opciones = "editar";
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            txtLegajo.IsEnabled = true;
            LimpiezaCampos();
            opciones = "eliminar";
            btnGuardar.IsEnabled = true;
            btnCancelar.IsEnabled = true;
            HabilitarBotones(false);
        }
    }
}
