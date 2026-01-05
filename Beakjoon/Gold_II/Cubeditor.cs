namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int[] lps = new int[s.Length];
            int left;
            int max = 0;
            for (int start = 0; start < s.Length - 1; start++)
            {
                for (int index = 0; index < lps.Length; index++)
                    lps[index] = start;
                left = start;
                for (int i = left + 1; i < s.Length; i++)
                {
                    while (left > start && !s[i].Equals(s[left]))
                        left = lps[left - 1];
                    if (s[i].Equals(s[left]))
                    {
                        left++;
                        lps[i] = left;
                        max = Math.Max(max, left - start);
                    }
                }
            }
            Console.WriteLine(max);
        }
    }
}