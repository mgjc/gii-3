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
using System.Collections.Generic;
using System.Data;
using System;

namespace WpfApp2
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

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            RotateTransform rt;
            rt = (RotateTransform)rec.RenderTransform;
            rt.Angle += 10;
        }

        private void Window_Key(object sender, KeyEventArgs e)
        {
            /*  Primera opcion, esta bien, aunque no se recomienda hacer el ToString con el Equals
            if (e.Key.ToString().Equals("Up"))
            {
                if (Grid.GetRow(rec) == 0) return;
                Grid.SetRow(rec, Grid.GetRow(rec) - 1);
            }

            if (e.Key.ToString().Equals("Left"))
            {
                if (Grid.GetColumn(rec) == 0) return;
                Grid.SetColumn(rec, Grid.GetColumn(rec) - 1);
            }
            if (e.Key.ToString().Equals("Down") && Grid.GetRow(rec) < 7)
                Grid.SetRow(rec, Grid.GetRow(rec) + 1);

            if (e.Key.ToString().Equals("Right") && Grid.GetColumn(rec) < 7)
                Grid.SetColumn(rec, Grid.GetColumn(rec) + 1);


            grid.columnDefinition.Count     //aqui habria que darle nombre el Grid, en este caso se llama tambien grid, pero ne minuscula
            */
            switch (e.Key)
            {
                case Key.Down:
                    if (Grid.GetRow(rec) == 7) return;
                    Grid.SetRow(rec, Grid.GetRow(rec) + 1);
                    break;
                case Key.Up:
                    if (Grid.GetRow(rec) == 0) return;
                    Grid.SetRow(rec, Grid.GetRow(rec) - 1);
                    break;
                case Key.Left:
                    if (Grid.GetColumn(rec) == 0) return;
                    Grid.SetColumn(rec, Grid.GetColumn(rec) - 1);
                    break;
                case Key.Right:
                    if (Grid.GetColumn(rec) == 7) return;
                    Grid.SetColumn(rec, Grid.GetColumn(rec) + 1);
                    break;
            }

        }

        
    }
        
}
