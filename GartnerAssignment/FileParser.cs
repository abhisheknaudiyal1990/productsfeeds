using Newtonsoft.Json.Linq;
using System;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace GartnerAssignment
{
    public static class FileParser
    {
        public static bool ParseFile(string fileName)
        {
            bool isComplete = true;
            Console.WriteLine();
            Console.WriteLine($"importing data from {fileName}");

            try
            {
                string filepath = Environment.CurrentDirectory + @"\" + @"feed-products\" + fileName;
                string fileExtension = Path.GetExtension(filepath);

                using (StreamReader file = new StreamReader(filepath))
                {
                    string fileContents = file.ReadToEnd();
                    if (fileExtension == ".yaml")
                    {
                        var deserializer = new DeserializerBuilder()
                          .WithNamingConvention(CamelCaseNamingConvention.Instance)
                          .Build();

                        var arrYaml = deserializer.Deserialize<dynamic>(fileContents);
                        if (arrYaml != null)
                        {
                            foreach (var item in arrYaml)
                            {
                                if (item != null)
                                {
                                    Console.WriteLine($"importing: Name: {item["name"]}; Categories: {item["tags"]}; Twitter: {item["twitter"]}");
                                }
                            }
                        }
                    }
                    else if (fileExtension == ".json")
                    {
                        JObject parsed = JObject.Parse(fileContents);

                        foreach (var pair in parsed)
                        {
                            Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                        }
                    }
                    else
                    {
                        isComplete = false;
                        Console.WriteLine("File type not supported");
                    }
                }
            }
            catch (Exception ex)
            {
                isComplete = false;
                Console.WriteLine("Some exception occured " + ex.Message);
            }
            return isComplete;
        }
    }
}
