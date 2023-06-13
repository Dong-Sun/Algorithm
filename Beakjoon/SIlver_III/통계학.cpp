#include <iostream>
#include <stdlib.h>
#include <algorithm>
#include <math.h>
using namespace std;

int main() {
	int arr[500005];
	int cnt[8001] = { 0 };
	int n, maxCnt = 0;
	int index;
	int second = 0;
	int sum = 0;
	cin >> n;

	for (int i = 0; i < n; i++) {
		cin >> arr[i];
		sum = sum + arr[i];
		arr[i] = arr[i] + 4000;
		cnt[arr[i]]++;
	}
	sort(arr, arr + n);
	for (int i = 0; i < 8001; i++) {
		if (cnt[i] > maxCnt) {
			maxCnt = cnt[i];
			index = i;
		}
	}
	for (int i = 0; i < 8001; i++) {
		if (cnt[i] == maxCnt) {
			second++;
			if (second == 2) {
				index = i;
				break;
			}
		}
	}
	if ((float)sum / n > -0.4 && (float)sum / n < 0)
		cout << -round((float)sum / n) << endl;
	else
		cout << round((float)sum / n) << endl;
	cout << arr[n / 2] - 4000 << endl;
	cout << index - 4000 << endl;
	cout << abs(arr[n - 1] - arr[0]) << endl;
	return 0;
}