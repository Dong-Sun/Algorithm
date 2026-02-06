// Initialize
int n = int.Parse(Console.ReadLine());
int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

// Solution
int result = int.MaxValue;
for (int i = 0; i < n; i++)
{
    for (int j = i + 1; j < n; j++)
    {
        // 공차 만들기
        if ((arr[i] - arr[j]) % (i - j) != 0)   // 나머지가 생기면 정수 공차가 아님
            continue;

        int d = (arr[i] - arr[j]) / (i - j);

        // 첫항을 구하고 공차를 더해가며 불일치 갯수 카운팅
        int a = arr[i] - d * i;
        int count = 0;
        for (int k = 0; k < n; k++)
        {
            if (arr[k] != a) count++;
            a += d;
        }
        result = Math.Min(result, count);
    }
}

// Output
Console.WriteLine(result);