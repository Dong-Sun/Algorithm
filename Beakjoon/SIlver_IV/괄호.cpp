#include <iostream>
#include <vector>
#include <string>
using namespace std;
vector<char> stack;
bool isEmpty() {
	return (stack.size() == 0);
}
int main() {
	int n;
	string str;
	cin >> n;
	for (int i = 0; i < n; i++) {
		cin >> str;
		for (int j = 0; j <= str.length(); j++) {
			if (j == str.length()) {
				if (isEmpty())
					cout << "YES" << endl;
				else
					cout << "NO" << endl;
			}
			else if (str[j] == '(') {
				stack.push_back('(');
			}
			else if (str[j] == ')') {
				if (isEmpty()) {
					cout << "NO" << endl;
					break;
				}
				else {
					stack.pop_back();
				}
			}
		}
		while (!isEmpty()) stack.pop_back();
	}
	return 0;
}