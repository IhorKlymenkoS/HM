using System;

namespace HW5
{
    class Program
    {
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        static void Write(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static (int, int) MinI(int[,] matrix)
        {
            int minI1 = 0;
            int minI2 = 0;
            int min = matrix[0, 0];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (min > matrix[i, j])
                    {
                        minI1 = i;
                        minI2 = j;
                        min = matrix[i, j];
                    }
                }
            }

            return (minI1, minI2);
        }
        static (int, int) MaxI(int[,] matrix)
        {
            int maxI1 = 0;
            int maxI2 = 0;
            int max = matrix[0, 0];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (max < matrix[i, j])
                    {
                        maxI1 = i;
                        maxI2 = j;
                        max = matrix[i, j];
                    }
                }
            }

            return (maxI1, maxI2);
        }
        static int Min(int[,] matrix)
        {
            (int minI1, int minI2) = MinI(matrix);
            int min = matrix[minI1, minI2];
            return min;
        }
        static int Max(int[,] matrix)
        {
            (int maxI1, int maxI2) = MaxI(matrix);
            int max = matrix[maxI1, maxI2];
            return max;
        }
        static int LargestCellsOld(int[,] matrix)
        {
            int count = 0;
            int count2 = 0;
            int a = matrix.GetLength(0) - 1;
            int b = matrix.GetLength(1) - 1;


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i > 0)
                    {
                        if (matrix[i, j] > matrix[i - 1, j])
                        {
                            count2 += 1;
                        }
                    }
                    if (i < a)
                    {
                        if (matrix[i, j] > matrix[i + 1, j])
                        {
                            count2 += 1;
                        }
                    }

                    if (j > 0)
                    {
                        if (matrix[i, j] > matrix[i, j - 1])
                        {
                            count2 += 1;
                        }
                    }
                    if (j < b)
                    {
                        if (matrix[i, j] > matrix[i, j + 1])
                        {
                            count2 += 1;
                        }
                    }

                    if (i != 0 && j != 0 && count2 == 4)
                    {
                        count += 1;
                        count2 = 0;
                        Console.WriteLine("Count xy" + i + j);
                    }
                    else if (i == 0 && j != 0 && count2 == 3)
                    {
                        count += 1;
                        count2 = 0;
                        Console.WriteLine("Count xy" + i + j);
                    }
                    else if (i != 0 && j == 0 && count2 == 3)
                    {
                        count += 1;
                        count2 = 0;
                        Console.WriteLine("Count xy" + i + j);
                    }
                    else if (i == 0 && j == 0 && count2 == 2)
                    {
                        count += 1;
                        count2 = 0;
                        Console.WriteLine("Count xy" + i + j);
                    }
                    else
                    {
                        count2 = 0;
                    }

                }

            }

            return count2;
        }
        static void ReverseLine(int[,] matrix)
        {
            int count = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = count; j < matrix.GetLength(1); j++)
                {
                    if (i != j)
                    {
                        Swap(ref matrix[i, j], ref matrix[j, i]);
                    }
                }
                count += 1;
            }
        }
        static int GetLargestCells(int[,] matrix)
        {
            int count = 0;
            int count2 = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i > 0 && j > 0 && i < matrix.GetLength(0) - 1 &&
                        j < matrix.GetLength(1) - 1)
                    {
                        if (matrix[i, j] > (matrix[i - 1, j - 1]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i - 1, j]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i - 1, j + 1]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i + 1, j + 1]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i + 1, j]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i + 1, j - 1]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i, j + 1]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i, j - 1]))
                        {
                            count += 1;
                        }

                        if (count == 8)
                        {
                            count2 += 1;
                            count = 0;
                            Console.WriteLine(i + " " + j);
                        }
                        else
                        {
                            count = 0;
                        }
                    }

                    if (i == 0 && j > 0 && j < matrix.GetLength(1) - 1)
                    {
                        if (matrix[i, j] > (matrix[i + 1, j + 1]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i + 1, j]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i + 1, j - 1]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i, j + 1]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i, j - 1]))
                        {
                            count += 1;
                        }

                        if (count == 5)
                        {
                            count2 += 1;
                            count = 0;
                            Console.WriteLine(i + " " + j);
                        }
                        else
                        {
                            count = 0;
                        }
                    }
                    if (j == 0 && i > 0 && i < matrix.GetLength(0) - 1)
                    {
                        if (matrix[i, j] > (matrix[i - 1, j]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i - 1, j + 1]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i + 1, j + 1]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i + 1, j]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i, j + 1]))
                        {
                            count += 1;
                        }

                        if (count == 5)
                        {
                            count2 += 1;
                            count = 0;
                            Console.WriteLine(i + " " + j);
                        }
                        else
                        {
                            count = 0;
                        }
                    }
                    if (i == matrix.GetLength(0) - 1 &&
                        j > 0 && j < matrix.GetLength(1) - 1)
                    {
                        if (matrix[i, j] > (matrix[i - 1, j - 1]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i - 1, j]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i - 1, j + 1]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i, j + 1]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i, j - 1]))
                        {
                            count += 1;
                        }

                        if (count == 5)
                        {
                            count2 += 1;
                            count = 0;
                            Console.WriteLine(i + " " + j);
                        }
                        else
                        {
                            count = 0;
                        }
                    }
                    if (j == matrix.GetLength(1) - 1 &&
                         i > 0 && i < matrix.GetLength(0) - 1)
                    {
                        if (matrix[i, j] > (matrix[i - 1, j - 1]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i - 1, j]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i + 1, j]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i + 1, j - 1]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i, j - 1]))
                        {
                            count += 1;
                        }
                        if (count == 5)
                        {
                            count2 += 1;
                            count = 0;
                            Console.WriteLine(i + " " + j);
                        }
                        else
                        {
                            count = 0;
                        }
                    }

                    if (i == 0 && j == 0)
                    {
                        if (matrix[i, j] > (matrix[i + 1, j]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i, j + 1]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i + 1, j + 1]))
                        {
                            count += 1;
                        }
                        if (count == 3)
                        {
                            count2 += 1;
                            count = 0;
                            Console.WriteLine(i + " " + j);
                        }
                        else
                        {
                            count = 0;
                        }
                    }
                    if (i == 0 && j == matrix.GetLength(1) - 1)
                    {
                        if (matrix[i, j] > (matrix[i + 1, j]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i, j - 1]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i + 1, j - 1]))
                        {
                            count += 1;
                        }
                        if (count == 3)
                        {
                            count2 += 1;
                            count = 0;
                            Console.WriteLine(i + " " + j);
                        }
                        else
                        {
                            count = 0;
                        }
                    }
                    if (j == 0 && i == matrix.GetLength(0) - 1)
                    {
                        if (matrix[i, j] > (matrix[i - 1, j]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i, j + 1]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i - 1, j + 1]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i, j + 1]))
                        {
                            count += 1;
                        }
                        if (count == 3)
                        {
                            count2 += 1;
                            count = 0;
                            Console.WriteLine(i + " " + j);
                        }
                        else
                        {
                            count = 0;
                        }
                    }
                    if (j == matrix.GetLength(1) - 1
                        && i == matrix.GetLength(0) - 1)
                    {
                        if (matrix[i, j] > (matrix[i - 1, j]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i, j - 1]))
                        {
                            count += 1;
                        }
                        if (matrix[i, j] > (matrix[i - 1, j - 1]))
                        {
                            count += 1;
                        }
                        if (count == 3)
                        {
                            count2 += 1;
                            count = 0;
                            Console.WriteLine(i + " " + j);
                        }
                        else
                        {
                            count = 0;
                        }
                    }
                }

            }

            return count2;
        }

        static void Main(string[] args)
        {
            int[,] matrix = new int[5, 5];
            Random random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(1, 10);
                }
            }

            Write(matrix);

            (int minI1, int minI2) = MinI(matrix);
            (int maxI1, int maxI2) = MaxI(matrix);
            int min = Min(matrix);
            int max = Max(matrix);
            Console.WriteLine("min indices "+minI1 + " " + minI2);
            Console.WriteLine("max indices "+maxI1 + " " + maxI2);
            Console.WriteLine("min number"+min);
            Console.WriteLine("max number"+max);

            Write(matrix);
            Console.WriteLine();
            int count2 = GetLargestCells(matrix);
            Console.WriteLine("Number of largest array elements " +count2);

            Console.WriteLine();
            ReverseLine(matrix);
            Write(matrix);
        }
    }
}
