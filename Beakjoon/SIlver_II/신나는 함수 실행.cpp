#include <iostream>
using namespace std;
int dp[105][105][105];
int w(int a, int b, int c) {
    if (dp[a + 50][b + 50][c + 50] != NULL)
        return dp[a + 50][b + 50][c + 50];
    else if (a <= 0 || b <= 0 || c <= 0)
        dp[a + 50][b + 50][c + 50] = 1;
    else if (a > 20 || b > 20 || c > 20)
        dp[a + 50][b + 50][c + 50] = w(20, 20, 20);
    else if (a < b && b < c)
        dp[a + 50][b + 50][c + 50] =
        w(a, b, c - 1) + w(a, b - 1, c - 1) - w(a, b - 1, c);
    else
        dp[a + 50][b + 50][c + 50] = w(a - 1, b, c) + w(a - 1, b - 1, c) +
        w(a - 1, b, c - 1) - w(a - 1, b - 1, c - 1);
    return dp[a + 50][b + 50][c + 50];
}
int main() {
    int a, b, c;
    int result;
    dp[50][50][50] = 1;
    while (true) {
        cin >> a >> b >> c;
        if (a == -1 && b == -1 && c == -1)
            break;
        result = w(a, b, c);
        cout << "w(" << a << ", " << b << ", " << c << ") = " << result << '\n';
    }
    return 0;
}