using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ULinker
{
    public class USecurity
    {

        public static UBase CreateDatabase(string name,string password = "")
        {

            string current_directory = Directory.GetCurrentDirectory() + @"\";
            string path = current_directory + name + ".ulink";
          
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine($"{DateTime.UtcNow.ToLongDateString()}|{name}|{password}");
            }
                
            return new UBase(name,password, DateTime.UtcNow.ToLongDateString(),path);

        }
        

          
    }
}
