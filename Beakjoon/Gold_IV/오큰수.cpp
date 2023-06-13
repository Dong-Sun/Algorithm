#include <iostream>
#include <stack>
#include <queue>
#include <vector>
using namespace std;

int main() {
	cin.tie(NULL);
	cout.tie(NULL);
	ios::sync_with_stdio(false);

	int n;
	cin >> n;

	int temp;
	vector<int> v;
	for (int i = 0; i < n; i++) {
		cin >> temp;
		v.push_back(temp);
	}

	stack<int> s;
	for (int i = 0; i < n; i++) {
		if (s.empty()) {
			s.push(i);
		}
		else {
			while (v[i] > v[s.top()]) {
				v[s.top()] = v[i];
				s.pop();
				if (s.empty()) break;
			}
			s.push(i);
		}
	}
	while (!s.empty()) {
		v[s.top()] = -1;
		s.pop();
	}
	for (int i = 0; i < v.size(); i++) {
		cout << v[i] << ' ';
	}
	return 0;
}