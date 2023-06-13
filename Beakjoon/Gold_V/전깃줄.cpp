#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

int main() {
	int n;
	cin >> n;
	vector<pair<int, int>> arr(n);
	vector<int> dp(n);
	for (int i = 0; i < n; i++) {
		cin >> arr[i].first >> arr[i].second;
	}
	sort(arr.begin(), arr.end());
	int length = 1;
	for (int i = 0; i < n; i++) {
		for (int j = i - 1; j >= 0; j--) {
			if (arr[i].second > arr[j].second) {
				if (length < dp[j] + 1) length = dp[j] + 1;
			}
		}
		dp[i] = length;
		length = 1;
	}
	int max = 0;
	for (int i = 0; i < n; i++)
		if (max < dp[i]) max = dp[i];

	cout << n - max;
	return 0;
}