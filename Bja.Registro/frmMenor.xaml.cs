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
  /// Lógica de interacción para frmMenor.xaml
  /// </summary>
  public partial class frmMenor : Window
  {
    public frmMenor()
    {
      this.Cursor = Cursors.Wait;
      InitializeComponent();
      this.Cursor = Cursors.Arrow;
    }

    private void cmdCancelar_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }

    /*
     * rrsc 26/07/2013
     * Por el momento, mientras se analiza como utilizarlo. 
    */

    //#region Lista Madre
    //private void btnMadre_Click(object sender, RoutedEventArgs e)
    //{
    //  WindowListaRegistros ventanaListaMadres = new WindowListaRegistros();

    //  ventanaListaMadres.NuevoRegistro += ventanaListaMadres_NuevoRegistro;
    //  ventanaListaMadres.MostrarDetallesRegistro += ventanaListaMadres_MostrarDetallesRegistro;
    //  ventanaListaMadres.ModificarRegistro += ventanaListaMadres_ModificarRegistro;
    //  ventanaListaMadres.BorrarRegistro += ventanaListaMadres_BorrarRegistro;

    //  ModeloMadre modelo = new ModeloMadre();

    //  ventanaListaMadres.proveedorDatos = modelo;
    //  ventanaListaMadres.titulo = "Lista de madres";
    //  ventanaListaMadres.ShowDialog();
    //}

    //void ventanaListaMadres_ModificarRegistro(object sender, IdentidadEventArgs fe)
    //{
    //  /*
    //   * Mostrar ventana de mantenimiento
    //   WindowNuevoConvenioMantenimiento wcm = new WindowNuevoConvenioMantenimiento();
    //  wcm.idConvenioMantenimiento = fe.id;
    //  wcm.accionVentana = Perseve.Admedif.Entidades.EnumAccionVentana.Modificar;
    //  wcm.ShowDialog();
    //   * * 
    //   */
    //  throw new NotImplementedException();
    //}

    //void ventanaListaMadres_BorrarRegistro(object sender, IdentidadEventArgs fe)
    //{
    //  throw new NotImplementedException();
    //}

    //void ventanaListaMadres_MostrarDetallesRegistro(object sender, IdentidadEventArgs fe)
    //{
    //  throw new NotImplementedException();
    //}

    //void ventanaListaMadres_NuevoRegistro(object sender, EventArgs e)
    //{
    //  throw new NotImplementedException();
    //}
    //#endregion

    //private void Window_Closed_1(object sender, EventArgs e)
    //{
    //  SessionManager.endSession();
    //}
    
  }
}
