namespace PersonLibrary
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private int _age;
        private Gender _gender;

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
        }

        public Gender Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
            }
        }

        public Person(string firstName, string lastName, int age, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
        }

        public void Print()
        {
            Console.WriteLine(
                $"Имя: {FirstName}\n" +
                $"Фамилия: {LastName}\n" +
                $"Возраст: {Age}\n" +
                $"Пол: {Gender}\n");
        }
        public void Read()
        {
            Console.WriteLine("Введите Имя человека:");
            FirstName = Console.ReadLine();
            Console.WriteLine("Введите Фамилию человека:");
            LastName = Console.ReadLine();
            Console.WriteLine("Введите Возраст человека:");
            Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите Пол человека:");
            Gender = Enum.Parse<Gender>(Console.ReadLine());
        }
    }
}
