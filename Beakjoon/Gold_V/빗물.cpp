#include<iostream>
using namespace std;

int main() {
	int arr[501];
	int h, w, result = 0;
	cin >> h >> w;
	for (int i = 0; i < w; i++) {
		cin >> arr[i];
	}

	bool hall = false;
	int start = 0;
	for (int i = 1; i <= h; i++) {
		for (int j = 0; j < w; j++) {
			if (arr[j] >= i) { // ���� ����
				if (hall == false) { // ���� �߰�
					hall = true;
					start = j;
				}
				else {	// ���� ����
					result += j - start - 1;
					start = j;
				}
			}
		}
		hall = false;
	}

	cout << result << endl;

	return 0;
}