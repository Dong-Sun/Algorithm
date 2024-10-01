using System.Text;

namespace Solution
{
    class DoublePriorityQueue
    {
        PriorityQueue<int, int> maxQueue = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x))); // 최대 힙
        PriorityQueue<int, int> minQueue = new PriorityQueue<int, int>(); // 최소 힙
        Dictionary<int, int> keys = new Dictionary<int, int>(); // 유효한 값인지 확인
        public bool IsEmpty()
        {
            return keys.Count == 0 ? true : false;
        }
        public int? GetMaxValue()
        {
            RemoveInvaild(maxQueue, keys);
            return maxQueue.Count > 0 ? maxQueue.Peek() : null;
        }
        public int? GetMinValue()
        {
            RemoveInvaild(minQueue, keys);
            return minQueue.Count > 0 ? minQueue.Peek() : null;
        }
        public void Insert(int value)
        {
            if (keys.ContainsKey(value))
            {
                keys[value]++;
            }
            else
            {
                keys.Add(value, 1);
                maxQueue.Enqueue(value, value);
                minQueue.Enqueue(value, value);
            }
        }
        public void RemoveMaxValue()
        {
            int? max = GetMaxValue();
            if (max.HasValue)
            {
                if (keys[max.Value] > 1)
                {
                    keys[max.Value]--;
                }
                else
                {
                    keys.Remove(max.Value);
                }
            }
        }
        public void RemoveMinValue()
        {
            int? min = GetMinValue();
            if (min.HasValue)
            {
                if (keys[min.Value] > 1)
                {
                    keys[min.Value]--;
                }
                else
                {
                    keys.Remove(min.Value);
                }
            }
        }
        public void RemoveInvaild(PriorityQueue<int, int> q, Dictionary<int, int> d)
        {
            while (q.Count > 0 && !d.ContainsKey(q.Peek()))
            {
                q.Dequeue();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new();
            int T = int.Parse(Console.ReadLine());
            while (T > 0)
            {
                T--;
                DoublePriorityQueue pq = new DoublePriorityQueue();
                int k = int.Parse(Console.ReadLine());
                while (k > 0)
                {
                    k--;
                    string[] split = Console.ReadLine().Split();
                    char Op = split[0][0];
                    int num = int.Parse(split[1]);
                    if (Op.Equals('I')) // 추가 연산
                    {
                        pq.Insert(num);
                    }
                    else if (Op.Equals('D'))    // 삭제 연산
                    {
                        if (pq.IsEmpty())    // 유효한 값이 없을 경우 건너 뜀
                            continue;
                        if (num == 1)
                        {
                            pq.RemoveMaxValue();
                        }
                        else if (num == -1) // 최소 힙 빼오기
                        {
                            pq.RemoveMinValue();
                        }
                    }
                }
                int? maxValue = pq.GetMaxValue();
                int? minValue = pq.GetMinValue();
                if (maxValue.HasValue && minValue.HasValue)
                    sb.AppendLine($"{maxValue} {minValue}");
                else
                    sb.AppendLine("EMPTY");
            }
            Console.Write(sb);
        }
    }
}