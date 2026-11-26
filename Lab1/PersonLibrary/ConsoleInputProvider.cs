using System;

namespace PersonLibrary
{
    /// <summary>
    /// Читает данные из консоли.
    /// </summary>
    public class ConsoleInputProvider : IInputProvider
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
