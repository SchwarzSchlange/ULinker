using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULinker
{
    class Program
    {
        const string VERSION = "1.0"; // PROGRAM VERSION

        static void Main(string[] args)
        {
            //////////////////////////////////////////////////////
            Initilaze();
            Alert.Info($"Version : {VERSION} | Kaan Temizkan");
            Alert.Sep();
           
            //////////////////////////////////////////////////////

      

            Console.ReadLine();

        }
        private static List<Arg> ArgsToGenList(string[] args)
        {
            List<Arg> list = new List<Arg>();
            int i = 0;
            foreach(var x in args)
            {
                list.Add(new Arg { value = x,index = i});
                i++;
            }
            return list;
        }

        private static void Initilaze()
        {
            Console.Title = "ULinker";
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
