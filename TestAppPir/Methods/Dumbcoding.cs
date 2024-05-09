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

        internal static string TokenNumberDecrypt(Guid id, string elem64)
        {
            // Валидация
            if (id == Guid.Empty || string.IsNullOrWhiteSpace(elem64))
            {
                return string.Empty;
            }

            string[] guidParts = id.ToString().Split('-');
            var plainTextBytes = Convert.FromBase64String(elem64);
            var data = Encoding.UTF8.GetString(plainTextBytes);
            string[] tockenNumberParts = data.Split("-");
            string ret= tockenNumberParts[2].Replace(guidParts[2], "").ToUpper();
            ret += '-'+tockenNumberParts[3];
            return ret;
        }
    }
}
