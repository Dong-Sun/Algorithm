int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int[] arr = new int[n];
int left = 0;
int right = 0;
for (int i = 0; i < n; i++)
{
    arr[i] = int.Parse(Console.ReadLine());
    left = Math.Max(left, arr[i]);
    right += arr[i];
}
left--;
right++;
while (left + 1 < right)
{
    int mid = (left + right) / 2;
    int count = 0;
    int money = 0;
    for (int i = 0; i < n; i++)
    {
        if (money < arr[i])
        {
            money = mid;
            count++;
        }
        money -= arr[i];
    }

    if (count > m)
        left = mid;
    else
        right = mid;
}
Console.WriteLine(right);