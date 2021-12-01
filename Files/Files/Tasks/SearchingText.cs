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
    internal class SearchingText
    {
        public static void SearchText(string path, string text, string textToReplace, string mask)
        {
            
            Regex regMask = RegexMethods.TransformMaskToRegex(mask);
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();

            foreach (FileInfo f in files)
            {

                if (regMask.IsMatch(f.Name))
                {

                    var sr = new StreamReader(directory.FullName + @"\" + f.Name, Encoding.Default);
                    string content = sr.ReadToEnd();
                    Console.WriteLine(content);
                    sr.Close();

                    if (Regex.IsMatch(content, text))
                    {

                        content = Regex.Replace(content, text, textToReplace);
                    }

                    StreamWriter sw = new StreamWriter(directory.FullName + @"\" + f.Name, false, Encoding.Default);
                    sw.Write(content);
                    sw.Close();


                }
            }
            DirectoryInfo[] subDirectories = directory.GetDirectories();
            foreach (DirectoryInfo p in subDirectories)
            {
                SearchText(p.FullName, text, textToReplace, mask);
            }



        }
    }
}
