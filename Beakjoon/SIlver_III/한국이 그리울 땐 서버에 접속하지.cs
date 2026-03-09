int n = int.Parse(Console.ReadLine());
int pivot = 0;
string pattern = Console.ReadLine();
for (int i = 0; i < pattern.Length; i++)
{
    if (pattern[i] == '*')
    {
        pivot = i;
        break;
    }
}
while (n-- > 0)
{
    string name = Console.ReadLine();
    if (name.Length < pattern.Length - 1)
    {
        Console.WriteLine("NE");
        continue;
    }
    bool flag = (pattern[..pivot] == name[..pivot]) && (pattern[(pivot + 1)..] == name[(name.Length - (pattern.Length - 1 - pivot))..]);
    if (flag) Console.WriteLine("DA");
    else Console.WriteLine("NE");
}