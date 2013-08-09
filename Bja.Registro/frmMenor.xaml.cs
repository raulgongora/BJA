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
        public long IdSeleccionado { get; set; }
        public int OpcionDeVisualizacion { get; set; }

        public frmMenor()
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
                ModeloMenor modelomenor = new ModeloMenor();
                Menor menor = new Menor();
                menor = modelomenor.Recuperar(IdSeleccionado);
                txtDocIde.Text = menor.DocumentoIdentidad;
                cboTipoDocIde.SelectedIndex = (int)menor.IdTipoDocumentoIdentidad;
                txtPaterno.Text = menor.PrimerApellido;
                txtMaterno.Text = menor.SegundoApellido;
                txtNombres.Text = menor.Nombres;
                if (menor.Sexo == "F")
                    rdbFemenino.IsChecked = true;
                else if (menor.Sexo == "M")
                    rdbMasculino.IsChecked = true;
                dtpFechaNacimiento.SelectedDate = menor.FechaNacimiento;
                if (menor.Defuncion == true)
                    chkDefuncion.IsChecked = true;
                txtLugarNacimiento.Text = menor.IdLocalidadNacimiento;
                txtObservaciones.Text = menor.Observaciones;
            }
        }

        private void cmdAceptar_Click(object sender, RoutedEventArgs e)
        {
            ModeloMenor modelomenor = new ModeloMenor();

            Menor menor = new Menor();

            menor.DocumentoIdentidad = txtDocIde.Text;
            menor.IdTipoDocumentoIdentidad = (long)cboTipoDocIde.SelectedValue;
            menor.PrimerApellido = txtPaterno.Text;
            menor.SegundoApellido = txtMaterno.Text;
            menor.Nombres = txtNombres.Text;
            menor.FechaNacimiento = dtpFechaNacimiento.SelectedDate.Value;
            menor.IdLocalidadNacimiento = txtLugarNacimiento.Text;
            menor.Defuncion = (chkDefuncion.IsChecked == true) ? true : false;
            menor.Observaciones = txtObservaciones.Text;
            if (rdbFemenino.IsChecked == true)
                menor.Sexo = "F";
            else if (rdbFemenino.IsChecked == false)
                menor.Sexo = "M";
            else
                menor.Sexo = "-";

            if (IdSeleccionado > 0)
                modelomenor.Editar(IdSeleccionado, menor);
            else
                modelomenor.Crear(menor);

            this.Close();
        }

        private void cmdCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
