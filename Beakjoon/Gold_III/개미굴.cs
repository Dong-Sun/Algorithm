using System.Text;

namespace CSharp
{
    class Program
    {
        static StringBuilder sb = new();
        static StreamReader sr = new(Console.OpenStandardInput());
        static int n;
        static string input;
        static string[] split;
        static string[] arr;
        static string[] select;
        static void Main(string[] args)
        {
            // 입력
            n = int.Parse(sr.ReadLine());
            select = new string[20];
            arr = new string[n];
            for (int i = 0; i < n; i++)
            {
                input = sr.ReadLine();
                split = input.Split();
                for (int j = 1; j < split.Length; j++)
                    sb.Append(split[j] + " ");
                arr[i] = sb.ToString();
                sb.Clear();
            }
            Array.Sort(arr);

            // 구현
            foreach (var s in arr)
            {
                split = s.Split();
                for (int i = 0; i < split.Length - 1; i++)
                {
                    if (split[i].Equals(select[i]))
                        continue;
                    for (int j = 0; j < i; j++)
                        sb.Append("--");
                    sb.AppendLine(split[i]);
                    select[i] = split[i];
                    for (int k = i + 1; k < select.Length; k++)
                        select[k] = "";
                }
            }

            // 출력
            Console.Write(sb);
        }
    }
}