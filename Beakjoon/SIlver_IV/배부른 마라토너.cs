int n = int.Parse(Console.ReadLine());
n = n * 2 - 1;
HashSet<string> hs = new HashSet<string>();
while (n-- > 0)
{
    string s = Console.ReadLine();
    if (hs.Contains(s))
        hs.Remove(s);
    else
        hs.Add(s);
}
hs.GetEnumerator().MoveNext();
foreach (var v in hs) Console.WriteLine(v);