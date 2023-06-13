#include <iostream>
using namespace std;

int main() {
	long long int s;
	cin >> s;
	int cnt = 0;
	int n = 0;
	while (s > n) {
		n++;
		s = s - n;
		cnt++;
	}
	cout << cnt << endl;

	return 0;
}