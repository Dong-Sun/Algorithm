#include<string>
#include<vector>
#include<algorithm>
#include<map>

using namespace std;
map<string, int> counting;

void DFS(string order, string cmp, char start, int depth, int length) {
    if (length == depth) {
        counting[cmp]++;
        return;
    }

    for (char c = start; c <= 'Z'; c++)
        if (order.find(c) != string::npos)
            DFS(order, cmp + c, c + 1, depth + 1, length);
}

vector<string> solution(vector<string> orders, vector<int> course) {
    vector<string> answer; int max;
    for (int cour : course)
        for (string order : orders)
            DFS(order, "", 'A', 0, cour);

    for (int cour : course) {
        max = 0;
        for (auto var : counting)
            if (var.first.length() == cour && var.second >= 2)
                if (var.second > max)
                    max = var.second;

        for (auto var : counting)
            if (var.first.length() == cour && var.second == max)
                answer.push_back(var.first);
    }
    sort(answer.begin(), answer.end());
    return answer;
}