using Newtonsoft.Json.Linq;
using TestAppPir.Interfaces.Pk;
using System.Text;

namespace TestAppPir.Models.Shared
{
    /// <summary>
    /// Модель элемента личного состава
    /// </summary>
    public class ItemPersonnel : IPkGuid
    {
        /// <summary>
        /// Уникальный идентификационный номер записи
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Личный номер
        /// </summary>
        public string TokenNumber { get; set; } = string.Empty;

        /// <summary>
        /// Позывной
        /// </summary>
        public string CallSign { get; set; } = string.Empty;

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; } = string.Empty;

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; } = string.Empty;


        /// <summary>
        /// Шифрование строки с отображением первого символа и последнего
        /// </summary>
        /// <param name="elem">Входная строка</param>
        /// <returns>Выходная строка</returns>
        internal static string CryptoField (string elem)
        {
            var crypto = "**********";
            // Валидация
            if (string.IsNullOrWhiteSpace(elem))
            {
                return crypto;
            }

            var firstChar = elem.Substring(0, 1);
            var lastChar = elem.Substring(elem.Length - 1, 1);
            

            return $"{firstChar}{crypto}{lastChar}";
        }

        /// <summary>
        /// Выбор первого символа из строки
        /// </summary>
        /// <param name="elem">Входная строка</param>
        /// <returns>Выходная строка</returns>
        internal static string Initial(string elem)
        {
            // Валидация
            if (string.IsNullOrWhiteSpace(elem))
            {
                return string.Empty;
            }

            return $"{elem.Substring(0, 1)}.";
        }

        /// <summary>
        /// Кодирование входной строки по уникальному идентификационный номер записи
        /// </summary>
        /// <param name="id">уникальный идентификационный номер записи</param>
        /// <param name="elem">Входная строка</param>
        /// <returns>Выходная строка</returns>
        internal static string TokenNumberEncoding(Guid id, string elem)
        {
            string result = string.Empty;
            try
            {
                // Валидация
                if (id == Guid.Empty || string.IsNullOrWhiteSpace(elem))
                {
                    return string.Empty;
                }

                string[] guidParts = id.ToString().Split('-');
                string data = $"{guidParts[0]}-{guidParts[1]}-{guidParts[2]}{elem.ToLower()}-{guidParts[4]}";
                var plainTextBytes = Encoding.UTF8.GetBytes(data);

                result = Convert.ToBase64String(plainTextBytes);
            }
            catch (Exception ex)
            {
                // TODO: обработка ошибки
            }

            return result ;
        }
    }
}
