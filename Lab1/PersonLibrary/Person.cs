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

            while (true)
            {
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int age) && age >= 0)
                {
                    Age = age;
                    break;
                }

                Console.WriteLine("Ошибка! Введите неотрицательное целое число.");
            }

            Console.WriteLine("Введите Пол человека (Male или Female):");
            Gender = Enum.Parse<Gender>(Console.ReadLine());
        }

        public static Person GetRandomPerson()
        {
            Random random = new Random();
            int age = random.Next(18, 101);

            int genderNumber = random.Next(2);

            string[] names;
            string[] surnames;
            Gender gender;

            if (genderNumber == 0)
            {
                gender = Gender.Male;
                names = new string[]
                    {
                        "Иван", "Александр", "Дмитрий", "Сергей", "Михаил",
                        "Андрей", "Максим", "Артём", "Никита", "Владимир"
                    };
                surnames = new string[]
                    {
                        "Иванов", "Петров", "Матвеев", "Смирнов", "Кузнецов",
                        "Попов", "Васильев", "Соколов", "Михайлов", "Новиков"
                    };
            }
            else
            {
                gender = Gender.Female;
                names = new string[]
                    {
                        "Алина", "Анна", "Екатерина", "Ольга", "Анастасия",
                        "Елена", "Дарья", "Наталья", "София", "Виктория"
                    };
                surnames = new string[]
                    {
                        "Иванова", "Петрова", "Матвеева", "Смирнова", "Кузнецова",
                        "Попова", "Васильева", "Соколова", "Михайлова", "Новикова"
                    };
            }
            
            int indexNames = random.Next(names.Length);
            int indexSurnames = random.Next(surnames.Length);

            string firstName = names[indexNames];
            string lastName = surnames[indexSurnames];

            return new Person(firstName, lastName, age, gender);
        }
    }
}
