int result = 0;
int n = int.Parse(Console.ReadLine());
string k = Console.ReadLine();
for (int i = 0; i < n; i++)
    if (k[i].Equals('1')) result++;
Console.WriteLine(result);