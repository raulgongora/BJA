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
  /// Lógica de interacción para frmPrincipal.xaml
  /// </summary>
  public partial class frmPrincipal : Window
  {
    public frmPrincipal()
    {
      this.Cursor = Cursors.Wait;
      InitializeComponent();
      this.Cursor = Cursors.Arrow;
    }

    private void cmdSalir_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }

    private void cmdMadres_Click(object sender, RoutedEventArgs e)
    {
      this.Cursor = Cursors.Wait;
      frmMadres objMadresWindow = new frmMadres();
      objMadresWindow.Owner = this;
      objMadresWindow.ShowDialog();
      objMadresWindow = null;
      this.Cursor = Cursors.Arrow;
    }
  }
}
