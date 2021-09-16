using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser;

namespace PersonContainerTests
{
    [TestClass]
    public class Tests
    {
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

            Assert.AreEqual(expected, people, "\"Sorted\" container: " + names);
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
    }
}
