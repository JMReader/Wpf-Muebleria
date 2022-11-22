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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public string Usuario { get; set; }

        public Menu()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Usuario == "vendedor")
            {
                Vendedores.IsEnabled = false;
            }
        }

        private void ABMProveedores_Click(object sender, RoutedEventArgs e)
        {
            MenuProveedores prov = new MenuProveedores();
            this.Hide();
            prov.Show();
        }

        private void Clientes_Click(object sender, RoutedEventArgs e)
        {
            MenuClientes cli = new MenuClientes();
            this.Hide();
            cli.Show();
        }

        private void Productos_Click(object sender, RoutedEventArgs e)
        {
            MenuProducto prod = new MenuProducto();
            this.Hide();
            prod.Show();
        }

        private void Ventas_Click(object sender, RoutedEventArgs e)
        {
            MenuVentas ven = new MenuVentas();
            this.Hide();
            ven.Show();
        }

        private void Vendedores_Click(object sender, RoutedEventArgs e)
        {
            MenuVendedores vends = new MenuVendedores();
            this.Hide();
            vends.Show();
        }

        private void filtroClientes_Click(object sender, RoutedEventArgs e)
        {
            Window2 fil = new Window2();
            this.Hide();
            fil.Show();

        }

        private void Productos_Click_1(object sender, RoutedEventArgs e)
        {
            VistaPreviaDeImpresion vis = new VistaPreviaDeImpresion();
            vis.Show();
        }

        private void ListaDeEstados_Click(object sender, RoutedEventArgs e)
        {
            ListaDeEstados list = new ListaDeEstados();
            this.Hide();
            list.Show();
        }

        private void btnAD_Click(object sender, RoutedEventArgs e)
        {
            AcercaDe AD = new AcercaDe();
            this.Hide();
            AD.Show();
        }



    }
}
