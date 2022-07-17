# ULinker
It is a database tool to parse "ulink" files.

## What is this tool for?
By creating "ulink" databases you can parse the data to a class it

Still on development...😑


## Example For Class Parsing
``` ruby

  static void Main(string[] args)
  {
            UBase mybase = UBase.FromPath(@"Your Path"); // Create Database from directory

            UParse<TestClass> parser = new UParse<TestClass>(); // Create a parser to parse database

            var datas = parser.ParseFileAsClass(mybase); // Parse

            foreach(TestClass test in datas)
            {
                Console.WriteLine(test.a * test.b / test.c); // Do a basic math process with the parsed values of each line
            }

            Console.ReadLine();
        }
    }

    class TestClass // Test class to parse
    {
        public float a { get; set; }
        public float b { get; set; }
        public float c { get; set; }

    }


```

## Example ULink File
``` ruby
Date|Name of the Database|Password
0.445|623.1|1
0.895|901.34|6
0.175|683.95|8
0.2|0.5|-20.4
-985.3|-3|9.453
```
