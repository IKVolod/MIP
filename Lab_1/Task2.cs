namespace Lab_1;

public class Task2
{
    public static void Start()
    {
        double[,] input = new double[2,3];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine($"Введіть p(x{i + 1}, y{j + 1}):");
                input[i,j] = double.Parse(Console.ReadLine());
            }
        }

        double Hxy = 0;
        for (int i = 0; i < 2; i++) { for (int j = 0; j < 3; j++) Hxy += -1 * input[i,j] * Math.Log2(input[i,j]); }
        Console.WriteLine($"H(X,Y) = {Hxy:F4} біт");
        
        double px1 = input[0,0] + input[0,1] + input[0,2];
        Console.WriteLine($"p(x1) = {px1}");
        double px2 = input[1,0] + input[1,1] + input[1,2];
        Console.WriteLine($"p(x2) = {px2}");
        
        double Hx = -px1 * Math.Log2(px1) - px2 * Math.Log2(px2);
        Console.WriteLine($"H(X) = {Hx:F4} біт");
        
        double py1 = input[0,0] + input[1,0];
        Console.WriteLine($"p(x1) = {py1:f2}");
        double py2 = input[0,1] + input[1,1];
        Console.WriteLine($"p(x2) = {py2}");
        double py3 = input[0,2] + input[1,2];
        Console.WriteLine($"p(x3) = {py3}");
        
        double Hy = -py1 * Math.Log2(py1) - py2 * Math.Log2(py2) - py3 * Math.Log2(py3);
        Console.WriteLine($"H(Y) = {Hy:F4} біт");

        double Rx = 1 - Hx / 1;
        Console.WriteLine($"Rx = {Rx:F4} біт");

        double Ry = 1 - Hy / Math.Log2(3);
        Console.WriteLine($"Ry = {Ry:F4} біт");

        if (Math.Round(Hx, 4) + Math.Round(Hy, 4) > Math.Round(Hxy, 4))
        {
            if (Math.Round(Hx, 4) + Math.Round(Hy, 4) == Math.Round(Hxy, 4)) Console.WriteLine($"{Hx:F4} + {Hy:F4} = {Hxy:F4} біт");
            else Console.WriteLine($"{Hx:F4} + {Hy:F4} > {Hxy:F4} біт");
        }
        else Console.WriteLine($"{Hx:F4} + {Hy:F4} < {Hxy:F4} біт");
        Console.WriteLine(0.99884+1.536436+" шд");
    }
}