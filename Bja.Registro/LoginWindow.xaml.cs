using Bja.Entidades;
using Bja.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bja.Registro
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public Boolean logeado { get; set; }
        public User user { get; set; }

        public LoginWindow()
        {
            InitializeComponent();
            

        }

        private void aceptarButton_Click(object sender, RoutedEventArgs e)
        {

            //authenticar usuario
            var rbac = new Rbac();

            user = rbac.authenticate(usuarioTextBox.Text, clavePasswordBox.Password);

            if (user != null)
            {
                //MessageBox.Show("Logeado");
                logeado = true;
            }
            else
            {
                //MessageBox.Show("usuario o clave invalida.");
                logeado = false;
            }

            this.Close();
        }

    }
}
