using PersonLibrary;

internal class Program
{
    private static void Main(string[] args)
    {
        Person person = new Person("", "", 0, Gender.Male);
        person.Read();
        person.Print();

        WaitForKey();

        // Создаём два списка персон.
        Console.WriteLine(
            "Создание двух списков персон, содержащих по три человека...");

        PersonList firstList = new PersonList();
        PersonList secondList = new PersonList();

        // Создаём шесть случайных персон.
        Person person1 = Person.GetRandomPerson();
        Person person2 = Person.GetRandomPerson();
        Person person3 = Person.GetRandomPerson();
        Person person4 = Person.GetRandomPerson();
        Person person5 = Person.GetRandomPerson();
        Person person6 = Person.GetRandomPerson();

        WaitForKey();

        // Добавляем по три персоны в каждый список.
        Console.WriteLine("Заполнение списков и вывод их содержимого...");

        firstList.Add(person1);
        firstList.Add(person2);
        firstList.Add(person3);

        secondList.Add(person4);
        secondList.Add(person5);
        secondList.Add(person6);

        PrintList(firstList, "Первый список:");
        PrintList(secondList, "Второй список:");

        WaitForKey();

        // Добавляем новую персону в первый список.
        Console.WriteLine("Добавление нового человека в первый список...");

        Person person7 = new Person(
            "Александр",
            "Александров",
            35,
            Gender.Male);

        firstList.Add(person7);

        PrintList(
            firstList,
            "Первый список после добавления новой персоны:");

        WaitForKey();

        // Получаем вторую персону первого списка
        // и добавляем ту же ссылку в конец второго списка.
        Console.WriteLine(
            "Копирование второго человека из первого списка " +
            "в конец второго списка...");

        Person? personToCopy = firstList.GetPerson(1);

        if (personToCopy != null)
        {
            secondList.Add(personToCopy);
        }
        else
        {
            Console.WriteLine("Не удалось получить персону для копирования.");
        }

        PrintList(firstList, "Первый список:");
        PrintList(secondList, "Второй список:");

        WaitForKey();

        // Удаляем персону из первого списка.
        // Во втором списке ссылка на этот объект сохраняется.
        Console.WriteLine(
            "Удаление второго человека из первого списка...");

        if (personToCopy != null)
        {
            firstList.Remove(personToCopy);
        }

        PrintList(firstList, "Первый список:");
        PrintList(secondList, "Второй список:");

        WaitForKey();

        // Очищаем второй список.
        Console.WriteLine("Очистка второго списка...");

        secondList.Clear();

        PrintList(
            secondList,
            $"Второй список (количество человек — {secondList.Count}):");
    }

    // Выводит содержимое списка с указанным заголовком.
    private static void PrintList(PersonList list, string title)
    {
        Console.WriteLine(title);

        for (int i = 0; i < list.Count; i++)
        {
            Person? person = list.GetPerson(i);

            if (person != null)
            {
                Console.WriteLine(
                    $"{person.FirstName} {person.LastName}, " +
                    $"{person.Age}, {person.Gender}");
            }
        }
    }

    // Приостанавливает выполнение программы до нажатия клавиши.
    private static void WaitForKey()
    {
        Console.WriteLine(
            "\nНажмите любую клавишу для продолжения...");

        Console.ReadKey();
        Console.WriteLine();
    }
}
