namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = Convert.ToInt32(Console.ReadLine());
            int[,] table = new int[64, 64];

            string str;
            for (int i = 0; i < n; i++)
            {
                str = Console.ReadLine();
                for (int j = 0; j < str.Length; j++)
                {
                    table[i, j] = Convert.ToInt32(str[j]) - 48;
                }
            }

            Divide(ref table, n, 0, 0);
        }

        static void Divide(ref int[,] table, int length, int startX, int startY)
        {
            int color = table[startY, startX];
            bool check = true;
            for (int y = startY; y < startY + length; y++)
            {
                for (int x = startX; x < startX + length; x++)
                {
                    if (color != table[y, x])
                        check = false;
                }
            }

            if (check)
            {
                Console.Write($"{color}");
                return;
            }

            Console.Write("(");
            Divide(ref table, length / 2, startX, startY);
            Divide(ref table, length / 2, startX + length / 2, startY);
            Divide(ref table, length / 2, startX, startY + length / 2);
            Divide(ref table, length / 2, startX + length / 2, startY + length / 2);
            Console.Write(")");
        }
    }
}
