int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
PriorityQueue<int, int> gift = new();
int[] children = new int[m + 1];
input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
for (int i = 0; i < n; i++)
    gift.Enqueue(input[i], -input[i]);
input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
for (int i = 1; i <= m; i++)
    children[i] = input[i - 1];

for (int i = 1; i <= m; i++)
{
    if (gift.Count == 0 || children[i] > gift.Peek())
    {
        Console.WriteLine(0);
        return;
    }
    int num = gift.Dequeue() - children[i];
    gift.Enqueue(num, -num);
}
Console.WriteLine(1);