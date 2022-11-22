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
    /// Interaction logic for MenuProducto.xaml
    /// </summary>
    public partial class MenuProducto : Window
    {
        //private ObservableCollection<Producto> prods;
        TrabajarProductos trabajarP = new TrabajarProductos();
        string opciones;

        public MenuProducto()
        {
            InitializeComponent();
            agregarImagen.IsEnabled = false;
            textImagen.Visibility = Visibility.Hidden;  
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            btnCancelar.IsEnabled = true;
            btnGuardar.IsEnabled = true;

            HabilitarCampos(false);
        }

        private void LimpiezaCampos()
        {
            txtCodigo.Text = string.Empty;
            txtCategoria.Text = string.Empty;
            txtColor.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

        private void HabilitarCampos(bool isEnabled)
        {
            txtCodigo.IsEnabled = isEnabled;
            txtCategoria.IsEnabled = isEnabled;
            txtColor.IsEnabled = isEnabled;
            txtPrecio.IsEnabled = isEnabled;
            txtDescripcion.IsEnabled = isEnabled;
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

            btnGuardar.IsEnabled = true;
            btnCancelar.IsEnabled = true;
            HabilitarBotones(false);
            agregarImagen.IsEnabled = true; 
            opciones = "cargar";
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //prods = new ObservableCollection<Producto>() {};
            
            switch(opciones){
                   
                case  "cargar":
                    MessageBoxResult result = MessageBox.Show("¿Guardar el Producto?", "Alta Producto", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    Producto prod = new Producto();
                    if (!string.IsNullOrEmpty(txtCodigo.Text) && !string.IsNullOrEmpty(txtPrecio.Text))
                    {
                        if (result == MessageBoxResult.Yes)
                        {
                            prod.CodProducto = txtCodigo.Text;
                            prod.Categoria = txtCategoria.Text;
                            prod.Color = txtColor.Text;
                            prod.Descripcion = txtDescripcion.Text;
                            prod.Precio = Convert.ToDecimal(txtPrecio.Text);
                            prod.CodImagen = textImagen.Text;
                            if (trabajarP.ProductoEntabla(prod.CodProducto) == false)
                            {
                                trabajarP.cargarProducto(prod);
                                //prods.Add(prod);
                                MessageBox.Show("Codigo: " + prod.CodProducto + Environment.NewLine +
                                    "Categoria: " + prod.Categoria + Environment.NewLine +
                                    "Color: " + prod.Color + Environment.NewLine +
                                    "Descripcion: " + prod.Descripcion + Environment.NewLine +
                                    "Precio: " + prod.Precio, "Producto Agregado", MessageBoxButton.OK, MessageBoxImage.Information);
                                LimpiezaCampos();
                                HabilitarCampos(false);
                                btnCancelar.IsEnabled = false;
                                btnGuardar.IsEnabled = false;
                                HabilitarBotones(true);
                                Productos.ItemsSource = trabajarP.traerProducto().AsDataView();
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
                    else
                    {
                        MessageBox.Show("No se puede agregar un producto con campos vacios");
                    }
                break;
                case "eliminar":
                                 MessageBoxResult Eliminar = MessageBox.Show("¿Eliminar el Producto?", "Alta Producto", MessageBoxButton.YesNo, MessageBoxImage.Question);
                     if (Eliminar == MessageBoxResult.Yes)
                     {
                            string codigoIden = txtCodigo.Text;

                            if (trabajarP.ProductoEntabla(codigoIden) == true)
                            {
                                trabajarP.eliminarProducto(codigoIden);

                                MessageBox.Show("Eliminado con exito.");
                                LimpiezaCampos();
                                HabilitarCampos(false);
                                btnCancelar.IsEnabled = false;
                                btnGuardar.IsEnabled = false;
                                HabilitarBotones(true);
                                Productos.ItemsSource = trabajarP.traerProducto().AsDataView();
                            }
                            else
                            {
                                MessageBox.Show("No existe ningun producto con ese codigo, ingrese uno diferente.");
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
                break;

                case "editar":
                MessageBoxResult editar = MessageBox.Show("¿Desea modificar el producto?", "Alta Producto", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (!string.IsNullOrEmpty(txtCodigo.Text) && !string.IsNullOrEmpty(txtPrecio.Text))
                {
                    if (editar == MessageBoxResult.Yes)
                    {
                        Producto prodEdi = new Producto();
                        prodEdi.CodProducto = txtCodigo.Text;
                        prodEdi.Categoria = txtCategoria.Text;
                        prodEdi.Color = txtColor.Text;
                        prodEdi.Descripcion = txtDescripcion.Text;
                        prodEdi.Precio = Convert.ToInt32(txtPrecio.Text);
                        prodEdi.CodImagen = textImagen.Text;

                        if (trabajarP.ProductoEntabla(prodEdi.CodProducto) == true)
                        {
                            trabajarP.actualizarProducto(prodEdi);

                            MessageBox.Show("Producto modificado con exito");
                            LimpiezaCampos();
                            HabilitarCampos(false);
                            btnCancelar.IsEnabled = false;
                            btnGuardar.IsEnabled = false;
                            HabilitarBotones(true);
                            Productos.ItemsSource = trabajarP.traerProducto().AsDataView();
                        }
                        else
                        {
                            MessageBox.Show("No existe ningun producto con ese codigo, ingrese uno diferente.");
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
                else
                {
                    MessageBox.Show("No se puede editar un producto con campos vacios");
                }
                break;
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

        private void btnModificar_Click_1(object sender, RoutedEventArgs e)
        {
            LimpiezaCampos();
            HabilitarCampos(true);
            txtCodigo.IsReadOnly = true; 

            btnGuardar.IsEnabled = true;
            btnCancelar.IsEnabled = true;
            HabilitarBotones(false);
            opciones = "editar";
            agregarImagen.IsEnabled = true; 
        }

        private void btnEliminar_Click_1(object sender, RoutedEventArgs e)
        {
            txtCodigo.IsEnabled = true;
            LimpiezaCampos();
            opciones = "eliminar";
            btnGuardar.IsEnabled = true;
            btnCancelar.IsEnabled = true;
            HabilitarBotones(false);
        }

        private void Productos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            //if (opciones != "eliminar") {
                DataRowView drv = Productos.SelectedItem as DataRowView;
                if (drv != null) {
                    string a;
                    string b;
                    txtCodigo.Text = drv.Row["CodProducto"] as string;
                    txtCategoria.Text = drv.Row["Categoria"] as string;
                    txtColor.Text = drv.Row["Color"] as string;
                    txtDescripcion.Text = drv.Row["Descripcion"] as string;
                    b = drv.Row["Precio"].ToString();
                    txtPrecio.Text = b;
                    try
                    {
                        BitmapImage foto = new BitmapImage();
                        foto.BeginInit();
                        a = drv.Row["CodImagen"] as string;
                        foto.UriSource = new Uri(a);
                        foto.EndInit();
                        imagenProd.Source = foto;
                    }
                    catch
                    {
                        imagenProd.Source = null;  
                        return;
                    }
                } 
        }

        private void txtPrecio_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char ch = e.Text[0];

            if ((Char.IsDigit(ch) || ch == '.'))
            {
                //Here TextBox1.Text is name of your TextBox
                if (ch == '.' && txtPrecio.Text.Contains('.'))
                    e.Handled = true;
            }
            else
                e.Handled = true;
        }

        private void agregarImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de Imagen (.jpg)|*.jpg|All Files (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == true)
            {
                textImagen.Text = "";

                try
                {
                    BitmapImage foto = new BitmapImage();
                    foto.BeginInit();
                    foto.UriSource = new Uri(ofd.FileName);
                    foto.EndInit();
                    foto.Freeze();
                    imagenProd.Source = foto;
                    textImagen.Text = ofd.FileName; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al subir imagen: "+ex.Message+" Error."); 
                }
            }
        }
    }
}
