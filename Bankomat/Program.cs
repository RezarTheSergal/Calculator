namespace Bank
{
    internal class Program
    {
        public static int[] denomination = [100, 200, 500, 1000, 2000, 5000];
        static void Main(string[] args)
        {
            Console.Write("Введите сумму: ");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                if (n >= 150000)
                {
                    Console.WriteLine("Ошибка: Банкомат не может выдать за один раз более 150 000 рублей.");
                    return;
                }

                if (n % denomination[0] != 0)
                {
                    Console.WriteLine("Ошибка: Банкомат не может выдать всю сумму имеющимися купюрами");
                    return;
                }

                for (int i = denomination.Length - 1; i >= 0; i--)
                {
                    if (n / denomination[i] >= 1)
                    {
                        int times = n / denomination[i];
                        n -= (denomination[i] * times);
                        Console.Write($"{times} по {denomination[i]} ");
                    }
                }

            }
        }
    }
}