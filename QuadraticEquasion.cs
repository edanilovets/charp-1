using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquasion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quadratic equasion solving: ax^2 + bx + c = 0");
            Console.WriteLine("Enter coefficients a,b,c (a!=0)");
            double a = CoefficientInput("a");
            double b = CoefficientInput("b");
            double c = CoefficientInput("c");
            Console.WriteLine($"The soultions of equasion:");
            double D = b * b - 4 * a * c;
            double x1 = 0;
            double x2 = 0;
            if (D > 0)
            {
                x1 = (-b + Math.Sqrt(D) / (2 * a));
                x2 = (-b - Math.Sqrt(D) / (2 * a));
            }
            if (D == 0)
            {
                x1 = x2 = -b / (2 * a);
            }
            if (D < 0)
            {
                Console.WriteLine("There are no solutions for this equasion");
            }
            Console.WriteLine($"x1={x1}");
            Console.WriteLine($"x2={x2}");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static double CoefficientInput(string coefName)
        {
            double input = 0;
            bool flag = false;
            while (!flag) {
                Console.Write(coefName + "=");
                string strInput = Console.ReadLine();
                if (Double.TryParse(strInput, out input))
                {
                    if ((coefName.Equals("a")) && (input == 0))
                    {
                        Console.WriteLine("Coefficient a can't = 0...");
                    } else flag = true;
                }
                else
                {
                    Console.WriteLine("Invalid argument. Enter a number...");
                }
            }
            return input;
        }
    }
}
