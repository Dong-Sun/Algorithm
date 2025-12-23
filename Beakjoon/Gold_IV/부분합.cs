using System.Text;

namespace CSharp
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static Func<int[]> InputIntArray = () => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        static Func<int> InputInt = () => int.Parse(Console.ReadLine());
        static void Main(string[] args)
        {
            // input
            int[] input = InputIntArray();
            int n = input[0];
            int s = input[1];
            input = InputIntArray();
            int left = 0;
            int right = 0;
            int temp = input[0];
            const int MAX = 1000000000;
            int dist = MAX;
            while (left <= right)
            {
                if (temp >= s)
                {
                    dist = Math.Min(dist, right - left + 1);
                    temp -= input[left++];
                }
                else
                {
                    if (right >= n - 1)
                        break;
                    temp += input[++right];
                }
            }
            if (dist == MAX)
                Console.WriteLine("0");
            else
                Console.WriteLine(dist);
        }
    }
}