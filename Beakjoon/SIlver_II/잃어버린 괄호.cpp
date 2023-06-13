#include<iostream>
#include<string>
using namespace std;

int main() {
	int result = 0;
	bool isMinus = false;
	string temp;
	string input;
	cin >> input;
	for (int i = 0; i < input.length(); i++) {
		if (input[i] == '+' || input[i] == '-') {
			if (isMinus)
				result -= stoi(temp);
			else
				result += stoi(temp);
			temp = "";
		}
		else {
			temp += input[i];
		}
		if (input[i] == '-')
			isMinus = true;
	}
	if (isMinus)
		result -= stoi(temp);
	else
		result += stoi(temp);

	cout << result << endl;
	return 0;
}