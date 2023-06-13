#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

int main() {
	int n;
	cin >> n;
	n++;
	vector<int> arr(n);
	arr[0] = 0;
	for (int i = 1; i < n; i++) {
		cin >> arr[i];
	}
	vector<int> dp(n);
	dp[0] = 0;
	int length = 0;
	int max = 0;
	for (int i = 0; i < n; i++) {
		length = 0;
		for (int j = i - 1; j >= 0; j--) {
			if (arr[i] > arr[j]) {
				if (dp[j] + 1 > length)
					length = dp[j] + 1;
			}
		}
		dp[i] = length;
		if (max < length) max = length;
	}
	cout << max;
	return 0;
}