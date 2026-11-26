namespace PersonLibrary
{
    /// <summary>
    /// Представляет список объектов Person с динамическим увеличением массива.
    /// </summary>
    public class PersonList
    {
        private Person[] _persons;
        private int _count;

        /// <summary>
        /// Возвращает количество персон в списке.
        /// </summary>
        public int Count
        {
            get
            {
                return _count;
            }
        }

        /// <summary>
        /// Создаёт пустой список с начальной вместимостью 10 элемента.
        /// </summary>
        public PersonList()
        {
            _persons = new Person[10];
            _count = 0;
        }

        /// <summary>
        /// Добавляет персону в конец списка.
        /// При необходимости увеличивает вместимость массива на 10.
        /// </summary>
        /// <param name="person">Персона, которую необходимо добавить.</param>
        public void Add(Person person)
        {
            if (_count == _persons.Length)
            {
                Person[] personsNew = new Person[_count + 10];

                for (int i = 0; i < _count; i++)
                {
                    personsNew[i] = _persons[i];
                }

                _persons = personsNew;
            }

            _persons[_count] = person;
            _count++;
        }

        /// <summary>
        /// Удаляет указанную персону из списка.
        /// </summary>
        /// <param name="person">Персона, которую необходимо удалить.</param>
        public void Remove(Person person)
        {
            int removeIndex = IndexOf(person);

            if (removeIndex != -1)
            {
                for (int i = removeIndex; i < _count - 1; i++)
                {
                    _persons[i] = _persons[i + 1];
                }

                _count--;
                _persons[_count] = null!;
            }
        }

        /// <summary>
        /// Удаляет персону по указанному индексу.
        /// Если индекс находится за пределами списка, ничего не происходит.
        /// </summary>
        /// <param name="index">Индекс удаляемой персоны.</param>
        public void RemoveAt(int index)
        {
            if (index >= 0 && index < _count)
            {
                for (int i = index; i < _count - 1; i++)
                {
                    _persons[i] = _persons[i + 1];
                }

                _count--;
                _persons[_count] = null!;
            }
        }

        /// <summary>
        /// Возвращает персону по указанному индексу.
        /// Если индекс недопустим, возвращает null.
        /// </summary>
        /// <param name="index">Индекс искомой персоны.</param>
        /// <returns>Найденная персона или null.</returns>
        public Person? GetPerson(int index)
        {
            if (index >= 0 && index < _count)
            {
                return _persons[index];
            }

            return null;
        }

        /// <summary>
        /// Возвращает индекс указанной персоны в списке.
        /// Если персона не найдена, возвращает -1.
        /// </summary>
        /// <param name="person">Персона, индекс которой необходимо найти.</param>
        /// <returns>Индекс персоны или -1, если она отсутствует.</returns>
        public int IndexOf(Person person)
        {
            for (int i = 0; i < _count; i++)
            {
                if (person == _persons[i])
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Удаляет все персоны из списка.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < _count; i++)
            {
                _persons[i] = null!;
            }

            _count = 0;
        }
    }
}
