#include<iostream>
#include<vector>
#include<algorithm>
using namespace std;

int main() {
	int n, c;
	cin >> n >> c;

	int left = 0;
	int right = 0;
	vector<int> arr(n);
	for (int i = 0; i < arr.size(); i++) {
		cin >> arr[i];
		if (right < arr[i])
			right = arr[i];
	}

	sort(arr.begin(), arr.begin() + arr.size());

	int mid, count, check;
	int ans = 0;
	while (left <= right) {
		mid = (left + right) / 2;
		count = 1;
		check = 0;

		for (int i = 0; i < arr.size() - 1; i++) {
			check += arr[i + 1] - arr[i];
			if (check >= mid)
			{
				count++;
				check = 0;
			}
		}

		if (count >= c)
		{
			ans = mid;
			left = mid + 1;
		}
		else
			right = mid - 1;
	}

	cout << ans << '\n';
	return 0;
}