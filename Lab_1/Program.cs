using System.Text;

namespace Lab_1;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        int num;
        do
        {
            Console.WriteLine("Виберіть завдання: 1-4\nКінець роботи: 0");
            num = Int32.Parse(Console.ReadLine());
            switch (num)
            {
                case 1: Task1.Start(); break;
                case 2: Task2.Start(); break;
                case 3: Task3.Start(); break;
                case 4: Task4.Start(); break;
                case 0: break;
                default: Console.WriteLine("Введене значення є некоректним"); break;
            }
        } while (num != 0);
    }
}