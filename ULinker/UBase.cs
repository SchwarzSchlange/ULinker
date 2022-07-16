using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ULinker
{
    public class UBase
    {
        public string DBName { get; set; }
        public string Password { get; private set; }
        public string CreateDate { get; private set; }
        public string Path { get; set; }

        

        public UBase(string name,string password,string date,string path)
        {
            this.DBName = name;
            this.Password = password;
            this.CreateDate = date;
            this.Path = path;
        }


        public static UBase FromPath(string path)
        {
            if(!File.Exists(path))
            {
                Alert.Error(path + "is not exitsts!");

                return null;
            }
            else
            {
                try
                {
                    var data = File.ReadAllLines(path)[0].Split('|');

                    return new UBase(data[1], data[2], data[0],path);
                }
                catch
                {
                    Alert.Error("The file could not be read please fix the format of the database.");
                    return null;
                }

            }
        }
    }
}
