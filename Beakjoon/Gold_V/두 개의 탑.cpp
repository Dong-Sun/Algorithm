#include <iostream>
using namespace std;

int main() 
{
    int n;
    cin >> n;
    int distance[n] = {0};
    int maxdistance = 0;
    for (int i = 0; i < n; i++) 
    {
        cin >> distance[i];
        maxdistance += distance[i];
    }
    
    int result = 0;
    int leftIndex = 0;
    int rightIndex = 1;
    
    int leftValue = distance[leftIndex];
    int rightValue = maxdistance - leftValue;
    
    while(leftIndex < n)
    {
        if (leftValue == rightValue)
        {
            result = leftValue;
            break;
        }
        else if (leftValue > rightValue)
        {
            leftValue -= distance[leftIndex];
            rightValue += distance[leftIndex];
            leftIndex++;
        }
        else
        {
            leftValue += distance[rightIndex];
            rightValue -= distance[rightIndex];
            rightIndex++;
            rightIndex = rightIndex % n;
        }
        result = max(result, min(leftValue, rightValue));
    }
    
    cout << result << endl;
    
    return 0;
}