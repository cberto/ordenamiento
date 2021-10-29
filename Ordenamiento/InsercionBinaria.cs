using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenamiento
{
    class InsercionBinaria
    {
        private int[] numeros;
        public void Ordenar()
        {
            int j, aux, izq, der, m;
            for (int i = 1; i < numeros.Length; i++)
            {
                aux = numeros[i];
                izq = 0;
                der = i - 1;
                while (izq <= der)
                {
                    m = ((izq + der) / 2);
                    if (aux < numeros[m])
                        der = m - 1;
                    else
                        izq = m + 1;
                }
                j = i - 1;
                while (j >= izq)
                {
                    numeros[j + 1] = numeros[j];
                    j = j - 1;
                }
                numeros[izq] = aux;
            }
        }
        public void Cargar()
        {
            Console.WriteLine("Metodo de insercion directa");
            String linea;
            for (int f = 0; f < numeros.Length; f++)
            {
                Console.Write("Ingrese elemento " + (f + 1) + ": ");
                linea = Console.ReadLine();
                numeros[f] = int.Parse(linea);
            }
        }
        public void CargarRnd()
        {
            Random rnd = new Random();
            int i=0;
            for (int ctr = 1; ctr <= numeros.Length; ctr++)
            {
                this.numeros[i]=rnd.Next(-100, 1010000);
                i++;
            }
        }
        public void Imprimir()
        {
            Console.WriteLine("Vector ordenados en forma ascendente");
            for (int f = 0; f < numeros.Length; f++)
            {
                Console.Write(numeros[f] + "  ");
            }
            Console.ReadKey();
        }
        public InsercionBinaria(Int32 l)
        {
            this.numeros = new int[l];
        }
    }
}
