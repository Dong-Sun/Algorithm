#include<iostream>
using namespace std;
int main() {
    unsigned long long int p[100] = { 1, 1, 1, 2, 2, 3, 4, 5, 7, 9 };
    for (int i = 10; i < 100; i++) {
        p[i] = p[i - 1] + p[i - 5];
    }
    int n, t;
    cin >> t;
    for (int i = 0; i < t; i++) {
        cin >> n;
        cout << p[n - 1] << endl;
    }
    return 0;
}