// 입력
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int t = input[2];
int[,] table = new int[n + 2, m];
for (int i = 1; i <= n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < m; j++)
        table[i, j] = input[j];
}
// 구현
while (t-- > 0)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    int x = input[0];
    int d = input[1];
    int k = input[2];
    while (k-- > 0)
    {
        for (int j = x; j <= n; j += x)
        {
            if (d == 0)
            {
                int temp = table[j, m - 1];
                for (int i = m - 1; i > 0; i--)
                    table[j, i] = table[j, i - 1];
                table[j, 0] = temp;
            }
            else
            {
                int temp = table[j, 0];
                for (int i = 0; i < m - 1; i++)
                    table[j, i] = table[j, i + 1];
                table[j, m - 1] = temp;
            }
        }
    }
    bool[,] delete = new bool[n + 2, m];
    bool trigger = false;
    for (int j = 1; j <= n; j++)
    {
        for (int i = 0; i < m; i++)
        {
            bool flag = false;
            if (table[j, i] == -1)
                continue;
            if (table[j, i] == table[j, (i + m - 1) % m])
            {
                delete[j, (i + m - 1) % m] = true;
                flag = true;
            }
            if (table[j, i] == table[j, (i + 1) % m])
            {
                delete[j, (i + 1) % m] = true;
                flag = true;
            }
            if (j - 1 > 0 && table[j, i] == table[j - 1, i])
            {
                delete[j - 1, i] = true;
                flag = true;
            }
            if (j + 1 <= n && table[j, i] == table[j + 1, i])
            {
                delete[j + 1, i] = true;
                flag = true;
            }
            if (flag)
            {
                delete[j, i] = true;
                trigger = true;
            }
        }
    }
    if (trigger)
    {
        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (delete[i, j])
                    table[i, j] = -1;
            }
        }
    }
    else
    {
        int avg = 0;
        int sum = 0;
        int count = 0;
        int rest = 0;
        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (table[i, j] == -1)
                    continue;
                sum += table[i, j];
                count++;
            }
        }
        if (count > 0)
        {
            avg = sum / count;
            rest = sum % count;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (table[i, j] == -1)
                        continue;
                    if (rest == 0)
                    {
                        if (table[i, j] < avg)
                            table[i, j]++;
                        else if (table[i, j] > avg)
                            table[i, j]--;
                    }
                    else
                    {
                        if (table[i, j] <= avg)
                            table[i, j]++;
                        else if (table[i, j] > avg)
                            table[i, j]--;
                    }
                }
            }
        }
    }
}
// 출력
int result = 0;
for (int i = 1; i <= n; i++)
{
    for (int j = 0; j < m; j++)
    {
        if (table[i, j] == -1)
            continue;
        result += table[i, j];
    }
}
Console.WriteLine(result);