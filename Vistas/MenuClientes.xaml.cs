using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClasesBase;
using System.Collections.ObjectModel;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for MenuClientes.xaml
    /// </summary>
    public partial class MenuClientes : Window
    {
        CollectionView Vista;
        ObservableCollection<Cliente>listaCliente;
        TrabajarClientes trabajarC = new TrabajarClientes();
        string opciones;

        public MenuClientes()
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
            txtDNI.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDireccion.Text = string.Empty;
        }

        private void HabilitarCampos(bool isEnabled)
        {
            txtDNI.IsEnabled = isEnabled;
            txtNombre.IsEnabled = isEnabled;
            txtDireccion.IsEnabled = isEnabled;
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
            switch (opciones)
            {

                case "cargar":
                    MessageBoxResult result = MessageBox.Show("¿Guardar el cliente?", "Alta Producto", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    Cliente cli = new Cliente();
                    if (!string.IsNullOrEmpty(txtDNI.Text) && !string.IsNullOrEmpty(txtApellido.Text))
                    {
                        cli.DNI = txtDNI.Text;
                        cli.Nombre = txtNombre.Text;
                        cli.Apellido = txtApellido.Text;
                        cli.Direccion = txtDireccion.Text;


                        if (result == MessageBoxResult.Yes)
                        {
                            if (trabajarC.ClienteEntabla(cli.DNI) == false)
                            {
                                listaCliente.Add(cli);
                                trabajarC.cargarCliente(cli);

                                MessageBox.Show("Codigo: " + cli.DNI + Environment.NewLine +
                                    "Categoria: " + cli.Apellido + Environment.NewLine +
                                    "Color: " + cli.Nombre + Environment.NewLine +
                                    "Descripcion: " + cli.Direccion + Environment.NewLine, "Cliente Agregado", MessageBoxButton.OK, MessageBoxImage.Information);
                                HabilitarCampos(false);
                                btnCancelar.IsEnabled = false;
                                btnGuardar.IsEnabled = false;
                                HabilitarBotones(true);



                                Vista.MoveCurrentToLast();

                            }
                            else
                            {
                                MessageBox.Show("No pueden existir dos clientes con el mismo DNI.");
                            }
                        }
                        else
                        {
                            HabilitarCampos(false);
                            btnCancelar.IsEnabled = false;
                            btnGuardar.IsEnabled = false;
                            HabilitarBotones(true);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta rellenar datos de cliente.");
                    }

                    break;


                case "editar":
                    MessageBoxResult editar = MessageBox.Show("¿Desea modificar los datos del Cliente?", "Alta Cliente", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (!string.IsNullOrEmpty(txtDNI.Text) && !string.IsNullOrEmpty(txtApellido.Text))
                    {
                        if (editar == MessageBoxResult.Yes)
                        {
                            Cliente cliEdi = new Cliente();
                            cliEdi.DNI = txtDNI.Text;
                            cliEdi.Nombre = txtNombre.Text;
                            cliEdi.Apellido = txtApellido.Text;
                            cliEdi.Direccion = txtDireccion.Text;

                            if (trabajarC.ClienteEntabla(cliEdi.DNI) == true)
                            {
                                trabajarC.actualizarCliente(cliEdi);

                                MessageBox.Show("Cliente modificado con exito");
                                HabilitarCampos(false);
                                btnCancelar.IsEnabled = false;
                                btnGuardar.IsEnabled = false;
                                HabilitarBotones(true);
                            }
                            else
                            {
                                MessageBox.Show("No existe ningun cliente con ese DNI.");
                            }
                        }
                        else
                        {
                            HabilitarCampos(false);
                            btnCancelar.IsEnabled = false;
                            btnGuardar.IsEnabled = false;
                            HabilitarBotones(true);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta rellenar datos de cliente.");
                    }
                    break;

            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["DATA_CLI"];
            listaCliente = odp.Data as ObservableCollection<Cliente>;
            Vista = (CollectionView)CollectionViewSource.GetDefaultView(Clientes.DataContext);
        }

        private void btnPrimero_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToFirst();
        }

        private void btnUltimo_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToLast();
        }

        private void btnAnterior_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToPrevious();
            if (Vista.IsCurrentBeforeFirst) {
                Vista.MoveCurrentToLast();
            }
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToNext();
            if (Vista.IsCurrentAfterLast) {
                Vista.MoveCurrentToFirst();
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            HabilitarBotones(false);

            MessageBoxResult Eliminar = MessageBox.Show("¿Eliminar el Cliente?", "Alta Cliente", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Eliminar == MessageBoxResult.Yes)
            {
                string codigoIden = txtDNI.Text;

                if (trabajarC.ClienteEntabla(codigoIden) == true)
                {
                    trabajarC.eliminarCliente(codigoIden);

                    MessageBox.Show("Eliminado con exito.");
                    HabilitarCampos(false);
                    btnCancelar.IsEnabled = false;
                    btnGuardar.IsEnabled = false;
                    HabilitarBotones(true);
                    for (int i = 0; i < listaCliente.Count; i++ )
                    {
                        if (listaCliente[i].DNI == codigoIden) {
                            listaCliente.RemoveAt(i);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No existe ningun cliente con ese DNI.");
                }
            }
            else
            {
                HabilitarCampos(false);
                btnCancelar.IsEnabled = false;
                btnGuardar.IsEnabled = false;
                HabilitarBotones(true);
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCampos(true);
            txtDNI.IsEnabled = false;

            btnGuardar.IsEnabled = true;
            btnCancelar.IsEnabled = true;
            HabilitarBotones(false);
            opciones = "editar"; 
        }

    }
}
