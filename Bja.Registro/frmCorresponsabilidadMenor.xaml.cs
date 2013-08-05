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
  /// Lógica de interacción para frmCorresponsabilidadMenor.xaml
  /// </summary>
  public partial class frmCorresponsabilidadMenor : Window
  {
      long IdMenor { get; set; }
      long IdMadre { get; set; }
      long IdTutor { get; set; }
      long IdCorresponsabilidadMenor { get; set; }
      long[] IdControlMenor = new long[14];
      
      public frmCorresponsabilidadMenor()
    {
      this.Cursor = Cursors.Wait;
      InitializeComponent();
      this.Cursor = Cursors.Arrow;
    }

    private void cmdSalir_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }

    private void cmdModificarMenor_Click(object sender, RoutedEventArgs e)
    {
        if (IdMenor > 0)
        {
            this.Cursor = Cursors.Wait;
            frmMenor objMenorWindow = new frmMenor();
            objMenorWindow.IdSeleccionado = IdMenor;
            objMenorWindow.Owner = this;
            objMenorWindow.ShowDialog();
            objMenorWindow = null;
            this.Cursor = Cursors.Arrow;
            RecuperarMenor();
        }
    }

    private void cmdSeleccionarMenor_Click(object sender, RoutedEventArgs e)
    {
        this.Cursor = Cursors.Wait;
        WindowListaRegistros formularioListaMenores = new WindowListaRegistros();

        formularioListaMenores.NuevoRegistro += formularioListaMenores_NuevoRegistro;
        formularioListaMenores.MostrarDetallesRegistro += formularioListaMenores_MostrarDetallesRegistro;
        formularioListaMenores.ModificarRegistro += formularioListaMenores_ModificarRegistro;
        formularioListaMenores.BorrarRegistro += formularioListaMenores_BorrarRegistro;
        formularioListaMenores.SeleccionarRegistro += formularioListaMenores_SeleccionarRegistro;

        ModeloMenor modelomenor = new ModeloMenor();

        formularioListaMenores.proveedorDatos = modelomenor;
        formularioListaMenores.titulo = "Menores";
        formularioListaMenores.ShowDialog();
        this.Cursor = Cursors.Arrow;
    }

    void formularioListaMenores_NuevoRegistro(object sender, EventArgs e)
    {
        this.Cursor = Cursors.Wait;
        frmMenor objMenorWindow = new frmMenor();
        objMenorWindow.IdSeleccionado = 0;
        objMenorWindow.Owner = this;
        objMenorWindow.ShowDialog();
        objMenorWindow = null;
        this.Cursor = Cursors.Arrow;
    }

    void formularioListaMenores_MostrarDetallesRegistro(object sender, IdentidadEventArgs fe)
    {
        this.Cursor = Cursors.Wait;
        frmMenor objMenorWindow = new frmMenor();
        objMenorWindow.IdSeleccionado = fe.id;
        objMenorWindow.Owner = this;
        objMenorWindow.ShowDialog();
        objMenorWindow = null;
        this.Cursor = Cursors.Arrow;
    }

    void formularioListaMenores_ModificarRegistro(object sender, IdentidadEventArgs fe)
    {
        this.Cursor = Cursors.Wait;
        frmMenor objMenorWindow = new frmMenor();
        objMenorWindow.IdSeleccionado = fe.id;
        objMenorWindow.Owner = this;
        objMenorWindow.ShowDialog();
        objMenorWindow = null;
        this.Cursor = Cursors.Arrow;
    }

    void formularioListaMenores_BorrarRegistro(object sender, IdentidadEventArgs fe)
    {
        //throw new NotImplementedException();
        //MessageBox.Show("Por Implementar.", "Mensaje");
        if (IdMenor == fe.id && IdMenor > 0)
            MessageBox.Show("No se puede eliminar este registro de mneor.", "Mensaje");
        else
        {
            ModeloMenor modelomenor = new ModeloMenor();
            modelomenor.Eliminar(fe.id);
        }
    }

    void formularioListaMenores_SeleccionarRegistro(object sender, IdentidadEventArgs fe)
    {
        IdMenor = fe.id;
        RecuperarMenor();
    }

    void RecuperarMenor()
    {
        ModeloMenor modelomenor = new ModeloMenor();
        Menor menor = new Menor();
        menor = modelomenor.Recuperar(IdMenor);
        lblPrimerApellidoMenor.Content = menor.PrimerApellido;
        lblSegundoApellidoMenor.Content = menor.SegundoApellido;
        lblNombresMenor.Content = menor.Nombres;
        lblDocumentoIdentidadMenor.Content = menor.DocumentoIdentidad;
        if (menor.Sexo == "F")
            lblSexoMenor.Content = "Femenino";
        else if (menor.Sexo == "M")
            lblSexoMenor.Content = "Masculino";
        else
            lblSexoMenor.Content = "(No Especificado)";
        lblFechaNacimientoMenor.Content = string.Format("{0:dd/MM/yyyy}", menor.FechaNacimiento);
    }
  }
}
