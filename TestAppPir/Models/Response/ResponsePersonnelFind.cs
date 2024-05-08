using TestAppPir.Models.Shared;

namespace TestAppPir.Models.Response
{
    /// <summary>
    /// Модель ответа
    /// </summary>
    public class ResponsePersonnelFind : ResponseBase
    {
        /// <summary>
        /// 
        /// </summary>
        public List<ItemPersonnel> Result { get; set; } = new();
    }
}
