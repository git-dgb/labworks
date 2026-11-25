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

        firstList.Add(person1);
        firstList.Add(person2);
        firstList.Add(person3);

        secondList.Add(person4);
        secondList.Add(person5);
        secondList.Add(person6);

    }
}