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
            UBase mybase = UBase.FromPath(@"C:\Users\User\Desktop\base.ulink"); // Create Database from directory

            //USecurity.EncryptBase(mybase);

            UBase enc_base = UBase.FromPath(@"C:\Users\User\source\repos\ULinker\Test\bin\Debug\My Base");
            USecurity.DecryptBase(enc_base, "Im3h3o9d");

            Alert.Info("Program Finished...");
            Console.ReadLine();
        }
    }

}
