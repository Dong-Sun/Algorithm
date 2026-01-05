using System.Text;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string T = Console.ReadLine();
            string P = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            // LPS
            int start = 0;
            int[] lps = new int[P.Length];
            for (int i = 1; i < P.Length; i++)
            {
                while (start > 0 && !P[i].Equals(P[start]))
                    start = lps[start - 1];
                if (P[i].Equals(P[start]))
                {
                    start++;
                    lps[i] = start;
                }
            }
            // KMP
            start = 0;
            int cnt = 0;
            for (int i = 0; i < T.Length; i++)
            {
                while (start > 0 && !T[i].Equals(P[start]))
                    start = lps[start - 1];
                if (T[i].Equals(P[start]))
                {
                    if (start == P.Length - 1)
                    {
                        cnt++;
                        sb.Append((i - start + 1).ToString() + " ");
                        start = lps[start];
                    }
                    else
                        start++;
                }
            }
            Console.WriteLine(cnt);
            Console.WriteLine(sb);
        }
    }
}