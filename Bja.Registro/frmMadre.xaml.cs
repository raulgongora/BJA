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
    /// Lógica de interacción para frmMadre.xaml
    /// </summary>
    public partial class frmMadre : Window
    {
        public long IdSeleccionado { get; set; }
        public int OpcionDeVisualizacion { get; set; }

        public frmMadre()
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
                ModeloMadre modelomadre = new ModeloMadre();
                Madre madre = new Madre();
                madre = modelomadre.Recuperar(IdSeleccionado);
                txtDocIde.Text = madre.DocumentoIdentidad;
                cboTipoDocIde.SelectedIndex = (int)madre.IdTipoDocumentoIdentidad;
                txtPaterno.Text = madre.PrimerApellido;
                txtMaterno.Text = madre.SegundoApellido;
                txtNombres.Text = madre.Nombres;
                dtpFechaNacimiento.SelectedDate = madre.FechaNacimiento;
                if (madre.Defuncion == true)
                    chkDefuncion.IsChecked = true;
                txtLugarNacimiento.Text = madre.IdLocalidadNacimiento;
                txtObservaciones.Text = madre.Observaciones;
                if (OpcionDeVisualizacion == 2)
                {
                    txtDocIde.IsEnabled = false;
                    cboTipoDocIde.IsEnabled = false;
                    txtPaterno.IsEnabled = false;
                    txtMaterno.IsEnabled = false;
                    txtConyuge.IsEnabled = false;
                    txtNombres.IsEnabled = false;
                    dtpFechaNacimiento.IsEnabled = false;
                    chkDefuncion.IsEnabled = false;
                    txtLugarNacimiento.IsEnabled = false;
                    txtObservaciones.IsEnabled = false;
                    cmdAceptar.IsEnabled = false;
                }
            }
        }

        private void cmdAceptar_Click(object sender, RoutedEventArgs e)
        {
            ModeloMadre modelomadre = new ModeloMadre();

            Madre madre = new Madre();

            madre.DocumentoIdentidad = txtDocIde.Text;
            madre.IdTipoDocumentoIdentidad = (long)cboTipoDocIde.SelectedValue;
            madre.PrimerApellido = txtPaterno.Text;
            madre.SegundoApellido = txtMaterno.Text;
            madre.TercerApellido = txtConyuge.Text;
            madre.Nombres = txtNombres.Text;
            madre.FechaNacimiento = dtpFechaNacimiento.SelectedDate.Value;
            madre.IdLocalidadNacimiento = txtLugarNacimiento.Text;
            madre.Defuncion = (chkDefuncion.IsChecked == true) ? true : false;
            madre.Observaciones = txtObservaciones.Text;

            if (IdSeleccionado > 0)
                modelomadre.Editar(IdSeleccionado, madre);
            else
                modelomadre.Crear(madre);

            this.Close();
        }

        private void cmdCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
