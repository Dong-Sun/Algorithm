int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];
int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

int[] count = new int[100001];
int left = 0;
int right = 0;
int result = 0;
while (right < n)
{
    int cur = arr[right];
    count[cur]++;
    if (count[cur] > k)
    {
        while (left < right)
        {
            int prev = arr[left];
            count[prev]--;
            left++;
            if (count[cur] <= k)
                break;
        }
    }
    result = Math.Max(result, right - left + 1);
    right++;
}
Console.WriteLine(result);