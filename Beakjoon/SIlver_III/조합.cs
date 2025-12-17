using System.Text;
namespace CSharp
{
    class Program
    {
        static string[,] tri;
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int n = input[0];
            int m = input[1];
            tri = new string[n + 2, n + 2];
            tri[0, 0] = "1";
            for (int i = 1; i <= n; i++)
            {
                tri[i, 0] = "1";
                for (int j = 1; j <= i; j++)
                {
                    tri[i, j] = StringAdd(tri[i - 1, j], tri[i - 1, j - 1]);
                }
            }
            Console.WriteLine(tri[n, m]);
        }

        static string StringAdd(string left, string right)
        {
            StringBuilder sb = new StringBuilder();
            Stack<string> reverse = new Stack<string>();
            string s1 = new string(left);
            string s2 = new string(right);
            int temp = 0;
            int sum;
            int index1 = s1.Length - 1;
            int index2 = s2.Length - 1;
            while (index1 >= 0 || index2 >= 0)
            {
                if (index1 < 0)
                {
                    sum = int.Parse(s2[index2].ToString()) + temp;
                    if (sum >= 10) temp = 1;
                    else temp = 0;
                    reverse.Push(Convert.ToString(sum % 10));
                    index2--;
                }
                else if (index2 < 0)
                {
                    sum = int.Parse(s1[index1].ToString()) + temp;
                    if (sum >= 10) temp = 1;
                    else temp = 0;
                    reverse.Push(Convert.ToString(sum % 10));
                    index1--;
                }
                else
                {
                    sum = int.Parse(s1[index1].ToString()) + int.Parse(s2[index2].ToString()) + temp;
                    if (sum >= 10) temp = 1;
                    else temp = 0;
                    reverse.Push(Convert.ToString(sum % 10));
                    index1--;
                    index2--;
                }
            }
            if (temp >= 1) reverse.Push(temp.ToString());
            while (reverse.Count > 0)
                sb.Append(reverse.Pop());
            return sb.ToString();
        }
    }
}