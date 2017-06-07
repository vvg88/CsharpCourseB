using System;

namespace HomeWork1_On2
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = { 1, 2, 3, 4, 5 };
            Console.Write("Исходный массив: ");
            foreach (var item in array)
                Console.Write($"{item} ");
            Console.WriteLine($"\nДлина массива: {array.Length}\n");

            int iterationsCount;
            var doubleArray = On2Method(array, out iterationsCount);
            Console.WriteLine("Полученный массив:");
            for (int i = 0; i < doubleArray.GetLength(0); i++)
            {
                for (int j = 0; j < doubleArray.GetLength(1); j++)
                {
                    Console.Write($"{doubleArray[i,j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Число итераций: {iterationsCount}\n");

            Console.ReadLine();
        }

        private static double[,] On2Method(double[] array, out int iterationsCnt)
        {
            double[,] matrix = new double[array.Length, array.Length];
            iterationsCnt = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    matrix[i, j] = array[j] + i;
                    iterationsCnt++;
                }
            }
            return matrix;
        }
    }
}
