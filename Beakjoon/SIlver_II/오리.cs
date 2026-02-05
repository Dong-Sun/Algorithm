// Initialize
string s = Console.ReadLine();
int[] word = new int[5];
int count = 0;
int max = 0;

// Solution
for (int i = 0; i < s.Length; i++)
{
    switch (s[i])
    {
        case 'q':
            word[0] += 1;
            count += 1;
            break;
        case 'u':
            if (word[0] > 0)
            {
                word[0] -= 1;
                word[1] += 1;
            }
            else
            {
                Console.WriteLine("-1");
                return;
            }
            break;
        case 'a':
            if (word[1] > 0)
            {
                word[1] -= 1;
                word[2] += 1;
            }
            else
            {
                Console.WriteLine("-1");
                return;
            }
            break;
        case 'c':
            if (word[2] > 0)
            {
                word[2] -= 1;
                word[3] += 1;
            }
            else
            {
                Console.WriteLine("-1");
                return;
            }
            break;
        case 'k':
            if (word[3] > 0)
            {
                word[3] -= 1;
                max = Math.Max(max, count);
                count -= 1;
            }
            else
            {
                Console.WriteLine("-1");
                return;
            }
            break;
    }
}

// Output
for (int i = 0; i < word.Length; i++)
{
    if (word[i] > 0)
    {
        Console.WriteLine("-1");
        return;
    }
}
Console.WriteLine(max);