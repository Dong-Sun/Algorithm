long k = long.Parse(Console.ReadLine());
long index = 1;
while (index < k)
    index += index;
index /= 2;
Console.WriteLine(Divide(k, index) == true ? 1 : 0);

bool Divide(long num, long i)
{
    if (num == 1) return false;
    while (i >= num)
        i /= 2;
    return !Divide(num - i, i / 2);
}