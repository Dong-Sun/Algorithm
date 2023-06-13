#include <iostream>
#include <vector>
#include <stack>
using namespace std;

int main() {
	int n;
	cin >> n;

	vector<int> v(n);

	for (int i = 0; i < n; i++) {
		cin >> v[i];
	}

	stack<int> s;
	int count = 0;
	int sum = 0;
	int max = 0;
	s.push(v[0]);
	for (int i = 1; i < n; i++) {
		if (v[i] >= s.top())
			s.push(v[i]);
		else {
			while (v[i] < s.top())
			{
				count++;
				sum = s.top() * count;
				if (sum > max)
					max = sum;
				s.pop();

				if (s.empty())
					break;
			}
			while (count > 0)
			{
				s.push(v[i]);
				count--;
			}
			s.push(v[i]);
		}
	}

	while (!s.empty())
	{
		count++;
		sum = s.top() * count;
		if (sum > max)
			max = sum;
		s.pop();
	}

	cout << max << endl;
	return 0;
}