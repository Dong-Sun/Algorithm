int n = int.Parse(Console.ReadLine());
int num = 1;
int result = 0;
while (num * num <= n)
{
    result++;
    num++;
}
Console.WriteLine(result);