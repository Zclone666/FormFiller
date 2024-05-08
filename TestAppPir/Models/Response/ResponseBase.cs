using TestAppPir.Interfaces;

namespace TestAppPir.Models.Response
{
    /// <summary>
    /// Модель ответа
    /// </summary>
    public class ResponseBase : IResponseBase
    {
        /// <summary>
        /// Коллекция параметров оповещения
        /// </summary>
        public Alert Alert { get; set; } = new Alert();
    }
}
