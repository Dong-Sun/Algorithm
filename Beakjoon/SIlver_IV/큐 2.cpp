#include<iostream>
#include<string>
#include<queue>
using namespace std;

int main() {
	ios::sync_with_stdio(false);
	cin.tie(NULL);
	cout.tie(NULL);
	int num, size = 0;
	int n;
	queue<int> arr;
	string str;
	cin >> num;
	for (int i = 0; i < num; i++) {
		cin >> str;
		if (str.compare("push") == 0) {
			cin >> n;
			arr.push(n);
		}
		else if (str.compare("pop") == 0) {
			if (arr.size() > 0) {
				cout << arr.front() << "\n";
				arr.pop();
			}
			else cout << "-1" << "\n";
		}
		else if (str.compare("size") == 0) {
			cout << arr.size() << "\n";
		}
		else if (str.compare("empty") == 0) {
			cout << arr.empty() << "\n";
		}
		else if (str.compare("front") == 0) {
			if (arr.size() > 0)
				cout << arr.front() << "\n";
			else cout << "-1" << "\n";
		}
		else if (str.compare("back") == 0) {
			if (arr.size() > 0)
				cout << arr.back() << "\n";
			else cout << "-1" << "\n";
		}
	}
	return 0;
}