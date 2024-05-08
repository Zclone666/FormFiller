namespace TestAppPir.Interfaces.Pk
{
    /// <summary>
    /// Интерфейс ключевых полей
    /// </summary>
    public interface IPkGuid
    {
        /// <summary>
        /// Уникальный идентификационный номер записи
        /// </summary>
        Guid Id { get; set; }
    }
}
