#include <iostream>
using namespace std;

long long int mul(int a, int pow, int c) {
	if (pow == 0) return 1;
	if (pow == 1) return a % c;
	long long int x = mul(a, pow / 2, c) % c;
	if (pow % 2 == 0)
		return x * x % c;
	else
		return x * x % c * a % c;
}

int main() {
	long long int a, b, c;
	cin >> a >> b >> c;
	a = mul(a, b, c) % c;
	cout << a << endl;
	return 0;
}