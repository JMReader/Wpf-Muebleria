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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        public string Usuario { get; set; }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string usuarioAdmin = "admin";
            string passAdmin = "123";
            string usuarioVendedor = "vendedor";
            string passVendedor = "456";

            Menu menu = new Menu();
            if ((UserC.txtUser.Text == usuarioAdmin) && (UserC.txtpassword.Password == passAdmin))
            {
                //MessageBox.Show("Bienvenido", "Muebleria LPOO", MessageBoxButton.OK, MessageBoxImage.Information);
                menu.Usuario = usuarioAdmin;
                this.Hide();
                menu.Show();
            }
            else if ((UserC.txtUser.Text == usuarioVendedor) && (UserC.txtpassword.Password == passVendedor))
            {
                //MessageBox.Show("Bienvenido", "Muebleria LPOO", MessageBoxButton.OK, MessageBoxImage.Information);
                menu.Usuario = usuarioVendedor;
                this.Hide();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrecto.", "Atención", MessageBoxButton.OK, MessageBoxImage.Information);
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



        //(prop y tabulador)
        //ctrl k y d para acomodar la pantalla

    }
}
