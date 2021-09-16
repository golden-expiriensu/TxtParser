using System;
using System.Collections.Generic;

namespace Parser
{
    public class Person
    {
        public string Name { get; private set; }
        public int RequestsPerHour { get; private set; }
        public int CountOfHours { get; private set; }
        public int TotalCountOfRequests { get; private set; } = 0;
        public string AdditionalInfo { get; private set; }

        public Person(string name, int requestsPerHour, int countOfHours, string additionalInfo)
        {
            Name = name;
            RequestsPerHour = requestsPerHour;
            CountOfHours = countOfHours;
            AddTotalCountOfRequests(requestsPerHour, countOfHours);
            AdditionalInfo = additionalInfo;
        }

        public void AddPersonRecord(Person person)
        {
            RequestsPerHour += person.RequestsPerHour;
            CountOfHours += person.CountOfHours;
            AddTotalCountOfRequests(person.RequestsPerHour, person.CountOfHours);
        }

        void AddTotalCountOfRequests(int requestsPerHour, int countOfHours)
        {
            TotalCountOfRequests += requestsPerHour * countOfHours;
        }
    }
}
