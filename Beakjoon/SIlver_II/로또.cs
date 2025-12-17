namespace CSharp
{
    class Program
    {
        static List<int> result = new List<int>();
        static int[] S;
        static int k;
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("0"))
                    break;
                S = Array.ConvertAll(input.Split(), int.Parse);
                k = S[0];
                for (int i = 1; i <= k - 6 + 1; i++)
                {
                    BackTracking(i, 1);
                }
                Console.WriteLine();
            }
        }
        static void BackTracking(int index, int depth)
        {
            if (depth == 6)
            {
                result.Add(S[index]);
                foreach (var v in result)
                    Console.Write("{0} ", v);
                Console.WriteLine();
                result.RemoveAt(result.Count - 1);
                return;
            }
            result.Add(S[index]);
            for (int i = index + 1; i <= k - (6 - depth) + 1; i++)
                BackTracking(i, depth + 1);
            result.RemoveAt(result.Count - 1);
        }
    }
}