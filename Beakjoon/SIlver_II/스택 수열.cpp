#include<iostream>
#include<vector>
#include<stack>
#include<queue>
using namespace std;

int main() {
	cin.tie(NULL);
	cout.tie(NULL);
	ios::sync_with_stdio(false);

	int n, temp;
	stack<int> s;
	queue<int> q;

	cin >> n;
	for (int i = 0; i < n; i++) {
		cin >> temp;
		q.push(temp);
	}

	vector<char> result;
	int num = 0;
	while (q.size() > 0 && num <= n) {
		if (s.size() > 0) {
			if (q.front() == s.top()) {
				result.push_back('-');
				s.pop(); q.pop();
			}
			else {
				result.push_back('+');
				s.push(++num);
			}
		}
		else {
			result.push_back('+');
			s.push(++num);
		}
	}

	if (q.size() > 0) cout << "NO" << endl;
	else {
		for (int i = 0; i < result.size(); i++) {
			cout << result[i] << '\n';
		}
	}

	return 0;
}