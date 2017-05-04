using CodersCat.Presentation;
using System;
using System.Threading;

namespace CodersCat.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var ui = new UI();
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Добро пожаловать в магазин питомцев!");
            Console.WriteLine("К сожалению (или к счастью), в наличии остались только кошки...");
            int age = 0;
            while (age <= 0)
            {
                Console.Write("Введите возраст кошки: ");
                int.TryParse(Console.ReadLine(), out age);
                Console.WriteLine(ui.BuyCat(age));
            }
            Console.WriteLine("Нажмите Ввод для общения с питомцем: ");
            var t = ConsoleKey.C;
            while(t!= ConsoleKey.D0){
                Console.WriteLine(ui.GetCatInfo());
                DrawMenu();
                Console.Write("Нажмите клавишу для выбора пункта: ");
                t = Console.ReadKey().Key;
                Console.WriteLine();
                switch (t)
                {
                    case ConsoleKey.D1:
                        Console.Write("Введите новое имя кошки: ");
                        var name = Console.ReadLine();
                        Console.WriteLine(ui.ChangeCatName(name));
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Кошка благодарна за еду! Мяу!");
                        ui.FeedCat();
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Кошка огорчена, и шипит...");
                        Console.WriteLine(ui.PunishCat());
                        break;
                    default:
                        Console.WriteLine("Такого пункта в меню нет.");
                        break;
                }
                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        private static void DrawMenu()
        {
            string menu = "1. Дать кошке имя"+Environment.NewLine+
                          "2. Покормить кошку"+ Environment.NewLine+
                          "3. Наказать кошку"+Environment.NewLine+
                          "0. Выход";
            Console.WriteLine(menu);
        }
    }
}