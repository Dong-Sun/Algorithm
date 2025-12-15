using System.Runtime.InteropServices;
using System.Text;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            string input = Console.ReadLine();
            var s = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                char cur = input[i];
                if (cur >= 'A' && cur <= 'Z')
                    sb.Append(cur);
                else
                {
                    if (cur == '+' || cur == '-')
                    {
                        while (s.Count > 0 && s.Peek() != '(')
                            sb.Append(s.Pop());
                        s.Push(cur);
                    }
                    else if (cur == ')')
                    {
                        while (s.Count > 0 && s.Peek() != '(')
                            sb.Append(s.Pop());
                        s.Pop();
                    }
                    else if (cur == '*' || cur == '/')
                    {
                        while (s.Count > 0 && (s.Peek() == '*' || s.Peek() == '/'))
                            sb.Append(s.Pop());
                        s.Push(cur);
                    }
                    else
                        s.Push(cur);
                }
            }
            while (s.Count > 0)
                sb.Append(s.Pop());
            Console.WriteLine(sb);
        }
    }
}