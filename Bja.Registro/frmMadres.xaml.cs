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
  /// Lógica de interacción para frmMadres.xaml
  /// </summary>
  public partial class frmMadres : Window
  {
    public frmMadres()
    {
      this.Cursor = Cursors.Wait;
      InitializeComponent();
      this.Cursor = Cursors.Arrow;
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      SoporteCombo.cargarEnumerador(cboBuscar, typeof(OpcionBusqueda));
    }

    private void cmdSalir_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }

    private void Button_Click_Detalles(object sender, RoutedEventArgs e)
    {
    }

    private void Button_Click_Modificar(object sender, RoutedEventArgs e)
    {
    }

    private void Button_Click_Borrar(object sender, RoutedEventArgs e)
    {
    }

    private void textBoxCriterioBusqueda_TextChanged(object sender, TextChangedEventArgs e)
    {
    }

    private void cmdNuevo_Click(object sender, RoutedEventArgs e)
    {
      //this.Cursor = Cursors.Wait;
      //frmMadre objMadreWindow = new frmMadre();
      //objMadreWindow.Owner = this;
      //objMadreWindow.ShowDialog();
      //objMadreWindow = null;
      //this.Cursor = Cursors.Arrow;
    }

    private void cmdBuscar_Click(object sender, RoutedEventArgs e)
    {
    }

  }
}
