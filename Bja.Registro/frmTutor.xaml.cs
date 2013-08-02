﻿using Bja.Entidades;
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
        private int IdSeleccionado { get; set; }

        public frmTutor()
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
            SoporteCombo.cargarEnumerador(cboExpedido, typeof(Lugar));
            this.cboExpedido.SelectedIndex = 0;
            SoporteCombo.cargarEnumerador(cboParentesco, typeof(Parentesco));
            this.cboParentesco.SelectedIndex = 0;
        }

        private void cmdCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmdAceptar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
