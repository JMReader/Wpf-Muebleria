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
    /// Lógica de interacción para VistaPreviaDeImpresion.xaml
    /// </summary>
    public partial class VistaPreviaDeImpresion : Window
    {
        public VistaPreviaDeImpresion()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pdlg = new PrintDialog();

            if (pdlg.ShowDialog() == true) {
                pdlg.PrintDocument(((IDocumentPaginatorSource)DocMain).DocumentPaginator, "imprimir");
            
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ListaArtImprimir_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
