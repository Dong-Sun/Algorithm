int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int d = input[0];
int k = input[1];

int[] fibo = new int[31];
fibo[1] = 1;
fibo[2] = 1;
for (int i = 3; i <= 30; i++)
    fibo[i] = fibo[i - 1] + fibo[i - 2];

int a = fibo[d - 2];
int b = fibo[d - 1];

int Ac = 1;
int Bc = 1;
while (a * Ac <= k)
{
    if ((k - a * Ac) % b == 0)
    {
        Bc = (k - a * Ac) / b;
        break;
    }
    Ac++;
}
System.Console.WriteLine(Ac);
System.Console.WriteLine(Bc);