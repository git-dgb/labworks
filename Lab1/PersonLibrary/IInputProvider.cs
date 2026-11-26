namespace PersonLibrary
{
    /// <summary>
    /// Определяет источник ввода строковых данных.
    /// </summary>
    public interface IInputProvider
    {
        /// <summary>
        /// Возвращает следующую строку ввода.
        /// </summary>
        string ReadLine();
    }
}
