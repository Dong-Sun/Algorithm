// 구간 마다 간격을 구하고 모든 간격들의 최대 공약수 구하기?
int n = int.Parse(Console.ReadLine());
int[] arr = new int[n];
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = int.Parse(Console.ReadLine());
}
int[] distance = new int[n - 1];
for (int i = 0; i < n - 1; i++)
{
    distance[i] = arr[i + 1] - arr[i];
}
Array.Sort(distance);
int result = int.MaxValue;
for (int i = 1; i <= distance[0]; i++)
{
    int j = 0;
    int cnt = 0;
    while (j < distance.Length && distance[j] % i == 0)
    {
        cnt += distance[j] / i - 1;
        j += 1;
    }
    if (j == distance.Length)
        result = Math.Min(result, cnt);
}
Console.WriteLine(result);