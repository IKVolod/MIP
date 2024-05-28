namespace Lab_1;

public class Task1
{
    public static void Start()
    {
        double[] input = new double[8];
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine($"Введіть p(x{i + 1}):");
            input[i] = double.Parse(Console.ReadLine());
        }
        for (int i = 4; i < 8; i++)
        {
            Console.WriteLine($"Введіть T{i - 3}:");
            input[i] = double.Parse(Console.ReadLine());
        }

        double Hx = 0;
        for (int i = 0; i < 4; i++) Hx += -1 * input[i] * Math.Log2(input[i]);
        Console.WriteLine($"H(X) = {Hx:F4} біт");

        double t = 0;    
        for (int i = 0; i < 4; i++) t += input[i] * input[i + 4];
        Console.WriteLine($"t = {t:F4} мс");

        double H = Hx / (t * 0.001);
        Console.WriteLine($"H = {H:F4} біт/с");

        double Rx = 1 - Hx / 2;
        Console.WriteLine($"Rx = {Rx:F4} біт");
    }
}