#include <iostream>
#include <math.h>
using namespace std;

int main()
{
    int T, x1, y1, r1, x2, y2, r2;
    double distance;
    cin >> T;
    for (int i = 0; i < T; i++)
    {
        cin >> x1 >> y1 >> r1 >> x2 >> y2 >> r2;
        distance = pow(x1 - x2, 2) + pow(y1 - y2, 2);
        distance = sqrt(distance);
        if (distance == 0 && r1 == r2)
            cout << "-1" << endl;
        else if (distance == r1 + r2 || distance == abs(r1 - r2))
            cout << "1" << endl;
        else if (abs(r1 - r2) < distance && distance < (r1 + r2))
            cout << "2" << endl;
        else
            cout << "0" << endl;
    }
    return 0;
}