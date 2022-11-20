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
            int digitsCount = number.Length;

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
            for (int i = 0; i < digitsCount; i++)
            {

                char symbol = number[i];
                if (symbol >= '0' && symbol <= '9') num = symbol - '0';
                else if (symbol >= 'A' && symbol <= 'Z') num = symbol - 'A' + 10;
                else if (symbol >= 'a' && symbol <= 'z') num = symbol - 'a' + (('Z' - 'A') + 1) + 10;
                else
                    throw new ArgumentException("Число некорректно");
                output *= baze;
                output += num;
            }
            return output;
        }

        public static string FromDecToAny(int number, int baze)
        {

            if (baze > 50)
                throw new ArgumentException("Основание неверно, должно быть от 1 до 50");
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
        }
    }
    public static class F2
    {

        public static void function2()
        {
            int[] nums = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
            string[] rim = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };

            Console.Write("Введите число от 1 до 5000: ");
            string input = Console.ReadLine();
            int number;
            if (!int.TryParse(input, out number) || !(number >= 1 && number <= 5000))
                if (number > 5000)
                    throw new ArgumentException("Число должно быть до 5000 включительно!");
            int s = 0;
            string output = "";
            while (number > 0)
            {
                if (nums[s] <= number)
                {
                    number = number - nums[s];
                    output = output + rim[s];
                }
                else s++;

            }
            Console.WriteLine("Ответ: " + output);
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
                string[] rim = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };

                for (int i = 0; i < input.Length; i++)
                {
                    bool isTrue = false;
                    int a = 0;
                    while (a < rim.Length)
                    {
                        if (input[i].ToString() == rim[a])
                        {
                            isTrue = true;
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
                        result -= RimtoNum[input[i]];
                    }
                    else if (RimtoNum[input[i]] >= RimtoNum[input[i + 1]])
                    {
                        result += RimtoNum[input[i]];
                    }
                }
                result += RimtoNum[input[^1]];
                

                Console.WriteLine("Ответ: " + result);
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
            int newDigit = 1;
            for (int i = 0; i < number1.Length; i++)
            {
                arr1[i] = ConvertToNumber(number1[i], baze);
            }

            for (int i = 0; i < number2.Length; i++)
            {
                arr2[i] = ConvertToNumber(number2[i], baze);
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

            for (int i = 0; i < arr3.Length; i++)
            {
                result[i] = ConvertToSymbol(arr3[i]);
            }

            if (!isTrue)
            {
                Console.WriteLine("Ответ: " + newDigit.ToString() + new string(result));
                return newDigit.ToString() + new string(result);
            }
            else
            {
                Console.WriteLine("Ответ: " + new string(result));
                return new string(result);
            }
        }

        static int ConvertToNumber(char num, int baze)
        {
            int n = (int)num;
            if (n >= 48 && n <= 57) n = n - '0';
            if (n >= 65 && n <= 90) n = n - 'A' + 10;
            if (n >= 97 && n <= 122) n = n - 'a' + 36;
            if (n >= baze) throw new Exception("Число некорректно!");
            return n;
        }
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
    }
    public static class F5
    {
        public static string alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public static void function5()
        {

            Console.Write("Введите первое число: ");
            string number1 = Console.ReadLine();
            Console.Write("Введите второе число: ");
            string number2 = Console.ReadLine();
            Console.Write("Введите систему счисления в которой будет происходить вычитание (от 1 до 50): ");
            int baze = int.Parse(Console.ReadLine());

            List<char> charList1 = number1.ToCharArray().ToList();
            List<char> charList2 = number2.ToCharArray().ToList();

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
        }
    }

}
