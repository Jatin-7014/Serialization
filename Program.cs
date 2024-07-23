using System;
using System.Configuration;
using System.Text.Json;
using ObjectSerialization.Models;

namespace ObjectSerialization
{
    internal class Program
    {
        static string Path = ConfigurationManager.AppSettings["filePath"].ToString();
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>()
            {
                new Person(101, "Jatin", "jk1952023"),
                new Person(102, "Abc", "abc1952023"),
                new Person(103, "xyz", "xyz1952023"),
                new Person(104, "pqr", "pqr1952023"),
                new Person(105, "alex", "alex1952023"),
            };
            

            //SerializeObject(persons);
            List<Person>result=DeserializeObject();
            foreach (Person person in result)
            {
                Console.WriteLine(person);
            }

        }
        static void SerializeObject(List<Person> persons) { 
            using (StreamWriter sw = new StreamWriter(Path))
            {
                sw.WriteLine(JsonSerializer.Serialize(persons));
               // Console.WriteLine("Person object is written to the file");
            }
        }

        static List<Person> DeserializeObject()
        {
            using (StreamReader sr = new StreamReader(Path))
            {
                List<Person> person = JsonSerializer.Deserialize<List<Person>>(sr.ReadToEnd());
                return person;
            }
        }
      }
}
