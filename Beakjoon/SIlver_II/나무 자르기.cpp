#include<iostream>
#include<vector>
using namespace std;

int main() {
	int n;
	int m;
	cin >> n >> m;

	vector<int> arr(n);

	int min = -1;
	int max = 0;
	for (int i = 0; i < n; i++) {
		cin >> arr[i];
		if (max < arr[i])
			max = arr[i];
	}
	max++;
	int mid;

	long long int length;

	while (min + 1 < max)
	{
		mid = (min + max) / 2;
		length = 0;

		for (int i = 0; i < n; i++) {
			if (mid < arr[i])
				length += arr[i] - mid;
		}

		if (length >= m)
			min = mid;
		else
			max = mid;
	}

	cout << min;

	return 0;
}