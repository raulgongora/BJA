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
      long[] IdControlMenor = new long[13];
      public long IdSeleccionado { get; set; }
      public int OpcionDeVisualizacion { get; set; }

      public frmCorresponsabilidadMenor()
      {
          this.Cursor = Cursors.Wait;
          InitializeComponent();
          this.Cursor = Cursors.Arrow;
      }

      private void Window_Loaded(object sender, RoutedEventArgs e)
      {
          if (IdSeleccionado == 0)
          {
              this.dtpFechaInscripcion.SelectedDate = DateTime.Today;
              this.dtpFechaSalida.SelectedDate = DateTime.Today;
          }
      }

      private void cmdSalir_Click(object sender, RoutedEventArgs e)
      {
          this.Close();
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
          objMenorWindow.OpcionDeVisualizacion = 0;
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
          objMenorWindow.OpcionDeVisualizacion = 2;
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
          objMenorWindow.OpcionDeVisualizacion = 1;
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
          lblNombresMenor.Content = menor.Nombres + " " + menor.PrimerApellido + " " + menor.SegundoApellido;
          lblFechaNacimientoMenor.Content = string.Format("{0:dd/MM/yyyy}", menor.FechaNacimiento);
      }

      private void cmdSeleccionarMadre_Click(object sender, RoutedEventArgs e)
      {
          this.Cursor = Cursors.Wait;
          WindowListaRegistros formularioListaMadres = new WindowListaRegistros();

          formularioListaMadres.NuevoRegistro += formularioListaMadres_NuevoRegistro;
          formularioListaMadres.MostrarDetallesRegistro += formularioListaMadres_MostrarDetallesRegistro;
          formularioListaMadres.ModificarRegistro += formularioListaMadres_ModificarRegistro;
          formularioListaMadres.BorrarRegistro += formularioListaMadres_BorrarRegistro;
          formularioListaMadres.SeleccionarRegistro += formularioListaMadres_SeleccionarRegistro;

          ModeloMadre modelomadre = new ModeloMadre();

          formularioListaMadres.proveedorDatos = modelomadre;
          formularioListaMadres.titulo = "Madres";
          formularioListaMadres.ShowDialog();
          this.Cursor = Cursors.Arrow;
      }

      void formularioListaMadres_NuevoRegistro(object sender, EventArgs e)
      {
          this.Cursor = Cursors.Wait;
          frmMadre objMadreWindow = new frmMadre();
          objMadreWindow.OpcionDeVisualizacion = 0; //Nuevo
          objMadreWindow.IdSeleccionado = 0;
          objMadreWindow.Owner = this;
          objMadreWindow.ShowDialog();
          objMadreWindow = null;
          this.Cursor = Cursors.Arrow;
      }

      void formularioListaMadres_MostrarDetallesRegistro(object sender, IdentidadEventArgs fe)
      {
          this.Cursor = Cursors.Wait;
          frmMadre objMadreWindow = new frmMadre();
          objMadreWindow.IdSeleccionado = fe.id;
          objMadreWindow.Owner = this;
          objMadreWindow.ShowDialog();
          objMadreWindow = null;
          this.Cursor = Cursors.Arrow;
      }

      void formularioListaMadres_ModificarRegistro(object sender, IdentidadEventArgs fe)
      {
          this.Cursor = Cursors.Wait;
          frmMadre objMadreWindow = new frmMadre();
          objMadreWindow.IdSeleccionado = fe.id;
          objMadreWindow.Owner = this;
          objMadreWindow.ShowDialog();
          objMadreWindow = null;
          this.Cursor = Cursors.Arrow;
      }

      void formularioListaMadres_BorrarRegistro(object sender, IdentidadEventArgs fe)
      {
          //throw new NotImplementedException();
          MessageBox.Show("Por Implementar.", "Mensaje");
      }

      void formularioListaMadres_SeleccionarRegistro(object sender, IdentidadEventArgs fe)
      {
          IdMadre = fe.id;
          RecuperarMadre();
      }

      void RecuperarMadre()
      {
          ModeloMadre modelomadre = new ModeloMadre();
          Madre madre = new Madre();
          madre = modelomadre.Recuperar(IdMadre);
          lblNombreMadre.Content = madre.Nombres + " " + madre.PrimerApellido + " " + madre.SegundoApellido;
          lblFechaNacimientoMadre.Content = string.Format("{0:dd/MM/yyyy}", madre.FechaNacimiento);
      }

      private void cmdDetallesMenor_Click(object sender, RoutedEventArgs e)
      {
          if (IdMenor > 0)
          {
              this.Cursor = Cursors.Wait;
              frmMenor objMenorWindow = new frmMenor();
              objMenorWindow.IdSeleccionado = IdMenor;
              objMenorWindow.OpcionDeVisualizacion = 2; //Detalles
              objMenorWindow.Owner = this;
              objMenorWindow.ShowDialog();
              objMenorWindow = null;
              this.Cursor = Cursors.Arrow;
              RecuperarMenor();
          }
      }

      private void cmdModificarMenor_Click(object sender, RoutedEventArgs e)
      {
          if (IdMenor > 0)
          {
              this.Cursor = Cursors.Wait;
              frmMenor objMenorWindow = new frmMenor();
              objMenorWindow.IdSeleccionado = IdMenor;
              objMenorWindow.OpcionDeVisualizacion = 1;
              objMenorWindow.Owner = this;
              objMenorWindow.ShowDialog();
              objMenorWindow = null;
              this.Cursor = Cursors.Arrow;
              RecuperarMenor();
          }
      }

      private void cmdSeleccionarTutor_Click(object sender, RoutedEventArgs e)
      {
          this.Cursor = Cursors.Wait;
          WindowListaRegistros formularioListaTutores = new WindowListaRegistros();

          formularioListaTutores.NuevoRegistro += formularioListaTutores_NuevoRegistro;
          formularioListaTutores.MostrarDetallesRegistro += formularioListaTutores_MostrarDetallesRegistro;
          formularioListaTutores.ModificarRegistro += formularioListaTutores_ModificarRegistro;
          formularioListaTutores.BorrarRegistro += formularioListaTutores_BorrarRegistro;
          formularioListaTutores.SeleccionarRegistro += formularioListaTutores_SeleccionarRegistro;

          ModeloTutor modelotutor = new ModeloTutor();

          formularioListaTutores.proveedorDatos = modelotutor;
          formularioListaTutores.titulo = "Tutores";
          formularioListaTutores.ShowDialog();
          this.Cursor = Cursors.Arrow;
      }

      void formularioListaTutores_NuevoRegistro(object sender, EventArgs e)
      {
          this.Cursor = Cursors.Wait;
          frmTutor objTutorWindow = new frmTutor();
          objTutorWindow.OpcionDeVisualizacion = 0;
          objTutorWindow.IdSeleccionado = 0;
          objTutorWindow.Owner = this;
          objTutorWindow.ShowDialog();
          objTutorWindow = null;
          this.Cursor = Cursors.Arrow;
      }

      void formularioListaTutores_MostrarDetallesRegistro(object sender, IdentidadEventArgs fe)
      {
          this.Cursor = Cursors.Wait;
          frmTutor objTutorWindow = new frmTutor();
          objTutorWindow.IdSeleccionado = fe.id;
          objTutorWindow.Owner = this;
          objTutorWindow.ShowDialog();
          objTutorWindow = null;
          this.Cursor = Cursors.Arrow;
      }

      void formularioListaTutores_ModificarRegistro(object sender, IdentidadEventArgs fe)
      {
          this.Cursor = Cursors.Wait;
          frmTutor objTutorWindow = new frmTutor();
          objTutorWindow.IdSeleccionado = fe.id;
          objTutorWindow.Owner = this;
          objTutorWindow.ShowDialog();
          objTutorWindow = null;
          this.Cursor = Cursors.Arrow;
      }

      void formularioListaTutores_BorrarRegistro(object sender, IdentidadEventArgs fe)
      {
          //throw new NotImplementedException();
          MessageBox.Show("Por Implementar.", "Mensaje");
      }

      void formularioListaTutores_SeleccionarRegistro(object sender, IdentidadEventArgs fe)
      {
          IdTutor = fe.id;
          RecuperarTutor();
      }

      void RecuperarTutor()
      {
          ModeloTutor modelotutor = new ModeloTutor();
          Tutor tutor = new Tutor();
          tutor = modelotutor.Recuperar(IdTutor);
          lblNombreTutor.Content = tutor.Nombres + " " + tutor.PrimerApellido + " " + tutor.SegundoApellido;
          lblFechaNacimientoTutor.Content = string.Format("{0:dd/MM/yyyy}", tutor.FechaNacimiento);
      }

      private void cmdDetallesTutor_Click(object sender, RoutedEventArgs e)
      {
          if (IdTutor > 0)
          {
              this.Cursor = Cursors.Wait;
              frmTutor objTutorWindow = new frmTutor();
              objTutorWindow.IdSeleccionado = IdTutor;
              objTutorWindow.OpcionDeVisualizacion = 2; //Detalles
              objTutorWindow.Owner = this;
              objTutorWindow.ShowDialog();
              objTutorWindow = null;
              this.Cursor = Cursors.Arrow;
              RecuperarTutor();
          }
      }

      private void cmdModificarTutor_Click(object sender, RoutedEventArgs e)
      {
          if (IdTutor > 0)
          {
              this.Cursor = Cursors.Wait;
              frmTutor objTutorWindow = new frmTutor();
              objTutorWindow.IdSeleccionado = IdTutor;
              objTutorWindow.OpcionDeVisualizacion = 1; //Editar
              objTutorWindow.Owner = this;
              objTutorWindow.ShowDialog();
              objTutorWindow = null;
              this.Cursor = Cursors.Arrow;
              RecuperarTutor();
          }
      }

      private void cmdDetallesMadre_Click(object sender, RoutedEventArgs e)
      {
          if (IdMadre > 0)
          {
              this.Cursor = Cursors.Wait;
              frmMadre objMadreWindow = new frmMadre();
              objMadreWindow.IdSeleccionado = IdMadre;
              objMadreWindow.OpcionDeVisualizacion = 2; //Detalles
              objMadreWindow.Owner = this;
              objMadreWindow.ShowDialog();
              objMadreWindow = null;
              this.Cursor = Cursors.Arrow;
              RecuperarMadre();
          }
      }

      private void cmdModificarMadre_Click(object sender, RoutedEventArgs e)
      {
          if (IdMadre > 0)
          {
              this.Cursor = Cursors.Wait;
              frmMadre objMadreWindow = new frmMadre();
              objMadreWindow.IdSeleccionado = IdMadre;
              objMadreWindow.OpcionDeVisualizacion = 1;
              objMadreWindow.Owner = this;
              objMadreWindow.ShowDialog();
              objMadreWindow = null;
              this.Cursor = Cursors.Arrow;
              RecuperarMadre();
          }
      }

      private void cmdGuardar_Click(object sender, RoutedEventArgs e)
      {
          ModeloCorresponsabilidadMenor modelocorresponsabilidadmenor = new ModeloCorresponsabilidadMenor();
          CorresponsabilidadMenor corresponsabilidadmenor = new CorresponsabilidadMenor();

          corresponsabilidadmenor.IdEstablecimientoSalud = 1;
          if (rdbNuevo.IsChecked == true)
              corresponsabilidadmenor.TipoInscripcionMenor = TipoInscripcion.Nueva;
          else if (rdbTranferencia.IsChecked == true)
              corresponsabilidadmenor.TipoInscripcionMenor = TipoInscripcion.Transferencia;

          corresponsabilidadmenor.FechaInscripcion = dtpFechaInscripcion.SelectedDate.Value;
          corresponsabilidadmenor.IdMadre = 1; //IdMadre;
          corresponsabilidadmenor.IdTutor = 1; //IdTutor;
          corresponsabilidadmenor.CodigoFormulario = txtFormulario.Text;
          corresponsabilidadmenor.FechaSalidaPrograma = dtpFechaSalida.SelectedDate.Value;
          corresponsabilidadmenor.TipoSalidaMenor = 0;
          corresponsabilidadmenor.Observaciones = "";
          corresponsabilidadmenor.AutorizadoPor = txtAutorizado.Text;
          corresponsabilidadmenor.CargoAutorizador = txtCargo.Text;
          corresponsabilidadmenor.DireccionMadre = "";
          corresponsabilidadmenor.DireccionMenor = "";
          corresponsabilidadmenor.DireccionTutor = "";

          modelocorresponsabilidadmenor.Crear(corresponsabilidadmenor);
          IdSeleccionado = corresponsabilidadmenor.Id;

          //generamos los 6 registro de controles

          ModeloControlMenor modelocontrolmenor = new ModeloControlMenor();

          for (int i = 0; i < 12; i++)
          {
              ControlMenor controlmenor = new ControlMenor();
              controlmenor.IdCorresponsabilidadMenor = IdSeleccionado;
              controlmenor.IdMedico = 1;
              controlmenor.IdTutor = 1; //IdTutor;
              controlmenor.FechaProgramada = DateTime.Now;
              controlmenor.FechaControl = DateTime.Now;
              controlmenor.TallaCm = 0;
              controlmenor.PesoKg = 1;
              controlmenor.NumeroControl = i + 1;
              controlmenor.Observaciones = "";
              controlmenor.EstadoPago = TipoEstadoPago.NoPagado;
              controlmenor.TipoBeneficiario = TipoBeneficiario.Madre;
              modelocontrolmenor.Crear(controlmenor);
              IdControlMenor[i] = controlmenor.Id;
          }
      }

      private void cmdPrueba_Click(object sender, RoutedEventArgs e)
      {
          if (IdMenor>0)
          {
              DateTime fechitaControles;
              string strMesesProgramados = "";
              string strMesesPerdidos = "";

              fechitaControles = Convert.ToDateTime(lblFechaNacimientoMenor.Content);
              fechitaControles = fechitaControles.AddMonths(-1);
              for (int i = 0; i < 12; i++)
              {
                  fechitaControles = fechitaControles.AddMonths(2);
                  //strMesesProgramados += "01/" + fechitaControles.Month.ToString() + "/" + fechitaControles.Year.ToString() + "      "; FECHA COMPLETA
                  strMesesProgramados += string.Format("{0:MM/yyyy}", fechitaControles) + " ";

                  if ((fechitaControles.Month >= dtpFechaInscripcion.SelectedDate.Value.Month) && (fechitaControles.Year >= dtpFechaInscripcion.SelectedDate.Value.Year))
                  {
                      //strMesesPerdidos += fechitaControles.Date; FECHA COMPLETA
                      strMesesPerdidos += string.Format("{0:MM/yyyy}", fechitaControles) + " ";
                  }
              }
              lblFechas.Content = "Fechas: " + strMesesProgramados;
              lblMesesPerdidos.Content = "A Pagar: " + strMesesPerdidos;
          }
      }

  }
}
