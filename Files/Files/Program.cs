using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            ///<summary>
            ///Создать программу, которая ищет в указанном каталоге файлы, удовлетворяющие заданной маске, и дата последней модификации которых находится в указанном диапазоне. 
            ///Поиск производится как в указанном каталоге, так и в его подкаталогах. Результаты поиска сбрасываются в файл отчета. 
            ///
            ///Создать программу для поиска указанного текста в файлах, удовлетворяющих заданной маске, и замене этого тектса на другой указанный текст.
            ///Поиск производится как в указанном каталоге, так и в его подкаталогах. 
            ///
            ///Создать программу для поиска по всему диску файлов и каталогов, удовлетворяющих заданной маске. 
            ///Необходимо вывести найденную информацию на экран в компактном виде(с нумерацией объектов) и запросить у пользователя о дальнейших действиях.
            ///Варианты действий: удалить все найденное, удалить указанный файл(каталог), удалить диапазон файлов(каталогов).
            ///</summary>
            ///
            //menu
            MenuList menu = new MenuList(new string[] { "Searching files by mask", "Searching and replacing text", "Searching All disk" });
            ConsoleKeyInfo arrow;
            do
            {
                arrow = Console.ReadKey(true);
                switch (arrow.Key)
                {
                    case ConsoleKey.UpArrow:
                        menu.SelectedIndex--;
                        break;
                    case ConsoleKey.DownArrow:
                        menu.SelectedIndex++;
                        break;
                    default:
                        break;
                }
            } while (arrow.Key != ConsoleKey.Enter);
            Console.Clear();
                MenuList.Choise(menu.SelectedItem);
            Console.ReadKey();

            switch (menu.SelectedItem)
            {
                case "Searching files by mask": //1
                    Console.WriteLine("enter: adress");
                        string adress = @$"{Console.ReadLine()}";
                    Console.WriteLine("enter: mask");
                        string mask = Console.ReadLine();
                    Console.WriteLine("enter: fromTime");
                        DateTime fromTime = DateTime.Parse(Console.ReadLine(), new CultureInfo("ru-Ru", true));
                    Console.WriteLine("enter: toTime");
                        DateTime toTime = DateTime.Parse(Console.ReadLine(), new CultureInfo("ru-Ru", true));
                        SearchingByMAsk.FilesToFile(adress, mask, fromTime, toTime);
                    break;
                case "Searching and replacing text": //2
                    Console.Write("Enter path: ");
                        string path = Console.ReadLine();
                    Console.Write("Enter mask: ");
                        string maskToSearch = Console.ReadLine();
                    Console.Write("Text to remove: ");
                        string text = Console.ReadLine();
                    Console.Write("Text to replace: ");
                        string textToReplace = Console.ReadLine();
                        SearchingText.SearchText(path, text, textToReplace, maskToSearch);
                    Console.ReadLine();
                    break;
                case "Searching All disk": //3
                    Console.Write("Enter path to disk: ");
                        string disk = Console.ReadLine();
                    Console.Write("Enter mask: ");
                        string directoriesMask = Console.ReadLine();
                    Console.Clear();
                    SearchingAllDisk.MaskSearch(disk, directoriesMask);
                    break;
                default:
                    Console.WriteLine("How dare you??");
                    break;

            }

        }
       
        
    }
}
