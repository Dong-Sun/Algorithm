namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution();
        }

        public static void Solution()
        {

            int T = int.Parse(Console.ReadLine());
            while (T > 0)
            {
                Queue<KeyValuePair<int, int>> q = new Queue<KeyValuePair<int, int>>();
                List<int> pq = new List<int>();
                string[] split = Console.ReadLine().Split();
                int n = int.Parse(split[0]);
                int m = int.Parse(split[1]);
                split = Console.ReadLine().Split();
                for (int i = 0; i < n; i++)
                {
                    KeyValuePair<int, int> temp = new KeyValuePair<int, int>(i, int.Parse(split[i]));
                    q.Enqueue(temp);
                    pq.Add(temp.Value);
                }
                pq.Sort();
                pq.Reverse();
                int count = 0;

                while (q.Count > 0)
                {
                    int index = q.Peek().Key;
                    int value = q.Peek().Value;
                    q.Dequeue();

                    if (value == pq[0])
                    {
                        count++;
                        if (index == m)
                        {
                            Console.WriteLine(count);
                            break;
                        }
                        pq.RemoveAt(0);
                    }
                    else
                        q.Enqueue(new KeyValuePair<int, int>(index, value));
                }
                T--;
            }
        }
    }
}