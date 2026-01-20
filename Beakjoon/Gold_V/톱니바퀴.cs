int[,] cogwheel = new int[5, 8];
for (int i = 1; i < 5; i++)
{
    string s = Console.ReadLine();
    for (int j = 0; j < 8; j++)
        cogwheel[i, j] = int.Parse(s[j].ToString());
}
int k = int.Parse(Console.ReadLine());
int[] rotate = new int[5];
int right = 2;
int left = 6;
while (k > 0)
{
    k--;
    int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    int order = input[0];
    int rotation = input[1];
    int next = order + 1;
    if (next < 5 && cogwheel[order, (right + rotate[order]) % 8] != cogwheel[next, (left + rotate[next]) % 8])
        Search(order + 1, 1, -rotation);
    next = order - 1;
    if (next > 0 && cogwheel[order, (left + rotate[order]) % 8] != cogwheel[next, (right + rotate[next]) % 8])
        Search(order - 1, -1, -rotation);
    rotate[order] = (rotate[order] - rotation + 8) % 8;
}
void Search(int index, int dir, int rotation)
{
    int next = index + dir;
    if (dir == 1)
    {
        if (next < 5 && cogwheel[index, (right + rotate[index]) % 8] != cogwheel[next, (left + rotate[next]) % 8])
            Search(next, dir, -rotation);
    }
    else
    {
        if (next > 0 && cogwheel[index, (left + rotate[index]) % 8] != cogwheel[next, (right + rotate[next]) % 8])
            Search(next, dir, -rotation);
    }
    rotate[index] = (rotate[index] - rotation + 8) % 8;
}
int result = 0;
for (int i = 1; i <= 4; i++)
{
    if (cogwheel[i, rotate[i]] == 1)
        result += 1 << (i - 1);
}
Console.WriteLine(result);