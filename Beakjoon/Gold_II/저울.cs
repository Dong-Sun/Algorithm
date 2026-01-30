int n = int.Parse(Console.ReadLine());
int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
Array.Sort(arr);
int sum = 0;
for (int i = 0; i < n; i++)
{
    if (sum + 1 < arr[i])
        break;
    sum += arr[i];
}
Console.WriteLine(sum + 1);