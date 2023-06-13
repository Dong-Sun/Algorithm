string str = Console.ReadLine();

int result = 0, size = 0;
for (int i = 0; i < str.Length; i++)
{
    if (str[i] == '(')
    {
        if (str[i + 1] == '(')
            size++;
        else if (str[i + 1] == ')')
        {
            result = result + size;
            i++;
        }
    }
    else if (str[i] == ')')
    {
        result++;
        size--;
    }
}
Console.WriteLine(result);