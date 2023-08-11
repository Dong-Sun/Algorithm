#include<iostream>
#include<vector>
using namespace std;

int table[10] = { 0, };
int key[10] = { 0, };
int n, m;

void dfs(int depth) {
	if (depth >= m) {
		for (int i = 0; i < m; i++) {
			cout << table[i] << ' ';
		}
		cout << '\n';
		return;
	}

	for (int i = 1; i <= n; i++) {
		if (key[i] == 0) {
			table[depth] = i;
			key[i] = 1;
			dfs(depth + 1);
			key[i] = 0;
		}
	}
}

int main() {
	cin >> n >> m;

	dfs(0);

	return 0;
}