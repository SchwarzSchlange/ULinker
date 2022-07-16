using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;


namespace ULinker
{
    public class UParse<T>
    {

        public List<object> ParseFileAsClass(UBase uBase)
        {
            List<object> to_return = new List<object>();

        

            if (!File.Exists(uBase.Path))
            {
                Alert.Error("Please enter a valid path!");
                return null;
            }

            string[] lines = File.ReadAllLines(uBase.Path);

            int line_index = 0;
            foreach (var line in lines)
            {
                if(line_index != 0 )
                {
                    string[] parsed_line = line.Split('|');


                    object obje = Activator.CreateInstance(typeof(T));


                    var bindingFlags = BindingFlags.Instance |
                       BindingFlags.NonPublic |
                       BindingFlags.Public;
                    var fieldValues = typeof(T)
                                         .GetFields(bindingFlags)
                                         .ToList();



                    int i = 0;
                    foreach (var x in fieldValues)
                    {
                        //Debug Console.WriteLine($"{line} {i} => {x.Name}");

                        x.SetValue(obje, Convert.ChangeType(parsed_line[i], x.FieldType));

                        i++;
                    }


                    to_return.Add(obje);



                }

                line_index++;
            }

            return to_return;
        }
    }
}
