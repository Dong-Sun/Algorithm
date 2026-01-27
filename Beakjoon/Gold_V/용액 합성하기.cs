int n = int.Parse(Console.ReadLine());
int[] A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int left = 0;
int right = n - 1;
int result = int.MaxValue;
while (left < right)
{
    int cur = A[left] + A[right];
    if (Math.Abs(result) > Math.Abs(cur))
        result = cur;
    if (cur == 0) break;
    if (cur > 0) right -= 1;
    else left += 1;
}
Console.WriteLine(result);