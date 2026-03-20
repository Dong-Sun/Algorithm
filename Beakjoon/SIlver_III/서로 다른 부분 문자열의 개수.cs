int result = 0;
HashSet<string> flag = new HashSet<string>();
string str = Console.ReadLine();
for (int i = 0; i < str.Length; i++)
{
    for (int j = i + 1; j <= str.Length; j++)
    {
        if (!flag.Contains(str[i..j]))
        {
            flag.Add(str[i..j]);
            result++;
        }
    }
}
Console.WriteLine(result);