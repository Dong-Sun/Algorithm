using System.Text;

int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];

int[] S = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int[] D = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int[] arr = new int[n];
while (k-- > 0)
{
    for (int i = 0; i < n; i++)
        arr[D[i] - 1] = S[i];
    for (int i = 0; i < n; i++)
        S[i] = arr[i];
}
StringBuilder sb = new StringBuilder();
for (int i = 0; i < n; i++)
    sb.Append(S[i] + " ");
Console.WriteLine(sb);