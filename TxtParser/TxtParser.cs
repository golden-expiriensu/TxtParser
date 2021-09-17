using System;
using System.Collections.Generic;
using System.IO;

namespace TxtParser
{
    public static class TxtParser
    {
        public static bool ParseTxtFile(string fileDirectory)
        {
            PersonContainer people = ConvertTxtToPersonContainer(fileDirectory);

            try
            {
                people.SortByAlphabet();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Exception :" + e.Message);
                return false;
            }

            if (WriteSortedRecordsToTxt(people, fileDirectory))
                return true;
            else return false;
        }

        static PersonContainer ConvertTxtToPersonContainer(string fileDirectory)
        {
            PersonContainer people = new();

            string line;
            try
            {
                StreamReader sr = new(fileDirectory);

                line = sr.ReadLine();
                while (line != null)
                {
                    people.Add(ConvertStringLineToPerson(line));
                    line = sr.ReadLine();
                }
                sr.Close();

                return people;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return null;
            }
        }

        static Person ConvertStringLineToPerson(string line)
        {
            string[] splitedLine = line.Split(" ");

            try
            {
                string name = splitedLine[0];
                int requestPerHour = int.Parse(splitedLine[1]);
                int countOfHours = int.Parse(splitedLine[2]);
                string info = splitedLine[3];

                return new Person(name, requestPerHour, countOfHours, info);
            }
            catch (FormatException e)
            {
                Console.WriteLine("FormatException: " + e.Message);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return null;
            }
        }

        static bool WriteSortedRecordsToTxt(PersonContainer personContainer, string directiory)
        {
            try
            {
                StreamWriter sw = new(directiory);

                ICollection<Person> people = (List<Person>)personContainer;

                WriteOneLineToTxt(sw, people);

                sw.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return false;
            }
        }

        static void WriteOneLineToTxt(StreamWriter sw, ICollection<Person> people)
        {
            foreach (Person person in people)
                sw.WriteLine($"{person.Name} {person.RequestsPerHour}" +
                    $" {person.CountOfHours} {person.TotalCountOfRequests}" +
                    $" {person.AdditionalInfo}");
        }
    }
}
