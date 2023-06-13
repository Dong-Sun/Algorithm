#include <iostream>
using namespace std;
char swap(char c)
{
    if (c == 'W')
        c = 'B';
    else if (c == 'B')
        c = 'W';
    return c;
}

void makeChess(char _color, char _temp, char _chess[][8])
{
    for (int i = 0; i < 8; i++)
    {
        _temp = _color;
        for (int j = 0; j < 8; j++)
        {
            _chess[i][j] = _temp;
            _temp = swap(_temp);
        }
        _color = swap(_color);
    }
}

void compare(char _chess[][8], char _arr[][8], int* _cnt)
{
    for (int _i = 0; _i < 8; _i++)
    {
        for (int _j = 0; _j < 8; _j++)
        {
            if (_chess[_i][_j] != _arr[_i][_j])
                (*_cnt)++;
        }
    }
}

int main()
{
    int a, b, cnt = 0;
    int minCnt = 64;
    char color1 = 'W';
    char color2 = 'B';
    char temp;
    char chess1[8][8];
    char chess2[8][8];
    char arrCut[8][8];
    makeChess(color1, temp, chess1);
    makeChess(color2, temp, chess2);
    cin >> a >> b;
    char arr[a][b];
    for (int i = 0; i < a; i++)
    {
        for (int j = 0; j < b; j++)
        {
            cin >> arr[i][j];
        }
    }
    for (int n = 0; n <= a - 8; n++)
    {
        for (int m = 0; m <= b - 8; m++)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    arrCut[i][j] = arr[i + n][j + m];
                }
            }
            compare(chess1, arrCut, &cnt);
            if (cnt < minCnt)
                minCnt = cnt;
            cnt = 0;
            compare(chess2, arrCut, &cnt);
            if (cnt < minCnt)
                minCnt = cnt;
            cnt = 0;
        }
    }
    cout << minCnt << endl;
    return 0;
}