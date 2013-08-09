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
    /// Lógica de interacción para frmControl.xaml
    /// </summary>
    public partial class frmControl : Window
    {
        public long IdSeleccionado { get; set; }
        public bool Tipo { get; set; }
        public long IdMedico { get; set; }
        public long IdMadre { get; set; }
        public long IdMenor { get; set; }
        public long IdTutor { get; set; }
        public int OpcionDeVisualizacion { get; set; }

        public frmControl()
        {
            this.Cursor = Cursors.Wait;
            InitializeComponent();
            this.Cursor = Cursors.Arrow;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (IdSeleccionado > 0)
            {
                if (Tipo == false)
                {
                    ModeloControlMadre modelocontrolmadre = new ModeloControlMadre();
                    ControlMadre controlmadre = new ControlMadre();
                    
                    IdMadre = IdSeleccionado;

                    controlmadre = modelocontrolmadre.Recuperar(IdSeleccionado);
                    dtpFechaProgramada.SelectedDate = controlmadre.FechaProgramada;
                    txtPeso.Text = Convert.ToString(controlmadre.PesoKg);
                    txtTalla.Text = Convert.ToString(controlmadre.TallaCm);
                    dtpFechaControl.SelectedDate = controlmadre.FechaControl;
                    lblNumeroControl.Content = controlmadre.NumeroControl;
                    IdTutor = controlmadre.IdTutor;
                    if (controlmadre.IdTutor > 0)
                        rdbTutor.IsChecked = true;
                    else
                        rdbMadre.IsChecked = true;
                    IdMedico = controlmadre.IdMedico;
                }
                else
                {
                    ModeloControlMenor modelocontrolmenor = new ModeloControlMenor();
                    ControlMenor controlmenor = new ControlMenor();

                    IdMenor = IdSeleccionado;

                    controlmenor = modelocontrolmenor.Recuperar(IdSeleccionado);
                    dtpFechaProgramada.SelectedDate = controlmenor.FechaProgramada;
                    txtPeso.Text = Convert.ToString(controlmenor.PesoKg);
                    txtTalla.Text = Convert.ToString(controlmenor.TallaCm);
                    dtpFechaControl.SelectedDate = controlmenor.FechaControl;
                    lblNumeroControl.Content = controlmenor.NumeroControl;
                    IdTutor = controlmenor.IdTutor;
                    IdMadre = controlmenor.IdMadre;
                    if (controlmenor.IdTutor > 0)
                        rdbTutor.IsChecked = true;
                    else
                        rdbMadre.IsChecked = true;
                    IdMedico = controlmenor.IdMedico;
                }
            }
        }

        private void cmdAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (Tipo == false)
            {
                ModeloControlMadre modelocontrolmadre = new ModeloControlMadre();

                ControlMadre controlmadre = new ControlMadre();

                controlmadre.FechaProgramada = dtpFechaProgramada.SelectedDate.Value;
                controlmadre.PesoKg = Convert.ToSingle(txtPeso.Text);
                controlmadre.TallaCm = Convert.ToInt32(txtTalla.Text);
                controlmadre.FechaControl = dtpFechaControl.SelectedDate.Value;

                modelocontrolmadre.Editar(IdMadre, controlmadre);
            }
            else
            {
                ModeloControlMenor modelocontrolmenor = new ModeloControlMenor();

                ControlMenor controlmenor = new ControlMenor();

                controlmenor.FechaProgramada = dtpFechaProgramada.SelectedDate.Value;
                controlmenor.PesoKg = Convert.ToSingle(txtPeso.Text);
                controlmenor.TallaCm = Convert.ToInt32(txtTalla.Text);
                controlmenor.FechaControl = dtpFechaControl.SelectedDate.Value;

                modelocontrolmenor.Editar(IdMadre, controlmenor);
            }

            this.Close();
        }

        private void cmdCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
