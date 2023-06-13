#include <algorithm>
#include <iostream>
#include <string>
#include <vector>
#include <map>
using namespace std;

int main() {
	cin.tie(NULL); cout.tie(NULL); ios::sync_with_stdio(false);
	int id = 1;
	int n, m;
	cin >> n >> m;
	map<int, string> map1;
	map<string, int> map2;
	string temp;
	while (n > 0) {
		cin >> temp;
		map1.insert(make_pair(id, temp));
		map2.insert(make_pair(temp, id++));
		n--;
	}
	while (m > 0) {
		cin >> temp;
		if (temp[0] < 'A') cout << map1[stoi(temp)] << '\n';
		else cout << map2[temp] << '\n';
		m--;
	}
	return 0;
}