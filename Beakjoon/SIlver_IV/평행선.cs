// input
int n = int.Parse(Console.ReadLine());
(int left, int right)[] pos = new (int left, int right)[n];
for (int i = 0; i < n; i++)
{
    int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    pos[i] = (input[0], input[1]);
}

// solution
Dictionary<int, int> dictY = new();
Dictionary<int, int> dictX = new();
for (int i = 0; i < n; i++)
{
    if (dictY.TryAdd(pos[i].left, 0) == false)
        dictY[pos[i].left]++;

    if (dictX.TryAdd(pos[i].right, 0) == false)
        dictX[pos[i].right]++;
}

// print
int result = 0;
foreach (var v in dictY)
{
    if (v.Value > 0)
        result++;
}
foreach (var v in dictX)
{
    if (v.Value > 0)
        result++;
}
Console.WriteLine(result);