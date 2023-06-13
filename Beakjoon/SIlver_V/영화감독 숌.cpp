#include <iostream>
#include <string>
using namespace std;
int main()
{
    string end = "666";
    string buf;
    int n, cnt = 0;
    int num = 0;
    cin >> n;
    while (n != cnt)
    {
        num++;
        buf = to_string(num);
        if (buf.find(end) != string::npos)
            cnt++;
    }

    cout << buf << endl;
    return 0;
}