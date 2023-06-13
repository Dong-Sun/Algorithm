#include<iostream>
using namespace std;

int main() {
	cin.tie(NULL);
	cout.tie(NULL);
	ios_base::sync_with_stdio(false);
	int n, m, f, b, num;
	cin >> n >> m;
	int arr[n];
	for (int i = 0; i < n; i++) {
		cin >> num;
		if (i == 0) arr[i] = num;
		else arr[i] = num + arr[i - 1];
	}
	for (int i = 0; i < m; i++) {
		cin >> f >> b;
		if (f <= 1) printf("%d\n", arr[b - 1]);
		else printf("%d\n", arr[b - 1] - arr[f - 2]);
	}
	return 0;
}