#include <iostream>
#include <vector>
using namespace std;

int main() {
	int n;
	cin >> n;
	n++;
	vector<int> arr(n);
	arr[0] = 0;
	for (int i = 1; i < n; i++) {
		cin >> arr[i];
	}

	vector<int> front(n);
	vector<int> back(n);
	front[0] = 0;
	back[0] = 0;
	//front
	int max = 0;
	for (int i = 1; i < n; i++) {
		for (int j = i - 1; j >= 0; j--) {
			if (arr[i] > arr[j]) {
				if (max < front[j] + 1)
					max = front[j] + 1;
			}
		}
		front[i] = max;
		max = 0;
	}
	//back
	for (int i = n - 1; i >= 0; i--) {
		for (int j = i + 1; j < n; j++) {
			if (arr[i] > arr[j]) {
				if (max < back[j] + 1)
					max = back[j] + 1;
			}
		}
		back[i] = max;
		max = 0;
	}

	for (int i = 0; i < n; i++) {
		if (max < front[i] + back[i])
			max = front[i] + back[i];
	}
	cout << max;
	return 0;
}