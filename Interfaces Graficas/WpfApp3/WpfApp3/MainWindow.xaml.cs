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

namespace WpfApp3
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int num_puntos = (int) lienzo.ActualWidth;
            Polyline p = new Polyline();
            PointCollection puntos = new PointCollection();
            float xminreal = -10, xmaxreal = 10;
            float yminreal = -10, ymaxreal = 110;
            float xreal, yreal,xpant,ypant;
            float xpantmax = num_puntos, xpantmin = 0, ypantmax = (float) lienzo.ActualHeight, ypantmin = 0;

            for (int i=0; i<num_puntos; i++)
            {
                xreal =xminreal+i*(xmaxreal - xminreal)/num_puntos;
                yreal =xreal*xreal;
                xpant =(xpantmax-xpantmin)* (xreal-xminreal)/(xmaxreal-xminreal) + xpantmin;
                ypant = (ypantmin - ypantmax) * (yreal - yminreal) / (ymaxreal - yminreal) + ypantmax;
                //xreal = (xmaxreal - xminreal) * (xpant - xpantmin) / (xpantmax - xpantmin) + xminreal;
                Point pt = new Point(xpant,ypant);
                puntos.Add(pt);
            }
            p.Points = puntos;
            p.Stroke = Brushes.Red;
            p.StrokeThickness = 4;
            lienzo.Children.Add(p);
        }
    }
}
