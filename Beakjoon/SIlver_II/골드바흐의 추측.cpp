#include <stdio.h>
int main() {
	int c, n, arr[10001] = { 0, };
	int pair[2];
	int sub = 10000;
	scanf("%d", &c);
	arr[1] = 1;

	for (int i = 2; i <= 10001; i++) {
		for (int j = 2; j * i <= 10001; j++) {
			arr[j * i] = 1;
		}
	}
	for (int i = 0; i < c; i++) {
		scanf("%d", &n);
		for (int j = 2; j <= n / 2; j++) {
			if (arr[j] == 0 && arr[n - j] == 0) {
				if (n - j - j < sub) {
					pair[0] = j;
					pair[1] = n - j;
					sub = n - j - j;
				}
			}
		}
		printf("%d %d\n", pair[0], pair[1]);
		sub = 10000;
	}

	return 0;
}