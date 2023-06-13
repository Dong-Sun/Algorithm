#include<iostream>
using namespace std;

char table[3072][6144];
void Draw(int row, int col)
{
    table[row][col] = '*';

    table[row + 1][col - 1] = '*';
    table[row + 1][col + 1] = '*';

    table[row + 2][col - 2] = '*';
    table[row + 2][col - 1] = '*';
    table[row + 2][col] = '*';
    table[row + 2][col + 1] = '*';
    table[row + 2][col + 2] = '*';
}
void Triangle(int size, int index, int line)
{
    if (size == 3)
    {
        Draw(line, index);
        return;
    }
    Triangle(size / 2, index, line);
    Triangle(size / 2, index - size / 2, line + size / 2);
    Triangle(size / 2, index + size / 2, line + size / 2);
}
void Print(int n)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n * 2; j++)
        {
            if (table[i][j] == '\0')
                cout << ' ';
            else
                cout << table[i][j];
        }
        cout << endl;
    }
}
int main()
{
    int n;
    cin >> n;
    Triangle(n, n - 1, 0);
    Print(n);
    return 0;
}