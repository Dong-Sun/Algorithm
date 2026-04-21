#include <string>
#include <vector>
#include <map>

using namespace std;

string solution(vector<string> participant, vector<string> completion)
{
    string answer = "";
    map<string, int> m;

    for (int i = 0; i < participant.size(); i++)
    {
        string key = participant[i];
        if (m.find(key) != m.end())
        {
            m[key]++;
        }
        else
        {
            m.insert({key, 1});
        }
    }
    for (int i = 0; i < completion.size(); i++)
    {
        string key = completion[i];
        m[key]--;
    }

    for (auto iter = m.begin(); iter != m.end(); iter++)
    {
        if (iter->second != 0)
            answer = iter->first;
    }

    return answer;
}