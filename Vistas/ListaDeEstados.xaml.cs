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
    /// Interaction logic for ListaDeEstados.xaml
    /// </summary>
    public partial class ListaDeEstados : Window
    {
        public ListaDeEstados()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Estado : " + comboEstados.SelectedValue.ToString());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboEstados.SelectedValue = "PENDIENTE";
        }

        private void btnAD_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }

    }
}
