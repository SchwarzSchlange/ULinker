using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ULinker;

namespace Test
{
    class Program
    {
        

        static void Main(string[] args)
        {
            UBase mybase = UBase.FromPath(@"base.ulink"); // Create Database from directory

            var en_base = USecurity.EncryptBase(mybase); // Protect the UBase into file named "en_base.DBNAME"

            var de_base = USecurity.DecryptBase(en_base, en_base.Password); // Unprotect the returned protected data into "DE_RANDOMSERIAL"

            Console.WriteLine(de_base.DBName + " " + de_base.CreateDate);

            Alert.Info("Program Finished...");
            Console.ReadLine();
        }
    }

}
