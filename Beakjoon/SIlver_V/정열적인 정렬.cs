using System.Text;

int n = int.Parse(Console.ReadLine());
int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
Array.Sort(arr);
StringBuilder sb = new StringBuilder();
foreach (var v in arr)
    sb.Append(v + " ");
Console.WriteLine(sb);