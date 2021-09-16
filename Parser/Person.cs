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

        public Person(string name, int requestsPerHour, int countOfHours, int totalCountRequests, string additionalInfo)
        {
            Name = name;
            RequestsPerHour = requestsPerHour;
            CountOfHours = countOfHours;
            TotalCountOfRequests = totalCountRequests;
            AdditionalInfo = additionalInfo;
        }

        public void AddPersonRecord(Person person)
        {
            RequestsPerHour += person.RequestsPerHour;
            CountOfHours += person.CountOfHours;
            AddTotalCountOfRequests(person.RequestsPerHour, person.CountOfHours);
        }

        public override bool Equals(object obj)
        {
            if (obj is not Person)
                return false;

            Person person = obj as Person;

            if (person.Name.Equals(Name)
            && person.RequestsPerHour == RequestsPerHour
            && person.CountOfHours == CountOfHours
            && person.TotalCountOfRequests == TotalCountOfRequests
            && person.AdditionalInfo.Equals(AdditionalInfo))
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        void AddTotalCountOfRequests(int requestsPerHour, int countOfHours)
        {
            TotalCountOfRequests += requestsPerHour * countOfHours;
        }
    }
}
