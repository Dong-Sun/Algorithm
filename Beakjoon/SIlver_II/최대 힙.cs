﻿using System.Text;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution();
        }

        public static void Solution()
        {
            StringBuilder sb = new StringBuilder();
            int n = int.Parse(Console.ReadLine());
            int[] heap = new int[100005];
            heap[0] = int.MaxValue;
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (input != 0)
                {
                    heap[++index] = input;
                    int curIndex = index;
                    while (heap[curIndex] > heap[curIndex / 2])
                    {
                        int temp = heap[curIndex];
                        heap[curIndex] = heap[curIndex / 2];
                        heap[curIndex / 2] = temp;
                        curIndex = curIndex / 2;
                        if (curIndex == 1)
                            break;
                    }
                }
                else
                {
                    if (index == 0)
                    {
                        sb.Append("0\n");
                        continue;
                    }
                    sb.Append(heap[1] + "\n");
                    heap[1] = heap[index--];
                    int curIndex = 1;
                    while (curIndex * 2 <= index)
                    {
                        int left = -1;
                        int right = -1;
                        if (curIndex * 2 <= index)
                            left = heap[curIndex * 2];
                        if (curIndex * 2 + 1 <= index)
                            right = heap[curIndex * 2 + 1];
                        int max = left > right ? curIndex * 2 : curIndex * 2 + 1;
                        if (heap[curIndex] < heap[max])
                        {
                            int temp = heap[curIndex];
                            heap[curIndex] = heap[max];
                            heap[max] = temp;
                            curIndex = max;
                        }
                        else
                            break;
                    }
                }
            }
            Console.Write(sb.ToString());
        }
    }
}