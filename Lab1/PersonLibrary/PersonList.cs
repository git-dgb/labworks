using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    public class PersonList
    {
        private Person[] _persons;
        private int _count;

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public PersonList()
        {
            _persons = new Person[4];
            _count = 0;
        }

        public void Add(Person person)
        {
            if (_count == _persons.Length)
            {
                Person[] personsNew = new Person[_count * 2];
                for (int i = 0; i < _count; i++)
                {
                    personsNew[i] = _persons[i];
                }
                _persons = personsNew;
            }
            _persons[_count] = person;
            _count++;
        }
    }
}
