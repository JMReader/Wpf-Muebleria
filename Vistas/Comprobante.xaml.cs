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
    /// Interaction logic for Comprobante.xaml
    /// </summary>
    public partial class Comprobante : Window
    {
        public Comprobante(string numF, string legajo, string dni, string codigo, string precio, string import, 
            string cant, DateTime fecha)
        {
            InitializeComponent();
            txtNroFactura.Text = numF;
            txtLegajo.Text = legajo;
            txtDNI.Text = dni;
            txtCodProd.Text = codigo;
            txtPrecio.Text = precio;
            txtImporte.Text = import;
            txtCant.Text = cant;
            txtFechaFactura.Text = fecha.ToString("yyyy"+ "/" +"MM" + "/" + "dd");
        }

    }
}
