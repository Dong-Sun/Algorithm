// input
long[] input = Array.ConvertAll(Console.ReadLine().Trim().Split(), long.Parse);
long n = input[0];
long p = input[1];
long q = input[2];

// solution
Dictionary<long, long> dict = new();
dict[0] = 1;
Search(n);

// print
Console.WriteLine(dict[n]);

// function
long Search(long n)
{
    if (dict.ContainsKey(n)) return dict[n];
    else dict.Add(n, Search(n / p) + Search(n / q));
    return dict[n];
}