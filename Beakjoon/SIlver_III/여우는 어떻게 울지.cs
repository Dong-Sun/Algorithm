using System.Text;

StringBuilder result = new StringBuilder();
int t = int.Parse(Console.ReadLine());
while (t-- > 0)
{
    string[] input = Console.ReadLine().Split();
    List<string> saying = new List<string>();
    while (true)
    {
        string line = Console.ReadLine();
        if (line.Equals("what does the fox say?"))
            break;
        saying.Add(line.Split()[2]);
    }
    for (int i = 0; i < input.Length; i++)
    {
        bool flag = true;
        foreach (var v in saying)
        {
            if (input[i].Equals(v))
                flag = false;
        }
        if (flag) result.Append(input[i] + " ");
    }
    result.AppendLine();
}
Console.Write(result);