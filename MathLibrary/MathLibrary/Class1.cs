using System;

namespace MathLibrary
{
    /// <summary>
    /// Класс, предоставляющий математические операции
    /// </summary>
    public class Calculator
    {
        #region Базовые арифметические операции

        /// <summary>
        /// Сложение двух чисел
        /// </summary>
        public static double Add(double number1, double number2)
        {
            return number1 + number2;
        }

        /// <summary>
        /// Вычитание второго числа из первого
        /// </summary>
        public static double Subtract(double number1, double number2)
        {
            return number1 - number2;
        }

        /// <summary>
        /// Умножение двух чисел
        /// </summary>
        public static double Multiply(double number1, double number2)
        {
            return number1 * number2;
        }

        /// <summary>
        /// Деление первого числа на второе
        /// </summary>
        /// <exception cref="DivideByZeroException">Выбрасывается при попытке деления на ноль</exception>
        public static double Divide(double dividend, double divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException("Ошибка: деление на ноль запрещено.");
            }
            return dividend / divisor;
        }

        #endregion

        #region Алгебраические операции

        /// <summary>
        /// Возведение числа в степень
        /// </summary>
        public static double Power(double baseNumber, double exponent)
        {
            return Math.Pow(baseNumber, exponent);
        }

        /// <summary>
        /// Вычисление факториала неотрицательного целого числа
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается при отрицательном аргументе</exception>
        /// <exception cref="OverflowException">Выбрасывается при переполнении (результат слишком велик)</exception>
        public static long Factorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"Ошибка: факториал отрицательного числа ({number}) не определен.");
            }

            if (number == 0 || number == 1)
            {
                return 1;
            }

            long result = 1;
            for (int i = 2; i <= number; i++)
            {
                checked 
                {
                    result *= i;
                }
            }
            return result;
        }

        /// <summary>
        /// Решение квадратного уравнения ax² + bx + c = 0
        /// </summary>
        /// <returns>Кортеж: (hasRoots, root1, root2)</returns>
        public static (bool hasRoots, double? root1, double? root2) SolveQuadratic(double a, double b, double c)
        {
            
            if (Math.Abs(a) < 1e-10)
            {
                throw new ArgumentException("Коэффициент 'a' не может быть равен нулю в квадратном уравнении.");
            }

            double discriminant = b * b - 4 * a * c;
            double? root1 = null;
            double? root2 = null;
            bool hasRoots = false;

            if (discriminant < 0)
            {
                hasRoots = false;
            }
            else if (Math.Abs(discriminant) < 1e-10) 
            {
                hasRoots = true;
                root1 = -b / (2 * a);
            }
            else
            {
                hasRoots = true;
                root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            }

            return (hasRoots, root1, root2);
        }

        #endregion

        #region Теория чисел

        /// <summary>
        /// Проверка, является ли число простым (оптимизированная версия)
        /// </summary>
        public static bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }

            if (number == 2)
            {
                return true;
            }

            if (number % 2 == 0)
            {
                return false;
            }

            
            int boundary = (int)Math.Floor(Math.Sqrt(number));
            for (int divisor = 3; divisor <= boundary; divisor += 2)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}