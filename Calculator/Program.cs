using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Calculator
{
    internal class Program
    {
        public static double temp = 0;
        public static bool has_memory = false;

        static void PrintAllActions()
        {
            Console.WriteLine(
                "Выберите операцию:\n" +
                "1. Сложение\n" +
                "2. Вычитание\n" +
                "3. Умножение\n" +
                "4. Деление\n" +
                "5. Вычисление остатка\n" +
                "6. Деление (1/x)\n" +
                "7. Возведение в квадрат\n" +
                "8. Квадратный корень\n" +
                "9. Сохранить в память (M+)\n" +
                "10. Очистить память (M-)\n" +
                "11. Извлечь из памяти (MR)\n" +
                "0. Выход\n"
                );
        }

        static void PrintMemActions()
        {
            Console.WriteLine(
                "\nОперации с памятью:\n" +
                "10. Очистить память (M-)\n" +
                "11. Извлечь из памяти (MR)\n" +
                "12. Продолжить без памяти\n"
                );
        }

        public static double GetNumber()
        {
            while (true)
            {
                // Предложить использовать память если ячейка заполнена
                if (has_memory)
                {
                    Console.WriteLine($"В памяти: {temp}");
                    PrintMemActions();
                    Console.Write("Выберите действие: ");

                    if (int.TryParse(Console.ReadLine(), out int memChoice))
                    {
                        switch (memChoice)
                        {
                            case 10:
                                temp = 0;
                                has_memory = false;
                                Console.WriteLine("Память очищена");
                                break;
                            case 11:
                                Console.WriteLine($"Использовано число из памяти: {temp}");
                                return temp;
                            case 12:
                                break;
                            default:
                                Console.WriteLine("Неверный выбор!");
                                continue;
                        }
                    }
                }

                Console.Write("Введите число: ");
                if (double.TryParse(Console.ReadLine(), out double x))
                {
                    return x;
                }
                else
                {
                    Console.WriteLine("Ошибка: Некорректное число!");
                }
            }
        }

        public static bool GetResult(int action, double x, double y)
        {
            double result = 0;
            bool success = true;

            switch (action)
            {
                case 1:
                    result = Calc.Add(x, y);
                    Console.WriteLine($"Результат: {result}");
                    break;
                case 2:
                    result = Calc.Substract(x, y);
                    Console.WriteLine($"Результат: {result}");
                    break;
                case 3:
                    result = Calc.Multiply(x, y);
                    Console.WriteLine($"Результат: {result}");
                    break;
                case 4:
                    result = Calc.Divide(x, y);
                    if (!double.IsNaN(result))
                        Console.WriteLine($"Результат: {result}");
                    else
                        return false;
                    break;
                case 5:
                    result = Calc.Mod(x, y);
                    if (!double.IsNaN(result))
                        Console.WriteLine($"Результат: {result}");
                    else
                        return false;
                    break;
                case 6:
                    result = Calc.OneX(x);
                    if (!double.IsNaN(result))
                        Console.WriteLine($"Результат: {result}");
                    else
                        return false;
                    break;
                case 7:
                    result = Calc.PowSquared(x);
                    Console.WriteLine($"Результат: {result}");
                    break;
                case 8:
                    result = Calc.Sqrt(x);
                    if (!double.IsNaN(result))
                        Console.WriteLine($"Результат: {result}");
                    else
                        return false;
                    break;
                default:
                    Console.WriteLine("Ошибка: Неизвестная операция!");
                    return false;
            }

            // Сохранение результата в память
            if (success && !double.IsNaN(result))
            {
                Console.Write("\nСохранить результат? (y/n): ");
                string save = Console.ReadLine();
                if (save?.ToLower() == "y")
                {
                    temp = result;
                    has_memory = true;
                    Console.WriteLine("Сохранено");
                }
            }

            return true;
        }

        public static bool MemOperations(int action, double x)
        {
            switch (action)
            {
                case 9:
                    temp = x;
                    has_memory = true;
                    Console.WriteLine($"Число {x} сохранено в память");
                    break;
                case 10:
                    temp = 0.0;
                    has_memory = false;
                    Console.WriteLine("Память очищена");
                    break;
                case 11:
                    if (has_memory)
                    {
                        Console.WriteLine($"В памяти: {temp}");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Память пуста");
                    }
                    break;
                default:
                    Console.WriteLine("Ошибка: Неизвестная операция!");
                    return false;
            }
            return true;
        }

        public static void ActionManager()
        {
            double x = GetNumber();

            PrintAllActions();
            Console.Write("Выберите операцию: ");

            if (int.TryParse(Console.ReadLine(), out int action))
            {
                if (action == 0)
                {
                    return;
                }
                else if (action >= 9 && action <= 11)
                {
                    MemOperations(action, x);
                }
                else if (action >= 6 && action <= 8)
                {
                    GetResult(action, x, 0);
                }
                else if (action >= 1 && action <= 5) 
                {
                    double y = GetNumber();
                    GetResult(action, x, y);
                }
                else
                {
                    Console.WriteLine("Ошибка: Не поддерживается!");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: Некорректный ввод.");
            }
        }

        static void Main(string[] args)
        {
            do
            {
                try
                {
                    ActionManager();

                    Console.WriteLine("\nНажмите Enter для продолжения или введите 'exit' для выхода");
                    string input = Console.ReadLine();

                    if (input?.ToLower() == "exit")
                    {
                        break;
                    }

                    Console.Clear();
                }
                catch (Exception e)
                {
                    Console.Write($"Произошла ошибка: {e.Message}\n Нажмите Enter для продолжения");
                    Console.ReadLine();
                    Console.Clear();
                }

            } while (true);
        }
    }
}