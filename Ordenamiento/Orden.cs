using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenamiento
{
    class Orden
    {
        #region VARIABLES MIEMBRO
        private Int64[] numeros;
        private Int64[] numerosBackup;
        #endregion

        #region METODOS
        #region BACKUP
        public void Backupear()
        {
            for (Int64 i = 0; i < numeros.Length; i++)
                this.numerosBackup[i] = this.numeros[i];
        }
        public void Restore()
        {
            for (Int64 i = 0; i < numeros.Length; i++)
                this.numeros[i] = this.numerosBackup[i];
        }
        #endregion

        #region METODOS DE ORDENAMIENTO
        #region InsercionBinaria
        public void InsercionBinaria()
        {
            Int64 aux;
            Int64 j, izq, der, m;
            for (Int64 i = 1; i < numeros.Length; i++)
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
        #endregion

        #region InsercionDirecta
        public void InsercionDirecta()
        {
            Int64 auxili;
            Int64 j;
            for (Int64 i = 0; i < numeros.Length; i++)
            {
                auxili = numeros[i];
                j = i - 1;
                while (j >= 0 && numeros[j] > auxili)
                {
                    numeros[j + 1] = numeros[j];
                    j--;
                }
                numeros[j + 1] = auxili;
            }
        }
        #endregion

        #region ShellSort
        public void ShellSort()
        {
            Int64 salto = 0;
            Int64 sw = 0;
            Int64 auxi = 0;
            Int64 e = 0;
            salto = numeros.Length / 2;
            while (salto > 0)
            {
                sw = 1;
                while (sw != 0)
                {
                    sw = 0;
                    e = 1;
                    while (e <= (numeros.Length - salto))
                    {
                        if (numeros[e - 1] > numeros[(e - 1) + salto])
                        {
                            auxi = numeros[(e - 1) + salto];
                            numeros[(e - 1) + salto] = numeros[e - 1];
                            numeros[(e - 1)] = auxi;
                            sw = 1;
                        }
                        e++;
                    }
                }
                salto = salto / 2;
            }
        }
        #endregion

        #region QuickSort
        public void QuickSort(Int64 primero, Int64 ultimo)
        {
            Int64 i, j, central;
            double pivote;
            central = (primero + ultimo) / 2;
            pivote = numeros[central];
            i = primero;
            j = ultimo;
            do
            {
                while (numeros[i] < pivote) i++;
                while (numeros[j] > pivote) j--;
                if (i <= j)
                {
                    Int64 temp;
                    temp = numeros[i];
                    numeros[i] = numeros[j];
                    numeros[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (primero < j)
            {
                QuickSort(primero, j);
            }
            if (i < ultimo)
            {
                QuickSort(i, ultimo);
            }
        }
        #endregion

        #region Burbujeo
        public void Burbujeo()
        {
            Int64 t;
            for (Int64 a = 1; a < numeros.Length; a++)
                for (Int64 b = numeros.Length - 1; b >= a; b--)
                {
                    if (numeros[b - 1] > numeros[b])
                    {
                        t = numeros[b - 1];
                        numeros[b - 1] = numeros[b];
                        numeros[b] = t;
                    }
                }
        }
        #endregion

        #region ShakerSort
        public void ShakerSort()
        {
            Int64 n = numeros.Length;
            Int64 izq = 1;
            Int64 k = n;
            Int64 aux;
            Int64 der = n-1;

            do
            {
                for (Int64 i = der; i >= izq; i--)
                {
                    if (numeros[i - 1] > numeros[i])
                    {
                        aux = numeros[i - 1];
                        numeros[i - 1] = numeros[i];
                        numeros[i] = aux;
                        k = i;
                    }
                }
                izq = k + 1;
                for (Int64 i = izq; i <= der; i++)
                {
                    if (numeros[i - 1] > numeros[i])
                    {
                        aux = numeros[i - 1];
                        numeros[i - 1] = numeros[i];
                        numeros[i] = aux;
                        k = 1;
                    }
                }
                der = k - 1;
            }
            while (der >= izq);
        }
        #endregion

        #region MergeSort
        //Método portal que llama al método recursivo inicial
        public void MergeSort()
        {
            MergeSort(numeros, 0, numeros.Length - 1);
        }

        static private void MergeSort(Int64[] x, Int64 desde, Int64 hasta)
        {
            //Condicion de parada
            if (desde == hasta)
                return;

            //Calculo la mitad del array
            Int64 mitad = (desde + hasta) / 2;

            //Voy a ordenar recursivamente la primera mitad
            //y luego la segunda
            MergeSort(x, desde, mitad);
            MergeSort(x, mitad + 1, hasta);

            //Mezclo las dos mitades ordenadas
            Int64[] aux = Merge(x, desde, mitad, mitad + 1, hasta);
            Array.Copy(aux, 0, x, desde, aux.Length);
        }

        //Método que mezcla las dos mitades ordenadas
        static private Int64[] Merge(Int64[] x, Int64 desde1, Int64 hasta1, Int64 desde2, Int64 hasta2)
        {
            Int64 a = desde1;
            Int64 b = desde2;
            Int64[] result = new Int64[hasta1 - desde1 + hasta2 - desde2 + 2];

            for (Int64 i = 0; i < result.Length; i++)
            {
                if (b != x.Length)
                {
                    if (a > hasta1 && b <= hasta2)
                    {
                        result[i] = x[b];
                        b++;
                    }
                    if (b > hasta2 && a <= hasta1)
                    {
                        result[i] = x[a];
                        a++;
                    }
                    if (a <= hasta1 && b <= hasta2)
                    {
                        if (x[b] <= x[a])
                        {
                            result[i] = x[b];
                            b++;
                        }
                        else
                        {
                            result[i] = x[a];
                            a++;
                        }
                    }
                }
                else
                {
                    if (a <= hasta1)
                    {
                        result[i] = x[a];
                        a++;
                    }
                }
            }
            return result;
        }
        #endregion
        #endregion

        #region I/O
        public void Cargar()
        {
            String linea;
            for (Int64 f = 0; f < numeros.Length; f++)
            {
                Console.Write("Ingrese elemento " + (f + 1) + ": ");
                linea = Console.ReadLine();
                numeros[f] = Int64.Parse(linea);
            }
        }
        public void CargarRnd()
        {
            Random rnd = new Random();
            Int64 i=0;
            for (Int64 ctr = 1; ctr <= numeros.Length; ctr++)
            {
                this.numeros[i]=rnd.Next(-100, 1010000);
                i++;
            }
        }
        public void Imprimir()
        {
            Console.WriteLine("numeros ordenados en forma ascendente");
            for (Int64 f = 0; f < numeros.Length; f++)
            {
                Console.Write(numeros[f] + "  ");
            }
            Console.ReadKey();
        }
        #endregion
        #endregion

        #region CONSTRUCTORES
        public Orden(Int64 l)
        {
            this.numeros = new Int64[l];
            this.numerosBackup = new Int64[l];

        }
        #endregion
    }
}
