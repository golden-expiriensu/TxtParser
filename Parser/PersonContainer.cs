using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Parser
{
    public class PersonContainer : ICollection<Person>
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

        #region ICollection implementing

        public int Count => _people.Count;

        public bool IsReadOnly => _people.IsReadOnly;

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

        public void Clear()
        {
            _people.Clear();
        }

        public bool Contains(Person item)
        {
            return FindPersonWithSameName(item) != null;
        }

        public void CopyTo(Person[] array, int arrayIndex)
        {
            _people.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Person> GetEnumerator()
        {
            return _people.GetEnumerator();
        }

        public bool Remove(Person item)
        {
            Person person = FindPersonWithSameName(item);

            if (person == null) return false;
            else return _people.Remove(person);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _people.GetEnumerator();
        } 
        
        #endregion


        public void SortByAlphabet()
        {
            List<string> names = new();

            foreach (Person person in _people)
                names.Add(person.Name);

            names.Sort();

            ICollection<Person> sortedPeople = new List<Person>();
            foreach (string name in names)
                sortedPeople.Add(this[name]);
        }

        Person FindPersonWithSameName(Person person) => _people.Where(
            p => p.Name.Equals(person.Name)
            ).FirstOrDefault();
    }
}
