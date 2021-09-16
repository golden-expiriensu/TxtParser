﻿using System;
using System.IO;

namespace Parser
{
    public static class TxtParser
    {
        public static void ParseTxtFile(string fileDirectory)
        {
            PersonContainer people = ConvertTxtToPersonContainer(fileDirectory);

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
    }
}