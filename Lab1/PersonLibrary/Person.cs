namespace PersonLibrary
{
    /// <summary>
    /// Представляет человека и содержит методы для работы с его данными.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Ввод границ возраста в константы класса
        /// </summary>
        private const int MinAge = 18;
        private const int MaxAge = 100;

        /// <summary>
        /// Статические поля для хранения имён и фамилий
        /// </summary>
        private static readonly string[] MaleNames =
            {
                "Иван", "Александр", "Дмитрий", "Сергей", "Михаил",
                "Андрей", "Максим", "Артём", "Никита", "Владимир"
            };

        private static readonly string[] MaleSurnames =
            {
                "Иванов", "Петров", "Матвеев", "Смирнов", "Кузнецов",
                "Попов", "Васильев", "Соколов", "Михайлов", "Новиков"
            };

        private static readonly string[] FemaleNames =
            {
                "Алина", "Анна", "Екатерина", "Ольга", "Анастасия",
                "Елена", "Дарья", "Наталья", "София", "Виктория"
            };

        private static readonly string[] FemaleSurnames =
            {
                "Иванова", "Петрова", "Матвеева", "Смирнова", "Кузнецова",
                "Попова", "Васильева", "Соколова", "Михайлова", "Новикова"
            };

        //TODO: XML+
        /// <summary>
        /// Создание приватных полей класса.
        /// </summary>
        private string _firstName;
        private string _lastName;
        private int _age;
        //TODO: remove+

        /// <summary>
        /// Возвращает или задаёт имя человека.
        /// </summary>
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                //TODO: validation+
                if (!IsValidName(value))
                {
                    throw new ArgumentException(
                        "Имя может содержать только русские и " +
                        "английские буквы, пробелы и дефисы.",
                        nameof(value));
                }

                _firstName = NormalizeName(value);
            }
        }

        /// <summary>
        /// Возвращает или задаёт фамилию человека.
        /// </summary>
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                //TODO: validation+
                if (!IsValidName(value))
                {
                    throw new ArgumentException(
                        "Фамилия может содержать только русские и " +
                        "английские буквы, пробелы и дефисы.",
                        nameof(value));
                }

                _lastName = NormalizeName(value);
            }
        }

        /// <summary>
        /// Возвращает или задаёт возраст человека.
        /// </summary>
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                //TODO: validation
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "Возраст не может быть отрицательным.");
                }

                _age = value;
            }
        }


        /// <summary>
        /// Возвращает или задаёт пол человека.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Создаёт объект человека с заданными характеристиками.
        /// </summary>
        /// <param name="firstName">Имя человека.</param>
        /// <param name="lastName">Фамилия человека.</param>
        /// <param name="age">Возраст человека.</param>
        /// <param name="gender">Пол человека.</param>
        public Person(string firstName, string lastName, int age, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
        }

        //TODO: refactor
        /// <summary>
        /// Выводит информацию о человеке в консоль.
        /// </summary>
        public void Print()
        {
            Console.WriteLine(
                $"Имя: {FirstName}\n" +
                $"Фамилия: {LastName}\n" +
                $"Возраст: {Age}\n" +
                $"Пол: {Gender}\n");
        }

        //TODO: refactor
        /// <summary>
        /// Считывает данные о человеке с консоли.
        /// Проверяет корректность введённых значений.
        /// </summary>
        public void Read()
        {
            Console.WriteLine("Введите имя человека:");

            while (true)
            {
                string? input = Console.ReadLine();

                try
                {
                    FirstName = input!;
                    break;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Ошибка! Имя может содержать только" +
                        " русские и английские буквы, пробелы и дефисы.");
                }
            }

            Console.WriteLine("Введите фамилию человека:");

            while (true)
            {
                string? input = Console.ReadLine();

                if (IsValidName(input))
                {
                    LastName = NormalizeName(input!);
                    break;
                }

                Console.WriteLine(
                    "Ошибка! Фамилия может содержать только русские и английские буквы, пробелы и дефисы.");
            }

            Console.WriteLine("Введите возраст человека:");

            while (true)
            {
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int age))
                {
                    try
                    {
                        Age = age;
                        break;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Ошибка! Возраст не может быть отрицательным.");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите целое число.");
                }
            }

            Console.WriteLine("Введите пол человека (Male или Female):");
            Gender = Enum.Parse<Gender>(Console.ReadLine());
        }

        /// <summary>
        /// Создаёт человека со случайными характеристиками.
        /// </summary>
        /// <returns>Новый объект человека.</returns>
        public static Person GetRandomPerson()
        {
            Random random = new Random();
            //TODO: to const+
            int age = random.Next(MinAge, MaxAge + 1);

            //TODO: refactor+
            Gender gender = random.Next(2) == 0 ? Gender.Male : Gender.Female;

            string[] names = gender == Gender.Male ? MaleNames : FemaleNames;
            string[] surnames = gender == Gender.Male ? MaleSurnames : FemaleSurnames;

            int indexName = random.Next(names.Length);
            int indexSurname = random.Next(surnames.Length);

            string firstName = names[indexName];
            string lastName = surnames[indexSurname];

            return new Person(firstName, lastName, age, gender);
        }

        /// <summary>
        /// Проверяет, содержит ли строка допустимые символы для имени или фамилии.
        /// </summary>
        /// <param name="input">Проверяемая строка.</param>
        /// <returns>True, если строка корректна; иначе False.</returns>
        private static bool IsValidName(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            foreach (char symbol in input)
            {
                bool isRussian =
                    (symbol >= 'А' && symbol <= 'Я') 
                    || (symbol >= 'а' && symbol <= 'я') 
                    || symbol == 'Ё' || symbol == 'ё';

                bool isEnglish =
                    (symbol >= 'A' && symbol <= 'Z') 
                    || (symbol >= 'a' && symbol <= 'z');

                if (!isRussian && !isEnglish 
                    && symbol != ' ' && symbol != '-')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Приводит имя или фамилию к нормализованному регистру.
        /// Первая буква и буквы после пробела или дефиса становятся заглавными.
        /// </summary>
        /// <param name="input">Строка для нормализации.</param>
        /// <returns>Нормализованная строка.</returns>
        private static string NormalizeName(string input)
        {
            input = input.ToLower();

            string result = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (i == 0 || input[i - 1] == ' ' || input[i - 1] == '-')
                {
                    result += char.ToUpper(input[i]);
                }
                else
                {
                    result += input[i];
                }
            }

            return result;
        }
    }
}
