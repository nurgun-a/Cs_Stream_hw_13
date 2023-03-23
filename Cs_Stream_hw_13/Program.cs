using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;

namespace Cs_Stream_hw_13
{
    class Program
    {
        static void Main(string[] args)
        {
            int index = 0;
            List<string> st_menu = new List<string> {"Записать","Считать" };
            try
            { 
                string adress = " ";              
                while (true)
                {
                    Clear();
                    Menu(st_menu, index);
                    switch (ReadKey(true).Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (index < st_menu.Count() - 1)
                                index++;
                            break;
                        case ConsoleKey.UpArrow:
                            if (index > 0)
                                index--;
                            break;
                        case ConsoleKey.Enter:
                                {
                                if (index==0)
                                {
                                    Write_adress(ref adress);
                                }
                                else if (index==1)
                                {
                                    Read_adress();
                                }
                                 ReadKey();
                                }break;
                            case ConsoleKey.Escape:
                                {
                                    Environment.Exit(0);
                                }
                                break;
                            default:
                                break;
                    }
                } 
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.Message}");
            }  
        }
        private static void Menu(List<string> st, int _index)
        {
            for (int i = 0; i < st.Count; i++)
            {
                if (i == _index)
                {
                    BackgroundColor = ForegroundColor;
                    ForegroundColor = ConsoleColor.Black;
                }
                WriteLine($"        {st[i]}") ;
                ResetColor();
            }
            WriteLine();
        }

        public static void Write_adress(ref string str)
        {
            string adress_pattern = @"^[а-яА-Я\. ]{2,6}[а-яА-Я ]+[а-я]{3}[0-9а-я/ ]{1,8}[а-я\.]{3}[0-9а-я/ ]{1,4}$";
            WriteLine($"Введите адресс:\n(ул. ******** дом *** кв. ***)");
            str = ReadLine();
            Regex r_adress = new Regex(adress_pattern);
            WriteLine(r_adress.IsMatch(str) ? "Correct" : "Not Correct");
            if (r_adress.IsMatch(str))
            {
                string fPath = "res.txt";
                using (FileStream fs = new FileStream(fPath, FileMode.Append))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                    {
                        sw.WriteLine(str);
                    }
                    WriteLine($"OK");
                }
            }
        }
        public static void Read_adress()
        {
            string fPath = "res.txt";
            using (FileStream fs = new FileStream(fPath, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    WriteLine(sr.ReadToEnd());
                }
                WriteLine($"OK");
            }           
        }
    }
}
