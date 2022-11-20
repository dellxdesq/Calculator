using Microsoft.VisualBasic;
using System;
using System.Text;

namespace InformatikaLab
{
    public static class Program
    {
        public static void Main()
        {
            Menu();
            ConsoleKey choose = Console.ReadKey().Key;
            switch (choose)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    F1.function1();
                    break;

                case ConsoleKey.D2:
                    Console.Clear();
                    F2.function2();
                    break;

                case ConsoleKey.D3:
                    Console.Clear();
                    F3.function3();
                    break;

                case ConsoleKey.D4:
                    Console.Clear();
                    F4.function4();
                    break;

                case ConsoleKey.D5:
                    Console.Clear();
                    F5.function5();
                    break;
            }
        }

        public static void Menu()
        {
            Console.WriteLine("Выберите функцию калькулятора, указав цифру");
            Console.WriteLine("1 - Перевод чисел из одной системы счисления в любую другую (от 1 до 50)");
            Console.WriteLine("2 - Перевод чисел в римские (числа от 1 до 5000)");
            Console.WriteLine("3 - Перевод римских чисел в арабские");
            Console.WriteLine("4 - Сложение в любой системе счисления");
            Console.WriteLine("5 - Вычитание в любой системе счисления");
        }
    }

    public static class F1
    {
        public static char ConvertToSymbol(int mod)
        {
            if (mod >= 0 && mod <= 9)
                return (char)('0' + mod);
            if (mod >= 10 && mod <= 36)
                return (char)('A' + mod - 10);
            if (mod >= 37 && mod <= 62)
                return (char)('a' + mod - 36);
            throw new ArgumentException("123");
        }

        public static int FromAnyToDec(string number, int baze)
        {
            if (baze > 50)
                throw new ArgumentException("Основание должно быть от 1 до 50");
            int output = 0;
            int numCount = number.Length;

            if (baze == 1)
            {
                int result = 0;
                char[] chars = number.ToCharArray();
                int i = 0;
                while (i < number.Length)
                {
                    char s = chars[i];
                    result += int.Parse(s.ToString());
                    i++;
                }
            }

            int num;
            for (int i = 0; i < numCount; i++)
            {

                char symbol = number[i];
                if 
                    (symbol >= '0' && symbol <= '9') num = symbol - '0';
                else if 
                    (symbol >= 'A' && symbol <= 'Z') num = symbol - 'A' + 10;
                else if 
                    (symbol >= 'a' && symbol <= 'z') num = symbol - 'a' + (('Z' - 'A') + 1) + 10;
                else
                    throw new ArgumentException("Число некорректно");
                output *= baze;
                output += num;
            }
            return output;
        }

        public static string FromDecToAny(int number, int baze)
        {

            StringBuilder builder = new StringBuilder();

            do
            {
                int mod = number % baze;
                char symbol = ConvertToSymbol(mod);
                builder.Append(symbol);
                number /= baze;

            } while (number >= baze);

            if (number != 0)
            {
                builder.Append(ConvertToSymbol(number));
            }

            string result = string.Join("", builder.ToString().Reverse()); return result;
        }

        public static void function1()
        {
            Console.Write("Введите число: ");
            string number = Console.ReadLine();
            Console.Write("Введите систему счисления этого числа: ");
            int numBaze = int.Parse(Console.ReadLine());
            Console.Write("Введите систему счисления, в которую нужно перевести число: ");
            int toBaze = int.Parse(Console.ReadLine());
            int toDec = FromAnyToDec(number, numBaze);
            Console.WriteLine("Ответ: " + FromDecToAny(toDec, toBaze));
            Console.ReadKey();
        }
    }

    public static class F2
    {     
        public static string ToRom(int number)
        {
            int[] nums = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] rom = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            StringBuilder result = new StringBuilder();
            int i = 0;
            while(i < nums.Length && number != 0)
            {
                while (number >= nums[i])
                {
                    number -= nums[i];
                    result.Append(rom[i]);
                }
            i++;
            }
            return result.ToString();
        }

        public static void function2()
        {
            
            Console.Write("Введите число: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                Console.Write("Ответ: " + ToRom(number) + "\n");
                Console.ReadKey();
            }                    
        }
    }
    public static class F3
    {
        public static void function3()
        {
            {
                string input = ""; 
                Console.Write("Введите римское число: ");
                input = Console.ReadLine();
                int[] nums = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
                string[] rom = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };

                for (int i = 0; i < input.Length; i++)
                {
                    int a = 0;
                    while (a < rom.Length)
                    {
                        if (input[i].ToString() == rom[a])
                        {
                            break;
                        }
                        a++;
                    }
                }

                int result = 0;
                var RimtoNum = new Dictionary<char, int>
                {{ 'I', 1 },{ 'V', 5 },{ 'X', 10 },{ 'L', 50 },{ 'C', 100 },{ 'D', 500 },{ 'M', 1000 } };
                for (int i = 0; i < input.Length - 1; ++i)
                {
                    if (RimtoNum[input[i]] < RimtoNum[input[i + 1]])
                    {
                        Console.WriteLine("Число слева - " + RimtoNum[input[i]] + " меньше, чем число справа - " + RimtoNum[input[i + 1]] + ", поэтому левое число вычитается из правого");
                        result -= RimtoNum[input[i]];
                    }
                        
                    else if (RimtoNum[input[i]] >= RimtoNum[input[i + 1]])
                    {
                        Console.WriteLine("Число справа - " + RimtoNum[input[i + 1]] + " меньше, чем число слева - " +  RimtoNum[input[i]] + ", поэтому цифры складываются");
                        result += RimtoNum[input[i]];
                    }
                }
                result += RimtoNum[input[^1]];
                Console.WriteLine("Ответ: " + result);
                Console.ReadKey();
            }

        }
    }

    public static class F4
    {
        public static string function4()
        {
            Console.Write("Введите первое число: ");
            string number1 = Console.ReadLine();
            Console.Write("Введите второе число: ");
            string number2 = Console.ReadLine();
            Console.Write("Введите систему счисления в которой будет происходить сложение (от 1 до 50): ");

            int baze = int.Parse(Console.ReadLine());
            int[] arr1 = new int[number1.Length];
            int[] arr2 = new int[number2.Length];
            int[] arr3 = new int[Math.Max(arr1.Length, arr2.Length)];
            char[] result = new char[Math.Max(arr1.Length, arr2.Length)];
            bool isTrue = true;
            int newNum = 1;
            int a = 0;
            while (a < number1.Length)
            {
                arr1[a] = ConvertToNumber(number1[a], baze);
                a++;
            }

            int s = 0;
            while (s < number2.Length)
            {
                arr2[s] = ConvertToNumber(number2[s], baze);
                s++;
            }

            for (int i = 0; i < Math.Max(arr1.Length, arr2.Length); i++)
            {
                if (arr1.Length - 1 - i >= 0 && arr2.Length - 1 - i >= 0)
                {
                    arr3[arr3.Length - 1 - i] = arr3[arr3.Length - 1 - i] + arr1[arr1.Length - 1 - i] + arr2[arr2.Length - 1 - i];
                }
                if (arr1.Length - 1 - i < 0)
                {
                    arr3[arr3.Length - 1 - i] += arr2[arr2.Length - 1 - i];
                }
                if (arr2.Length - 1 - i < 0)
                {
                    arr3[arr3.Length - 1 - i] += arr1[arr1.Length - 1 - i];
                }
                if (arr3[arr3.Length - 1 - i] >= baze)
                {
                    arr3[arr3.Length - 1 - i] -= baze;
                    if (arr3.Length - i - 2 >= 0) arr3[arr3.Length - i - 2]++;
                    else isTrue = false;
                }

            }

            int m = 0;
            while (m < arr3.Length)
            {
                result[m] = ConvertToSymbol(arr3[m]);
                m++;
            }

            if (!isTrue)
            {
                Console.WriteLine("Ответ: " + newNum.ToString() + new string(result));
                Console.ReadKey();
                return newNum.ToString() + new string(result);
            }

            else
            {
                Console.WriteLine("Ответ: " + new string(result));
                Console.ReadKey();
                return new string(result);
            }
        }

        static int ConvertToNumber(char num, int baze)
        {
            int i = (int)num;
            if (i >= 48 && i <= 57) i = i - '0';
            if (i >= 65 && i <= 90) i = i - 'A' + 10;
            if (i >= 97 && i <= 122) i = i - 'a' + 36;
            if (i >= baze) 
                throw new Exception("Число некорректно!");
            return i;
        }
        public static char ConvertToSymbol(int mod)
        {
            if (mod >= 0 && mod <= 9)
                return (char)('0' + mod);
            if (mod >= 10 && mod <= 36)
                return (char)('A' + mod - 10);
            if (mod >= 37 && mod <= 62)
                return (char)('a' + mod - 36);
            throw new ArgumentException(" ");
        }
    }
    public static class F5
    {
        public static string alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public static void function5()
        {
            Console.Write("Введите первое число: ");
            string num1 = Console.ReadLine();
            Console.Write("Введите второе число: ");
            string num2 = Console.ReadLine();
            Console.Write("Введите систему счисления в которой будет происходить вычитание (от 1 до 50): ");
            int baze = int.Parse(Console.ReadLine());

            List<char> charList1 = num1.ToCharArray().ToList();
            List<char> charList2 = num2.ToCharArray().ToList();

            List<int> numberList1 = charList1.Select(c => (int)alphabet.IndexOf(c)).ToList();
            List<int> numberList2 = charList2.Select(c => (int)alphabet.IndexOf(c)).ToList();
            int j;

            for (int i = numberList1.Count - 1; i >= 0; i--)
            {
                j = i - (numberList1.Count - numberList2.Count);

                if (j >= 0)
                {
                    numberList1[i] -= numberList2[j];
                }

                while (numberList1[i] < 0)
                {
                    numberList1[i] += baze;
                    numberList1[i - 1]--;
                }
            }

            StringBuilder result = new StringBuilder();
            int s = 0;
            while (s < numberList1.Count)
            {
                result.Append(alphabet[numberList1[s]]);
                s++;
            }
            Console.WriteLine("Ответ: " + result.ToString().TrimStart('0'));
            Console.ReadKey();
        }
    }
}
