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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bja.Registro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            InicializacionBD.inicializarBD();


            //login
            LoginWindow login = new LoginWindow();

            login.ShowDialog();

            if (login.logeado)
            {
                //inicia session
                SessionManager.initSession(login.user);
            }
            else
            {
                //terminar aplicación
                this.Close();
            }
        }

        #region Lista Madre
        private void btnMadre_Click(object sender, RoutedEventArgs e)
        {
            WindowListaRegistros ventanaListaMadres = new WindowListaRegistros();

            ventanaListaMadres.NuevoRegistro += ventanaListaMadres_NuevoRegistro;
            ventanaListaMadres.MostrarDetallesRegistro += ventanaListaMadres_MostrarDetallesRegistro;
            ventanaListaMadres.ModificarRegistro += ventanaListaMadres_ModificarRegistro;
            ventanaListaMadres.BorrarRegistro += ventanaListaMadres_BorrarRegistro;

            ModeloMadre modelo = new ModeloMadre();

            ventanaListaMadres.proveedorDatos = modelo;
            ventanaListaMadres.titulo = "Lista de madres";
            ventanaListaMadres.ShowDialog();
        }

        void ventanaListaMadres_ModificarRegistro(object sender, IdentidadEventArgs fe)
        {
            /*
             * Mostrar ventana de mantenimiento
             WindowNuevoConvenioMantenimiento wcm = new WindowNuevoConvenioMantenimiento();
            wcm.idConvenioMantenimiento = fe.id;
            wcm.accionVentana = Perseve.Admedif.Entidades.EnumAccionVentana.Modificar;
            wcm.ShowDialog();
             * * 
             */
            throw new NotImplementedException();
        }

        void ventanaListaMadres_BorrarRegistro(object sender, IdentidadEventArgs fe)
        {
            throw new NotImplementedException();
        }

        void ventanaListaMadres_MostrarDetallesRegistro(object sender, IdentidadEventArgs fe)
        {
            throw new NotImplementedException();
        }

        void ventanaListaMadres_NuevoRegistro(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        private void Window_Closed_1(object sender, EventArgs e)
        {
            SessionManager.endSession();
        }

    }
}
