#include<iostream>
using namespace std;
int main() {
    int n;
    int p[1005];
    int result = 0;
    int temp;
    cin >> n;
    for (int i = 0; i < n; i++) {
        cin >> p[i];
    }
    for (int i = 0; i < n - 1; i++) {
        for (int j = i + 1; j < n; j++) {
            if (p[i] > p[j]) {
                temp = p[i];
                p[i] = p[j];
                p[j] = temp;
            }
        }
    }
    for (int i = 1; i < n; i++) {
        p[i] = p[i] + p[i - 1];
    }

    for (int i = 0; i < n; i++) {
        result = result + p[i];
    }
    cout << result << endl;
    return 0;
}