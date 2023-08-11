#include <iostream>
using namespace std;

int main() {
	int table[1001] = {0,};
	int n, result = 0;
	cin >> n;

	int left, right;
	for (int i = 0; i < n; i++) {
		cin >> left >> right;
		table[left] = right;
	}

	int max = 0;
	int start = 0;
	for (int i = 0; i < 1001; i++) {
		if (table[i] > max) {
			result += max * (i - start);
			start = i;
			max = table[i];
		}
	}

	left = start;
	max = 0;
	start = 1000;
	for (int i = 1000; i >= 0; i--) {
		if (table[i] > max) {
			result += max * (start - i);
			start = i;
			max = table[i];
		}
	}
	right = start;

	result += max * (right - left + 1);

	cout << result << endl;

	return 0;
}