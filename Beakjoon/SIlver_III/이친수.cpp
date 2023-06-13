#include <iostream>
using namespace std;

long long int dp[90] = {};

long long int fibonacci(int n) {
	if (dp[n] != 0) return dp[n];
	dp[n] = fibonacci(n - 1) + fibonacci(n - 2);
	return dp[n];
}

int main() {
	dp[1] = 1;
	dp[2] = 1;

	int n;
	cin >> n;
	cout << fibonacci(n) << endl;

	return 0;
}