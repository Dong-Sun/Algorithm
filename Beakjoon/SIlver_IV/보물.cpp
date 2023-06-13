#include<iostream>
#include <algorithm>
using namespace std;

bool compare(int a, int b) {
	return a > b;
}

int main() {
	int n, cnt, S = 0;
	int A[55];
	int B[55];
	cin >> n;
	for (int i = 0; i < n; i++)
		cin >> A[i];
	for (int i = 0; i < n; i++)
		cin >> B[i];
	sort(A, A + n, compare);
	sort(B, B + n);
	for (int i = 0; i < n; i++) {
		S = S + B[i] * A[i];
	}
	cout << S << endl;
	return 0;
}