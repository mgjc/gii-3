using System.Windows;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Windows.Media;
using System;

namespace Trabajo
{

    public partial class MainWindow : Window
    {
        Class1 modelo = new Class1();
        List<Tabla> ListaFunciones = new List<Tabla>();
        Window1 z;
        public MainWindow()
        {
            InitializeComponent();
            Window1 w = new Window1(modelo);
            w.Show();
            z = w;
            modelo.AgregarEventHandler += new RoutedEventHandler(Pintar);
            modelo.EliminarEventHandler += new RoutedEventHandler(Despintar);
            return;
        }
        private void Despintar(object sender, RoutedEventArgs e)
        {
            string nombre = modelo.FuncionADespintar();
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Error al eliminar la funcion");
                return;
            }
            for(int i = 0; i < ListaFunciones.Count; i++)
            {
                if (ListaFunciones[i].Nombre.Equals(nombre))
                {
                    ListaFunciones.RemoveAt(i);
                }
            }
            if (ListaFunciones.Count!=0)
                Pintar(sender,e);
            else
                lienzo.Children.Clear();
        }
        private void Pintar(object sender, RoutedEventArgs e)
        {
            ListaFunciones = modelo.ObtenerFunciones();
            double topeMAX, topemin, tempM,tempm;
            EliminaFuncionesRepetidas();
            lienzo.Children.Clear();
            if (ListaFunciones.Count==0) return;
            Tabla x = ListaFunciones[0];
            topeMAX = double.Parse(x.EjeXMax);
            topemin = double.Parse(x.EjeXMin);
            for (int num_funciones = 1; num_funciones < ListaFunciones.Count; num_funciones++)
            {
                x = ListaFunciones[num_funciones];
                tempM = double.Parse(x.EjeXMax);
                tempm = double.Parse(x.EjeXMin);
                if (topeMAX < tempM)
                    topeMAX = tempM;
                if (topemin > tempm)
                    topemin = tempm;
            }
            tempM = topeMAX;
            tempm = topemin;
            for (int num_funciones = 0; num_funciones < ListaFunciones.Count; num_funciones++)
            {
                x = ListaFunciones[num_funciones];
                topeMAX = double.Parse(x.EjeXMax);
                topemin = double.Parse(x.EjeXMin);
                int ancho = (int)lienzo.ActualWidth;
                int num_puntos = (int)lienzo.ActualWidth;
                Polyline p = new Polyline();
                double porcentaje;
                double restaderecha;
                double sumaizquierda=0;
                PointCollection puntos = new PointCollection();
                double ypantmax = (double)lienzo.ActualHeight;
                if (x.Expresion.Equals("a*sen(b*x)"))
                {
                    porcentaje = ancho / (tempM-tempm);
                    restaderecha = ancho + (topemin*porcentaje);
                    num_puntos = (int)(topeMAX * porcentaje - topemin * porcentaje);
                    if(topemin!=tempm) sumaizquierda =porcentaje*(tempm-topemin);
                    if (sumaizquierda < 0) sumaizquierda *= -1;
                    for (int i = 0; i < num_puntos; i++)
                    {
                        Point pt = new Point(i+sumaizquierda,ypantmax*float.Parse(x.A)*(Math.Sin(i * float.Parse(x.B) / porcentaje) + 2) / 4);
                        puntos.Add(pt);
                    }
                }
                if (x.Expresion.Equals("a*cos(b*x)"))
                {
                    porcentaje = ancho / (tempM - tempm);
                    restaderecha = ancho + (topemin * porcentaje);
                    num_puntos = (int)(topeMAX * porcentaje - topemin * porcentaje);
                    if (topemin != tempm) sumaizquierda = porcentaje * (tempm - topemin);
                    if (sumaizquierda < 0) sumaizquierda *= -1;
                    for (int i = 0; i < num_puntos; i++)
                    {
                        Point pt = new Point(i + sumaizquierda, ypantmax * float.Parse(x.A) * (Math.Cos((i * float.Parse(x.B)) / porcentaje) + 2) / 4);
                        puntos.Add(pt);
                    }
                }
                if (x.Expresion.Equals("a*x^n"))
                {
                    porcentaje = ancho / (tempM - tempm);
                    restaderecha = ancho + (topemin * porcentaje);
                    num_puntos = (int)(topeMAX * porcentaje - topemin * porcentaje);
                    if (topemin != tempm) sumaizquierda = porcentaje * (tempm - topemin);
                    if (sumaizquierda < 0) sumaizquierda *= -1;

                    float xminreal = (float)topemin, xmaxreal = (float)topeMAX;
                    float yminreal = (float)topemin, ymaxreal = (float)topeMAX;
                    float xreal, yreal, xpant, ypant;
                    float xpantmax=num_puntos, xpantmin=0;
                    float ypantmin=0;
                    for (int i = 0; i < num_puntos; i++)
                    {
                        xreal = xminreal + i * (xmaxreal - xminreal) / num_puntos;
                        yreal = float.Parse(x.A)* (float)Math.Pow((double)xreal,double.Parse(x.Const));
                        xpant = (xpantmax - xpantmin) * (xreal - xminreal) / (xmaxreal - xminreal) + xpantmin + (float)sumaizquierda;
                        ypant = (ypantmin - (float)ypantmax) * (yreal - yminreal) / (ymaxreal - yminreal) + (float)ypantmax;
                        Point pt = new Point(xpant, ypant);
                        puntos.Add(pt);

                    }
                }
                if (x.Expresion.Equals("a*x+b"))
                {
                    porcentaje = ancho / (tempM - tempm);
                    restaderecha = ancho + (topemin * porcentaje);
                    num_puntos = (int)(topeMAX * porcentaje - topemin * porcentaje);
                    if (topemin != tempm) sumaizquierda = porcentaje * (tempm - topemin);
                    if (sumaizquierda < 0) sumaizquierda *= -1;

                    float xminreal = (float)topemin, xmaxreal = (float)topeMAX;
                    float yminreal = (float)topemin, ymaxreal = (float)topeMAX;
                    float xreal, yreal, xpant, ypant;
                    float xpantmax = num_puntos, xpantmin = 0;
                    float ypantmin = 0;
                    for (int i = 0; i < num_puntos; i++)
                    {
                        xreal = xminreal + i * (xmaxreal - xminreal) / num_puntos;
                        yreal = float.Parse(x.A) * xreal + float.Parse(x.B);
                        xpant = (xpantmax - xpantmin) * (xreal - xminreal) / (xmaxreal - xminreal) + xpantmin + (float)sumaizquierda;
                        ypant = (ypantmin - (float)ypantmax) * (yreal - yminreal) / (ymaxreal - yminreal) + (float)ypantmax;
                        Point pt = new Point(xpant, ypant);
                        puntos.Add(pt);

                    }
                }
                if (x.Expresion.Equals("a*x2+b*x+c"))
                {
                    porcentaje = ancho / (tempM - tempm);
                    restaderecha = ancho + (topemin * porcentaje);
                    num_puntos = (int)(topeMAX * porcentaje - topemin * porcentaje);
                    if (topemin != tempm) sumaizquierda = porcentaje * (tempm - topemin);
                    if (sumaizquierda < 0) sumaizquierda *= -1;

                    float xminreal = (float)topemin, xmaxreal = (float)topeMAX;
                    float yminreal = (float)topemin, ymaxreal = (float)topeMAX;
                    float xreal, yreal, xpant, ypant;
                    float xpantmax = num_puntos, xpantmin = 0;
                    float ypantmin = 0;
                    for (int i = 0; i < num_puntos; i++)
                    {
                        xreal = xminreal + i * (xmaxreal - xminreal) / num_puntos;
                        yreal = float.Parse(x.A) * xreal* xreal + float.Parse(x.B)*xreal+float.Parse(x.C);
                        xpant = (xpantmax - xpantmin) * (xreal - xminreal) / (xmaxreal - xminreal) + xpantmin + (float)sumaizquierda;
                        ypant = (ypantmin - (float)ypantmax) * (yreal - yminreal) / (ymaxreal - yminreal) + (float)ypantmax + (float)ypantmax / 2;
                        Point pt = new Point(xpant, ypant);
                        puntos.Add(pt);

                    }
                }
                if (x.Expresion.Equals("a/(b*x)")) {

                    porcentaje = ancho / (tempM - tempm);
                    restaderecha = ancho + (topemin * porcentaje);
                    num_puntos = (int)(topeMAX * porcentaje - topemin * porcentaje);
                    if (topemin != tempm) sumaizquierda = porcentaje * (tempm - topemin);
                    if (sumaizquierda < 0) sumaizquierda *= -1;

                    float xminreal = (float)topemin, xmaxreal = (float)topeMAX;
                    float yminreal = (float)topemin, ymaxreal = (float)topeMAX;
                    float xreal, yreal, xpant, ypant;
                    float xpantmax = num_puntos, xpantmin = 0;
                    float ypantmin = 0;
                    for (int i = 1; i < num_puntos; i++)
                    {
                        xreal = xminreal + i * (xmaxreal - xminreal) / num_puntos;
                        yreal = float.Parse(x.A) / (xreal * float.Parse(x.B));
                        xpant = (xpantmax - xpantmin) * (xreal - xminreal) / (xmaxreal - xminreal) + xpantmin + (float)sumaizquierda;
                        ypant = (ypantmin - (float)ypantmax) * (yreal - yminreal) / (ymaxreal - yminreal) + (float)ypantmax;
                        Point pt = new Point(xpant, ypant);
                        puntos.Add(pt);

                    }
                }
                if (x.Color.Equals("Rojo")) p.Stroke = Brushes.Red;
                if (x.Color.Equals("Azul"))p.Stroke = Brushes.Blue;
                if (x.Color.Equals("Naranja"))p.Stroke = Brushes.Orange;
                if (x.Color.Equals("Rosa"))p.Stroke = Brushes.Pink;
                if(x.Color.Equals("Verde"))p.Stroke = Brushes.Green;
                p.Points = puntos;
                p.StrokeThickness = 1;
                lienzo.Children.Add(p);
            }
        }
        private void EliminaFuncionesRepetidas()
        {
            List<string> temp = new List<string>();
            List<int> indices = new List<int>();
            for(int i = 0; i < ListaFunciones.Count; i++)
            {
                temp.Add(ListaFunciones[i].Nombre);
                for(int j=0; j < i; j++)
                {
                    if (temp[j].Equals(ListaFunciones[i].Nombre))
                    {
                        indices.Add(i);
                    }
                }
            }
            for (int i = 0; i < indices.Count; i++)
            {
                ListaFunciones.RemoveAt(indices[i]);
            }
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            RoutedEventArgs p = new RoutedEventArgs();
            Pintar(sender, p);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            z.Close();
        }
    }
}
