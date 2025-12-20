namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int V = input[0];
            int E = input[1];
            int[,] distance = new int[V + 1, V + 1];
            int Max = 100000005;
            for (int i = 1; i <= V; i++)
            {
                for (int j = 1; j <= V; j++)
                {
                    if (i == j)
                        distance[i, j] = 0;
                    else
                        distance[i, j] = Max;
                }
            }

            for (int i = 0; i < E; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int start = input[0];
                int end = input[1];
                int dist = input[2];
                distance[start, end] = dist;
            }

            for (int k = 1; k <= V; k++)
                for (int i = 1; i <= V; i++)
                    for (int j = 1; j <= V; j++)
                    {
                        if (i == j) continue;
                        if (distance[i, k] != Max && distance[k, j] != Max)
                            distance[i, j] = Math.Min(distance[i, j], distance[i, k] + distance[k, j]);
                    }

            int result = Max;
            for (int i = 1; i <= V; i++)
            {
                for (int j = 1; j <= V; j++)
                {
                    if (i == j) continue;
                    if (distance[i, j] != Max && distance[j, i] != Max)
                        result = Math.Min(result, distance[i, j] + distance[j, i]);
                }
            }
            if (result == Max)
                Console.WriteLine("-1");
            else
                Console.WriteLine(result);
        }
    }
}