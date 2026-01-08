using System.Text;

namespace CSharp
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
        static StreamReader sr = new StreamReader(Console.OpenStandardInput());
        static void Main(string[] args)
        {
            // 입력
            int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int n = input[0];   // 코스의 길이
            int m = input[1];   // 시야의 범위
            input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse); // 빛의 세기

            // 구현
            List<(int value, int index)> list = new();
            List<int> result = new();
            int size = Math.Min(n, m * 2 - 1);
            for (int i = 0; i < size; i++)
            {
                list.Add((input[i], i));
                while (list.Count > 1 && list[list.Count - 1].value > list[list.Count - 2].value)
                    list.RemoveAt(list.Count - 2);
            }
            result.Add(list[0].value);
            for (int i = m; i < n - m + 1; i++)
            {
                if (list[0].index == i - m)
                    list.RemoveAt(0);
                list.Add((input[i + m - 1], i + m - 1));
                while (list.Count > 1 && list[list.Count - 1].value > list[list.Count - 2].value)
                    list.RemoveAt(list.Count - 2);
                result.Add(list[0].value);
            }

            // 출력
            for (int i = 0; i < result.Count; i++)
                sb.Append(result[i] + " ");
            sw.Write(sb);
            sw.Flush();
        }
    }
}