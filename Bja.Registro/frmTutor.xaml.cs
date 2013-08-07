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
    /// Lógica de interacción para frmTutor.xaml
    /// </summary>
    public partial class frmTutor : Window
    {
        public long IdSeleccionado { get; set; }
        public int OpcionDeVisualizacion { get; set; }

        public frmTutor()
        {
            this.Cursor = Cursors.Wait;
            InitializeComponent();
            this.Cursor = Cursors.Arrow;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SoporteCombo.cargarEnumerador(cboTipoDocIde, typeof(TipoDocumentoIdentidad));
            if (IdSeleccionado == 0)
            {
                this.cboTipoDocIde.SelectedIndex = 0;
                this.dtpFechaNacimiento.SelectedDate = DateTime.Today;
            }
            else
            {
                ModeloTutor modelotutor = new ModeloTutor();
                Tutor tutor = new Tutor();
                tutor = modelotutor.Recuperar(IdSeleccionado);
                txtDocIde.Text = tutor.DocumentoIdentidad;
                cboTipoDocIde.SelectedIndex = (int)tutor.IdTipoDocumentoIdentidad;
                txtPaterno.Text = tutor.PrimerApellido;
                txtMaterno.Text = tutor.SegundoApellido;
                txtNombres.Text = tutor.Nombres;
                dtpFechaNacimiento.SelectedDate = tutor.FechaNacimiento;
                if (tutor.Sexo == "F")
                    rdbFemenino.IsChecked = true;
                else if (tutor.Sexo == "M")
                    rdbMasculino.IsChecked = true;
                if (tutor.Defuncion == true)
                    chkDefuncion.IsChecked = true;
                txtLugarNacimiento.Text = tutor.IdLocalidadNacimiento;
                txtObservaciones.Text = tutor.Observaciones;
                if (OpcionDeVisualizacion == 2)
                {
                    txtDocIde.IsEnabled = false;
                    cboTipoDocIde.IsEnabled = false;
                    txtPaterno.IsEnabled = false;
                    txtMaterno.IsEnabled = false;
                    txtConyuge.IsEnabled = false;
                    txtNombres.IsEnabled = false;
                    dtpFechaNacimiento.IsEnabled = false;
                    rdbFemenino.IsEnabled = false;
                    rdbMasculino.IsEnabled = false;
                    chkDefuncion.IsEnabled = false;
                    txtLugarNacimiento.IsEnabled = false;
                    txtObservaciones.IsEnabled = false;
                    cmdAceptar.IsEnabled = false;
                }
            }
        }

        private void cmdCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmdAceptar_Click(object sender, RoutedEventArgs e)
        {
            ModeloTutor modelotutor = new ModeloTutor();

            Tutor tutor = new Tutor();

            tutor.DocumentoIdentidad = txtDocIde.Text;
            tutor.IdTipoDocumentoIdentidad = (long)cboTipoDocIde.SelectedValue;
            tutor.PrimerApellido = txtPaterno.Text;
            tutor.SegundoApellido = txtMaterno.Text;
            tutor.TercerApellido = txtConyuge.Text;
            tutor.Nombres = txtNombres.Text;
            tutor.FechaNacimiento = dtpFechaNacimiento.SelectedDate.Value;
            tutor.IdLocalidadNacimiento = txtLugarNacimiento.Text;
            tutor.Defuncion = (chkDefuncion.IsChecked == true) ? true : false;
            tutor.Observaciones = txtObservaciones.Text;
            if (rdbFemenino.IsChecked == true)
                tutor.Sexo = "F";
            else if (rdbFemenino.IsChecked == false)
                tutor.Sexo = "M";
            else
                tutor.Sexo = "-";

            if (IdSeleccionado > 0)
                modelotutor.Editar(IdSeleccionado, tutor);
            else
                modelotutor.Crear(tutor);

            this.Close();
        }
    }
}
