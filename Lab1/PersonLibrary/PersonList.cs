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

        public void Remove(Person person)
        {
            for (int i = 0; i < _count; i++)
            {
                if (person == _persons[i])
                {
                    int removeIndex = i;
                    if (removeIndex != _count - 1)
                    {
                        for (int j = removeIndex; j < _count - 1; j++)
                        {
                            _persons[j] = _persons[j + 1];
                        }
                    }
                    _count--;
                    break;
                }
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < _count)
            {
                if (index != _count - 1)
                {
                    for (int k = index; k < _count - 1; k++)
                    {
                        _persons[k] = _persons[k + 1];
                    }
                }
                _count--;
            }
        }
    }
}
