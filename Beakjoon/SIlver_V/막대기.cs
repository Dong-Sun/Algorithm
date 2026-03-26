int x = int.Parse(Console.ReadLine());
string s = Convert.ToString(x, 2);
int count = 0;
for (int i = 0; i < s.Length; i++)
    if (s[i].Equals('1')) count++;
Console.WriteLine(count);