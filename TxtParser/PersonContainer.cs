using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TxtParser
{
    public class PersonContainer : IEnumerable<Person>
    {
        ICollection<Person> _people = new List<Person>();
        public Person this[int i]
        {
            get => _people.ToList()[i];
        }
        public Person this[string name]
        {
            get => _people.Where(p => p.Name.Equals(name)).FirstOrDefault();
        }
        public int Count => _people.Count;

        public static explicit operator List<Person>(PersonContainer people) { return people.GetCollection().ToList(); }

        ICollection<Person> GetCollection() => _people;

        #region IEnumerable implementing

        public IEnumerator<Person> GetEnumerator()
        {
            return _people.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _people.GetEnumerator();
        }

        #endregion


        public void Add(Person item)
        {
            if (!Contains(item))
            {
                _people.Add(item);
            }
            else
            {
                FindPersonWithSameName(item).AddPersonRecord(item);
            }
        }

        public bool Contains(Person item)
        {
            return FindPersonWithSameName(item) != null;
        }

        public bool Remove(Person item)
        {
            Person person = FindPersonWithSameName(item);

            if (person == null) return false;
            else return _people.Remove(person);
        }

        public void SortByAlphabet()
        {
            IEnumerable<string> names = GetNamesSortedByAlphabet();

            ICollection<Person> sortedPeople = new List<Person>();
            foreach (string name in names)
                sortedPeople.Add(this[name]);

            _people = sortedPeople;
        }

        public IEnumerable<string> GetNamesSortedByAlphabet()
        {
            List<string> names = new();

            foreach (Person person in _people)
                names.Add(person.Name);

            names.Sort();

            return names;
        }

        public override bool Equals(object obj)
        {
            if (obj is not PersonContainer)
                return false;

            PersonContainer people = obj as PersonContainer;

            try
            {
                for (int i = 0; i < _people.Count; i++)
                    if (!this[i].Equals(people[i]))
                        return false;
                return true;
            }
            catch (System.IndexOutOfRangeException e)
            {
                System.Console.WriteLine(e.Message);
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        Person FindPersonWithSameName(Person person) => _people.Where(
            p => p.Name.Equals(person.Name)
            ).FirstOrDefault();
    }
}
