using System.Numerics;

int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int s = input[0];
int c = input[1];
int[] arr = new int[s];
int left = 0;
int right = 1000000001;
for (int i = 0; i < s; i++)
{
    arr[i] = int.Parse(Console.ReadLine());
}
while (left + 1 < right)
{
    int mid = (left + right) / 2;
    int count = 0;
    foreach (var v in arr)
        count += v / mid;

    if (count < c)
        right = mid;
    else
        left = mid;
}
long result = 0;
foreach (var v in arr)
{
    if (v / left < c)
    {
        result += v - left * (v / left);
        c -= v / left;
    }
    else
    {
        result += v - left * c;
        c = 0;
    }
}
Console.WriteLine(result);