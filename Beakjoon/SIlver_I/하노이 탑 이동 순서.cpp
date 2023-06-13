#include <iostream>
using namespace std;
void hanoi(int n, int start, int end, int mid)
{
    if (n == 1)
        printf("%d %d\n", start, end);
    else
    {
        hanoi(n - 1, start, mid, end);
        printf("%d %d\n", start, end);
        hanoi(n - 1, mid, end, start);
    }
}
int main()
{
    int n;
    cin >> n;
    cout << (1 << n) - 1 << endl;
    hanoi(n, 1, 3, 2);
    return 0;
}