using System.Text;

int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];
int m = input[2];

int index = 0;
int count = 0;
bool dir = true;

Queue<int> result = new Queue<int>();
List<int> arr = new List<int>();
bool[] flag = new bool[n];
for (int i = 1; i <= n; i++)
    arr.Add(i);

while (result.Count < n)
{
    if (dir)
    {
        index += k - 1;
        if (index >= arr.Count)
            index %= arr.Count;
    }
    else
    {
        index = index + arr.Count - k % arr.Count;
        if (index >= arr.Count)
            index %= arr.Count;
    }
    result.Enqueue(arr[index]);
    arr.RemoveAt(index);
    flag[index] = true;
    count++;
    if (count == m)
    {
        dir = !dir;
        count = 0;
    }
}

StringBuilder sb = new StringBuilder();
while (result.Count > 0)
    sb.AppendLine(result.Dequeue().ToString());
Console.Write(sb);