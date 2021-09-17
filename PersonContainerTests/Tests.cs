using Microsoft.VisualStudio.TestTools.UnitTesting;
using TxtParser;
using System.Collections.Generic;
using System.Linq;

namespace PersonContainerTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestAccessingByIndex()
        {
            Person person1 = new("¿", 1, 1, "1");
            Person person2 = new("¡", 1, 1, "1");

            PersonContainer people = new() { person1, person2 };

            Person actual;
            Person expected = person2;

            actual = people[1];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAccessingByName()
        {
            Person person1 = new("¿", 1, 1, "1");
            Person person2 = new("¡", 1, 1, "1");

            PersonContainer people = new() { person1, person2 };

            Person actual;
            Person expected = person2;

            actual = people["¡"];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNameSorting()
        {
            Person person1 = new("¡··", 1, 1, "1");
            Person person2 = new("¿‡‡", 1, 1, "1");
            Person person3 = new("¬‡‡", 1, 1, "1");
            Person person4 = new("¿Ô‡", 1, 1, "1");
            Person person5 = new("¿ˇ‡", 1, 1, "1");

            PersonContainer people = new() { person1, person2, person3, person4, person5 };

            IEnumerable<string> actual;
            IEnumerable<string> expected = new List<string>() { "¿‡‡", "¿Ô‡", "¿ˇ‡", "¡··", "¬‡‡" };

            actual = people.GetNamesSortedByAlphabet();

            string names = "";

            foreach (string name in actual)
                names += name + " ";

            CollectionAssert.AreEqual(expected.ToList(), actual.ToList(), names);
        }

        [TestMethod]
        public void TestSorting()
        {
            Person person1 = new("¡··", 1, 1, "1");
            Person person2 = new("¿‡‡", 1, 1, "1");
            Person person3 = new("¬‡‡", 1, 1, "1");
            Person person4 = new("¿Ô‡", 1, 1, "1");
            Person person5 = new("¿ˇ‡", 1, 1, "1");

            PersonContainer people = new() { person1, person2, person3, person4, person5 };
            PersonContainer expected = new() { person2, person4, person5, person1, person3 };

            people.SortByAlphabet();

            string names = $"{people[0].Name} {people[1].Name} {people[2].Name} " +
                $"{people[3].Name} {people[4].Name}";

            CollectionAssert.AreEqual((List<Person>)expected, (List<Person>)people, "\"Sorted\" container: " + names);
        }

        [TestMethod]
        public void TestAdd()
        {
            Person person1 = new("¡··", 10, 10, "2");
            Person person2 = new("¿‡‡", 10, 10, "1");
            Person person3 = new("¡··", 5, 10, "2");
            Person person4 = new("¿‡‡", 10, 10, "1");
            Person person5 = new("¿‡‡", 5, 10, "1");

            Person person1Total = new("¿‡‡", 25, 30, 250, "1");
            Person person2Total = new("¡··", 15, 20, 150, "2");

            PersonContainer people = new();
            people.Add(person1);
            people.Add(person2);
            people.Add(person3);
            people.Add(person4);
            people.Add(person5);
            people.SortByAlphabet();

            PersonContainer expected = new() { person1Total, person2Total };

            string message = $"\ncount: {people.Count}" +
                $"\nrequests: {people[0].RequestsPerHour} {people[1].RequestsPerHour}" +
                $"\ncount of hours: {people[0].CountOfHours} {people[1].CountOfHours}" +
                $"\ntotal requests: {people[0].TotalCountOfRequests} {people[1].TotalCountOfRequests}";

            Assert.IsTrue(expected.Equals(people), message);
        }
    }
}
