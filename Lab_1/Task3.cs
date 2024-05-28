namespace Lab_1;

public class Task3
{
    public static void Start()
    {
        double[,] input = new double[2,3];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.WriteLine($"Введіть p(x{j + 1}, x{i + 1}):");
                input[i,j] = double.Parse(Console.ReadLine());
            }
        }
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine($"Введіть T{i + 1}:");
            input[i,2] = double.Parse(Console.ReadLine());
        }

        double Hx = 0;
        for (int i = 0; i < 2; i++) { for (int j = 0; j < 2; j++) Hx += -1 * input[i,j] * Math.Log2(input[i,j]); }
        Console.WriteLine($"H(X) = {Hx:F4} біт");

        double HT1 = Hx / input[0, 2];
        Console.WriteLine($"H = H/T1 = {HT1:F4} біт");
        double HT2 = Hx / input[1, 2];
        Console.WriteLine($"H = H/T2 = {HT2:F4} біт");
        
        double Rx = 1 - Hx / 1;
        Console.WriteLine($"Rx = {Rx:F4} біт");
    }
}