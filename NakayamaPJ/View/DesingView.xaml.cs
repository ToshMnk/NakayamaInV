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

namespace NakayamaPJ.View
{
    /// <summary>
    /// Lógica de interacción para DesingView.xaml
    /// </summary>
    public partial class DesingView : UserControl
    {
        public DesingView()
        {
            InitializeComponent();
        }

        private void Bordado_Checked(object sender, RoutedEventArgs e)
        {
            // Verifica el estado del CheckBox y obtiene 1 si está marcado, 0 si no lo está
            int valor = Bordado.IsChecked == true ? 1 : 0;

            // Llamar al método para enviar el valor a la base de datos
        }


    }

}
