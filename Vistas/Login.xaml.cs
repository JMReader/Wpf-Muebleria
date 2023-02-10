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
using System.IO;
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        TrabajarVendedor vendedorsql = new TrabajarVendedor();
        public Login()
        {
            InitializeComponent();
        }

        public string Usuario { get; set; }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Vendedor user = vendedorsql.registrar(this.UserC.txtUser.Text, this.UserC.txtpassword.Password);

            Menu menu = new Menu();
            if (user != null) {
                MessageBox.Show("registradopa");
                
            }
            else
            {
                MessageBox.Show("Legajo inexsistente, intente nuevamente", "Atención", MessageBoxButton.OK, MessageBoxImage.Information);
                UserC.txtUser.Text = string.Empty;
                UserC.txtpassword.Password = "";
            }
            
           

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var CurrentDirectory = Directory.GetCurrentDirectory();
          
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri(CurrentDirectory + "\\Audio\\musicaDeFondo.mp3"));
            player.Play();


            

            

        }

        private void UserC_Loaded(object sender, RoutedEventArgs e)
        {

        }



        //(prop y tabulador)
        //ctrl k y d para acomodar la pantalla

    }
}
