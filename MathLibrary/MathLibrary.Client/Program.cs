using System;
using MathLibrary;

namespace CalculatorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ДЕМОНСТРАЦИЯ РАБОТЫ КАЛЬКУЛЯТОРА\n");

            #region Демонстрация арифметических операций
            Console.WriteLine(" Арифметические операции");
            double a = 15, b = 5;
            Console.WriteLine($"{a} + {b} = {Calculator.Add(a, b)}");
            Console.WriteLine($"{a} - {b} = {Calculator.Subtract(a, b)}");
            Console.WriteLine($"{a} * {b} = {Calculator.Multiply(a, b)}");
            Console.WriteLine($"{a} / {b} = {Calculator.Divide(a, b)}");

            try
            {
                Console.WriteLine("\nПопытка деления на ноль:");
                Calculator.Divide(10, 0);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"  {ex.Message}");
            }
            #endregion

            #region Демонстрация алгебраических операций
            Console.WriteLine("\n Алгебраические операции");
            Console.WriteLine($"2 в степени 8 = {Calculator.Power(2, 8)}");

            Console.WriteLine("\nФакториалы:");
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"{i}! = {Calculator.Factorial(i)}");
            }

            try
            {
                Console.WriteLine("\nПопытка вычислить факториал отрицательного числа:");
                Calculator.Factorial(-5);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"  {ex.Message}");
            }

            try
            {
                Console.WriteLine("\nПопытка вычислить факториал слишком большого числа (переполнение):");
                Calculator.Factorial(30);
            }
            catch (OverflowException)
            {
                Console.WriteLine("  Ошибка: переполнение (результат слишком велик для типа long)");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  {ex.Message}");
            }
            #endregion

            #region Демонстрация решения квадратных уравнений
            Console.WriteLine("\nРешение квадратных уравнений ");

            TestQuadratic(1, 2, 1);     
            TestQuadratic(1, 0, 1);      
            TestQuadratic(2, 4, 2);     

            try
            {
                TestQuadratic(0, 2, 3);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка при решении: {ex.Message}");
            }
            #endregion

            #region Демонстрация проверки на простоту
            Console.WriteLine("\n Проверка чисел на простоту");
            int[] testNumbers = { -5, 2, 3, 4, 17, 97, 100 };
            foreach (int num in testNumbers)
            {
                Console.WriteLine($"Число {num,3}: {(Calculator.IsPrime(num) ? "простое" : "не простое")}");
            }
            #endregion

            
        }

        static void TestQuadratic(double a, double b, double c)
        {
            var result = Calculator.SolveQuadratic(a, b, c);

            if (!result.hasRoots)
            {
                Console.WriteLine($"Уравнение {a}x^2 + {b}x + {c} = 0 не имеет действительных корней");
            }
            else if (result.root2 == null)
            {
                Console.WriteLine($"Уравнение {a}x^2 + {b}x + {c} = 0 имеет один корень: x = {result.root1}");
            }
            else
            {
                Console.WriteLine($"Уравнение {a}x^2 + {b}x + {c} = 0 имеет корни: x₁ = {result.root1:F3}, x₂ = {result.root2:F3}");
            }
        }
    }
}