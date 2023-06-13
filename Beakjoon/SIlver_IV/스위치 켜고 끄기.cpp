#include <iostream>
#include <vector>
using namespace std;

int main() {
	int n;
	cin >> n;

	vector<int> vec(n + 1);
	for (int i = 1; i <= n; i++)
		cin >> vec[i];

	int t;
	cin >> t;

	int gender;
	int s;

	for (int i = 0; i < t; i++) {
		cin >> gender >> s;
		if (gender == 1) {
			for (int j = s; j <= n; j = j + s) {
				vec[j] = ~vec[j];
			}
		}
		else if (gender == 2) {
			int range = 1;
			vec[s] = ~vec[s];
			while (s - range >= 1 && s + range <= n) {
				if (vec[s - range] != vec[s + range]) break;
				vec[s - range] = ~vec[s - range];
				vec[s + range] = ~vec[s + range];
				range++;
			}
		}
	}

	for (int k = 1; k <= n; k++) {
		cout << vec[k] << ' ';
		if (k % 20 == 0)
			cout << '\n';
	}

	return 0;
}