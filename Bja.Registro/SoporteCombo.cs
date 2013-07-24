using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Bja.Registro
{
    public class SoporteCombo
    {
        /// <summary>
        /// Carga datos de enumerador en combo especificado
        /// </summary>
        /// <param name="combo">Combo en el que se cargan los datos del enumerador</param>
        /// <param name="tipoEnumerador">Tipo del enumerador</param>
        public static void cargarEnumerador(ComboBox combo, Type tipoEnumerador)
        {
            String[] nombres = Enum.GetNames(tipoEnumerador);

            foreach (var item in nombres)
            {
                var idEnum = Enum.Parse(tipoEnumerador, item);
                combo.Items.Add(new ItemCombo() { id = (Int32)idEnum, descripcion = item });//
            }

            combo.DisplayMemberPath = "descripcion";
            combo.SelectedValuePath = "id";
        }
    }
}
