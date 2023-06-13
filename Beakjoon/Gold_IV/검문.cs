static int GCD(int a, int b)
{
    if (a == 0) return b;
    if (b == 0) return a;

    if (a % b == 0) return b;
    else return GCD(b, a % b);
}
int n = int.Parse(Console.ReadLine());
int[] numarr = new int[n];
int GcdN = 0;
for (int i = 0; i < numarr.Length; i++)
{
    numarr[i] = int.Parse(Console.ReadLine());
    if (i == 0) continue;
    numarr[i] = Math.Abs(numarr[i] - numarr[0]);
    if (i == 1)
    {
        GcdN = numarr[i];
        continue;
    }
    GcdN = GCD(GcdN, numarr[i]);
}
for (int i = 2; i <= GcdN; i++)
{
    if (GcdN % i == 0)
        Console.WriteLine(i);
}