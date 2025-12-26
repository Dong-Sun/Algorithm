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
            string input = Console.ReadLine();
            Stack<string> s = new Stack<string>();
            if (input[0].Equals('A'))
                Console.WriteLine("NP");
            else
            {
                s.Push("P");
                for (int i = 1; i < input.Length; i++)
                {
                    if (s.Count > 0)
                    {
                        if (s.Peek().Equals("P"))
                            s.Push(input[i].ToString());
                        else
                        {
                            if (input[i].Equals('A'))
                                break;
                            else
                            {
                                s.Pop();
                                if (s.Count > 0)
                                    s.Pop();
                            }
                        }
                    }
                    else
                        break;
                }
                if (s.Count != 1 || s.Peek().Equals("A"))
                    Console.WriteLine("NP");
                else
                    Console.WriteLine("PPAP");
            }
        }
    }
}