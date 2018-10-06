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

        //https://www.wpf-tutorial.com/es/45/dialogos/el-messagebox-la-caja-de-mensajes/

namespace Trabajo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            Window win = new Window();
            win.Title = "Primer Programa";
            Label lb = new Label();
            lb.Content = "hola";
            win.Content = lb;
            win.Show();

            EtiquetaGra.Visibility = Visibility.Visible;
            win.Close();
            Window1 w = new Window1();

            w.Show();
            
            return;
        }

        // Funcion para cambiar la visibilidad de las funciones
        public void Visibilidad_Parametros(CheckBox cb, Visibility v)
        {
            
        }

        public void Visibilidad_Botones(Button bt, Visibility v)
        {

        }

    }
}
