# ULinker
It is a database tool to parse "ulink" files.

## What is this tool for?
By creating "ulink" databases you can parse the data to a class it

Still on development...😑


## Example For Class Parsing
``` ruby

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


```
