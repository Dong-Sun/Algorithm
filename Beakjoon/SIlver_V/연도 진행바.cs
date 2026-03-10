string[] input = Console.ReadLine().Split();
int month = 0;
switch (input[0])
{
    case "January":
        month = 1;
        break;
    case "February":
        month = 2;
        break;
    case "March":
        month = 3;
        break;
    case "April":
        month = 4;
        break;
    case "May":
        month = 5;
        break;
    case "June":
        month = 6;
        break;
    case "July":
        month = 7;
        break;
    case "August":
        month = 8;
        break;
    case "September":
        month = 9;
        break;
    case "October":
        month = 10;
        break;
    case "November":
        month = 11;
        break;
    case "December":
        month = 12;
        break;

}
int day = int.Parse(input[1][..^1]);
int year = int.Parse(input[2]);
int hour = int.Parse(input[3][..2]);
int minute = int.Parse(input[3][3..]);
int[] calendar = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
IsLeapYear(year);

double maxSecond = 0;
for (int i = 1; i <= 12; i++)
    maxSecond += calendar[i] * 24 * 60 * 60;

double second = 0;
for (int i = 1; i < month; i++)
    second += calendar[i] * 24 * 60 * 60;
second += (day - 1) * 24 * 60 * 60;
second += hour * 60 * 60;
second += minute * 60;

Console.WriteLine(second / maxSecond * 100d);

void IsLeapYear(int year)
{
    if (year % 400 == 0)
        calendar[2] = 29;
    else if (year % 4 == 0 && year % 100 != 0)
        calendar[2] = 29;
}