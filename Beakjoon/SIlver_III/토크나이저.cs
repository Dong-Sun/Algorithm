using System.Runtime.CompilerServices;
using System.Text;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            char c = '\0';
            for (int i = 0; i < input.Length; i++)
            {
                if (c == ' ' && input[i] == ' ')
                    continue;
                if (input[i] == '<' || input[i] == '>'
                || input[i] == '(' || input[i] == ')')
                {
                    if (c != ' ' && c != '\0')
                        sb.Append(' ');
                    sb.Append(input[i]);
                    sb.Append(' ');
                    c = ' ';
                }
                else if (input[i] == '&' || input[i] == '|')
                {
                    if (c != ' ' && c != '\0')
                        sb.Append(' ');
                    sb.Append(input[i]);
                    sb.Append(input[i]);
                    sb.Append(' ');
                    c = ' ';
                    i++;
                }
                else
                {
                    sb.Append(input[i]);
                    c = input[i];
                }
            }
            System.Console.WriteLine(sb);
        }
    }
}