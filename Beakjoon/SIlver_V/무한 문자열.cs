using System.Text;

string s = Console.ReadLine();
string t = Console.ReadLine();

StringBuilder sb1 = new StringBuilder();
StringBuilder sb2 = new StringBuilder();
for (int i = 0; i < t.Length; i++)
    sb1.Append(s);
for (int i = 0; i < s.Length; i++)
    sb2.Append(t);
if (sb1.ToString().Contains(sb2.ToString()))
    Console.WriteLine("1");
else
    Console.WriteLine("0");