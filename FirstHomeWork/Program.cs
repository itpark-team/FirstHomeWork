using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace FirstHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneNumbersManager phmanager = new PhoneNumbersManager();
            int action;

            /*PhoneNumber Pnum1 = new PhoneNumber("99999", "Катя", "Шлюха", PhoneNumber.GradeList.important);
            PhoneNumber Pnum2 = new PhoneNumber("88888", "Анжелла", "Шлюха но получше", PhoneNumber.GradeList.friend);

            phmanager.AddPhoneNumber(Pnum1);
            phmanager.AddPhoneNumber(Pnum2);*/

            while (true)
            {
                Console.Clear();
                phmanager.PrintPhoneNumbers();

                Console.WriteLine("Меню контактов");
                Console.WriteLine("1. Добавить контакт");
                Console.WriteLine("2. Удалить контакт");
                Console.WriteLine("3. Изменить контакт");
                Console.WriteLine("4. Сохранить контакты в txt файл");
                Console.WriteLine("5. Загрузить контакты из txt файла");
                Console.WriteLine("6. Сохранить контакты в bin файл");
                Console.WriteLine("7. Загрузить контакты из bin файла");
                Console.WriteLine("8. Выбрать контакты по типу важности");
                Console.WriteLine("0. Выход");
                Console.Write("Введите действие: ");
                action = int.Parse(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        {
                            Console.Write("Введите номер телефона: ");
                            string number = Console.ReadLine();
                            Console.Write("Введите имя контакта: ");
                            string name = Console.ReadLine();
                            Console.Write("Введите информацию о контакте: ");
                            string info = Console.ReadLine(); 
                            Console.Write("Важность контакта/кем является контакт\n0 - коллега,\n1 - друг,\n2 - родственник,\n3 - важный контакт: ");
                            PhoneNumber.GradeList grade = (PhoneNumber.GradeList)int.Parse(Console.ReadLine());

                            PhoneNumber pnum = new PhoneNumber(number, name, info, grade);

                            phmanager.AddPhoneNumber(pnum);
                        }
                        break;
                    case 2:
                        {
                            try
                            {
                                Console.Write("Введите индекс контакта : ");
                                int index = int.Parse(Console.ReadLine());

                                Console.WriteLine(phmanager.DeletePhoneNumber(index - 1));
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }

                        }
                        break;
                    case 3:
                        {
                            try
                            {
                                Console.Write("Введите индекс контакта : ");
                                int index = int.Parse(Console.ReadLine());

                                Console.Write("Введите номер телефона: ");
                                string number = Console.ReadLine();
                                Console.Write("Введите имя контакта: ");
                                string name = Console.ReadLine();
                                Console.Write("Введите информацию о контакте: ");
                                string info = Console.ReadLine();
                                Console.Write("Важность контакта/кем является контакт\n0 - коллега,\n1 - друг,\n2 - родственник,\n3 - важный контакт: ");
                                PhoneNumber.GradeList grade = (PhoneNumber.GradeList)int.Parse(Console.ReadLine());

                                PhoneNumber pnum = new PhoneNumber(number, name, info, grade);

                                phmanager.ReplacePhoneNumber(index - 1, pnum);

                                Console.WriteLine("Замена выполнена");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }

                        }
                        break;
                    case 4:
                        {
                            phmanager.SavePhoneNumbersTxtToFile();
                            Console.WriteLine("успешно сохранено");

                        }
                        break;
                    case 5:
                        {
                            phmanager.LoadPhoneNumbersFromTxtFile();
                            Console.WriteLine("успешно загружено");
                        }
                        break;

                    case 6:
                        {
                            phmanager.SavePhoneNumbersBinToFile();
                            Console.WriteLine("успешно сохранено");

                        }
                        break;
                    case 7:
                        {
                            phmanager.LoadPhoneNumbersFromBinFile();
                            Console.WriteLine("успешно загружено");
                        }
                        break;

                    case 0:
                        {
                            Environment.Exit(0);
                        }
                        break;
                    case 8:
                        {
                            Console.Write("Важность контакта/кем является контакт\n0 - коллега,\n1 - друг,\n2 - родственник,\n3 - важный контакт: ");
                            PhoneNumber.GradeList grade = (PhoneNumber.GradeList)int.Parse(Console.ReadLine());

                            phmanager.PrintPhoneNumbersByGrade(grade);
                        }
                        break;

                    default:
                            Console.WriteLine("Такого действия нету!");
                        break;
                }

                Console.ReadKey();
            }
        }
    }
}
