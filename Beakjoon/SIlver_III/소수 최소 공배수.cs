int n = int.Parse(Console.ReadLine());
int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);

bool[] flag = new bool[1000001];
for (int i = 2; i <= 1000000; i++)
{
    if (flag[i] == false)
    {
        for (int j = i + i; j <= 1000000; j += i)
        {
            flag[j] = true;
        }
    }
}

List<int> list = new List<int>();
foreach (var v in arr)
{
    if (flag[v] == false)
        list.Add(v);
}

if (list.Count <= 0)
    Console.WriteLine("-1");
else
{
    long result = 1;
    foreach (var v in list)
    {
        if (result % v != 0)
            result *= v;
    }
    Console.WriteLine(result);
}