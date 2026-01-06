namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            using var input = new StreamReader(Console.OpenStandardInput());
            int n = int.Parse(input.ReadLine());
            int[] A = Array.ConvertAll(input.ReadLine().Split(), int.Parse);
            int[] lis = new int[n];
            for (int i = 0; i < n; i++)
                lis[i] = int.MaxValue;
            int result = 0;
            for (int i = 0; i < n; i++)
            {
                int left = -1;
                int right = n;
                while (left + 1 < right)
                {
                    int pivot = (left + right) / 2;
                    if (lis[pivot] < A[i])
                        left = pivot;
                    else
                        right = pivot;
                }
                lis[right] = A[i];
                result = Math.Max(result, right + 1);
            }
            Console.WriteLine(result);
        }
    }
}