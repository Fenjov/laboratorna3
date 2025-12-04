using System;
using System.Text;
namespace electronics_store {
    struct Product
    {
        public string Name { get; set; } = "";
        public int Price { get; set; } = 0;
        public int quantity;
        public string category { get; set; }
        public Product(string name, int price, int quantity, string category)
        {
            this.Name = name;
            this.Price = price;
            this.quantity = quantity;
            this.category = category;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Назва: {Name}, Ціна: {Price}, Кількість: {quantity}, Категорія: {category}");
        }
        public bool IsEmpty()
        {
            return String.IsNullOrWhiteSpace(Name);
        }
    }


        internal class Program
    {
        private static Product p1 = new Product();
        private static Product p2 = new Product();
        private static Product p3 = new Product();
        private static Product p4 = new Product();
        private static Product p5 = new Product();

        
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Login();
            MainMenu();
        }
        static void Login()
        {
            string correctUsername = "Ivan";
            string correctPassword = "9909";
            int sprob = 0;
            int maxSprob = 3;
            do
            {
                Console.Write("Введіть ваш логін: ");
                string inputName = Console.ReadLine();
                Console.Write("Введіть ваш пароль: ");
                string inputPassword = Console.ReadLine();
                if (inputName == correctUsername && inputPassword == correctPassword)
                {
                    Console.WriteLine("Вхід успішний! Ласкаво просимо до автосалону AUDI.");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    sprob++;
                    Console.WriteLine($"Невірний логін або пароль. Спроба {sprob} з {maxSprob}.");
                    Console.ResetColor();
                }
            } while (sprob < maxSprob);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Перевищено максимальну кількість спроб. Вихід з програми.");
            Exit();
            Console.ResetColor();
        }
        static double GetUserInput(string text = "")
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(text);
                double choice = double.Parse(Console.ReadLine());
                Console.ResetColor();
                return choice;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Невірний формат вводу. Будь ласка, введіть число.");
                Console.ResetColor();
                return GetUserInput(text);
            }
        }

        public static void AskForProduct()
        {
            while (true)
            {
                Console.Write("Введіть назву моделі яку ви хочете добавити: ");
                string name = Console.ReadLine();

                double price = GetUserInput("Введіть ціну продукта");

                if (p1.IsEmpty())
                {
                    p1 = new Product(name, (int)price, 1, "Машина");

                }
                else if (p2.IsEmpty())
                {
                    p2 = new Product(name, (int)price, 1, "Машина");

                }
                else if (p3.IsEmpty())
                {
                    p3 = new Product(name, (int)price, 1, "Машина");
                }


                else if (p4.IsEmpty())
                {
                    p4 = new Product(name, (int)price, 1, "Машина");

                }
                else if (p5.IsEmpty())
                {
                    p5 = new Product(name, (int)price, 1, "Машина");

                }
                else
                {
                    Console.WriteLine("Немає місця для продуктів");
                    break;
                }

                    Console.WriteLine("================================");
                    Console.WriteLine("Чи хочете додати ще один продукт 1 - Yes, 0 - No");
                    int choice = (int)GetUserInput();

                    if (choice == 1)
                    {
                        AskForProduct();
                        break;
                    }
                    else if (choice == 0)
                    {

                        Console.WriteLine("Ваші продукти:");

                        if (!p1.IsEmpty()) p1.ShowInfo();
                        if (!p2.IsEmpty()) p2.ShowInfo();
                        if (!p3.IsEmpty()) p3.ShowInfo();
                        if (!p4.IsEmpty()) p4.ShowInfo();
                        if (!p5.IsEmpty()) p5.ShowInfo();
                        Console.WriteLine("Натисніть будь-яку кнопку, щоб продовжити");
                        Console.ReadKey();
                        break;
                    }
                }
            }

            static void MainMenu()
            {
                bool exit = true;
                while (exit)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("-- АВТОСАЛОН Audi --");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("ГОЛОВНЕ МЕНЮ:");
                    Console.WriteLine("1. Додати товар");
                    Console.WriteLine("2. Оформити замовлення");
                    Console.WriteLine("3. Статистика");
                    Console.WriteLine("4. (Додатково) Сервіс");
                    Console.WriteLine("5. Скидки");
                    Console.WriteLine("6. Вихід з програми");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Будь ласка, введіть вибір (1-6):");

                    double choice = GetUserInput("Введіть число від 1-6 ");
                    switch (choice)
                    {
                        case 1:
                            AskForProduct();
                            Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
                            Console.ReadKey();
                            MainMenu();
                            break;
                        case 2:
                            SellMeneger();
                            Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
                            Console.ReadKey();
                            MainMenu();
                            break;
                        case 3:
                            Statistic();
                            MainMenu(); break;
                        case 4:
                            Servis();
                            MainMenu(); break;
                        case 5:
                            ShowdDiscounts();
                            MainMenu(); break;
                        case 6:
                            exit = false;
                            Exit(); break;
                        default:
                            Console.WriteLine("Невірний вибір. Будь ласка, спробуйте ще раз.");
                            MainMenu();
                            break;
                    }
                }
            }
            static void ShowProducts()
            {
            
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Загальна кількість продуктів: {GetProductsCount()}");
                Console.WriteLine("========= Наші товари =========");

                if (!p1.IsEmpty()) p1.ShowInfo();
                if (!p2.IsEmpty()) p2.ShowInfo();
                if (!p3.IsEmpty()) p3.ShowInfo();
                if (!p4.IsEmpty()) p4.ShowInfo();
                if (!p5.IsEmpty()) p5.ShowInfo();

                if (p1.IsEmpty() && p2.IsEmpty() && p3.IsEmpty() && p4.IsEmpty() && p5.IsEmpty())
                {
                    Console.WriteLine("Список товарів порожній.");
                }
                Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися...");
                Console.ReadKey();
                Console.ResetColor();
            }
            static int GetProductsCount()
            {
                int count = 0;
                if (!p1.IsEmpty()) count++;
                if (!p2.IsEmpty()) count++;
                if (!p3.IsEmpty()) count++;
                if (!p4.IsEmpty()) count++;
                if (!p5.IsEmpty()) count++;
                return count;
            }
            static void Statistic()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("========= Статистика =========");
                Console.WriteLine("1. Подивитися продукти");
                Console.WriteLine("2. Фінансовий звіт");
                Console.WriteLine("3. Повернутись до головного меню");
                Console.WriteLine("================================");
                double choice = GetUserInput("Введіть число від 1-3: ");
                switch (choice)
                {
                    case 1:
                     
                        ShowProducts();
                        break;
                    case 2:
                        Financial();
                        break;
                    case 3:
                        MainMenu();
                        return;
                    default:
                        Console.WriteLine("Невірний вибір. Будь ласка, спробуйте ще раз.");
                        return;
                }
                Console.ResetColor();
            }
            static void Financial()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("========= Фінансовий звіт =========");

                int count = GetProductsCount();
                if (count == 0)
                {
                    Console.WriteLine("Дані відсутні.");
                    return;
                }

                Console.Clear();
                int totalSum = 0;
                int totalQuantity = 0;
                double maxPrice = double.MinValue;
                double minPrice = double.MaxValue;
                int expensiveItemsCount = 0;

                if (!p1.IsEmpty())
                {
                    totalSum += p1.Price;
                    totalQuantity++;
                    if (p1.Price > maxPrice) maxPrice = p1.Price;
                    if (p1.Price < minPrice) minPrice = p1.Price;
                    if (p1.Price > 500) expensiveItemsCount++;
                }
                if (!p2.IsEmpty())
                {
                    totalSum += p2.Price;
                    totalQuantity++;
                    if (p2.Price > maxPrice) maxPrice = p2.Price;
                    if (p2.Price < minPrice) minPrice = p2.Price;
                    if (p2.Price > 500) expensiveItemsCount++;
                }
                if (!p3.IsEmpty())
                {
                    totalSum += p3.Price;
                    totalQuantity++;
                    if (p3.Price > maxPrice) maxPrice = p3.Price;
                    if (p3.Price < minPrice) minPrice = p3.Price;
                    if (p3.Price > 500) expensiveItemsCount++;
                }
                if (!p4.IsEmpty())
                {
                    totalSum += p4.Price;
                    totalQuantity++;
                    if (p4.Price > maxPrice) maxPrice = p4.Price;
                    if (p4.Price < minPrice) minPrice = p4.Price;
                    if (p4.Price > 500) expensiveItemsCount++;
                }
                if (!p5.IsEmpty())
                {
                    totalSum += p5.Price;
                    totalQuantity++;
                    if (p5.Price > maxPrice) maxPrice = p5.Price;
                    if (p5.Price < minPrice) minPrice = p5.Price;
                    if (p5.Price > 500) expensiveItemsCount++;
                }

                double averagePrice = (double)totalSum / totalQuantity;

                Console.WriteLine($"Загальна вартість складу: {totalSum}$");
                Console.WriteLine($"Загальна кількість товарів: {totalQuantity}");
                Console.WriteLine($"Середня ціна товару: {averagePrice:F2}$");
                Console.WriteLine($"Найдорожчий товар: {maxPrice}$");
                Console.WriteLine($"Найдешевший товар: {minPrice}$");
                Console.WriteLine($"Кількість дорогих товарів (>500$): {expensiveItemsCount}");

                Console.ResetColor();
                Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутись...");
                Console.ReadKey();
            }
            static void ShowdDiscounts()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("====================================");
                Console.WriteLine("==========АКЦІЇ ТА ЗНИЖКИ===========");
                Console.WriteLine("====================================");
                Console.WriteLine("1.Знижка - 10 % на заміну масла");
                Console.WriteLine("2.Купи версію RS — отримай комплект шин у подарунок");
                Console.WriteLine("3.Акція Чорна П’ятниця — до - 30");
                Console.WriteLine("4.Розпродаж лед ламп");
                Console.WriteLine("5.Назад до головного меню");
                Console.WriteLine("====================================");
                Console.ResetColor();
                double choice = GetUserInput("Введіть число від 1-5: ");

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Функція в розробці...");
                        Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Функція в розробці...");
                        Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Функція в розробці...");
                        Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Функція в розробці...");
                        Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися до головного меню.");
                        Console.ReadKey();
                        break;
                    case 5:
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Будь ласка, спробуйте ще раз.");
                        return;
                }
            }
            static void Servis()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("---------СЕРВІС---------");
                Console.WriteLine("Телефон: +380 66 593 65 80");
                Console.WriteLine("Електронна пошта: c.fenov.ivan@student.uzhnu.edu.ua");
                Console.WriteLine("---------------------------");
                Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутись...");
                Console.ReadKey();
                MainMenu();
                Console.ResetColor();
                Console.Clear();
            }
            static void Exit()
            {
                Console.WriteLine("Вихід з програми. До побачення!");
                Console.ReadKey();
                Environment.Exit(1);
            }

            static void SellMeneger()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("-Автосалон AUDI-");
                Console.ForegroundColor = ConsoleColor.White;
                int s5 = 45000;
                int s6 = 60000;
                int s7 = 70000;
                int Q5 = 75000;
                int Q8 = 90000;

                Console.WriteLine("Audi S5 - 45000$");
                Console.WriteLine("Audi S6 - 60000$");
                Console.WriteLine("Audi S7 - 70000$");
                Console.WriteLine("Audi Q5 - 75000$");
                Console.WriteLine("Audi Q8 - 90000$");

                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write("Введіть кількість Audi S5:");
                int numberS5 = int.Parse(Console.ReadLine());
                Console.Write("Введіть кількість Audi S6:");
                int numberS6 = int.Parse(Console.ReadLine());
                Console.Write("Введіть кількість Audi S7:");
                int numberS7 = int.Parse(Console.ReadLine());
                Console.Write("Введіть кількість Audi Q5:");
                int numberQ5 = int.Parse(Console.ReadLine());
                Console.Write("Введіть кількість Audi Q8:");
                int numberQ8 = int.Parse(Console.ReadLine());

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                int all = s5 * numberS5 + s6 * numberS6 + s7 * numberS7 + Q5 * numberQ5 + Q8 * numberQ8;
                Console.WriteLine("Загальеа сумма: " + all + "$");

                int skidka;
                if (all >= 10000)
                {
                    skidka = 20;
                }
                else if (all >= 6000)
                {
                    skidka = 15;
                }
                else if (all >= 3000)
                {
                    skidka = 10;
                }
                else
                {
                    skidka = 0;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nВаша знижка: {skidka}%");
                Console.ResetColor();
                double discountAmount = all * (skidka / 100.0);

                double finalPrice = all - discountAmount;
                finalPrice = Math.Round(finalPrice, 2);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nЦіна зі знижкою: {finalPrice} $");
                Console.ResetColor();

                double korin = Math.Sqrt(all);
                Console.WriteLine($"Квадратний корінь з {all}$ = {korin}");

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-Кількість покупок-");
                Console.WriteLine("Загальна кількість Audi S5:" + numberS5);
                Console.WriteLine("Загальна кількість Audi S6:" + numberS6);
                Console.WriteLine("Загальна кількість Audi S7:" + numberS7);
                Console.WriteLine("Загальна кількість Audi Q5:" + numberQ5);
                Console.WriteLine("Загальна кількість Audi Q8:" + numberQ8);

                Console.ForegroundColor = ConsoleColor.DarkGray;

            }
        }
    }
