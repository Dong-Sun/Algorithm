#include<iostream>
#include<string>
#include<algorithm>
#include<vector>
using namespace std;

bool comp(string a, string b)
{
	if (a.length() != b.length()) {
		return a.length() < b.length();
	}
	else
		return a < b;
}

int main()
{
	int n;
	cin >> n;
	string str[20001];
	for (int i = 0; i < n; i++)
	{
		cin >> str[i];
	}
	sort(str, str + n, comp);
	for (int i = 0; i < n; i++)
	{
		if (str[i] == str[i - 1]) continue;
		cout << str[i] << endl;
	}
	return 0;
}