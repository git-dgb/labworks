namespace PersonLibrary
{
    /// <summary>
    /// Определяет приёмник строковых данных.
    /// </summary>
    public interface IOutputProvider
    {
        /// <summary>
        /// Выводит строку.
        /// </summary>
        /// <param name="text">Текст для вывода.</param>
        void WriteLine(string text);
    }
}