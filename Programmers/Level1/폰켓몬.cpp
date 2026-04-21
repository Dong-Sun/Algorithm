#include <vector>
#include <map>
using namespace std;

int solution(vector<int> nums)
{
    int answer = 0;
    map<int, int> m;
    for (int i = 0; i < nums.size(); i++)
    {
        if (m.find(nums[i]) != m.end())
            m[nums[i]]++;
        else
            m.insert({nums[i], 1});
    }
    for (auto a = m.begin(); a != m.end(); a++)
        if (answer + 1 <= nums.size() / 2)
            answer++;
    return answer;
}