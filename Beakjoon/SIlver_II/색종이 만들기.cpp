#include <iostream>
using namespace std;

int arr[128][128];
int whiteCnt = 0;
int blueCnt = 0;

void check(int startX, int endX, int startY, int endY) {
	int color = arr[startY][startX];
	for (int i = startY; i < endY; i++) {
		for (int j = startX; j < endX; j++) {
			if (color != arr[i][j]) {
				check(startX, startX + (endX - startX) / 2, startY, startY + (endY - startY) / 2);
				check(startX + (endX - startX) / 2, endX, startY, startY + (endY - startY) / 2);
				check(startX, startX + (endX - startX) / 2, startY + (endY - startY) / 2, endY);
				check(startX + (endX - startX) / 2, endX, startY + (endY - startY) / 2, endY);
				return;
			}
		}
	}

	if (color == 0) whiteCnt++;
	else if (color == 1) blueCnt++;
}

int main() {
	int n;
	cin >> n;
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			cin >> arr[i][j];
		}
	}

	check(0, n, 0, n);
	cout << whiteCnt << endl;
	cout << blueCnt << endl;
	return 0;
}