#include<iostream>
using namespace std;

int main() {
	cin.tie(NULL);
	cout.tie(NULL);
	ios_base::sync_with_stdio(false);
	int t, pivot;

	cin >> t;
	int arr[t];
	int a, b;
	for (int i = 0; i < t; i++) {
		cin >> arr[i];
		if (i == 0) pivot = arr[i];
	}

	for (int i = 1; i < t; i++) {
		a = pivot;
		b = arr[i];
		while (b > 0) {
			if (a % b == 0) break;
			else {
				int temp = a % b;
				a = b;
				b = temp;
			}
		}
		printf("%d/%d\n", pivot / b, arr[i] / b);
	}
	return 0;
}