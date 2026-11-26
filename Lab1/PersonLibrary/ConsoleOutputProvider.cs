using System;

namespace PersonLibrary
{
    /// <summary>
    /// Выводит данные в консоль.
    /// </summary>
    public class ConsoleOutputProvider : IOutputProvider
    {
        /// <summary>
        /// Выводит строку в консоль.
        /// </summary>
        /// <param name="text">Текст для вывода.</param>
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
