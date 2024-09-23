using System.Text;

namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            while (t > 0)
            {
                string p = Console.ReadLine();
                int n = int.Parse(Console.ReadLine());
                string arr = Console.ReadLine();
                arr = arr.Substring(1, arr.Length - 2);
                var list = n == 0 ? new List<int>() : Array.ConvertAll(arr.Split(','), int.Parse).ToList();
                bool isError = false;
                bool isReverse = false;

                // 명령시작
                for (int i = 0; i < p.Length; i++)
                {
                    // 뒤집기
                    if (p[i].Equals('R'))
                        isReverse = !isReverse;
                    // 첫 번째 수 버리기
                    else if (p[i].Equals('D'))
                    {
                        if (list.Count > 0)
                        {
                            if (!isReverse)
                                list.RemoveAt(0);
                            else
                                list.RemoveAt(list.Count - 1);
                        }
                        else
                            isError = true;
                    }
                }
                if (isError)
                    sb.Append("error\n");
                else
                {
                    sb.Append("[");
                    if (!isReverse)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (i == list.Count - 1)
                                sb.Append($"{list[i]}");
                            else
                                sb.Append($"{list[i]},");
                        }
                    }
                    else
                    {
                        for (int i = list.Count - 1; i >= 0; i--)
                        {
                            if (i == 0)
                                sb.Append($"{list[i]}");
                            else
                                sb.Append($"{list[i]},");
                        }
                    }
                    sb.Append("]\n");
                }
                t--;
            }
            Console.Write(sb.ToString());
        }
    }
}