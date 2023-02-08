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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {

        

  private CollectionViewSource vistaColeccionFiltrada;

        


 /// <summary>
 /// EVENTO TEXTCHANGED PARA REALIZAR EL FILTRO Y AÑADIR ELEMENTOS A LA VISTA
        
 private void txtApellido_TextChanged(object sender, TextChangedEventArgs e)
 {
     if (vistaColeccionFiltrada != null)
     {
         vistaColeccionFiltrada.Filter += eventVistaCliente_Filter;
     }
 }

        
 /// EVENTO FILTRO VA FILTRANDO Y AÑADIENDO A LA VISTA LOS ELEMENTOS QUE COMIENCEN CON CIERTA LETRA

 private void eventVistaCliente_Filter(object sender, FilterEventArgs e)
 {
     Cliente oCliente = e.Item as Cliente;

     if (oCliente.Apellido.StartsWith(txtFiltroApellido.Text, StringComparison.CurrentCultureIgnoreCase))
     {
         e.Accepted = true;
     }
     else
     {
         e.Accepted = false;
     }
 }
            
 






        public Window2()
        {
            InitializeComponent();
             vistaColeccionFiltrada = Resources["FILTRO_APELLIDO"] as CollectionViewSource;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        /* Punto 1 C
List<Cliente> listaFiltrada = new List<Cliente>();
private void btn_Imprimir_Click(object sender, RoutedEventArgs e)
{
   foreach (Cliente cli in ListaClientesFiltro.Items)
   {
       listaFiltrada.Add(cli);
   }

   listaFiltrada = ListaClientesFiltro.Items.Cast<Cliente>().ToList();
   TrabajarClientes.agregarListaClientess(listaFiltrada);
   //MessageBox.Show("Cantidad:" + listaFiltrada.Count.ToString());

   VistaPreviaDeImpresion oImprimir = new VistaPreviaDeImpresion(vistaColeccionFiltrada);
   oImprimir.Show();
}
*/
    }
}
