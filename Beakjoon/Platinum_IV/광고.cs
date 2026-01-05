namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int L = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            int[] lps = new int[L];
            int left = 0;
            for (int i = 1; i < L; i++)
            {
                while (left > 0 && !s[i].Equals(s[left]))
                    left = lps[left - 1];
                if (s[i].Equals(s[left]))
                {
                    left++;
                    lps[i] = left;
                }
            }
            Console.WriteLine(L - lps[L - 1]);
        }
    }
}