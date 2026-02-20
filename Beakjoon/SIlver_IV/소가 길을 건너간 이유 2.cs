string s = Console.ReadLine();
int[,] alpha = new int[26, 2];
bool[] flag = new bool[26];
for (int i = 0; i < s.Length; i++)
{
    int cur = s[i] - 'A';
    if (flag[cur])
        alpha[cur, 1] = i;
    else
        alpha[cur, 0] = i;
    flag[cur] = true;
}
int result = 0;
for (int i = 0; i < 26; i++)
{
    int left = alpha[i, 0];
    int right = alpha[i, 1];
    for (int j = i + 1; j < 26; j++)
    {
        int nextLeft = alpha[j, 0];
        int nextRight = alpha[j, 1];
        if (left < nextLeft && nextLeft < right && right < nextRight)
            result++;
        else if (nextLeft < left && left < nextRight && nextRight < right)
            result++;
    }
}
Console.WriteLine(result);