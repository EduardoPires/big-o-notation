using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;
using BigOhNotation;
using System.Text;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Mathematics;

BenchmarkRunner.Run<BigOBenchmarks>();

namespace BigOhNotation
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn(NumeralSystem.Arabic)]
    [MarkdownExporter]
    public class BigOBenchmarks
    {
        readonly List<int> NumerosOrdenados = new()
        {
            1, 2, 4, 6, 10, 14, 15, 19, 20, 34, 36, 38, 40, 42, 50, 52, 55, 60, 61, 62, 63, 67, 70, 78, 80, 82, 84, 86, 88, 90, 92, 93, 99, 101, 105, 107, 110, 115,118
        };

        readonly List<int> NumerosDesordenados = new ()
        {
            2, 23, -575, 1, -400, 8, 44, -90, 0, 4, 180, -32, 323, 73, 59, 663, 35, 45, -67, 28, 3, 5, -5, 52, 7, 62, -20, 9, 92, 63, -342, 12, 53, 200, 234, 756, 456
        };

        [Benchmark(Description = "O(1)")]
        public void BigO_1() 
        {
            var ehpar = EhPar(3);
        }

        [Benchmark(Description = "O(log n)")]
        public void BigO_LogN()
        {
            BinarySearch(NumerosOrdenados, 52);
        }

        [Benchmark(Description = "O(n)")]
        public void BigO_N()
        {
            LacoSimples(84);
        }

        [Benchmark(Description = "O(n log n)")]
        public void BigO_NLogN()
        {
            OrdenacaoMergeSort();
        }

        [Benchmark(Description = "O(n^2)")]
        public void BigO_N2()
        {
            LacoDuplo();
        }

        [Benchmark(Description = "O(2^n)")]
        public void BigO_2n()
        {
            TowerOfHanoi(13, 'A', 'B', 'C');
        }


        // O(1)
        public bool EhPar(int numero)
        {
            return numero % 2 == 0;
        }

        // O(log n)
        private static int BinarySearch(List<int> numberElements, int valuesToBeSearched)
        {
            if (numberElements == null)
                throw new ArgumentNullException(nameof(numberElements));

            if (numberElements[0] > valuesToBeSearched)
                return -1;

            if (valuesToBeSearched > numberElements[numberElements.Count - 1])
                return -1;

            int upperBound = numberElements.Count;
            int lowerBound = 0;

            while (lowerBound < upperBound)
            {
                int mid = (upperBound + lowerBound) / 2;
                if (numberElements[mid] < valuesToBeSearched)
                {
                    lowerBound = mid;
                }
                else if (numberElements[mid] > valuesToBeSearched)
                {
                    upperBound = mid;
                }
                else
                {
                    return mid;
                }
            }
            return -1;
        }

        public bool LacoSimples(int numeroPesquisa)
        {
            // O(n)
            foreach (var element in NumerosOrdenados)
            {
                if (element == numeroPesquisa)
                    return true;
            }

            return false;
        }

        // O(n log n)"
        public static int[] MergeSort(int[] inputItems, int lowerBound, int upperBound)
        {
            if (lowerBound < upperBound)
            {
                int middle = (lowerBound + upperBound) / 2;

                MergeSort(inputItems, lowerBound, middle);
                MergeSort(inputItems, middle + 1, upperBound);

                int[] leftArray = new int[middle - lowerBound + 1];
                int[] rightArray = new int[upperBound - middle];

                Array.Copy(inputItems, lowerBound, leftArray, 0, middle - lowerBound + 1);
                Array.Copy(inputItems, middle + 1, rightArray, 0, upperBound - middle);

                int i = 0;
                int j = 0;
                for (int count = lowerBound; count < upperBound + 1; count++)
                {
                    if (i == leftArray.Length)
                    {
                        inputItems[count] = rightArray[j];
                        j++;
                    }
                    else if (j == rightArray.Length)
                    {
                        inputItems[count] = leftArray[i];
                        i++;
                    }
                    else if (leftArray[i] <= rightArray[j])
                    {
                        inputItems[count] = leftArray[i];
                        i++;
                    }
                    else
                    {
                        inputItems[count] = rightArray[j];
                        j++;
                    }
                }
            }
            return inputItems;
        }

        // O(n log n)"
        public void OrdenacaoMergeSort()
        {
            var numerosMergeSort = MergeSort(NumerosDesordenados.ToArray<int>(),
                0, NumerosDesordenados.Count - 1).ToList<int>();

            var sbMergeSort = new StringBuilder();
            for (int count = 0; count < numerosMergeSort.Count; count++)
            {
                sbMergeSort.Append(numerosMergeSort[count].ToString() + "==>");
            }

            Console.WriteLine(sbMergeSort.ToString());
        }

        public static void LacoDuplo()
        {
            var n2Array = new int[20000];   
                        
            int contador = 0;

            // O(n * n) = O(n²)

            for (int i = 0; i < n2Array.Length; i++)         // O(n)
            {
                for (int j = 0; j < n2Array.Length; j++)     // O(n)
                {
                    contador++;
                }
            }

            Console.WriteLine("O(n^2) finalizado em " + contador.ToString() + " ciclos.");
        }

        public static void TowerOfHanoi(int n, char from_rod, char to_rod, char aux_rod)
        {
            if (n == 0)
            {
                return;
            }

            // O(2^n)
            TowerOfHanoi(n - 1, from_rod, aux_rod, to_rod);

            Console.WriteLine($"Move disk { n } from rod { from_rod } to rod { to_rod }");

            TowerOfHanoi(n - 1, aux_rod, to_rod, from_rod);
        }
    }
}