int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];
bool[] flag = new bool[n];
int cur = 0;
int plus = 0;
int count = 0;
List<int> result = new List<int>();
while (count < n)
{
    cur = (cur + 1) % n;
    if (!flag[cur])
        plus++;
    if (plus == k)
    {
        flag[cur] = true;
        plus = 0;
        count++;
        result.Add(cur == 0 ? n : cur);
    }
}
Console.Write("<{0}", result[0]);
for (int i = 1; i < n - 1; i++)
{
    Console.Write(", {0}", result[i]);
}
if (n > 1)
    Console.Write(", {0}>", result[n - 1]);
else
    Console.Write(">");
