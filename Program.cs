using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {


            do
            {
                Console.Clear();
                Console.WriteLine("Создать текстовый файл (cr)\n" +
                    "Добавить запись в текстовый файл (add)\n" +
                    "Просмотреть содержимое текстового файла (read)\n" +

   "Удалить текстовый файл (del)\n");

                switch (Console.ReadLine())
                {
                    case "cr":
                        Console.Clear();
                        Console.WriteLine("Введите имя текстового файла:");
                        try
                        {
                            System.IO.File.Create(Console.ReadLine() + ".txt");
                            Console.Write("Текстовый файл создан");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.ReadKey();
                        break;
                    case "add":
                        Console.Clear();
                        Console.WriteLine("Введите имя текстового файла:");
                        string writePath = Console.ReadLine() + ".txt";

                        StringBuilder sb = new StringBuilder();

                        char c = 'n';

                        do
                        {
                            if (sb.Length > 0)
                                sb.Append("\n");
                            Console.Write("Введите фамилию: ");
                            sb.Append(Console.ReadLine() + ' ');


                            Console.Write("Введите инициалы: ");
                            sb.Append(Console.ReadLine() + ' ');
                            Console.Write("Введите оценку: ");
                            sb.Append(Console.ReadLine());
                            Console.WriteLine("Создать ещё одну запись? (y/n)");
                            c = Console.ReadLine()[0];
                        } while (c == 'y');

                        string text = sb.ToString();
                        try
                        {
                            using (StreamWriter sw = new StreamWriter(writePath, true,
System.Text.Encoding.UTF8))
                            {
                                sw.WriteLine(text);
                            }
                            Console.WriteLine("Запись выполнена");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.ReadKey();
                        break;
                    case "read":
                        Console.Clear();
                        Console.WriteLine("Введите имя файла:");
                        string path = Console.ReadLine() + ".txt";
                        try

                        {
                            using (StreamReader sr = new StreamReader(path))
                            {
                                Console.WriteLine(sr.ReadToEnd());

                            }

                        }
                        catch (Exception e)
                        {


                            Console.WriteLine(e.Message);
                        }
                        Console.ReadKey();
                        break;
                    case "del":
                        Console.Clear();
                        Console.WriteLine("Введите имя файла:");
                        try
                        {
                            System.IO.File.Delete(Console.ReadLine() + ".txt");
                            Console.Write("Файл удален");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.ReadKey();
                        break;

                    default: goto exit;
                }
            }
            while (true);
        exit:
            Console.ReadKey();
        }
    }
}
