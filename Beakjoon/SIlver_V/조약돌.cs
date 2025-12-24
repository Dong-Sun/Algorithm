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
            int n = InputInt();
            int row = 1;
            int col = 1;
            while ((row + 1) * (col + 1) < n)
            {
                row++;
                if ((row + 1) * (col + 1) >= n)
                    break;
                col++;
            }
            System.Console.WriteLine((row + col) * 2);
        }
    }
}