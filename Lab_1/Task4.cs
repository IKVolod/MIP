namespace Lab_1;

public class Task4
{
    public static void Start()
    {
        double[] inputY = new double[3];
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Введіть p(y{i + 1}):");
            inputY[i] = double.Parse(Console.ReadLine());
        }
        double[,] inputYX = new double[2,3];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine($"Введіть p(y{j + 1}, x{i + 1}):");
                inputYX[i,j] = double.Parse(Console.ReadLine());
            }
        }
        
        double Hxy = 0;
        for (int i = 0; i < 2; i++) { for (int j = 0; j < 3; j++) Hxy += -1 * inputYX[i,j] * Math.Log2(inputYX[i,j]); }
        Console.WriteLine($"H(X,Y) = {Hxy:F4} біт");
        
        double Hy = -inputY[0] * Math.Log2(inputY[0]) - inputY[1] * Math.Log2(inputY[1]) - inputY[2] * Math.Log2(inputY[2]);
        Console.WriteLine($"H(Y) = {Hy:F4} біт");
        
        double px1 = inputY[0] * inputYX[0,0] + inputY[1] * inputYX[0,1] + inputY[2] * inputYX[0,2];
        Console.WriteLine($"p(x1) = {px1}");
        double px2 = inputY[0] * inputYX[1,0] + inputY[1] * inputYX[1,1] + inputY[2] * inputYX[1,2];
        Console.WriteLine($"p(x2) = {px2}");
        
        double Hx = -px1 * Math.Log2(px1) - px2 * Math.Log2(px2);
        Console.WriteLine($"H(X) = {Hx:F4} біт");
        
        double Rx = 1 - Hx / Math.Log2(6);
        Console.WriteLine($"Rx = {Rx:F4} біт");

        double Ry = 1 - Hy / Math.Log2(6);
        Console.WriteLine($"Ry = {Ry:F4} біт");

        double HYx1 = -inputYX[0,0] * Math.Log2(inputYX[0,0]) - inputYX[0,1] * Math.Log2(inputYX[0,1]) - inputYX[0,2] * Math.Log2(inputYX[0,2]);
        Console.WriteLine($"H(Y|x1) = {HYx1:F4} біт");
        double HYx2 = -inputYX[1,0] * Math.Log2(inputYX[1,0]) - inputYX[1,1] * Math.Log2(inputYX[1,1]) - inputYX[1,2] * Math.Log2(inputYX[1,2]);
        Console.WriteLine($"H(Y|x2) = {HYx2:F4} біт");

        double HXY = px1 * HYx1 + px2 * HYx2;
        Console.WriteLine($"H(X|Y) = {HXY:F4} біт");
        
        double Ixy = Hy - HXY;
        Console.WriteLine($"I(X|Y) = {Ixy:F4} біт");
    }
}