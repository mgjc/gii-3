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

namespace Trabajo
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        
        private void Fun1C_Click(object sender, RoutedEventArgs e)
        {
            if (VarA1.Visibility == Visibility.Hidden)
            {
                VarA1.Visibility = Visibility.Visible;
                VarB1.Visibility = Visibility.Visible;
                Nomb1.Visibility = Visibility.Visible;

                VarA2.Visibility = Visibility.Hidden;
                VarB2.Visibility = Visibility.Hidden;
                Nomb2.Visibility = Visibility.Hidden;
                VarA3.Visibility = Visibility.Hidden;
                VarB3.Visibility = Visibility.Hidden;
                Nomb3.Visibility = Visibility.Hidden;
                VarA4.Visibility = Visibility.Hidden;
                VarB4.Visibility = Visibility.Hidden;
                Nomb4.Visibility = Visibility.Hidden;
                VarA5.Visibility = Visibility.Hidden;
                VarB5.Visibility = Visibility.Hidden;
                VarC5.Visibility = Visibility.Hidden;
                Nomb5.Visibility = Visibility.Hidden;
                VarA6.Visibility = Visibility.Hidden;
                VarB6.Visibility = Visibility.Hidden;
                Nomb6.Visibility = Visibility.Hidden;
                this.VarA2.Text = "a";
                this.VarB2.Text = "b";
                this.VarA3.Text = "a";
                this.VarB3.Text = "b";
                this.VarA4.Text = "a";
                this.VarB4.Text = "b";
                this.VarA5.Text = "a";
                this.VarB5.Text = "b";
                this.VarC5.Text = "c";
                this.VarA6.Text = "a";
                this.VarB6.Text = "b";
                this.Nomb2.Text = "Nombre";
                this.Nomb3.Text = "Nombre";
                this.Nomb4.Text = "Nombre";
                this.Nomb5.Text = "Nombre";
                this.Nomb6.Text = "Nombre";
            }
            else
            {
                VarA1.Visibility = Visibility.Hidden;
                VarB1.Visibility = Visibility.Hidden;
                Nomb1.Visibility = Visibility.Hidden;
            }
        }

        private void Fun2C_Click(object sender, RoutedEventArgs e)
        {
            if (VarA2.Visibility == Visibility.Hidden)
            {
                VarA2.Visibility = Visibility.Visible;
                VarB2.Visibility = Visibility.Visible;
                Nomb2.Visibility = Visibility.Visible;


                VarA1.Visibility = Visibility.Hidden;
                VarB1.Visibility = Visibility.Hidden;
                Nomb1.Visibility = Visibility.Hidden;
                VarA3.Visibility = Visibility.Hidden;
                VarB3.Visibility = Visibility.Hidden;
                Nomb3.Visibility = Visibility.Hidden;
                VarA4.Visibility = Visibility.Hidden;
                VarB4.Visibility = Visibility.Hidden;
                Nomb4.Visibility = Visibility.Hidden;
                VarA5.Visibility = Visibility.Hidden;
                VarB5.Visibility = Visibility.Hidden;
                VarC5.Visibility = Visibility.Hidden;
                Nomb5.Visibility = Visibility.Hidden;
                VarA6.Visibility = Visibility.Hidden;
                VarB6.Visibility = Visibility.Hidden;
                Nomb6.Visibility = Visibility.Hidden;
                this.VarA1.Text = "a";
                this.VarB1.Text = "b";
                this.VarA3.Text = "a";
                this.VarB3.Text = "b";
                this.VarA4.Text = "a";
                this.VarB4.Text = "b";
                this.VarA5.Text = "a";
                this.VarB5.Text = "b";
                this.VarC5.Text = "c";
                this.VarA6.Text = "a";
                this.VarB6.Text = "b";
                this.Nomb1.Text = "Nombre";
                this.Nomb3.Text = "Nombre";
                this.Nomb4.Text = "Nombre";
                this.Nomb5.Text = "Nombre";
                this.Nomb6.Text = "Nombre";

            }
            else
            {
                VarA2.Visibility = Visibility.Hidden;
                VarB2.Visibility = Visibility.Hidden;
                Nomb2.Visibility = Visibility.Hidden;
            }
        }

        private void Fun3C_Click(object sender, RoutedEventArgs e)
        {
            if (VarA3.Visibility == Visibility.Hidden)
            {
                VarA3.Visibility = Visibility.Visible;
                VarB3.Visibility = Visibility.Visible;
                Nomb3.Visibility = Visibility.Visible;

                VarA1.Visibility = Visibility.Hidden;
                VarB1.Visibility = Visibility.Hidden;
                Nomb1.Visibility = Visibility.Hidden;
                VarA2.Visibility = Visibility.Hidden;
                VarB2.Visibility = Visibility.Hidden;
                Nomb2.Visibility = Visibility.Hidden;
                VarA4.Visibility = Visibility.Hidden;
                VarB4.Visibility = Visibility.Hidden;
                Nomb4.Visibility = Visibility.Hidden;
                VarA5.Visibility = Visibility.Hidden;
                VarB5.Visibility = Visibility.Hidden;
                VarC5.Visibility = Visibility.Hidden;
                Nomb5.Visibility = Visibility.Hidden;
                VarA6.Visibility = Visibility.Hidden;
                VarB6.Visibility = Visibility.Hidden;
                Nomb6.Visibility = Visibility.Hidden;
                this.VarA1.Text = "a";
                this.VarB1.Text = "b";
                this.VarA2.Text = "a";
                this.VarB2.Text = "b";
                this.VarA4.Text = "a";
                this.VarB4.Text = "b";
                this.VarA5.Text = "a";
                this.VarB5.Text = "b";
                this.VarC5.Text = "c";
                this.VarA6.Text = "a";
                this.VarB6.Text = "b";
                this.Nomb1.Text = "Nombre";
                this.Nomb2.Text = "Nombre";
                this.Nomb4.Text = "Nombre";
                this.Nomb5.Text = "Nombre";
                this.Nomb6.Text = "Nombre";

            }
            else
            {
                VarA3.Visibility = Visibility.Hidden;
                VarB3.Visibility = Visibility.Hidden;
                Nomb3.Visibility = Visibility.Hidden;
            }
        }

        private void Fun4C_Click(object sender, RoutedEventArgs e)
        {
            if (VarA4.Visibility == Visibility.Hidden)
            {
                VarA4.Visibility = Visibility.Visible;
                VarB4.Visibility = Visibility.Visible;
                Nomb4.Visibility = Visibility.Visible;

                VarA1.Visibility = Visibility.Hidden;
                VarB1.Visibility = Visibility.Hidden;
                Nomb1.Visibility = Visibility.Hidden;
                VarA2.Visibility = Visibility.Hidden;
                VarB2.Visibility = Visibility.Hidden;
                Nomb2.Visibility = Visibility.Hidden;
                VarA3.Visibility = Visibility.Hidden;
                VarB3.Visibility = Visibility.Hidden;
                Nomb3.Visibility = Visibility.Hidden;
                VarA5.Visibility = Visibility.Hidden;
                VarB5.Visibility = Visibility.Hidden;
                VarC5.Visibility = Visibility.Hidden;
                Nomb5.Visibility = Visibility.Hidden;
                VarA6.Visibility = Visibility.Hidden;
                VarB6.Visibility = Visibility.Hidden;
                Nomb6.Visibility = Visibility.Hidden;
                this.VarA1.Text = "a";
                this.VarB1.Text = "b";
                this.VarA2.Text = "a";
                this.VarB2.Text = "b";
                this.VarA3.Text = "a";
                this.VarB3.Text = "b";
                this.VarA5.Text = "a";
                this.VarB5.Text = "b";
                this.VarC5.Text = "c";
                this.VarA6.Text = "a";
                this.VarB6.Text = "b";
                this.Nomb1.Text = "Nombre";
                this.Nomb2.Text = "Nombre";
                this.Nomb3.Text = "Nombre";
                this.Nomb5.Text = "Nombre";
                this.Nomb6.Text = "Nombre";

            }
            else
            {
                VarA4.Visibility = Visibility.Hidden;
                VarB4.Visibility = Visibility.Hidden;
                Nomb4.Visibility = Visibility.Hidden;
            }
        }

        private void Fun5C_Click(object sender, RoutedEventArgs e)
        {
            if (VarA5.Visibility == Visibility.Hidden)
            {
                VarA5.Visibility = Visibility.Visible;
                VarB5.Visibility = Visibility.Visible;
                VarC5.Visibility = Visibility.Visible;
                Nomb5.Visibility = Visibility.Visible;


                VarA1.Visibility = Visibility.Hidden;
                VarB1.Visibility = Visibility.Hidden;
                Nomb1.Visibility = Visibility.Hidden;
                VarA2.Visibility = Visibility.Hidden;
                VarB2.Visibility = Visibility.Hidden;
                Nomb2.Visibility = Visibility.Hidden;
                VarA3.Visibility = Visibility.Hidden;
                VarB3.Visibility = Visibility.Hidden;
                Nomb3.Visibility = Visibility.Hidden;
                VarA4.Visibility = Visibility.Hidden;
                VarB4.Visibility = Visibility.Hidden;
                Nomb4.Visibility = Visibility.Hidden;
                VarA6.Visibility = Visibility.Hidden;
                VarB6.Visibility = Visibility.Hidden;
                Nomb6.Visibility = Visibility.Hidden;
                this.VarA1.Text = "a";
                this.VarB1.Text = "b";
                this.VarA2.Text = "a";
                this.VarB2.Text = "b";
                this.VarA3.Text = "a";
                this.VarB3.Text = "b";
                this.VarA4.Text = "a";
                this.VarB4.Text = "b";
                this.VarA6.Text = "a";
                this.VarB6.Text = "b";
                this.Nomb1.Text = "Nombre";
                this.Nomb2.Text = "Nombre";
                this.Nomb3.Text = "Nombre";
                this.Nomb4.Text = "Nombre";
                this.Nomb6.Text = "Nombre";

            }
            else
            {
                VarA5.Visibility = Visibility.Hidden;
                VarB5.Visibility = Visibility.Hidden;
                VarC5.Visibility = Visibility.Hidden;
                Nomb5.Visibility = Visibility.Hidden;
            }
        }

        private void Fun6C_Click(object sender, RoutedEventArgs e)
        {
            if (VarA6.Visibility == Visibility.Hidden)
            {
                VarA6.Visibility = Visibility.Visible;
                VarB6.Visibility = Visibility.Visible;
                Nomb6.Visibility = Visibility.Visible;

                VarA1.Visibility = Visibility.Hidden;
                VarB1.Visibility = Visibility.Hidden;
                Nomb1.Visibility = Visibility.Hidden;
                VarA2.Visibility = Visibility.Hidden;
                VarB2.Visibility = Visibility.Hidden;
                Nomb2.Visibility = Visibility.Hidden;
                VarA3.Visibility = Visibility.Hidden;
                VarB3.Visibility = Visibility.Hidden;
                Nomb3.Visibility = Visibility.Hidden;
                VarA4.Visibility = Visibility.Hidden;
                VarB4.Visibility = Visibility.Hidden;
                Nomb4.Visibility = Visibility.Hidden;
                VarA5.Visibility = Visibility.Hidden;
                VarB5.Visibility = Visibility.Hidden;
                VarC5.Visibility = Visibility.Hidden;
                Nomb5.Visibility = Visibility.Hidden;
                this.VarA1.Text = "a";
                this.VarB1.Text = "b";
                this.VarA2.Text = "a";
                this.VarB2.Text = "b";
                this.VarA3.Text = "a";
                this.VarB3.Text = "b";
                this.VarA4.Text = "a";
                this.VarB4.Text = "b";
                this.VarA5.Text = "a";
                this.VarB5.Text = "b";
                this.VarC5.Text = "c";
                this.Nomb1.Text = "Nombre";
                this.Nomb2.Text = "Nombre";
                this.Nomb3.Text = "Nombre";
                this.Nomb4.Text = "Nombre";
                this.Nomb5.Text = "Nombre";


            }
            else
            {
                VarA6.Visibility = Visibility.Hidden;
                VarB6.Visibility = Visibility.Hidden;
                Nomb6.Visibility = Visibility.Hidden;
            }
        }

        private void VarA1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            VarA1.Text = "";
        }

        private void VarB1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            VarB1.Text = "";
        }

        private void VarA2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            VarA2.Text = "";
        }

        private void VarB2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            VarB2.Text = "";
        }

        private void VarA3_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            VarA3.Text = "";
        }

        private void VarB3_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            VarB3.Text = "";
        }

        private void VarA4_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            VarA4.Text = "";
        }

        private void VarB4_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            VarB4.Text = "";
        }

        private void VarA5_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            VarA5.Text = "";
        }

        private void VarB5_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            VarB5.Text = "";
        }

        private void VarC5_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            VarC5.Text = "";
        }

        private void VarA6_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            VarA6.Text = "";
        }

        private void VarB6_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            VarB6.Text = "";
        }

        private void Nomb1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Nomb1.Text = "";
        }

        private void Nomb2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Nomb2.Text = "";
        }

        private void Nomb3_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Nomb3.Text = "";
        }

        private void Nomb4_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Nomb4.Text = "";
        }

        private void Nomb5_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Nomb5.Text = "";
        }

        private void Nomb6_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Nomb6.Text = "";
        }

        private void Incluye_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
