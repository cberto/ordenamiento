using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenamiento
{
    class Program
    {
        public const Int64 l = 100000;
        static void Main(string[] args)
        {
            DateTime t0;
            Orden id = new Orden(l);
            id.CargarRnd();
            id.Backupear();
            t0 = DateTime.Now;
            id.InsercionDirecta();
            Console.WriteLine("Metodo Insercion Directa: " + (DateTime.Now - t0));
            id.Restore();
            t0 = DateTime.Now;
            id.InsercionBinaria();
            Console.WriteLine("Metodo Insercion Binaria: " + (DateTime.Now - t0));
            id.Restore();
            t0 = DateTime.Now;
            id.ShellSort();
            Console.WriteLine("Metodo Shell Sort: " + (DateTime.Now-t0));
            id.Restore();
            t0 = DateTime.Now;
            id.QuickSort(0, l - 1);
            Console.WriteLine("Metodo Quick Sort: " + (DateTime.Now - t0));
            id.Restore();
            t0 = DateTime.Now;
            id.Burbujeo();
            Console.WriteLine("Metodo Burbujeo: " + (DateTime.Now - t0));
            id.Restore();
            t0 = DateTime.Now;
            id.ShakerSort();
            Console.WriteLine("Metodo Shaker Sort: " + (DateTime.Now - t0));
            id.Restore();
            t0 = DateTime.Now;
            id.MergeSort();
            Console.WriteLine("Metodo Merge Sort: " + (DateTime.Now - t0));
            //id.Imprimir();
            Console.ReadKey();
        }
    }
}
