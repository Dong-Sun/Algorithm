int n = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

int left = -1;
int right = n + 1;

while (left + 1 < right)
{
    int[,] light = new int[m, 2];
    int mid = (left + right) / 2;
    for (int i = 0; i < m; i++)
    {
        light[i, 0] = input[i] - mid;
        light[i, 1] = input[i] + mid;
    }
    bool flag = true;
    for (int i = 0; i < m; i++)
    {
        if (i == 0 && 0 < light[i, 0])
        {
            flag = false;
            break;
        }
        if (i == m - 1 && light[i, 1] < n)
        {
            flag = false;
            break;
        }
        if (i < m - 1 && light[i, 1] < light[i + 1, 0])
        {
            flag = false;
            break;
        }
    }
    if (flag)
        right = mid;
    else
        left = mid;
}
Console.WriteLine(right);