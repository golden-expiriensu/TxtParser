using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Parser
{
    class PersonContainer : ICollection<Person>
    {
        ICollection<Person> _people = new List<Person>();

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
                FindPersonByName(item).AddPersonRecord(item);
            }
        }

        public void Clear()
        {
            _people.Clear();
        }

        public bool Contains(Person item)
        {
            return FindPersonByName(item) != null;
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
            Person person = FindPersonByName(item);

            if (person == null) return false;
            else return _people.Remove(person);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _people.GetEnumerator();
        }

        Person FindPersonByName(Person person) => _people.Where(p => p.Name == person.Name).FirstOrDefault();
    }
}
