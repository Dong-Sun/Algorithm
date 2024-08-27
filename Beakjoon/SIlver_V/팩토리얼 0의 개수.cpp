#include <iostream>

using namespace std;

int main()
{
	int num = 0;
    cin >> num;
    
    int result = 0;

    for(int i = 5; i <= num; i *= 5)
        result += (num / i);

    cout << result << endl;
	return 0;
}