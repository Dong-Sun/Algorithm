// 입력
int n = int.Parse(Console.ReadLine());
int[] parent = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int d = int.Parse(Console.ReadLine());
List<List<int>> tree = new();
bool[] visited = new bool[n];
int count = 0;
visited[d] = true;
for (int i = 0; i < n; i++)
    tree.Add(new List<int>());
int root = 0;
for (int i = 0; i < n; i++)
{
    if (parent[i] == -1)
        root = i;
    else
        tree[parent[i]].Add(i);
}
// 구현
if (!visited[root])
    Dfs(root);
void Dfs(int node)
{
    bool leaf = true;
    visited[node] = true;
    foreach (var v in tree[node])
    {
        if (visited[v])
            continue;
        leaf = false;
        Dfs(v);
    }
    if (leaf) count++;
}

// 출력
Console.WriteLine(count);