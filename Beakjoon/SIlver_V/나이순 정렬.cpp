#include <iostream>
#include <algorithm>
#include <string>
#include <vector>
using namespace std;

bool Compare(pair<int, string> a, pair<int, string> b) {
	return a.first < b.first;
}

int main() {
	int n;
	int key, j;
	string skey;
	cin >> n;
	pair<int, string> tmp;
	vector<pair<int, string>> v;
	for (int i = 0; i < n; i++) {
		cin >> tmp.first >> tmp.second;
		v.push_back(tmp);
	}
	stable_sort(v.begin(), v.end(), Compare);

	for (int i = 0; i < n; i++) {
		cout << v[i].first << ' ' << v[i].second << '\n';
	}

	return 0;
}