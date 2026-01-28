int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
Console.WriteLine(m - GCD(n, m));
int GCD(int a, int b)
{
    if (b == 0) return a;
    else return GCD(b, a % b);
}