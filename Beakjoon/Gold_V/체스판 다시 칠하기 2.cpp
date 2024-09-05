#include <iostream>
#include <string.h>
using namespace std;

int n, m, k;
char board[2002][2002];
int sum[2002][2002];

int solve(char color)
{
    memset(sum, 0, sizeof(sum));
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= m; j++)
        {
            if (i % 2 == 1)
            {
                if (j % 2 == 1 && board[i][j] != color)
                        sum[i][j] = 1;
                if (j % 2 == 0 && board[i][j] == color)
                        sum[i][j] = 1;
            }
            else
            {
                if (j % 2 == 1 && board[i][j] == color)
                        sum[i][j] = 1;
                if (j % 2 == 0 && board[i][j] != color)
                        sum[i][j] = 1;
            }
        }
    }
    int result = 100000000;
    // 누적 합
    for (int i = 1; i <= n; i++)
        for (int j = 1; j <= m; j++)
            sum[i][j] += sum[i - 1][j] + sum[i][j - 1] - sum[i - 1][j - 1];
    
    for (int i = 1; i <= n - k + 1; i++)
    {
        for (int j = 1; j <= m - k + 1; j++)
        {
            int cnt = sum[i + k - 1][j + k - 1] - sum[i - 1][j + k - 1] - sum[i + k - 1][j - 1] + sum[i - 1][j - 1];
            result = min(result, cnt);
        }
    }
    return result;
}

int main()
{
    cin >> n >> m >> k;
    for (int i = 1; i <= n; i++)
        for (int j = 1; j <= m; j++)
            cin >> board[i][j];
    
    cout << min(solve('B'), solve('W')) << endl;
    
    return 0;
}