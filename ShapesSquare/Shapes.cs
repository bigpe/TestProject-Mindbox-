using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ShapesSquare
{
    public class Shapes
    {
        private const double Pi = 3.1415;
        private uint decimalNum;
        private const char postFix = '²';
        private double SQ;
        private string shapeType;
        private string unitsName;
        private string additionalParam;

        public Shapes(string unitsName, uint decimalNum = 2)
        {
            this.decimalNum = decimalNum;
            this.unitsName = unitsName;
        }
        
        static readonly Regex trimmer = new Regex(@"\s\s+");
        public double[] convertStringToNumbers(string userData)
        {
            //Check String Not Empty
            if (string.IsNullOrEmpty(userData))
                return (new double[]{});
            //Replace dots with commas so that there are no problems with parsing && Trim Spaces
            userData = trimmer.Replace(userData.Replace(',', '.').Trim(), " ");
            var numsList = new List<double>();
            //Separate numbers
            var userDataSplitted = userData.Split(' ');
            //Parse Double and Fill List
            foreach (var uD in userDataSplitted)
            {
                double num;
                //Parse Double Right Way (Avoid Problems With String)
                double.TryParse(uD, out num);
                numsList.Add(num);
            }
            //Convert List to Double Array
            var nums = numsList.ToArray();
            return (nums);
        }
        
        public void checkShapeType(double[] nums)
        {
            int numsLen = nums.Length;
            if (numsLen == 1) //Circle
                circleFindSq(nums[0]);
            if (numsLen == 3) //Triangle
                triangleFindSq(nums);
        }

        public void circleFindSq(double R)
        {
            this.shapeType = "Circle";
            double R2 = R * R;
            double SQ = Math.Round((R2 * Pi), (int)decimalNum);
            this.SQ = SQ;
        }

        public void triangleFindSq(double[] lines)
        {
            double a = lines[0];
            double b = lines[1];
            double c = lines[2];
            //Check correct Triangle
            if (checkCorrectTriangle(a, b, c))
            {
                this.shapeType = "Triangle";
                checkTriangleType(a, b, c);
                double p = (a + b + c) / 2; //Find Half Perimeter
                //Heron's formula
                double SQ = Math.Round(Math.Sqrt(p * (p - a) * (p - b) * (p - c)), (int)decimalNum);
                this.SQ = SQ;
            }
        }

        public void checkTriangleType(double a, double b, double c)
        {
            //Check Angle Type
            if (a * a + b * b > c * c)
                this.additionalParam = "Acute";
            else if (a * a + b * b < c * c)
                this.additionalParam = "Obtuse";
            else
                this.additionalParam = "Right-angled";
            //Additional Check Angles Type
            if(a == b && a == c && c == b)
                this.additionalParam = this.additionalParam + " Equilateral";
            else if(a != b && b != c && c != a)
                this.additionalParam = this.additionalParam + " Scalene";
            else if(a == b || b == c  || c == a)
                this.additionalParam = this.additionalParam + " Isosceles";
        }

        public bool checkCorrectTriangle(double a, double b, double c)
        {
            if (a + b > c && a + c > b && b + c > a)
                return (true);
            return (false);
        }

        public string getResult()
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            string result;
            if (shapeType != null) //Correct Result
            {
                result = $"Shape Type: {shapeType}\n" +
                         $"Square: {SQ}{unitsName}{postFix}\n";
                if (additionalParam != null)
                    result += $"Additional Param: {additionalParam}";
            }
            else //Incorrect Result
                result = "Shape is not Defined, please input correct data.";
            return (result);
        }
    }
}