string input = Console.ReadLine();
int size = input.Length;
char[] table = new char[size];
bool[] flag = new bool[size];
int count = 0;
HashSet<string> check = new HashSet<string>();

Dfs(0);
Console.WriteLine(count);
void Dfs(int depth)
{
    if (depth == size)
    {
        string str = new string(table);
        if (check.Contains(str))
            return;

        check.Add(str);

        if (IsLucky())
            count++;
    }

    for (int i = 0; i < size; i++)
    {
        if (flag[i])
            continue;

        flag[i] = true;
        table[depth] = input[i];
        Dfs(depth + 1);
        flag[i] = false;
    }
}
bool IsLucky()
{
    for (int i = 0; i < size - 1; i++)
    {
        if (table[i] == table[i + 1])
            return false;
    }
    return true;
}