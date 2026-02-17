using System.Text;

// input
int n = int.Parse(Console.ReadLine());
StringBuilder sb = new StringBuilder();

// solution
while (n-- > 0)
{
    int input = int.Parse(Console.ReadLine());
    bool flag = false;
    for (int i = 2; i <= 64; i++)
    {
        List<int> list = new List<int>();
        int temp = input;
        while (temp >= i)
        {
            list.Add(temp % i);
            temp /= i;
        }
        list.Add(temp % i);
        int left = 0;
        int right = list.Count - 1;
        while (left <= right)
        {
            if (list[left] != list[right])
                break;
            left++;
            right--;
        }
        if (left > right)
        {
            flag = true;
            break;
        }
    }
    if (flag)
        sb.AppendLine("1");
    else
        sb.AppendLine("0");
}
// print
Console.WriteLine(sb);