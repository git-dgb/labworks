using PersonLibrary;
using System;

internal class Program
{
    //TODO: XML+
    private static void Main(string[] args)
    {
        /// <summary>
        /// Блок проверки ручного ввода персон.
        /// </summary>
        IInputProvider consoleInput = new ConsoleInputProvider();
        IOutputProvider consoleOutput = new ConsoleOutputProvider();
        Person newPerson = new Person("Иван", "Иванов", 0, Gender.Male);
        newPerson.Read(consoleInput);
        newPerson.Print(consoleOutput);

        WaitForKey();

        /// <summary>
        /// Создаём два списка персон.
        /// </summary>
        Console.WriteLine(
            "Создание двух списков персон, содержащих по три человека...");

        PersonList firstList = new PersonList();
        PersonList secondList = new PersonList();

        /// <summary>
        /// Создаём шесть случайных персон.
        /// </summary>
        Person person1 = Person.GetRandomPerson();
        Person person2 = Person.GetRandomPerson();
        Person person3 = Person.GetRandomPerson();
        Person person4 = Person.GetRandomPerson();
        Person person5 = Person.GetRandomPerson();
        Person person6 = Person.GetRandomPerson();

        WaitForKey();

        /// <summary>
        /// Добавляем по три персоны в каждый список.
        /// </summary>
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

        /// <summary>
        /// Добавляем новую персону в первый список.
        /// </summary>
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

        /// <summary>
        /// Получаем вторую персону первого списка
        /// и добавляем ту же ссылку в конец второго списка.
        /// </summary>
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

        /// <summary>
        /// Удаляем персону из первого списка.
        /// Во втором списке ссылка на этот объект сохраняется.
        /// </summary>
        Console.WriteLine(
            "Удаление второго человека из первого списка...");

        if (personToCopy != null)
        {
            firstList.Remove(personToCopy);
        }

        PrintList(firstList, "Первый список:");
        PrintList(secondList, "Второй список:");

        WaitForKey();

        /// <summary>
        /// Очищаем второй список.
        /// </summary>
        Console.WriteLine("Очистка второго списка...");

        secondList.Clear();

        PrintList(
            secondList,
            $"Второй список (количество человек — {secondList.Count}):");
    }

    //TODO: XML+
    /// <summary>
    /// Выводит содержимое списка с указанным заголовком.
    /// </summary>
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

    //TODO: XML+
    /// <summary>
    /// Приостанавливает выполнение программы до нажатия клавиши.
    /// </summary>
    private static void WaitForKey()
    {
        Console.WriteLine(
            "\nНажмите любую клавишу для продолжения...");

        Console.ReadKey();
        Console.WriteLine();
    }
}
