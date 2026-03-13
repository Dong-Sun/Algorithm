int n = int.Parse(Console.ReadLine());
int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

int max = 0;
int index = 0;
for (int i = 0; i < n; i++)
{
    if (arr[i] > max)
    {
        max = arr[i];
        index = i;
    }
}

int result = max * (n - 1);
for (int i = 0; i < n; i++)
{
    if (i == index) continue;
    result += arr[i];
}
Console.WriteLine(result);