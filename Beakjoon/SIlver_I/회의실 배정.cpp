#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

int main() {
	int N;
	int n1, n2;
	int cnt = 0;
	int time = 0;

	cin >> N;
	vector<pair<int, int>> arr(N);

	for (int i = 0; i < N; i++)
	{
		cin >> arr[i].second >> arr[i].first;
	}

	sort(arr.begin(), arr.end());

	for (int i = 0; i < arr.size(); i++)
	{
		if (time <= arr[i].second)
		{
			time = arr[i].first;
			cnt++;
		}
	}
	cout << cnt << endl;
	return 0;
}