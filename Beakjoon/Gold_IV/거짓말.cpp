#include<iostream>
#include<vector>
using namespace std;

int main() {
	int n, m;
	cin >> n >> m;
	
	vector<bool> visited(n + 1);
	vector<vector<int>> list(m);
	vector<int> open(n);

	int count;
	int num;
	cin >> count;
	for (int i = 0; i < count; i++) {
		cin >> num;
		visited[num] = true;
		open.push_back(num);
	}

	for (int i = 0; i < m; i++) {
		cin >> count;
		for (int j = 0; j < count; j++) {
			cin >> num;
			list[i].push_back(num);
		}
	}

	while (!open.empty()) {
		num = open.back();
		open.pop_back();

		for (int i = 0; i < list.size(); i++) {
			for (int var : list[i]) {
				if (var == num) {
					for (int var : list[i]) {
						if (visited[var] == false) {
							open.push_back(var);
							visited[var] = true;
						}
					}
					list.erase(list.begin() + i);
					i--;
					break;
				}
			}
		}
	}

	cout << list.size() << endl;

	return 0;
}