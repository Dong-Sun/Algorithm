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
            string input = Console.ReadLine();
            List<string> list = new List<string>(input.Length + 1);
            sb.Append(input);
            while (sb.Length > 0)
            {
                list.Add(sb.ToString());
                sb.Remove(0, 1);
            }
            list.Sort();
            foreach (var v in list)
                Console.WriteLine(v);
        }
    }
}