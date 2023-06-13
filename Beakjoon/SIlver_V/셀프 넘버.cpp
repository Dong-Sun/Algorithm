#include<iostream>
using namespace std;
const int SIZE = 10001;
int Creater(int n);


int main() {

    int storage[SIZE] = { 0, };
    int r;
    for (int i = 1; i < SIZE; i++) {
        r = Creater(i);
        if (r < SIZE)
            storage[r] = 1;
    }
    for (int i = 1; i < SIZE; i++) {
        if (storage[i] == 0) cout << i << endl;
    }
    return 0;
}

int Creater(int n) {
    int num = 0;
    int n1, n2, n3, n4;
    if (n >= 1 && n <= 9) {
        num = n + n;
    }
    else if (n <= 99) {
        n1 = n / 10;
        n2 = n % 10;
        num = n + n1 + n2;
    }
    else if (n <= 999) {
        n1 = n / 100;
        n2 = (n % 100) / 10;
        n3 = n % 10;
        num = n + n1 + n2 + n3;
    }
    else if (n <= 9999) {
        n1 = n / 1000;
        n2 = (n % 1000) / 100;
        n3 = (n % 100) / 10;
        n4 = n % 10;
        num = n + n1 + n2 + n3 + n4;
    }
    return num;
}