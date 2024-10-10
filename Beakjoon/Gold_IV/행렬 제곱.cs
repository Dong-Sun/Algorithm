using System.Text;

namespace Debug
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static long[,] table;
        static long[,] temp;
        static long n;
        static long b;
        static long[,] arr;
        static void Main(string[] args)
        {
            long[] input = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            n = input[0];
            b = input[1];
            table = new long[n, n];
            temp = new long[n, n];
            arr = new long[n, n];
            for (int i = 0; i < n; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                for (int j = 0; j < n; j++)
                {
                    table[i, j] = input[j];
                }
                temp[i, i] = 1;
            }
            while (b > 0)
            {
                if (b % 2 == 1)
                {
                    Multiply(ref temp, ref table);
                }
                Multiply(ref table, ref table);
                b /= 2;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sb.Append($"{temp[i, j]} ");
                }
                sb.AppendLine();
            }
            Console.Write(sb);
        }
        static void Multiply(ref long[,] left, ref long[,] right)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    long sum = 0;
                    for (int k = 0; k < n; k++)
                    {
                        sum += left[i, k] * right[k, j];
                    }
                    arr[i, j] = sum % 1000;
                }
            }
            Array.Copy(arr, left, arr.Length);
        }
    }
}