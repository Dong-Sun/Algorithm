#include <iostream>
#include <algorithm>
#include <string>
#include <vector>
using namespace std;

int main() {
	int n;
	cin >> n;
	int arr[n];
	vector<int> tmp;
	for (int i = 0; i < n; i++) {
		cin >> arr[i];
		tmp.push_back(arr[i]);
	}

	sort(tmp.begin(), tmp.end());
	tmp.erase(unique(tmp.begin(), tmp.end()), tmp.end());
	for (int i = 0; i < n; i++) {
		cout << lower_bound(tmp.begin(), tmp.end(), arr[i]) - tmp.begin() << ' ';
	}
	return 0;
}