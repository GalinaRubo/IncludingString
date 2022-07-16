using System;
using System.IO;
using System.Text;
class Task
{
    public static void Main()
    {
        string str = ""; // строка для вывода на экран
        bool flag = false;//флаг первого нахождения заданного символа в строке
        int index = 0;//индекс позиции символа в строке
        int counter = 0;//счетчик строк
        Console.WriteLine("***Нахождение подстрок с первым и последним заданным символом***");
        Console.Write("Введите символ: ");
        string? symbol = Console.ReadLine();
        
        using (StreamReader fs = new StreamReader("D:/Text.txt"))

            while (fs.Peek() > -1)
            {
                str = fs.ReadLine();
                do
                {
            //        Console.WriteLine(str);
                    index = str.IndexOf(symbol);
                    if (index >= 0 && flag == false)
                    {
                        str = str.Remove(0, index + 1);
                        flag = true;
                        continue;
                    }
                    if (index >= 0 && flag == true)
                    {
                        str = str.Insert(0, symbol);
                        Console.WriteLine($"Строка №{++counter}:"); ;
                        Console.WriteLine(str.Substring(0, index + 2));
                        
                        str = str.Remove(0, index + 2);
                    }
                } while (index != -1);
            }
        if (counter == 0) Console.WriteLine("Подстрока с заданным символом не найдена!");
    }
}
