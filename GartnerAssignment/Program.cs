using Newtonsoft.Json.Linq;
using System;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace GartnerAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (String fileName in args)
            {
                if (!FileParser.ParseFile(fileName))
                    Console.Write("File parsing not successfull");
            }
            Console.Write("Press any key to close the console app...");
            Console.ReadKey();
        }
    }
}
