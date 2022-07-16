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
            UBase mybase = UBase.FromPath(@"C:\Users\User\source\repos\ULinker\ULinker\bin\Debug\data.ulink"); // Create Database from directory

            UParse<TestClass> parser = new UParse<TestClass>(); // Create a parser to parse database

            var datas = parser.ParseFileAsClass(mybase); // Parse

            foreach(TestClass test in datas)
            {
                Console.WriteLine(test.a * test.b / test.c); // Do a basic math process with the parsed values of each line
            }

            Console.ReadLine();
        }
    }

    class TestClass
    {
        public float a { get; set; }
        public float b { get; set; }
        public float c { get; set; }

    }
}
