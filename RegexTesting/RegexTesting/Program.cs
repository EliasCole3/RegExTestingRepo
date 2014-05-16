using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            //string pattern = @"(?=.*\+=)(?!.*new)";//working
            //string pattern = @"(?=\+=)(?!new)";
            //string pattern = @"(?!new)(?=\+=)";
            string pattern = @"^(?=.*\+=)(?!.*new)(?!.*//.*)";


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





















namespace Fabtrol.McKenzie.Tests.MSTests.Localization
{

    public class Test_EventHandlersUsingFullSyntax
    {

        public void Method_EventHandlersUsingFullSyntax()
        {
            string codePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (codePath.Contains("\\FabTrol"))
            {
                codePath = codePath.Substring(0, codePath.LastIndexOf("\\FabTrol"));
            }

            int countOfFilteredLines = 0;

            var filePathList = Directory.GetFiles(codePath, "*designer.cs", SearchOption.AllDirectories).ToList(); //designer files

            foreach (var filePath in filePathList)
            {
                Regex rgx = new Regex(@"^(?=.*\+=)(?!.*new)(?!.*//.*)");

                var lines = File.ReadAllLines(filePath)
                    .Select(x => new { Line = x })
                    .Where(d => rgx.IsMatch(d.Line))
                    .ToList();

                countOfFilteredLines += lines.Count;
                if (lines.Count != 0)
                {
                    Console.WriteLine("Number of lines with incorrect event handler assignment: " + countOfFilteredLines);

                    foreach (var line in lines)
                    {
                        Console.WriteLine(line);
                        Console.WriteLine(filePath);
                        Console.WriteLine();
                    }
                }
            }

            //Assert.IsTrue(countOfFilteredLines == 0);

        }
    }
}


