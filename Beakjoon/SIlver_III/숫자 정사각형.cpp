#include <iostream>
#include <vector>
#include <string>
using namespace std;

int main() {
	int arr[51][51];
	int n, m;
	string str;
	cin >> n >> m;

	for (int i = 0; i < n; i++) {
		cin >> str;
		for (int j = 0; j < m; j++) {
			arr[i][j] = (int)str[j] - 48;
		}
	}

	int min = n < m ? n : m;

	int maxSize = 1;
	int currentSize = 2;
	while (currentSize <= min) {
		for (int i = 0; i + currentSize - 1 < n; i++) {
			for (int j = 0; j + currentSize - 1 < m; j++) {
				if (arr[i][j] == arr[i][j + currentSize - 1] &&
					arr[i][j] == arr[i + currentSize - 1][j] &&
					arr[i][j] == arr[i + currentSize - 1][j + currentSize - 1])
					maxSize = currentSize;
			}
		}
		currentSize++;
	}
	cout << maxSize * maxSize << endl;
	return 0;
}