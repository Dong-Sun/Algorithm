#include<iostream>
#include<math.h>
using namespace std;

int main() {
	ios_base::sync_with_stdio(false); cin.tie(NULL); cout.tie(NULL);
	int t;
	int x1, x2, y1, y2;
	int n;
	int cX, cY, r;
	int cnt = 0;
	cin >> t;
	for (int i = 0; i < t; i++) {
		cin >> x1 >> y1 >> x2 >> y2;
		cin >> n;
		for (int j = 0; j < n; j++) {
			cin >> cX >> cY >> r;

			if ((pow(x1 - cX, 2) + pow(y1 - cY, 2) < pow(r, 2)) && (pow(x2 - cX, 2) + pow(y2 - cY, 2) < pow(r, 2))) continue; // 둘다 포함 x
			else if ((pow(x1 - cX, 2) + pow(y1 - cY, 2) > pow(r, 2)) && (pow(x2 - cX, 2) + pow(y2 - cY, 2) > pow(r, 2))) continue; // 둘다 포함 o 
			else cnt++;
		}
		cout << cnt << '\n';
		cnt = 0;
	}
	return 0;
}