int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int N = input[0];
int S = input[1];

input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int mid = N / 2;
long result = 0;
List<int> A = new();
List<int> B = new();

Left(0, 0, mid);
Right(0, mid, N);

A.Sort();
B.Sort();

for (int i = 0; i < A.Count;)
{
    int a = A[i];
    long mul1 = UpperBound(A, a) - LowerBound(A, a) + 1;
    long mul2 = UpperBound(B, S - a) - LowerBound(B, S - a) + 1;
    result += mul1 * mul2;
    i += (int)mul1;
}

// S가 0일 경우 공집합인 경우를 빼야한다.
if (S == 0) result -= 1;
Console.WriteLine(result);

void Left(int sum, int cur, int end)
{
    if (cur == end)
    {
        A.Add(sum);
        return;
    }
    Left(sum, cur + 1, mid);    // 부분수열에 포함x
    Left(sum + input[cur], cur + 1, mid); // 부분수열에 포함o
}
void Right(int sum, int cur, int end)
{
    if (cur == end)
    {
        B.Add(sum);
        return;
    }
    Right(sum, cur + 1, end);
    Right(sum + input[cur], cur + 1, end);
}
int LowerBound(List<int> list, int target)
{
    int left = -1;
    int right = list.Count;
    while (left + 1 < right)
    {
        int mid = (left + right) / 2;
        if (list[mid] < target)
            left = mid;
        else
            right = mid;
    }
    return right;
}
int UpperBound(List<int> list, int target)
{
    int left = -1;
    int right = list.Count;
    while (left + 1 < right)
    {
        int mid = (left + right) / 2;
        if (list[mid] <= target)
            left = mid;
        else
            right = mid;
    }
    return left;
}