#include <iostream>
#include <algorithm>
using namespace std;

int main() {
	string str;
	cin >> str;
	sort(str.rbegin(), str.rend());

	cout << str << endl;

	return 0;
}