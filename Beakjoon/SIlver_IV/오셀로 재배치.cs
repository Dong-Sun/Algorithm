using System.Text;

StringBuilder sb = new StringBuilder();
int t = int.Parse(Console.ReadLine());
while (t-- > 0)
{
    int n = int.Parse(Console.ReadLine());
    string start = Console.ReadLine();
    string end = Console.ReadLine();
    int white = 0;
    int black = 0;

    for (int i = 0; i < n; i++)
    {
        if (!start[i].Equals(end[i]))
        {
            if (start[i].Equals('W'))
                white++;
            else
                black++;
        }
    }
    sb.AppendLine(Math.Max(white, black).ToString());
}
Console.WriteLine(sb);