int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
Array.Sort(arr, (left, right) =>
{
    if (left % 10 == 0 && right % 10 == 0)
        return left.CompareTo(right);
    else if (left % 10 == 0)
        return -1;
    else if (right % 10 == 0)
        return 1;
    else
        return left.CompareTo(right);
});

int result = 0;
for (int i = 0; i < n; i++)
{
    if (arr[i] < 10) continue;
    if (arr[i] == 10) result++;
    else
    {
        int cake = arr[i] / 10; // 길이가 10인 롤케이크 수
        if (arr[i] % 10 == 0)    // 10의 배수
        {
            int cut = cake - 1;
            if (cut > m)
            {
                result += m;
                break;
            }
            else
            {
                result += cake;
                m -= cut;
            }
        }
        else
        {
            int cut = cake;
            if (cut > m)
            {
                result += m;
                break;
            }
            else
            {
                result += cake;
                m -= cut;
            }
        }
    }
}
Console.WriteLine(result);