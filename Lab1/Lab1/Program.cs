using PersonLibrary;

internal class Program
{
    private static void Main(string[] args)
    {
        PersonList firstList = new PersonList();
        PersonList secondList = new PersonList();

        Person person1 = new Person("Иван", "Иванов", 25, Gender.Male);
        Person person2 = new Person("Анна", "Петрова", 22, Gender.Female);
        Person person3 = new Person("Пётр", "Сергеев", 30, Gender.Male);
        Person person4 = new Person("Сергей", "Смирнов", 40, Gender.Male);
        Person person5 = new Person("Елена", "Кулешова", 67, Gender.Female);
        Person person6 = new Person("Матвей", "Матвеев", 29, Gender.Male);

        WaitForKey();

        firstList.Add(person1);
        firstList.Add(person2);
        firstList.Add(person3);

        secondList.Add(person4);
        secondList.Add(person5);
        secondList.Add(person6);

        PrintList(firstList, "Первый список:");
        PrintList(secondList, "Второй список:");

        WaitForKey();

        Person person7 = new Person(
            "Александр",
            "Александров",
            35,
            Gender.Male);

        firstList.Add(person7);

        PrintList(firstList, "Первый список после добавления новой персоны:");

        WaitForKey();

        Person? personToCopy = firstList.GetPerson(1);

        if (personToCopy != null)
        {
            secondList.Add(personToCopy);
        }

        PrintList(firstList, "Первый список:");
        PrintList(secondList, "Второй список:");

        WaitForKey();

        firstList.Remove(personToCopy);

        PrintList(firstList, "Первый список:");
        PrintList(secondList, "Второй список:");

        WaitForKey();

        secondList.Clear();
        PrintList(secondList, $"Второй список (кол-во человек - {secondList.Count}):");
    }

    private static void PrintList(PersonList list, string title)
    {
        Console.WriteLine(title);

        for (int i = 0; i < list.Count; i++)
        {
            Person? person = list.GetPerson(i);

            if (person != null)
            {
                Console.WriteLine(
                    person.FirstName + " " +
                    person.LastName + ", " +
                    person.Age + ", " +
                    person.Gender);
            }
        }
    }

    private static void WaitForKey()
    {
        Console.WriteLine("\nНажмите любую клавишу для продолжения...");
        Console.ReadKey();
        Console.WriteLine();
    }
}