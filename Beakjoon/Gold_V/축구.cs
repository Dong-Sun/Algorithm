// Initialize
double percentA = double.Parse(Console.ReadLine()) / 100d;
double percentB = double.Parse(Console.ReadLine()) / 100d;
double result;

// Solution
// 적어도 한 팀이 골을 소수로 득점할 확률
// => 1 - 두팀 다 소수가 아닌 확률
int[,] comb = new int[19, 19]; // 이항계수
MakeComb();

int[] goals = { 0, 1, 4, 6, 8, 9, 10, 12, 14, 15, 16, 18 };
double sumA = 0;
double sumB = 0;
foreach (var r in goals)
{
    sumA += comb[18, r] * Math.Pow(percentA, r) * Math.Pow(1 - percentA, 18 - r);
    sumB += comb[18, r] * Math.Pow(percentB, r) * Math.Pow(1 - percentB, 18 - r);
}
result = 1 - sumA * sumB;

// Output
Console.WriteLine(result);

//Function
void MakeComb()
{
    comb[0, 0] = 1;
    for (int i = 1; i <= 18; i++)
    {
        comb[i, 0] = 1;
        for (int j = 1; j <= i; j++)
        {
            comb[i, j] = comb[i - 1, j - 1] + comb[i - 1, j];
        }
    }
}