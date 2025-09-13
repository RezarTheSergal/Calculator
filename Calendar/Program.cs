using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Calendar
{
    public struct Info()
    {
        public static string WeekDay = "Будний";
        public static string WeekEnd = "Выходной";
    }
    public struct Day
    {
        public Day(string day, string stat) 
        {
            Name = day;
            Stat = stat;
        }
        public string Name { get; }
        public string Stat { get; }
    }
    public class Week
    {
        public readonly Day[] days = new Day[7];


        public Week() 
        {
            days[0] = new Day("Monday", Info.WeekDay);
            days[1] = new Day("Tuesday", Info.WeekDay);
            days[2] = new Day("Wednesday", Info.WeekDay);
            days[3] = new Day("Thursday", Info.WeekDay);
            days[4] = new Day("Friday", Info.WeekDay);
            days[5] = new Day("Saturday", Info.WeekEnd);
            days[6] = new Day("Sunday", Info.WeekEnd);
        }
    }

    internal class Program
    {
        public static bool IsWeekend(DateTime dateTime)
        {
            if (dateTime.DayOfWeek.ToString() == "Saturday" || dateTime.DayOfWeek.ToString() == "Sunday") return true;
            return false;

        }
        static void Main(string[] args)
        {
            Week week = new Week();
            while (true)
            {
                Console.WriteLine("Введите день недели с которого начинается месяц 1(пн) - 7(вс)");
                if (int.TryParse(Console.ReadLine(), out int day))
                {
                    if (day > 7)
                    {
                        Console.WriteLine("Ошибка: Выход за пределы диапазона 1(пн) - 7(вс)");
                        continue;
                    }
                    Console.Write("Введите день месяца: ");
                    if (int.TryParse(Console.ReadLine(), out int number))
                    {
                        if (number > 31 || number < 1)
                        {
                            Console.WriteLine("Ошибка: В мае 31 день");
                            continue;
                        }

                        if (number <= 5 || (number >= 8 && number <= 10))
                        {
                            Console.WriteLine(Info.WeekEnd);
                            continue;
                        }

                        bool flag = false;
                        DateTime dateTime = new(2025, 5, 1);
                        int year = dateTime.Year;
                        while (!flag)
                        {
                            Console.WriteLine($"{dateTime.DayOfWeek} {week.days[day-1].Name} {dateTime.Year}");
                            if (dateTime.DayOfWeek.ToString().Equals(week.days[day-1].Name))
                            {
                                flag = true;
                            }
                            else
                            {
                                dateTime = dateTime.AddYears(-1);
                                year = dateTime.Year;
                            }

                        }
                        dateTime = new(year, 5, number);
                        Console.WriteLine($"{(IsWeekend(dateTime) ? Info.WeekEnd : Info.WeekDay)} {dateTime.DayOfWeek}");
                    }
                }
            }
        }
    }
}