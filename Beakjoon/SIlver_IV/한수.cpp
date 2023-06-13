#include<iostream>
using namespace std;
void counting(int n, int* c);
bool difference(int n);
int main() {
    int n, cnt = 0;
    cin >> n;
    for (int i = 1; i <= n; i++) {
        counting(i, &cnt);
    }
    cout << cnt;
    return 0;
}
void counting(int n, int* c) {
    if (n < 100)  *c += 1;
    else if (difference(n)) {
        *c += 1;
    }
}
bool difference(int n) {
    int n1, n2;
    n1 = (n / 100) - ((n % 100) / 10);
    n2 = ((n / 10) % 10) - (n % 10);
    return n1 == n2;
}