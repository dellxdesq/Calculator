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

            }
        }
        public static void Menu()
        {
            Console.WriteLine("Выберите функцию калькулятора, указав цифру");
            Console.WriteLine("1 - Перевод чисел из одной системы счисления в любую другую (от 1 до 50)");
            Console.WriteLine("2 - Перевод чисел в римские (числа от 1 до 5000)");
            Console.WriteLine("3 - Перевод римских чисел в арабские");
            Console.WriteLine("4 - Сложение в любой системе счисления");
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
                for (int i = 0; i < number.Length; i++)
                {
                    char s = chars[i];
                    result += int.Parse(s.ToString());
                }
            }

            int num;
            for (int i = 0; i < digitsCount; i++)
            {

                char symbol = number[i];
                if (symbol >= '0' && symbol <= '9') num = symbol - '0';
                else if (symbol >= 'A' && symbol <= 'Z') num = symbol - 'A' + 10;
                else if (symbol >= 'a' && symbol <= 'z') num = symbol - 'a' + (('Z' - 'A') + 1) + 10;
                else throw new ArgumentException("wrong number");
                if (num >= baze) throw new ArgumentException(" ");
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
                Console.Write("Введите римское число: ");
                string input = Console.ReadLine();
                int[] nums = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
                string[] rim = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };

                for (int i = 0; i < input.Length; i++)
                {
                    bool isTrue = false;
                    for (int a = 0; a < rim.Length; a++)
                    {
                        if (input[i].ToString() == rim[a])
                        {
                            isTrue = true;
                            break;
                        }
                    }
                }

                int result = 0;
                var RimtoNum = new Dictionary<char, int>
                {{ 'I', 1 },{ 'V', 5 },{ 'X', 10 },{ 'L', 50 },{ 'C', 100 },{ 'D', 500 },{ 'M', 1000 } };
                for (short i = 0; i < input.Length - 1; ++i)
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
        public static void function4()
        {

        }

    }

}
