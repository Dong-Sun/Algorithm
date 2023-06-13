#include <iostream>
using namespace std;
struct Man {
	int manKg;
	int manHeight;
};
int main() {
	int n, kg, height;
	int rank = 1;
	cin >> n;

	Man* m = (Man*)malloc(sizeof(Man) * n);
	for (int i = 0; i < n; i++) {
		cin >> kg >> height;
		(m + i)->manKg = kg;
		(m + i)->manHeight = height;
	}
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			if (i != j) {
				if ((m + i)->manKg < (m + j)->manKg && (m + i)->manHeight < (m + j)->manHeight) rank++;
			}
		}
		cout << rank << ' ';
		rank = 1;
	}
	cout << endl;
	free(m);
	return 0;
}