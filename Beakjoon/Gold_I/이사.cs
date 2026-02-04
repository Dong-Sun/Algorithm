// Initialize
int n = int.Parse(Console.ReadLine());
var positions = new (int x, int y)[n];
double min = double.MaxValue;
int rx = 0;
int ry = 0;
for (int i = 0; i < n; i++)
{
    int[] p = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    positions[i] = (p[0], p[1]);
}

// Solution
for (int i = 0; i < n; i++)
{
    double max = 0;
    for (int j = 0; j < n; j++)
    {
        max = Math.Max(max, Distance(positions[i], positions[j]));
    }
    if (min > max)
    {
        min = max;
        rx = positions[i].x;
        ry = positions[i].y;
    }
}

// Output
Console.WriteLine("{0} {1}", rx, ry);

// Function
double Distance((int x, int y) cur, (int x, int y) next)
{
    return Math.Sqrt(Math.Pow(cur.x - next.x, 2) + Math.Pow(cur.y - next.y, 2));
}