using System;
using System.IO;
using System.Text;
class Task
{
    public static void Main()
    {
        string str = ""; // строка для вывода на экран
        int index = 0;//индекс позиции символа в строке
        bool flag_str = false;//флаг начала и конца строки
        bool new_str = false;//флаг перехода на новую строку
        int counter = 0;//счетчик строк для вывода на экран
        Console.WriteLine("***Нахождение подстрок с первым и последним заданным символом***");
        Console.Write("Введите символ: ");
        string? symbol = Console.ReadLine();
        string str_temp = "";
        using (StreamReader fs = new StreamReader("C:/Test/2.txt"))

            while (fs.Peek() > -1)
            {
                new_str = true;
                str = fs.ReadLine();//считываем новую строку
                
                do
                {
                    // Console.WriteLine(str);
                    index = str.IndexOf(symbol);//ищем символ в строке
                    if (index >= 0 && new_str == true && flag_str == false)//если строка новая но конец строки не найден
                    {
                        str = str.Remove(0, index + 1);
                        str_temp = str;
                        new_str = false;
                        flag_str = true;
                        continue;
                    }
                    if (index >= 0 && new_str == false && flag_str == true)//если строка та же, и конец строки найден
                    {
                        str = str.Insert(0, symbol);
                        Console.WriteLine($"Строка №{++counter}:");
                        Console.WriteLine(str.Substring(0, index + 2));
                        str = str.Remove(0, index - 1);
                        str_temp = str;
                        new_str = false;
                        flag_str = false;
                        continue;
                    }

                    if (index >= 0 && new_str == true  && flag_str == true)//если строка новая, и конец строки найден
                    {
                        str = str.Insert(0, str_temp);
                        str = str.Insert(0, symbol);
                        Console.WriteLine($"Строка №{++counter}:"); ;
                        Console.WriteLine(str.Substring(0, str_temp.Length + index + 2));
                        str = str.Remove(0, index - 1);
                        str_temp = str;
                        new_str = false;
                        flag_str = false;
                        continue;
                    }
                    if (index >= 0 && new_str == false && flag_str == false)//если строка та же,а конец строки не найден
                    {
                        str = str.Remove(0, index + 1);
                        str_temp = str;

                        new_str = false;
                        flag_str = true;
                        continue;
                    }
                } while (index != -1);
                if (new_str == true) str_temp = str_temp.Insert(str_temp.Length, str);//если строка новая и в ней нет символа
            }
        if (counter == 0) Console.WriteLine("Подстрока с заданным символом не найдена!");
    }
}
