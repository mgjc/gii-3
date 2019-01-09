using System.Collections.Generic;
using System.Windows;

namespace Trabajo
{
    class Class1
    {
        List<Tabla> Funciones = new List<Tabla>();
        string funcionEliminada = "";
        public event RoutedEventHandler EliminarEventHandler;
        public event RoutedEventHandler AgregarEventHandler;

        public void AñadirFuncion(Tabla t, object sender, RoutedEventArgs e)
        {
            Funciones.Add(t);
            PintaFunciones(this, e);
        }
        public void EliminarFuncion(string nombre, object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Funciones.Count; i++)
            {
                if (Funciones[i].Nombre.Equals(nombre))
                {
                    Funciones.RemoveAt(i);
                    funcionEliminada = nombre;
                    DespintaFunciones(this, e);
                    break;
                }
            }
        }
        public void ModificarFuncion(Tabla t, object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Funciones.Count; i++)
            {
                if (Funciones[i].Nombre.Equals(t.Nombre))
                {
                    Funciones.RemoveAt(i);
                    break;
                }
            }
        }
        public int PintaFunciones(object sender, RoutedEventArgs e)
        {

            AgregarEventHandler?.Invoke(this, e);
            return 0;
        }
        public int DespintaFunciones(object sender, RoutedEventArgs e)
        {

            EliminarEventHandler?.Invoke(this, e);
            return 0;
        }
        public List<Tabla> ObtenerFunciones()
        {
            return Funciones;
        }
        public string FuncionADespintar()
        {
            return funcionEliminada;
        }
    }
}
