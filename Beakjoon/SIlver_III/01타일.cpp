#include<iostream>
using namespace std;

int f[1000001];

int main() {
	f[0] = 1;
	f[1] = 1;
	int num;
	cin >> num;

	for (int i = 2; i <= num; i++) {
		f[i] = f[i - 1] + f[i - 2];
		f[i] = f[i] % 15746;
	}
	cout << f[num] << endl;
	return 0;
}