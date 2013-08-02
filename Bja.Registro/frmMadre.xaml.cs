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
        private int IdSeleccionado { get; set; }

        public frmMadre()
        {
            this.Cursor = Cursors.Wait;
            InitializeComponent();
            this.Cursor = Cursors.Arrow;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SoporteCombo.cargarEnumerador(cboTipoDocIde, typeof(TipoDocumentoIdentidad));
            this.cboTipoDocIde.SelectedIndex = 0;
            IdSeleccionado = 0;
            this.dtpFechaNacimiento.SelectedDate = DateTime.Today;
            string[] Cadena = new string[] { "<No Especificado>" };
            cboTutor.ItemsSource = Cadena;
            cboTutor.SelectedIndex = 0;
        }

        private void cmdAceptar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmdCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmdTutor_Click(object sender, RoutedEventArgs e)
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
            objTutorWindow.Owner = this;
            objTutorWindow.ShowDialog();
            objTutorWindow = null;
            this.Cursor = Cursors.Arrow;
        }

        void formularioListaTutores_MostrarDetallesRegistro(object sender, IdentidadEventArgs fe)
        {
            throw new NotImplementedException();
        }

        void formularioListaTutores_ModificarRegistro(object sender, IdentidadEventArgs fe)
        {
            throw new NotImplementedException();
        }

        void formularioListaTutores_BorrarRegistro(object sender, IdentidadEventArgs fe)
        {
            throw new NotImplementedException();
        }

        void formularioListaTutores_SeleccionarRegistro(object sender, IdentidadEventArgs fe)
        {
            throw new NotImplementedException();
        }

    }
}
