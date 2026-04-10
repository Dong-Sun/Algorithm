string x = Console.ReadLine();
int count = 0;
while (x.Length >= 2)
{
    count++;
    int temp = 0;
    for (int i = 0; i < x.Length; i++)
        temp += int.Parse(x[i].ToString());
    x = temp.ToString();
}
if (int.Parse(x) % 3 == 0)
{
    Console.WriteLine(count);
    Console.WriteLine("YES");
}
else
{
    Console.WriteLine(count);
    Console.WriteLine("NO");
}