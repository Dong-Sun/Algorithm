#include<iostream>
using namespace std;

int main() {
    ios::sync_with_stdio(false);
    cin.tie(NULL);
    cout.tie(NULL);

    int num, div, sum = 0, cnt = 1;
    cin >> num;

    for (int i = 1; ; i++) {

        if (num <= sum + i) {
            sum += i;
            break;
        }
        else {
            sum += i;
            cnt++;
        }
    }

    div = cnt % 2;

    switch (div) {
    case 0:
        cout << num + cnt - sum << '/' << 1 + (sum - num) << endl;
        break;
    case 1:
        cout << 1 + (sum - num) << '/' << num + cnt - sum << endl;
        break;
    }
    return 0;
}