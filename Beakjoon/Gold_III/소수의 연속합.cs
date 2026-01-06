using System.Text;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //  에라토스테네스의 체
            bool[] visited = new bool[n + 1];
            for (int i = 2; i <= n / 2; i++)
                for (int j = i + i; j <= n; j += i)
                    visited[j] = true;

            //  소수배열 만들기
            List<int> list = new List<int>(n);
            for (int i = 2; i < visited.Length; i++)
                if (!visited[i])
                    list.Add(i);

            //  투포인터
            int left = 0;
            int right = 0;
            int sum = 2;
            int result = 0;
            while (left <= right && right < list.Count)
            {
                if (sum == n)
                {
                    result++;
                    if (++right < list.Count)
                        sum += list[right];
                }
                else if (sum > n)
                    sum -= list[left++];
                else if (++right < list.Count)
                    sum += list[right];
            }

            Console.WriteLine(result);
        }
    }
}