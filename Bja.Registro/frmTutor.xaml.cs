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

        public frmTutor()
        {
            this.Cursor = Cursors.Wait;
            InitializeComponent();
            this.Cursor = Cursors.Arrow;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SoporteCombo.cargarEnumerador(cboTipoDocIde, typeof(TipoDocumentoIdentidad));
            SoporteCombo.cargarEnumerador(cboExpedido, typeof(Lugar));
            SoporteCombo.cargarEnumerador(cboParentesco, typeof(Parentesco));
            if (IdSeleccionado == 0)
            {
                this.cboTipoDocIde.SelectedIndex = 0;
                this.dtpFechaNacimiento.SelectedDate = DateTime.Today;
                this.cboExpedido.SelectedIndex = 0;
                this.cboParentesco.SelectedIndex = 0;
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
            //tutor.TipoDocumentoIdentidad = (TipoDocumentoIdentidad)cboTipoDocIde.SelectedValue;
            tutor.PrimerApellido = txtPaterno.Text;
            tutor.SegundoApellido = txtMaterno.Text;
            tutor.TercerApellido = txtConyuge.Text;
            tutor.Nombres = txtNombres.Text;
            tutor.FechaNacimiento = dtpFechaNacimiento.SelectedDate.Value;
            tutor.IdLocalidadNacimiento = txtLugarNacimiento.Text;
            tutor.Defuncion = (chkDefuncion.IsChecked == true) ? true : false;
            tutor.Observaciones = txtObservaciones.Text;
            if ((long)cboTipoDocIde.SelectedValue == 1)
                tutor.Sexo = "F";
            else if ((long)cboTipoDocIde.SelectedValue == 2)
                tutor.Sexo = "M";
            else
                tutor.Sexo = "-";

            modelotutor.Crear(tutor);

            this.Close();
        }
    }
}
