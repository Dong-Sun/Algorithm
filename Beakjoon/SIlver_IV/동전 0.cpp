#include<iostream>
using namespace std;
int main() {
    int n, k, c = 0;
    cin >> n >> k;
    int price[10];
    for (int i = 0; i < n; i++) {
        cin >> price[i];
    }
    while (k > 0) {
        c += (k / price[n - 1]);
        k = k % price[n - 1];
        n = n - 1;
    }
    cout << c << endl;
    return 0;
}