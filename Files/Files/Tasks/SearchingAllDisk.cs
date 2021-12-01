using Files.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Files
{
    internal class SearchingAllDisk
    {
        internal static void MaskSearch(string disk, string mask)
        {
            DirectoryInfo di = new DirectoryInfo(disk);
            DirectoryInfo[] directories = di.GetDirectories();
            ShowDirectories(directories, RegexMethods.TransformMaskToRegex(mask));
            MenuDeleting();



        }


        static void ShowDirectories(DirectoryInfo[] directories, Regex regMask)
        {
            int index = 0;
            foreach (DirectoryInfo s in directories)
            {
                if (regMask.IsMatch(s.Name))
                {
                    index++;
                    Console.WriteLine($"{index} --- {s.FullName}");
                    ShowFiles(s, regMask, index);
                    ShowDirectories(s.GetDirectories(), regMask);
                }
            }
            
        }


        static void ShowFiles(DirectoryInfo directory, Regex regMask, int directoryIndex)
        {
            int fileIndex = 0;
            FileInfo[] files = directory.GetFiles();
            //Dictionary<int, string> filesW
            foreach (FileInfo f in files)
            {
                if (regMask.IsMatch(f.Name))
                {
                    fileIndex++;
                    Console.WriteLine($"\t{fileIndex} --- {f.FullName}");
                }
            }
        }

        static void DeleteFile(string path)
        {
           
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            
        }
        static void DeleteFileNotRealy(string path) //defence from stupidness
        {

            if (File.Exists(path))
            {
                Console.WriteLine($"{path} - DELETED");
            }

        }


        static void MenuDeleting()
        {
            Console.WriteLine("Press 1 to delete file\nPress 2 to delete from to\n Press 3 to delete all");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.WriteLine("Enter path: ");
                    string path = Console.ReadLine();
                    DeleteFileNotRealy(path);
                    break;

                case 2:
                    Console.WriteLine("Enter path of first file: ");
                    string pathFirst = Console.ReadLine();
                    Console.WriteLine("Enter path of first file: ");
                    string pathSecond = Console.ReadLine();
                    break;

                case 3:
                    Console.WriteLine("All files delete");
                    break;
                default:
                    break;


            }
        }


    }
}
