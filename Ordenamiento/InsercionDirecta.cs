using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenamiento
{
    class InsercionDirecta
    {
        private int[] vector;

        public void Cargar()
        {
            Console.WriteLine("Metodo de insercion directa");
            String linea;
            for (int f = 0; f < vector.Length; f++)
            {
                Console.Write("Ingrese elemento " + (f + 1) + ": ");
                linea = Console.ReadLine();
                vector[f] = int.Parse(linea);
            }
        }

        public void Ordenar()
        {
            int auxili;
            int j;
            for (int i = 0; i < vector.Length; i++)
            {
                auxili = vector[i];
                j = i - 1;
                while (j >= 0 && vector[j] > auxili)
                {
                    vector[j + 1] = vector[j];
                    j--;
                }
                vector[j + 1] = auxili;
            }
        }

        public void Imprimir()
        {
            Console.WriteLine("Vector ordenados en forma ascendente");
            for (int f = 0; f < vector.Length; f++)
            {
                Console.Write(vector[f] + "  ");
            }
            Console.ReadKey();
        }
        public InsercionDirecta(Int32 l)
        {
            this.vector = new int[l];
        }

    }
}
