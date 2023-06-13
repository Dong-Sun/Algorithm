int k = int.Parse(System.Console.ReadLine());
int[] num = new int[k];
int n, index = -1, sum = 0;
for (int i = 0; i < k; i++)
{
    n = int.Parse(System.Console.ReadLine());
    if (n != 0)
    {
        index++;
        num[index] = n;
    }
    else index--;
}
for (int i = 0; i <= index; i++) sum = sum + num[i];
System.Console.WriteLine(sum);