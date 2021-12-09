using System;
using System.Linq;
using System.Collections.Generic;

namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new List<Contact>();


            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            var sortPhoneBook = from sort in phoneBook
                                orderby sort.Name, sort.LastName
                                select sort;

            while (true)
            {
                Console.WriteLine("Введите число");
                var keyChar = Console.ReadKey().KeyChar;
                Console.Clear();

                if (!Char.IsDigit(keyChar))
                {
                    Console.WriteLine("Ошибка ввода, введите число");
                }
                else
                {
                    IEnumerable<Contact> page = null;

                    switch (keyChar)
                    {

                        case ('1'):
                            page = sortPhoneBook.Take(2);
                            break;
                        case ('2'):
                            page = sortPhoneBook.Skip(2).Take(2);
                            break;
                        case ('3'):
                            page = sortPhoneBook.Skip(4).Take(2);
                            break;
                    }
                    if (page == null)
                    {
                        Console.WriteLine($"Ошибка ввода, страницы {keyChar} не существует");
                        continue;
                    }
                    foreach (var contact in page)
                        Console.WriteLine($"Имя {contact.Name} Фамилия {contact.LastName }");

                }

            }

        }
    }
 }

