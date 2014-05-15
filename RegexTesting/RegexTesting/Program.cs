using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexTesting
{
    public class Program
    {
        static void Main(string[] args)
        {
            Method_RegEx_Testing();
        }

        public static void Method_RegEx_Testing()
        {

            string filePath = "test.txt";
            
				

            ////sting methods
            //var sr = new StreamReader(filePath);
            //while (sr.Peek() >= 0)
            //{
            //    var line = sr.ReadLine();
					
            //    if(
            //        line.Contains("+=")
            //        && !line.Contains("//") 
            //        && !line.Contains("new")
            //      )
            //    {
            //        Console.WriteLine(line);
            //        Console.WriteLine();
            //    }
            //}


            ////LINQ
            //var lines = File.ReadAllLines(@filePath)
            //    .Select(x => new { Line = x })
            //    .Where(x => x.Line.Contains("+="))
            //    .Where(x => !x.Line.Contains("new"))
            //    .ToList();

            //foreach (var line in lines)
            //{
            //    Console.WriteLine(line);
            //    Console.WriteLine(filePath);
            //    Console.WriteLine();
            //}
            

            //RegEx
            List<string> listTest = new List<string>();
            listTest.Add("aaaaa");
            listTest.Add("55555");
            listTest.Add("test@test.com");
            listTest.Add("a5a5a5");
            listTest.Add("$%^");

            //Regex searchTerm = new Regex(@"test");

            //string pattern = @"\btest\b";
            //string pattern = @"\b(test)\b";
            //string pattern = @"test";
            string pattern = @"(?=.*\+=)(?!.*new)";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            

            ////using MatchCollection
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("Regex + MatchCollection");
            //Console.WriteLine();

            //foreach (string listItem in listTest)
            //{
                
            //    MatchCollection matches = rgx.Matches(listItem);
            //    if (matches.Count > 0)
            //    {
            //        Console.WriteLine("{0} ({1} matches):", listItem, matches.Count);
            //        foreach (Match match in matches)
            //            Console.WriteLine("   " + match.Value);
            //    }
            //}



            //using List
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("LINQ + RegEx");
            Console.WriteLine();

            var lines2 = File.ReadAllLines(@filePath)
            .Select(x => new { Line = x })
            .Where(d => rgx.IsMatch(d.Line))
            .ToList();

            foreach (var line in lines2)
            {
                //Console.WriteLine(line);
                Console.WriteLine(line.Line);
            }



            Console.WriteLine();
            Console.WriteLine();


        }//end of method
    }//end of class
}//end of namespace




















//foreach (var filePath in filePathList)
//{
//    var lines = File.ReadAllLines(filePath)
//        .Select(x => new {Line = x})
//        .Where(x => !x.Line.Contains("this.Name = \""))/* only retrieving the line if a name declaration can be checked,
//                                                            e.g. "this.Name = 'froglove'" can't be checked against itself.
//                                                            "this.froglove.Name = 'froglove'" can be checked against itself. */
//        .Where(x => !x.Line.Contains("//")) //We don't want any commented out code
//        .Where(x => !x.Line.Contains("get {")) //We don't want properties
//        .Where(x => !x.Line.Contains("set {")) //We don't want properties
//        .Where(x => !x.Line.Contains("EventHandler")) //We don't want event handlers
//        .Where(x => !x.Line.Contains(".Properties.Name"))
//        .ToList();

//    foreach (var anonLine in lines)
//    {
//        countOfFilteredLines++;
//        string line = anonLine.Line; //Made a new anonymous type, getting the string property out of it
//        line = line.Trim();
//        var lineArray = line.Split(".".ToCharArray());

//        string toCompare1 = "";
//        if (line.StartsWith("this.")) //some name assigments don't begin with "this.froglove.Name", just "froglove.Name"
//        {
//            toCompare1 = lineArray[1];
//        }
//        else
//        {
//            toCompare1 = lineArray[0];
//        }

//        //getting the name of the right side of the assignment statement
//        var toCompare2 = lineArray[lineArray.Length - 1];
//        toCompare2 = toCompare2.TrimStart("Name = ".ToCharArray());
//        //when on one line had an odd error, taking off the beginning m too
//        toCompare2 = toCompare2.TrimStart("\"".ToCharArray());
//        toCompare2 = toCompare2.TrimEnd("\";".ToCharArray());

//        if (toCompare1 != toCompare2)
//        {
//            if (toCompare2 == "")
//            {
//                countOfLinesWithEmptyNames++;
//            }
//            else
//            {
//                countOfDisparateNameLines++;

//                Console.WriteLine(filePath);
//                Console.WriteLine(line);
//                Console.WriteLine("First piece: " + toCompare1);
//                //e.g. First piece is froglove in  "this.froglove.Name = 'froglove2'"
//                Console.WriteLine("Second piece: " + toCompare2);
//                //e.g. Second piece is froglove2 in  "this.froglove.Name = 'froglove2'"
//                Console.WriteLine();
//            }
//        }
//    }
//}