#include <stdio.h>
int main() {
	int n, arr[1000001] = { 0, };
	int cnt = 0;
	scanf("%d", &n);
	arr[1] = 1;
	while (n != 0) {
		for (int i = 2; i <= n; i++) {
			for (int j = 2; j * i <= 2 * n; j++) {
				arr[j * i] = 1;
			}
		}
		for (int i = n + 1; i <= 2 * n; i++) {
			if (arr[i] == 0) cnt++;
		}
		printf("%d\n", cnt);
		cnt = 0;
		scanf("%d", &n);
	}
	return 0;
}