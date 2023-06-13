#define _CRT_SECURE_NO_WARNINGS
#include<iostream>
#include<cmath>
using namespace std;

int main() {
	ios::sync_with_stdio(false); cin.tie(NULL); cout.tie(NULL);
	int t;
	int x, y;
	long long length;
	long long left, right, mid;
	cin >> t;
	for (int i = 0; i < t; i++) {
		cin >> x >> y;
		length = y - x;

		left = 0;
		right = length + 1;
		while (left + 1 < right) {
			mid = left + (right - left) / 2;
			if (mid * (mid + 1) >= length)
				right = mid;
			else
				left = mid;

		}

		if (sqrt(length) <= right)
			cout << (right * 2) - 1 << '\n';
		else
			cout << right * 2 << '\n';
	}

	return 0;
}