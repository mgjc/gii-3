using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAcopladas
{
    class Acopladas
    {
        static void Main(string[] args)
        {
            observador obj = new observador();
            obj.funciona();
        }
    }
    class observador
    {
        TrabajoDuro tb;
        public observador() { tb = new TrabajoDuro(); }
        public void funciona()
        {
            Console.WriteLine("Vamos a probar el informe");
            tb.alcanzandoPorcentaje += InformeAvance;           // OJO !! Hay que poner += siempre que haya que usar un evento por si alguien ya ha añadido cosas a ese evento
            tb.ATrabajar();
            Console.WriteLine("Terminado");
        }
        public void InformeAvance(int x)
        {
            string str = String.Format("Ya llevamos el {0}", x);
            Console.WriteLine(str);
        }
    }

    delegate void TipoDelegado(int x);


    class TrabajoDuro
    {
        int PocentajeHecho;
        public event TipoDelegado alcanzandoPorcentaje;
        //observador eljefe;
        public TrabajoDuro(/*observador o*/)
        {
            PocentajeHecho = 0;
            //eljefe = o;
        }
        public void ATrabajar()
        {
            int i;
            for (i = 0; i < 500; i++)
            {
                System.Threading.Thread.Sleep(1); //Hacemos el trabajo
                switch (i)
                {
                    case 125:
                        PocentajeHecho = 25;
                        if(alcanzandoPorcentaje != null)
                            alcanzandoPorcentaje(PocentajeHecho);
                        break;
                    case 250:
                        PocentajeHecho = 50;
                        if (alcanzandoPorcentaje != null)
                            alcanzandoPorcentaje(PocentajeHecho);
                        break;
                    case 375:
                        PocentajeHecho = 75;
                        if (alcanzandoPorcentaje != null)
                            alcanzandoPorcentaje(PocentajeHecho);
                        break;
                }
            }
        }
    }
}
