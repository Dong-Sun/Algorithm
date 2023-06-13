#include <iostream>
#include <vector>
#include <sstream>
#include <deque>
using namespace std;

vector<string> split(string input, char delimiter) {
	vector<string> result;
	stringstream ss(input);
	string temp;
	while (getline(ss, temp, delimiter))
		result.push_back(temp);
	return result;
}

int main() {
	deque<int> v;
	string s;
	vector<string> arr;
	int N;
	int n;
	cin >> N;
	cin.ignore();
	for (int i = 0; i < N; i++) {
		getline(cin, s);
		arr = split(s, ' ');
		if (arr.front() == "push_front") {
			stringstream ssInt(arr.back());
			ssInt >> n;
			v.push_front(n);
		}
		else if (arr.front() == "push_back") {
			stringstream ssInt(arr.back());
			ssInt >> n;
			v.push_back(n);
		}
		else if (arr.front() == "front") {
			if (v.size() > 0)
				cout << v.front() << endl;
			else
				cout << "-1" << endl;
		}
		else if (arr.front() == "back") {
			if (v.size() > 0)
				cout << v.back() << endl;
			else
				cout << "-1" << endl;
		}
		else if (arr.front() == "size") {
			cout << v.size() << endl;
		}
		else if (arr.front() == "empty") {
			cout << v.empty() << endl;
		}
		else if (arr.front() == "pop_front") {
			if (v.size() > 0) {
				cout << v.front() << endl;
				v.pop_front();
			}
			else
				cout << "-1" << endl;
		}
		else if (arr.front() == "pop_back") {
			if (v.size() > 0) {
				cout << v.back() << endl;
				v.pop_back();
			}
			else
				cout << "-1" << endl;
		}
		n = 0;
	}
	return 0;
}