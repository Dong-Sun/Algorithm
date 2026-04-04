int n = int.Parse(Console.ReadLine());
int result = 0;
while (n-- > 0)
{
    string s = Console.ReadLine();
    if (s.Length % 2 == 1)
        continue;
    Stack<char> stack = new Stack<char>();
    stack.Push(s[0]);
    for (int i = 1; i < s.Length; i++)
    {
        if (stack.Count == 0)
            stack.Push(s[i]);
        else if (stack.Peek() != s[i])
            stack.Push(s[i]);
        else
            stack.Pop();
    }
    if (stack.Count == 0)
        result++;
}
Console.WriteLine(result);