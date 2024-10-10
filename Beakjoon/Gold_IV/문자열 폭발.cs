using System.Text;

namespace Debug
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static Func<int[]> InputIntArray = () => Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        static Func<int> InputInt = () => int.Parse(Console.ReadLine());
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string key = Console.ReadLine();
            int keySize = key.Length;
            char[] result = new char[input.Length];
            int index = 0;
            for (int i = 0; i < input.Length; i++)
            {
                result[index++] = input[i];
                if (index >= keySize)
                {
                    bool flag = true;
                    for (int j = 0; j < keySize; j++)
                    {
                        if (!result[j + index - keySize].Equals(key[j]))
                            flag = false;
                    }
                    if (flag)
                    {
                        index -= keySize;
                    }
                }
            }
            for (int i = 0; i < index; i++)
                sb.Append(result[i]);
            if (index == 0)
                Console.WriteLine("FRULA");
            else
                Console.WriteLine(sb);
        }
    }
}