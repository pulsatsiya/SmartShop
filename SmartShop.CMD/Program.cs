using SmartShop.BL.Controller;
using SmartShop.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmartShop.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Обьявление переменных.
            int num;
            string _name;
            string screen;
            string os;
            string cpu;
            int ram;
            int memory;
            string NAME;
            int answer;
            #endregion

            Console.ForegroundColor = ConsoleColor.Yellow;
            
            Console.WriteLine("Привет! Это приложение подберет вам смартфон по заданным параметрам или вы можете сами дополнить базу новыми моделями. ");
           
            Console.WriteLine("Для начала введите ваше имя:  ");
            string name = Console.ReadLine();
            Console.Clear();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Введите корректное имя");
                name = Console.ReadLine();
                Console.Clear();
            }
            Console.Clear();
            UserController user = new UserController(name);
            if (user.IsNewUser)
            {
                Console.WriteLine(name + ", раз вы новый ползователь, введите дату рождения: ");
                DateTime birthday;
                while (!DateTime.TryParse(Console.ReadLine(), out birthday))
                {
                    Console.Clear();
                    Console.WriteLine("Введите дату в формате: " + "01.01.1900");
                }
                Console.Clear();
                Console.WriteLine("Введите ваш Email для получения уведомлений о новинках (принимаем только gmail.com и mail.ru): ");

                string email = Console.ReadLine();
                Console.Clear();
                

                // Mетод reg описан в низу класса.
                while (string.IsNullOrWhiteSpace(email) || reg(email, @"^[\w-\.]+@(gmail.com|mail.ru)$", 0).Length == 0)
                {
                    Console.WriteLine("Введите корректный email");
                    email = Console.ReadLine();
                    Console.Clear();
                }
                user.SetNewUserData(birthday, email);
                Console.Clear();
            }
            user.Save();
            Console.WriteLine($"Отлично, {name}, Проверим ваши введенные данные: ");
            Console.ForegroundColor = ConsoleColor.Blue;



            Console.WriteLine(user.CurrentUser);
            Console.ResetColor();
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{name}, какие действия хотите сделать?");
                Console.WriteLine("1: Добавить новый смартфон.\n2: Посмотреть весь список смартфонов.\n3: Найти смартфон по ключевому слову.\n4: Очистить весь список смартфонов.\n5: Выйти из приложения.");



                    while (!int.TryParse(Console.ReadLine(), out num) || num < 1 || num > 5)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введите в консоль правильные цифры!");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{name}, какие действия хотите сделать?");
                    Console.WriteLine("1: Добавить новый смартфон.\n2: Посмотреть весь список смартфонов.\n3: Найти смартфон по ключевому слову.\n4: Очистить весь список смартфонов.\n5: Выйти из приложения.");
                }
                using (SmartphoneContext db = new SmartphoneContext())
                {
                    var smartphones = db.Smartphones;
                    List<Smartphone> smart = new List<Smartphone>();
                    switch (num)
                    {
                        case 1:
                            // TODO: сделать проверку, сейчас лень.
                            Console.Clear();
                            Console.WriteLine("Введите наименование модели: ");
                            _name = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("Введите тип экрана: ");
                            screen = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("Введите тип операционной системы: ");
                            os = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("Введите название процессора: ");
                            cpu = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("Введите количество оперативной памяти: ");
                            ram = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            Console.WriteLine("Введите количество встроенной памяти в смартфоне: ");
                            memory = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            
                            
                                Smartphone add = new Smartphone()
                                {
                                    Name = _name,
                                    Screen = screen,
                                    RAM = ram,
                                    Memory = memory,
                                    CPU = cpu,
                                    OS = os
                                };
                                smart.Add(add);
                                db.Smartphones.Add(add);
                                db.SaveChanges();
                            
                            Console.WriteLine("Вы успешно добавили новую модель в базу данных! Вот ваш новый смартфон: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{_name}\n{screen}\n{ram}\n{memory}\n{cpu}\n{os}");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Yellow;

                            break;
                        case 4:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Вы уверены? Введите 1 - Да или 2 - Нет");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                             while(!Int32.TryParse(Console.ReadLine(), out answer) || answer < 1 || answer > 2)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Вы уверены? Введите 1 - Да или 2 - Нет");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }
                            if (answer == 1)
                            {
                                db.Smartphones.RemoveRange(db.Smartphones);
                                db.SaveChanges();
                                Console.WriteLine("Список смартфонов полностью очищен");
                            }
                            else
                            {
                                break;
                            }
                            break;

                        case 2:
                            Console.Clear();
                            try
                            {
                                Console.WriteLine("Весь список смартфонов: ");
                                foreach (Smartphone s in smartphones)
                                {
                                    
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"{s.Name} {s.Screen} {s.RAM} {s.Memory} {s.CPU} {s.OS}");
                                    Console.ResetColor();
                                }
                            }
                            catch
                            {
                                throw new Exception("На данный момент списка не существует.");
                                
                            }
                           
                            break;
                        case 5:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("До встречи!");
                            Environment.Exit(0);
                            break;

                        case 3:
                           
                            Console.Clear();
                            Console.WriteLine("Введите ключевое слово: ");
                            NAME = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("Все модели : " + NAME + "\n");
                            foreach (Smartphone s in
                                          smartphones.Where(c => c.Name.StartsWith(NAME)|| c.Screen.StartsWith(NAME)|| c.CPU.StartsWith(NAME)|| c.OS.StartsWith(NAME)))
                            {

                                Console.WriteLine($"{s.Name} {s.Screen} {s.RAM} {s.Memory} {s.CPU} {s.OS}");
                            }
                            
                            break;
                        default:
                            break;
                       

                    }

                }

                Console.ReadLine();

            }


        }
        /// <summary>
        /// Этот метод нашел в инете, для проверки валидности email. Использую его в цикле, пока не будут введены праьные данные.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="redex"></param>
        /// <param name="_index"></param>
        /// <returns></returns>
        public static string reg(string text, string redex, int _index)
        {
            return new Regex(redex).Match(text).Groups[_index].Value;
        }
    }
    
}




