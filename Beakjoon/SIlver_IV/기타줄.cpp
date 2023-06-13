#include <iostream>
#include <vector>
#include <cmath>
using namespace std;

int main() {
	int n, m;
	int ans;
	cin >> n >> m;
	vector<pair<int, int>> vec(m);
	for (int i = 0; i < m; i++)
		cin >> vec[i].first >> vec[i].second;

	int pakage = 1001, single = 1001;
	for (int i = 0; i < m; i++) {
		if (pakage > vec[i].first) pakage = vec[i].first;
		if (single > vec[i].second) single = vec[i].second;
	}

	if (single <= pakage / 6) ans = single * n;
	else {
		ans = pakage * (n / 6);
		n = n % 6;
		if (pakage > single * n) ans = ans + single * n;
		else ans = ans + pakage;
	}
	cout << ans << endl;
	return 0;
}