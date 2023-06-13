#include <iostream>
#include <vector>
using namespace std;
vector<int> stack;
bool isEmpty() {
	return (stack.size() == 0);
}
int main() {
	int n, temp;
	string str;
	cin >> n;

	for (int i = 0; i < n; i++) {
		cin >> str;
		if (str == "push") {
			cin >> temp;
			stack.push_back(temp);
		}
		else if (str == "top") {
			if (isEmpty()) cout << "-1" << endl;
			else cout << stack.back() << endl;
		}
		else if (str == "pop") {
			if (isEmpty()) cout << "-1" << endl;
			else {
				cout << stack.back() << endl;
				stack.pop_back();
			}
		}
		else if (str == "size") {
			cout << stack.size() << endl;
		}
		else if (str == "empty") {
			cout << isEmpty() << endl;
		}
	}
	return 0;
}