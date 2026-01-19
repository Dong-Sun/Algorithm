// 입력
int[,] table = new int[10, 10];
int m = 0;
for (int i = 0; i < 10; i++)
{
    int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < 10; j++)
    {
        table[i, j] = input[j];
        if (input[j] == 1)
            m += 1;
    }
}
// 구현
int[] count = { 0, 5, 5, 5, 5, 5 };
int result = -1;

Dfs(0, 0, 0);
void Dfs(int y, int x, int depth)
{
    // 비어있으면 return
    if (m <= 0)
    {
        if (result == -1) result = depth;
        else result = Math.Min(result, depth);
        return;
    }
    // 큰 색종이 부터 놓을 수 있는지 계산
    for (int i = y; i < 10; i++)
    {
        for (int j = x; j < 10; j++)
        {
            if (table[i, j] == 0)
                continue;

            for (int size = 5; size >= 1; size--)
            {
                if (count[size] <= 0)
                    continue;
                if (Possible(i, j, size))
                {
                    Minus(i, j, size);
                    Dfs(i, j + size, depth + 1);
                    Plus(i, j, size);
                }
            }
            return;
        }
        x = 0;
    }
}
bool Possible(int y, int x, int size)
{
    for (int i = y; i < y + size; i++)
        for (int j = x; j < x + size; j++)
            if (i >= 10 || j >= 10 || table[i, j] == 0)
                return false;

    return true;
}
void Plus(int y, int x, int size)
{
    for (int i = y; i < y + size; i++)
        for (int j = x; j < x + size; j++)
            table[i, j] = 1;
    count[size] += 1;
    m += size * size;
}
void Minus(int y, int x, int size)
{
    for (int i = y; i < y + size; i++)
        for (int j = x; j < x + size; j++)
            table[i, j] = 0;
    count[size] -= 1;
    m -= size * size;
}
// 출력
Console.WriteLine(result);