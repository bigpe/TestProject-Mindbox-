using ShapesSquare;
using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var unitName = "cm";
            uint decimalNum = 3;
            var Shape = new Shapes(unitName, decimalNum);
            Console.Write("Input Numbers: ");
            var userData = Console.ReadLine();
            var nums = Shape.convertStringToNumbers(userData);
            Shape.checkShapeType(nums);
            Console.WriteLine(Shape.getResult());
            Console.WriteLine("Press Any Key to Exit.");
            Console.ReadKey();
        }
    }
}