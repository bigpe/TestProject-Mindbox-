using System;
using NUnit.Framework;
using ShapesSquare;

namespace UnitTests
{
    [TestFixture]
    public class Tests
    {
        private const string unitsName = "cm";
        private uint randIterate;
        private uint minRandomValue = 1;
        private uint maxRandomValue = 100;
        private uint decimalNum = 2;
        private uint notAllowedArgsLens = 5;

        [Test]
        public void checkCircle()
        {
            this.randIterate = 1;
            var Shape = createShape();
            var randValue = createRandValue(randIterate);
            var nums = Shape.convertStringToNumbers(randValue);
            Shape.checkShapeType(nums);
            TestContext.WriteLine(Shape.getResult());
        }
        [Test]
        public void checkTriangle()
        {
            this.randIterate = 3;
            var Shape = createShape();
            var randValue = createRandValue(randIterate);
            var nums = Shape.convertStringToNumbers(randValue);
            //Recursion until a regular triangle is found
            while (!Shape.checkCorrectTriangle(nums[0], nums[1], nums[2]))
            {
                TestContext.WriteLine("Failure - Re roll");
                randValue = createRandValue(randIterate);
                nums = Shape.convertStringToNumbers(randValue);
            }
            Shape.checkShapeType(nums);
            TestContext.WriteLine(Shape.getResult());
        }
        [Test]
        public void checkEmptyString()
        {
            var Shape = createShape();
            string s = "";
            var nums = Shape.convertStringToNumbers(s);
            TestContext.WriteLine(Shape.getResult());
        }
        [Test]
        public void checkEmptyNumbers()
        {
            var Shape = createShape();
            var nums = new double[]{};
            Shape.checkShapeType(nums);
            TestContext.WriteLine(Shape.getResult());
        }
        [Test]
        public void checkNegativeNumbers()
        {
            var Shape = createShape();
            var nums = new double[]{-12, -12, -21};
            Shape.checkShapeType(nums);
            TestContext.WriteLine(Shape.getResult());
        }
        [Test]
        public void checkNotAllowedArgsLens()
        {
            var Shape = createShape();
            var randValue = createRandValue(notAllowedArgsLens);
            var nums = Shape.convertStringToNumbers(randValue);
            TestContext.WriteLine($"Args Count - {nums.Length}");
            Shape.checkShapeType(nums);
            TestContext.WriteLine(Shape.getResult());
        }
        [Test]
        public void checkDirtyString()
        {
            var Shape = createShape();
            var s = "   12.1   12,2      21.3    ";
            TestContext.WriteLine($"Dirty String - {s}");
            var nums = Shape.convertStringToNumbers(s);
            Shape.checkShapeType(nums);
            TestContext.WriteLine(Shape.getResult());
        }
        [Test]
        public void checkCustomString()
        {
            var Shape = createShape();
            var s = "Your String for Test Here";
            TestContext.WriteLine($"Custom String - {s}");
            var nums = Shape.convertStringToNumbers(s);
            Shape.checkShapeType(nums);
            TestContext.WriteLine(Shape.getResult());
        }
        private string createRandValue(uint n)
        {
            var randValue = "";
            for (var i = 0; i < n; i++)
            {
                var num = new Random().Next((int)minRandomValue, (int)maxRandomValue).ToString();
                randValue = string.Concat(randValue, $" {num}");
            }
            TestContext.WriteLine($"Test String: {randValue}");
            return (randValue);
        }
        private Shapes createShape()
        {
            var Shape = new Shapes(unitsName, decimalNum);
            return (Shape);
        }
    }
}