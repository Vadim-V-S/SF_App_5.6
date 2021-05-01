using System;

namespace SF_App_5._6
{
    class Program
    {
        static int CheckInput()
        {
            int num;
            while (!int.TryParse(Console.ReadLine(), out num))
                Console.WriteLine("Ошибка ввода. Введите корректное число");
            if (num <= 0) 
            { 
                Console.Write("Число должно быть больше 0:\t");
                num = CheckInput();
            }
            return num;
        }

        static string[] GetArray(string str, int num)
        {
            string[] array = new string[num];
            for (int i = 0; i < num; i++)
            {
                Console.Write("Введите {0} {1}:\t", str, i + 1);
                array[i] = Console.ReadLine();
            }
            return array;
        }

        static bool CheckYesNo() => Console.ReadLine().ToLower() == "да";

        static void ShowAnswers(string str, params string[] array)
        {
            Console.WriteLine(str); 

            int i = 0;
            if (array.Length > 0)
            {
                foreach (string color in array)
                    Console.WriteLine("{0}: {1}", ++i, color);
            }
        }

        static void Main(string[] args)
        {
            (string firstName, string lastName, int age, string[] pets, string[] colors) user;
            Console.Write("Введите свое имя:\t");
            user.firstName = Console.ReadLine();
            Console.Write("Введите фамилию:\t");
            user.lastName = Console.ReadLine();
            Console.Write("Введите свой возраст:\t");
            user.age = CheckInput();

            Console.Write("У Вас есть домашнее животное (да/нет)?:\t");
            user.pets = new string[0];
            if (CheckYesNo() == true)
            {
                Console.Write("Сколько у Вас животных:\t");
                int petsNumber = CheckInput();
                user.pets = GetArray("животное", petsNumber);
            }

            Console.Write("Сколько у Вас любимых цветов?\t");
            int colorsNmber = CheckInput();
            user.colors = GetArray("цвет", colorsNmber);

            Console.WriteLine("\nРезультат опроса:");
            ShowAnswers(string.Format($"{user.firstName} {user.lastName}"));
            ShowAnswers(string.Format($"Вам {user.age} лет"));

            if (user.pets.Length > 0) { ShowAnswers("Ваше любимое животное:\t", user.pets); }
            else { Console.WriteLine("Домашних животных у Вас нет");}

            ShowAnswers("Ваши любимые цвета:\t", user.colors);

            Console.ReadKey();
        }
    }
}
