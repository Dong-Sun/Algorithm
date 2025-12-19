using System.Text;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int n = input[0];
            int m = input[1];
            int[,] A = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                for (int j = 0; j < m; j++)
                    A[i, j] = input[j];
            }
            input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int k = input[1];
            int[,] B = new int[m, k];
            for (int i = 0; i < m; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                for (int j = 0; j < k; j++)
                    B[i, j] = input[j];
            }

            int[,] result = new int[n, k];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < k; j++)
                    for (int l = 0; l < m; l++)
                        result[i, j] += A[i, l] * B[l, j];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < k; j++)
                    sb.Append(result[i, j] + " ");
                sb.Append('\n');
            }
            Console.WriteLine(sb);
        }
    }
}