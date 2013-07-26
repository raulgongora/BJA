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
  /// Lógica de interacción para frmLogin.xaml
  /// </summary>
  public partial class frmLogin : Window
  {
    public frmLogin()
    {
      this.Cursor = Cursors.Wait;
      InitializeComponent();
      InicializacionBD.inicializarBD();
      this.Cursor = Cursors.Arrow;
    }

    private void cmdAceptar_Click(object sender, RoutedEventArgs e)
    {
      //authenticar usuario
      var rbac = new Rbac();
      User user = rbac.authenticate(txtUsuario.Text, pasContrasena.Password);
      if (user != null)
      {
        //MessageBox.Show("Acceso concedido.","Mensaje");
        //inicia session
        SessionManager.initSession(user);
        //rrscgyov
        this.Hide();

        frmPrincipal objPrincipal = new frmPrincipal();
        bool? Resultado = objPrincipal.ShowDialog();
        if (Resultado == false)
        {
          objPrincipal.Close();
          Application.Current.Shutdown();
        }
      }
      else
      {
        MessageBox.Show("Usuario o clave no válido.", "Error");
      }
    }

    private void cmdSalir_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      txtUsuario.Focus();
    }

  }
}
