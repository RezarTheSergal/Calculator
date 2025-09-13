using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Calendar
{
    struct Week()
    {
        public static string WeekDay = "Будний";
        public static string WeekEnd = "Выходной";
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
                        if (number > 31)
                        {
                            Console.WriteLine("Ошибка: В мае 31 день");
                            continue;
                        }

                        if (number <= 5 || (number >= 8 && number <= 10))
                        {
                            Console.WriteLine(Week.WeekEnd);
                            continue;
                        }

                        bool flag = false;
                        DateTime dateTime = new(2025, 5, 1);
                        int year = dateTime.Year;
                        while (!flag)
                        {
                            Console.WriteLine($"{(int)dateTime.DayOfWeek} {dateTime.Year}");
                            if ((int)dateTime.DayOfWeek == day)
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
                        Console.WriteLine($"{(IsWeekend(dateTime) ? Week.WeekEnd : Week.WeekDay)} {dateTime.DayOfWeek}");
                    }
                }
            }
        }
    }
}