int n = int.Parse(Console.ReadLine());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int m = input[0];
int k = input[1];
int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
Array.Sort(arr, (left, right) => right.CompareTo(left));
int count = m * k;
for (int i = 0; i < n; i++)
{
    count -= arr[i];
    if (count <= 0)
    {
        Console.WriteLine(i + 1);
        return;
    }
}
Console.WriteLine("STRESS");