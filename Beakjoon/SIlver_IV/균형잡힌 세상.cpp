#include<iostream>
#include<string>
#include<stack>
using namespace std;

int main() {
	string str;
	stack<char> ballance;
	while (true) {
		getline(cin, str);
		if (str.size() == 1 && str[0] == '.') break;
		for (int i = 0; i < str.size(); i++) {
			if (str[i] == '(' || str[i] == '[') ballance.push(str[i]);
			else if (str[i] == ')' || str[i] == ']') {
				if (!ballance.empty()) {
					if (str[i] == ')' && ballance.top() == '(') ballance.pop();
					else if (str[i] == ']' && ballance.top() == '[') ballance.pop();
					else ballance.push(str[i]);
				}
				else ballance.push(str[i]);
			}
		}
		if (ballance.empty()) cout << "yes" << endl;
		else cout << "no" << endl;
		while (!ballance.empty())ballance.pop();
		str.clear();
	}
	return 0;
}