using System;
using System.Threading;

class TimerApp
{
    static void Main()
    {
        Console.WriteLine("Введите время в секундах для таймера:");
        int seconds;
        while (!int.TryParse(Console.ReadLine(), out seconds) || seconds < 0)
        {
            Console.WriteLine("Пожалуйста, введите корректное число секунд:");
        }

        Console.WriteLine("Таймер установлен на {0} секунд.", seconds);
        Console.WriteLine("Для паузы/возобновления нажмите 'p', для выхода - 'q'.");

        bool isPaused = false;
        while (seconds > 0)
        {
            if (!isPaused)
            {
                Console.WriteLine("Оставшееся время: {0} секунд", seconds);
                Thread.Sleep(1000);
                seconds--;
            }

            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.P)
                {
                    isPaused = !isPaused;
                    Console.WriteLine(isPaused ? "Таймер на паузе." : "Таймер возобновлен.");
                }
                else if (key.Key == ConsoleKey.Q)
                {
                    break;
                }
            }
        }

        if (seconds == 0)
        {
            Console.WriteLine("Время вышло!");
            // Здесь можно добавить звуковой сигнал, если платформа это поддерживает
            Console.Beep();
        }

        Console.WriteLine("Таймер остановлен.");
    }
}