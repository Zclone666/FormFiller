using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppPir.Methods
{
    public static class Dumbcoding
    {
        public static string TokenNumberEncoding(Guid id, string elem)
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

            return result;
        }


        public static string TokenNumberDecoding(Guid id, string BadgeId)//Guid id, string elem)
        {
            string result = string.Empty;
            try
            {
                string plainText = Encoding.UTF8.GetString(Convert.FromBase64String(BadgeId));

                
                // Валидация
                if (id == Guid.Empty)
                {
                    return string.Empty;
                }

                string[] guidParts = id.ToString().Split('-');
              //  result = plainText.Split('-');
             //   string data = $"{guidParts[0]}-{guidParts[1]}-{guidParts[2]}{elem.ToLower()}-{guidParts[4]}";
             //   var plainTextBytes = Encoding.UTF8.GetBytes(data);

            //    result = Convert.ToBase64String(plainTextBytes);
            }
            catch (Exception ex)
            {
                // TODO: обработка ошибки
            }

            return result;
        }
    }
}
