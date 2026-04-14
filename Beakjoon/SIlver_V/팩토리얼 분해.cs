long n = long.Parse(Console.ReadLine());
long temp = 1;
long[] arr = new long[20];
arr[0] = 1;
for (int i = 1; i < 20; i++)
{
    temp *= i;
    arr[i] = temp;
}

bool flag = false;
for (int i = 0; i < 20; i++)
{
    if (arr[i] == n)
    {
        flag = true;
        break;
    }
    else if (flag == false && arr[i] < n)
        Comb(arr[i], i + 1);
}
if (flag)
    Console.WriteLine("YES");
else
    Console.WriteLine("NO");

void Comb(long num, int index)
{
    for (int i = index; i < 20; i++)
    {
        if (flag)
            return;
        if (num + arr[i] == n)
            flag = true;
        else if (num + arr[i] < n)
            Comb(num + arr[i], i + 1);
        else
            break;
    }
}