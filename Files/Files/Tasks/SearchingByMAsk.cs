using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    internal class SearchingByMAsk
    {
        //Searching files by mask and time
        internal static void FilesToFile(string adress, string mask, DateTime fromTime, DateTime toTime)
        {


            string[] files = Directory.GetFiles(adress, mask, SearchOption.AllDirectories);

            for (int i = 0; files.Length > i; i++)
            {
                FileStream fileStream = new FileStream("log.txt", FileMode.Append);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                DateTime lastWriteTime = File.GetLastWriteTime(files[i]);
                if (lastWriteTime >= fromTime && lastWriteTime <= toTime)
                {
                    streamWriter.WriteLine(files[i] + "Created:  " + lastWriteTime + ",");
                }

                streamWriter.Close();


            }

        }

        


    }
}
