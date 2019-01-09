using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System;

namespace Trabajo
{

    public partial class Window1 : Window
    {
        List<string> nombres = new List<string>();
        string nombreActual = "";
        Class1 obj;

        public Window1(object modelo)
        {
            InitializeComponent();
            obj = (Class1)modelo;
        }

        private void Incluye_Click(object sender, RoutedEventArgs e)
        {
            string verifica = "^[-0-9]";

            if (Funciones.SelectedIndex == -1)
            {
                MessageBox.Show("Elige una expresion, pon los parametros y el color");
                return;
            }

            if (ListaColores.SelectedIndex == -1)
            {
                MessageBox.Show("Falta añadir el color");
                return;
            }

            if (string.IsNullOrEmpty(NombreFuncion.Text))
            {
                MessageBox.Show("Falta introducir el nombre");
                return;
            }

            for (int i = 0; i < nombres.Count; i++)
            {
                if (NombreFuncion.Text.Equals(nombres[i]))
                {
                    MessageBox.Show("Nombre ya usado");
                    return;
                }
            }
            if (!Regex.IsMatch(VarA.Text, verifica) || (!Regex.IsMatch(VarB.Text, verifica) && VarB.IsEnabled) || (!Regex.IsMatch(VarC.Text, verifica) && VarC.IsEnabled) || (!Regex.IsMatch(Const.Text, verifica) && Const.IsEnabled))
            {
                MessageBox.Show("Falta introducir un parametro");
                return;
            }

            nombres.Add(NombreFuncion.Text);
            tabla.Items.Add(new Tabla(NombreFuncion.Text, Funciones.Text, ListaColores.Text, "10", "-10", VarA.Text, VarB.Text, VarC.Text, Const.Text) { Nombre = NombreFuncion.Text, Expresion = Funciones.Text, Color = ListaColores.Text, EjeXMax = "10", EjeXMin = "-10", A = VarA.Text, B = VarB.Text, C = VarC.Text, Const = Const.Text });
        }

        private void Funciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NombreFuncion.Text = "Nombre";
            VarA.Text = "a";
            VarA.IsEnabled = true;

            switch (Funciones.SelectedIndex)
            {
                case 2:

                    VarB.Text = "-";
                    VarC.Text = "-";
                    Const.Text = "n";

                    Const.IsEnabled = true;
                    VarB.IsEnabled = false;
                    VarC.IsEnabled = false;
                    break;
                case 4:
                    VarB.Text = "b";
                    VarC.Text = "c";
                    Const.Text = "-";

                    VarB.IsEnabled = true;
                    VarC.IsEnabled = true;
                    Const.IsEnabled = false;
                    break;
                default:
                    MuestraAB();
                    break;
            }
        }

        private void MuestraAB()
        {
            VarB.Text = "b";
            VarC.Text = "-";
            Const.Text = "-";
            VarB.IsEnabled = true;
            VarC.IsEnabled = false;
            Const.IsEnabled = false;
        }

        private void NombreFuncion_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NombreFuncion.Text = "";
        }

        private void VarA_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            VarA.Text = "";
        }

        private void VarB_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            VarB.Text = "";
        }

        private void VarC_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            VarC.Text = "";
        }

        private void Const_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Const.Text = "";
        }

        private void Tabla_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MeteAGrafica.Visibility = Visibility.Visible;
            ModificaFuncion.Visibility = Visibility.Visible;
            EliminarDeGrafica.Visibility = Visibility.Visible;
        }

        private void MeteAGrafica_Click(object sender, RoutedEventArgs e)
        {
            if (tabla.SelectedItems.Count > 0)
            {
                Tabla t;
                t = (Tabla)tabla.SelectedItem;
                nombreActual = t.Nombre;

                if (t.Expresion.Equals("a/(b*x)") && int.Parse(t.B) == 0)
                {
                    MessageBox.Show("No puedes dividir entre 0");
                    return;
                }
                obj.AñadirFuncion(t, sender, e);

                if (tabla.Items.Count > 1)
                {
                    CambiaA.Visibility = Visibility.Collapsed;
                    CambiaB.Visibility = Visibility.Collapsed;
                    CambiaC.Visibility = Visibility.Collapsed;
                    CambiaConst.Visibility = Visibility.Collapsed;
                    CambiaXMAX.Visibility = Visibility.Collapsed;
                    CambiaXmin.Visibility = Visibility.Collapsed;
                    CambiaValores.Visibility = Visibility.Collapsed;
                    GuardaCambios.Visibility = Visibility.Collapsed;
                    MeteAGrafica.Visibility = Visibility.Collapsed;
                    EliminarDeGrafica.Visibility = Visibility.Collapsed;
                    ModificaFuncion.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void ModificaFuncion_Click(object sender, RoutedEventArgs e)
        {
            if (tabla.SelectedItems.Count > 0)
            {
                Tabla t = (Tabla)tabla.SelectedItem;
                CambiaValores.Visibility = Visibility.Visible;
                CambiaA.Visibility = Visibility.Visible;
                CambiaXMAX.Visibility = Visibility.Visible;
                CambiaXmin.Visibility = Visibility.Visible;
                GuardaCambios.Visibility = Visibility.Visible;
                CambiaA.Text = t.A;
                CambiaXmin.Text = t.EjeXMin;
                CambiaXMAX.Text = t.EjeXMax;
                nombreActual = t.Nombre;
                if (!t.B.Equals("-"))
                {
                    CambiaB.Visibility = Visibility.Visible;
                    CambiaB.Text = t.B;
                }
                else
                {
                    CambiaB.Visibility = Visibility.Collapsed;
                    t.B = "-";
                }
                if (!t.C.Equals("-"))
                {
                    CambiaC.Visibility = Visibility.Visible;
                    CambiaC.Text = t.C;
                }
                else
                {
                    CambiaC.Visibility = Visibility.Collapsed;
                    t.C = "-";
                }
                if (!t.Const.Equals("-"))
                {
                    CambiaConst.Visibility = Visibility.Visible;
                    CambiaConst.Text = t.Const;
                }
                else
                {
                    CambiaConst.Visibility = Visibility.Collapsed;
                    t.Const = "-";
                }
            }
        }

        private void EliminarDeGrafica_Click(object sender, RoutedEventArgs e)
        {
            Tabla x;
            int i;
            x = (Tabla)tabla.SelectedItem;
            nombreActual = x.Nombre;
            for (i = 0; i < tabla.Items.Count; i++)
            {
                x = (Tabla)tabla.Items[i];
                if (x.Nombre.Equals(nombreActual))
                {
                    break;
                }

            }
            x = (Tabla)tabla.Items[i];
            for (int j = 0; j < nombres.Count; j++)
            {
                if (nombres[j].Equals(x.Nombre))
                {
                    nombres.RemoveAt(j);
                }
            }
            obj.EliminarFuncion(x.Nombre, sender, e);
            tabla.Items.RemoveAt(i);
            CambiaA.Visibility = Visibility.Collapsed;
            CambiaB.Visibility = Visibility.Collapsed;
            CambiaC.Visibility = Visibility.Collapsed;
            CambiaConst.Visibility = Visibility.Collapsed;
            CambiaXMAX.Visibility = Visibility.Collapsed;
            CambiaXmin.Visibility = Visibility.Collapsed;
            CambiaValores.Visibility = Visibility.Collapsed;
            GuardaCambios.Visibility = Visibility.Collapsed;
            MeteAGrafica.Visibility = Visibility.Collapsed;
            EliminarDeGrafica.Visibility = Visibility.Collapsed;
            ModificaFuncion.Visibility = Visibility.Collapsed;

        }

        private void GuardaCambios_Click(object sender, RoutedEventArgs e)
        {
            string verifica = "^[-0-9]";
            Tabla t = (Tabla)tabla.SelectedItem;
            Tabla x;
            int i;
            for (i = 0; i < tabla.Items.Count; i++)
            {
                x = (Tabla)tabla.Items[i];
                if (x.Nombre.Equals(nombreActual))
                {
                    break;
                }

            }
            if (!Regex.IsMatch(CambiaA.Text, verifica) || (!Regex.IsMatch(CambiaB.Text, verifica) && (CambiaB.Visibility == Visibility.Visible)) || (!Regex.IsMatch(CambiaC.Text, verifica) && (CambiaC.Visibility == Visibility.Visible)) || (!Regex.IsMatch(CambiaConst.Text, verifica) && (CambiaConst.Visibility == Visibility.Visible)) || (!Regex.IsMatch(CambiaXmin.Text, verifica)) || (!Regex.IsMatch(CambiaXMAX.Text, verifica)) || string.IsNullOrEmpty(CambiaXMAX.Text) || string.IsNullOrEmpty(CambiaXmin.Text))
            {
                MessageBox.Show("Falta introducir un parametro");
                return;
            }
            double q = double.Parse(CambiaXmin.Text);
            double w = double.Parse(CambiaXMAX.Text);
            if (w < q)
            {
                string z = "";
                z = CambiaXmin.Text;
                CambiaXmin.Text = CambiaXMAX.Text;
                CambiaXMAX.Text = z;

            }
            tabla.Items.RemoveAt(i);
            t.EjeXMax = CambiaXMAX.Text;
            t.EjeXMin = CambiaXmin.Text;
            if (t.Expresion.Equals("a*sen(b*x)") || t.Expresion.Equals("a*cos(b*x)") || t.Expresion.Equals("a*x+b") || t.Expresion.Equals("a/(b*x)"))
            {
                CambiaC.Text = "-";
                CambiaConst.Text = "-";
            }
            else
            {
                if (t.Expresion.Equals("a*x^n"))
                {
                    CambiaB.Text = "-";
                    CambiaC.Text = "-";
                }
                else
                {
                    CambiaConst.Text = "-";
                }
            }
            nombreActual = "";
            CambiaA.Visibility = Visibility.Collapsed;
            CambiaB.Visibility = Visibility.Collapsed;
            CambiaC.Visibility = Visibility.Collapsed;
            CambiaConst.Visibility = Visibility.Collapsed;
            CambiaXMAX.Visibility = Visibility.Collapsed;
            CambiaXmin.Visibility = Visibility.Collapsed;
            CambiaValores.Visibility = Visibility.Collapsed;
            GuardaCambios.Visibility = Visibility.Collapsed;
            MeteAGrafica.Visibility = Visibility.Collapsed;
            EliminarDeGrafica.Visibility = Visibility.Collapsed;
            ModificaFuncion.Visibility = Visibility.Collapsed;
            obj.ModificarFuncion(t, sender, e);
            tabla.Items.Add(new Tabla(t.Nombre, t.Expresion, t.Color, t.EjeXMax, t.EjeXMin, CambiaA.Text, CambiaB.Text, CambiaC.Text, CambiaConst.Text) { Nombre = t.Nombre, Expresion = t.Expresion, Color = t.Color, EjeXMax = t.EjeXMax, EjeXMin = t.EjeXMin, A = CambiaA.Text, B = CambiaB.Text, C = CambiaC.Text, Const = CambiaConst.Text });

        }
    }
}
class Tabla
{
    public string Nombre { get; set; }
    public string Expresion { get; set; }
    public string Color { get; set; }
    public string EjeXMax { get; set; }
    public string EjeXMin { get; set; }
    public string A { get; set; }
    public string B { get; set; }
    public string C { get; set; }
    public string Const { get; set; }

    public Tabla(string nomb, string expr, string color, string ejexmax, string ejexmin, string a, string b, string c, string cte)
    {
        Nombre = nomb;
        Expresion = expr;
        Color = color;
        EjeXMin = ejexmin;
        EjeXMax = ejexmax;
        A = a;
        B = b;
        C = c;
        Const = cte;

        
    }
    public float CalculaX(float x)
    {

        if (Expresion.Equals("a*sen(b*x)"))
            return float.Parse(A) * (float)(Math.Sin(x * float.Parse(B)) + 4) / 8;
        if (Expresion.Equals("a*cos(b*x)"))
            return float.Parse(A) * (float)(Math.Cos(x * float.Parse(B)) + 4) / 8;
        if (Expresion.Equals("a*x^n"))
            return float.Parse(A) * (float)Math.Pow((double)x, double.Parse(Const));
        if (Expresion.Equals("a*x+b"))
            return float.Parse(A) * x + float.Parse(B);
        if (Expresion.Equals("a*x2+b*x+c"))
            return float.Parse(A) * x * x + float.Parse(B) * x + float.Parse(C);
        if (Expresion.Equals("a/(b*x)"))
            if (x == 0) return 0;
        else
            return float.Parse(A) / (x * float.Parse(B));
        return 0;
    }
}
