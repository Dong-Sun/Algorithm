#include<iostream>
#include<vector>
using namespace std;

int main() {
	int n, temp;
	long long int sum = 0;

	vector<long long int> nextLoad;
	vector<long long int> nowPrice;
	int miniIndex = 0;

	cin >> n;
	for (int i = 0; i < n - 1; i++) {
		cin >> temp;
		nextLoad.push_back(temp);
	}

	for (int i = 0; i < n; i++) {
		cin >> temp;
		nowPrice.push_back(temp);
	}

	sum += nowPrice[miniIndex] * nextLoad[miniIndex];
	for (int i = 1; i < n - 1; i++) {
		if (nowPrice[miniIndex] < nowPrice[i]) {
			sum += nowPrice[miniIndex] * nextLoad[i];
		}
		else {
			miniIndex = i;
			sum += nowPrice[miniIndex] * nextLoad[i];
		}
	}
	cout << sum << endl;
	return 0;
}