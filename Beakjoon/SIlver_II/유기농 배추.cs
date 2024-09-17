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
                string[] split = Console.ReadLine().Split();
                int Row = int.Parse(split[0]);
                int Col = int.Parse(split[1]);
                int K = int.Parse(split[2]);
                int count = 0;
                bool[,] visited = new bool[Col + 2, Row + 2];
                bool[,] actived = new bool[Col + 2, Row + 2];
                Queue<Position> q = new Queue<Position>();
                while (K > 0)
                {
                    split = Console.ReadLine().Split();
                    int x = int.Parse(split[0]) + 1;
                    int y = int.Parse(split[1]) + 1;
                    actived[y, x] = true;
                    K--;
                }
                for (int i = 1; i <= Col; i++)
                {
                    for (int j = 1; j <= Row; j++)
                    {
                        if (actived[i, j] == false || visited[i, j] == true)
                            continue;
                        count++;
                        q.Enqueue(new Position(i, j));
                        visited[i, j] = true;
                        while (q.Count > 0)
                        {
                            Position p = q.Dequeue();
                            int y = p.ypos;
                            int x = p.xpos;
                            if (actived[y, x + 1] == true && visited[y, x + 1] == false)
                            {
                                q.Enqueue(new Position(y, x + 1));
                                visited[y, x + 1] = true;
                            }
                            if (actived[y, x - 1] == true && visited[y, x - 1] == false)
                            {
                                q.Enqueue(new Position(y, x - 1));
                                visited[y, x - 1] = true;
                            }
                            if (actived[y + 1, x] == true && visited[y + 1, x] == false)
                            {
                                q.Enqueue(new Position(y + 1, x));
                                visited[y + 1, x] = true;
                            }
                            if (actived[y - 1, x] == true && visited[y - 1, x] == false)
                            {
                                q.Enqueue(new Position(y - 1, x));
                                visited[y - 1, x] = true;
                            }
                        }
                    }
                }
                Console.WriteLine(count);
                T--;
            }
        }
        public class Position
        {
            public int ypos;
            public int xpos;
            public Position(int _ypos, int _xpos)
            {
                ypos = _ypos;
                xpos = _xpos;
            }
        }
    }
}