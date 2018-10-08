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
using System.Text.RegularExpressions;

namespace Trabajo
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        int funcionSeleccionada = 0;
        bool nomb_func = false, a=false, b=false, c=false;

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
                funcionSeleccionada = 1;
                OcultaFunc2();
                OcultaFunc3();
                OcultaFunc4();
                OcultaFunc5();
                OcultaFunc6();
            }
            else
            {
                OcultaFunc1();
            }
        }

        private void Fun2C_Click(object sender, RoutedEventArgs e)
        {
            if (VarA2.Visibility == Visibility.Hidden)
            {
                VarA2.Visibility = Visibility.Visible;
                VarB2.Visibility = Visibility.Visible;
                Nomb2.Visibility = Visibility.Visible;
                funcionSeleccionada = 2;
                OcultaFunc1();
                OcultaFunc3();
                OcultaFunc4();
                OcultaFunc5();
                OcultaFunc6();
            }
            else
            {
                OcultaFunc2();
            }
        }

        private void Fun3C_Click(object sender, RoutedEventArgs e)
        {
            if (VarA3.Visibility == Visibility.Hidden)
            {
                VarA3.Visibility = Visibility.Visible;
                VarB3.Visibility = Visibility.Visible;
                Nomb3.Visibility = Visibility.Visible;
                funcionSeleccionada = 3;
                OcultaFunc1();
                OcultaFunc2();
                OcultaFunc4();
                OcultaFunc5();
                OcultaFunc6();
            }
            else
            {
                OcultaFunc3();
            }
        }

        private void Fun4C_Click(object sender, RoutedEventArgs e)
        {
            if (VarA4.Visibility == Visibility.Hidden)
            {
                VarA4.Visibility = Visibility.Visible;
                VarB4.Visibility = Visibility.Visible;
                Nomb4.Visibility = Visibility.Visible;
                funcionSeleccionada = 4;
                OcultaFunc1();
                OcultaFunc2();
                OcultaFunc3();
                OcultaFunc5();
                OcultaFunc6();
            }
            else
            {
                OcultaFunc4();
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
                funcionSeleccionada = 5;
                OcultaFunc1();
                OcultaFunc2();
                OcultaFunc3();
                OcultaFunc4();
                OcultaFunc6();
            }
            else
            {
                OcultaFunc5();
            }
        }

        private void Fun6C_Click(object sender, RoutedEventArgs e)
        {
            if (VarA6.Visibility == Visibility.Hidden)
            {
                VarA6.Visibility = Visibility.Visible;
                VarB6.Visibility = Visibility.Visible;
                Nomb6.Visibility = Visibility.Visible;
                funcionSeleccionada = 6;
                OcultaFunc1();
                OcultaFunc2();
                OcultaFunc3();
                OcultaFunc4();
                OcultaFunc5();
            }
            else
            {
                OcultaFunc6();
            }
        }

        private void Incluye_Click(object sender, RoutedEventArgs e)
        {

            string verifica = "^[0-9]";

            if (funcionSeleccionada == 0)
                MessageBox.Show("Elige una expresion, pon los parametros y el color");
            switch (funcionSeleccionada)
            {
                case 1:
                    a = Regex.IsMatch(VarA1.Text.ToString(), verifica);
                    b = Regex.IsMatch(VarB1.Text.ToString(), verifica);
                    nomb_func =string.IsNullOrEmpty(Nomb1.Text);
                    break;
                case 2:
                    a = Regex.IsMatch(VarA2.Text.ToString(), verifica);
                    b = Regex.IsMatch(VarB2.Text.ToString(), verifica);
                    nomb_func = string.IsNullOrEmpty(Nomb2.Text);
                    break;
                case 3:
                    a = Regex.IsMatch(VarA3.Text.ToString(), verifica);
                    b = Regex.IsMatch(VarB3.Text.ToString(), verifica);
                    nomb_func = string.IsNullOrEmpty(Nomb3.Text);
                    break;
                case 4:
                    a = Regex.IsMatch(VarA4.Text.ToString(), verifica);
                    b = Regex.IsMatch(VarB4.Text.ToString(), verifica);
                    nomb_func = string.IsNullOrEmpty(Nomb4.Text);
                    break;
                case 5:
                    a = Regex.IsMatch(VarA5.Text.ToString(), verifica);
                    b = Regex.IsMatch(VarB5.Text.ToString(), verifica);
                    c = Regex.IsMatch(VarC5.Text.ToString(), verifica);
                    nomb_func = string.IsNullOrEmpty(Nomb5.Text);
                    break;
                case 6:
                    a = Regex.IsMatch(VarA6.Text.ToString(), verifica);
                    b = Regex.IsMatch(VarB6.Text.ToString(), verifica);
                    nomb_func = string.IsNullOrEmpty(Nomb6.Text);
                    break;
            }
            if (!a || !b || ((funcionSeleccionada == 5) && !c))
                MessageBox.Show("Falta introducir un parametro");
            if(nomb_func) // la funcion isNullOfEmpty devuelve verdadero en caso de que este vacia
                MessageBox.Show("Falta introducir el nombre");
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
        
        private void OcultaFunc1()
        {
            this.VarA1.Text = "a";
            this.VarB1.Text = "b";
            this.Nomb1.Text = "Nombre";
            VarA1.Visibility = Visibility.Hidden;
            VarB1.Visibility = Visibility.Hidden;
            Nomb1.Visibility = Visibility.Hidden;
        }
        private void OcultaFunc2()
        {
            this.VarB1.Text = "b";
            this.VarA2.Text = "a";
            this.Nomb2.Text = "Nombre";
            VarA2.Visibility = Visibility.Hidden;
            VarB2.Visibility = Visibility.Hidden;
            Nomb2.Visibility = Visibility.Hidden;
        }
        private void OcultaFunc3()
        {
            this.VarA3.Text = "a";
            this.VarB3.Text = "b";
            this.Nomb3.Text = "Nombre";
            VarA3.Visibility = Visibility.Hidden;
            VarB3.Visibility = Visibility.Hidden;
            Nomb3.Visibility = Visibility.Hidden;
        }
        
        private void OcultaFunc4()
        {
            this.VarA4.Text = "a";
            this.VarB4.Text = "b";
            this.Nomb4.Text = "Nombre";
            VarA4.Visibility = Visibility.Hidden;
            VarB4.Visibility = Visibility.Hidden;
            Nomb4.Visibility = Visibility.Hidden;
        }
        private void OcultaFunc5()
        {
            this.VarA5.Text = "a";
            this.VarB5.Text = "b";
            this.VarC5.Text = "c";
            this.Nomb5.Text = "Nombre";
            VarA5.Visibility = Visibility.Hidden;
            VarB5.Visibility = Visibility.Hidden;
            VarC5.Visibility = Visibility.Hidden;
            Nomb5.Visibility = Visibility.Hidden;
        }
        private void OcultaFunc6()
        {
            this.VarA6.Text = "a";
            this.VarB6.Text = "b";
            this.Nomb6.Text = "Nombre";
            VarA6.Visibility = Visibility.Hidden;
            VarB6.Visibility = Visibility.Hidden;
            Nomb6.Visibility = Visibility.Hidden;
        }
        
    }
}
