// input
int n = int.Parse(Console.ReadLine());
string str = Console.ReadLine();

// solution
Stack<int> s = new();
bool[] correct = new bool[n];
for (int i = 0; i < n; i++)
{
    if (str[i].Equals('('))
    {
        s.Push(i);
    }
    else
    {
        if (s.Count > 0)
        {
            correct[i] = true;
            correct[s.Pop()] = true;
        }
    }
}

int max = 0;
int length = 0;
for (int i = 0; i < n; i++)
{
    if (correct[i])
    {
        length++;
        max = Math.Max(max, length);
    }
    else
    {
        length = 0;
    }
}

// print
Console.WriteLine(max);