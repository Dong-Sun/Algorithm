using System.Text;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            string input;
            while (true)
            {
                input = Console.ReadLine();
                if (input.Equals("."))
                    break;

                int[] pi = new int[input.Length];
                int j = 0;
                for (int i = 1; i < input.Length; i++)
                {
                    while (j > 0 && !Equals(input[i], input[j]))
                        j = pi[j - 1];
                    if (Equals(input[i], input[j]))
                        pi[i] = ++j;
                }
                int div = input.Length - pi[pi.Length - 1];
                if (div == 0) sb.AppendLine("1");
                else if (input.Length % div > 0) sb.AppendLine("1");
                else sb.AppendLine((input.Length / div).ToString());
            }
            Console.Write(sb);
        }
    }
}