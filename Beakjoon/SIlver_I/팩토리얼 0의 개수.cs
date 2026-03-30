int m = int.Parse(Console.ReadLine());
long left = 0;
long right = long.MaxValue;
while (left + 1 < right)
{
    long mid = (left + right) / 2;
    long count = Counting(mid);
    if (count < m)
        left = mid;
    else
        right = mid;
}
if (Counting(right) == m)
    Console.WriteLine(right);
else
    Console.WriteLine("-1");

long Counting(long num)
{
    long result = 0;
    for (long i = 5; i <= num; i *= 5)
        result += num / i;
    return result;
}