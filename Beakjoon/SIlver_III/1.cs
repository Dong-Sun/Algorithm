using System.Numerics;

while (true)
{
    string? input = Console.ReadLine();
    if (input is null) break;
    int n = int.Parse(input);
    BigInteger num = 0;
    while (true)
    {
        num = num * 10 + 1;
        if (num % n == 0)
            break;
    }
    Console.WriteLine(num.ToString().Length);
}