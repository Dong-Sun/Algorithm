int[] input = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
int w = input[0];
int h = input[1];
input = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
int p = input[0];
int q = input[1];
int t = int.Parse(Console.ReadLine());
int pt = t % (w * 2);
int qt = t % (h * 2);
if (pt <= w - p)
{
    p += pt;
    pt = 0;
}
else
{
    pt -= w - p;
    p = w;
}
if (pt <= w)
{
    p -= pt;
    pt = 0;
}
else
{
    pt -= w;
    p = 0;
}
if (pt > 0)
{
    p += pt;
    pt = 0;
}

if (qt <= h - q)
{
    q += qt;
    qt = 0;
}
else
{
    qt -= h - q;
    q = h;
}

if (qt <= h)
{
    q -= qt;
    qt = 0;
}
else
{
    qt -= h;
    q = 0;
}
if (qt > 0)
{
    q += qt;
    qt = 0;
}

Console.WriteLine($"{p} {q}");