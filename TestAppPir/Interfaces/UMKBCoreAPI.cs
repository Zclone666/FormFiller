using Microsoft.Maui.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppPir.Interfaces
{
        public interface IResponseBase
        {
            //
            // Summary:
            //     Коллекция параметров оповещения
            Alert Alert { get; set; }
        }

    public class Alert
    {
        public static class Const
        {
            public static readonly string Code100 = "100";

            public static readonly string Code101 = "101";

            public static readonly string Code102 = "102";

            public static readonly string Code103 = "103";

            public static readonly string Code200 = "200";

            public static readonly string Code201 = "201";

            public static readonly string Code202 = "202";

            public static readonly string Code203 = "203";

            public static readonly string Code204 = "204";

            public static readonly string Code205 = "205";

            public static readonly string Code206 = "206";

            public static readonly string Code207 = "207";

            public static readonly string Code208 = "208";

            public static readonly string Code226 = "226";

            public static readonly string Code300 = "300";

            public static readonly string Code301 = "301";

            public static readonly string Code302 = "302";

            public static readonly string Code303 = "303";

            public static readonly string Code304 = "304";

            public static readonly string Code305 = "305";

            public static readonly string Code307 = "307";

            public static readonly string Code308 = "308";

            public static readonly string Code400 = "400";

            public static readonly string Code401 = "401";

            public static readonly string Code402 = "402";

            public static readonly string Code403 = "403";

            public static readonly string Code404 = "404";

            public static readonly string Code405 = "405";

            public static readonly string Code406 = "406";

            public static readonly string Code407 = "407";

            public static readonly string Code408 = "408";

            public static readonly string Code409 = "409";

            public static readonly string Code410 = "410";

            public static readonly string Code411 = "411";

            public static readonly string Code412 = "412";

            public static readonly string Code413 = "413";

            public static readonly string Code414 = "414";

            public static readonly string Code415 = "415";

            public static readonly string Code416 = "416";

            public static readonly string Code417 = "417";

            public static readonly string Code418 = "418";

            public static readonly string Code419 = "419";

            public static readonly string Code421 = "421";

            public static readonly string Code422 = "422";

            public static readonly string Code423 = "423";

            public static readonly string Code424 = "424";

            public static readonly string Code425 = "425";

            public static readonly string Code426 = "426";

            public static readonly string Code428 = "428";

            public static readonly string Code429 = "429";

            public static readonly string Code431 = "431";

            public static readonly string Code449 = "449";

            public static readonly string Code451 = "451";

            public static readonly string Code499 = "499";

            public static readonly string Code500 = "500";

            public static readonly string Code501 = "501";

            public static readonly string Code502 = "502";

            public static readonly string Code503 = "503";

            public static readonly string Code504 = "504";

            public static readonly string Code505 = "505";

            public static readonly string Code506 = "506";

            public static readonly string Code507 = "507";

            public static readonly string Code508 = "508";

            public static readonly string Code509 = "509";

            public static readonly string Code510 = "510";

            public static readonly string Code511 = "511";

            public static readonly string Code520 = "520";

            public static readonly string Code521 = "521";

            public static readonly string Code522 = "522";

            public static readonly string Code523 = "523";

            public static readonly string Code524 = "524";

            public static readonly string Code525 = "525";

            public static readonly string Code526 = "526";

            public static readonly string Title100 = "Continue";

            public static readonly string Title101 = "Switching Protocols";

            public static readonly string Title102 = "Processing";

            public static readonly string Title103 = "Early Hints";

            public static readonly string Title200 = "OK";

            public static readonly string Title201 = "Created";

            public static readonly string Title202 = "Accepted";

            public static readonly string Title203 = "Non-Authoritative Information";

            public static readonly string Title204 = "No Content";

            public static readonly string Title205 = "Reset Content";

            public static readonly string Title206 = "Partial Content";

            public static readonly string Title207 = "Multi-Status";

            public static readonly string Title208 = "Already Reported";

            public static readonly string Title226 = "IM Used";

            public static readonly string Title300 = "Multiple Choices";

            public static readonly string Title301 = "Moved Permanently";

            public static readonly string Title302 = "Moved Temporarily";

            public static readonly string Title303 = "See Other";

            public static readonly string Title304 = "Not Modified";

            public static readonly string Title305 = "Use Proxy";

            public static readonly string Title307 = "Temporary Redirect";

            public static readonly string Title308 = "Permanent Redirect";

            public static readonly string Title400 = "Bad Request";

            public static readonly string Title401 = "Unauthorized";

            public static readonly string Title402 = "Payment Required";

            public static readonly string Title403 = "Forbidden";

            public static readonly string Title404 = "Not Found";

            public static readonly string Title405 = "Method Not Allowed";

            public static readonly string Title406 = "Not Acceptable";

            public static readonly string Title407 = "Proxy Authentication Required";

            public static readonly string Title408 = "Request Timeout";

            public static readonly string Title409 = "Conflict";

            public static readonly string Title410 = "Gone";

            public static readonly string Title411 = "Length Required";

            public static readonly string Title412 = "Precondition Failed";

            public static readonly string Title413 = "Payload Too Large";

            public static readonly string Title414 = "URI Too Long";

            public static readonly string Title415 = "Unsupported Media Type";

            public static readonly string Title416 = "Range Not Satisfiable";

            public static readonly string Title417 = "Expectation Failed";

            public static readonly string Title418 = "I’m a teapot";

            public static readonly string Title419 = "Authentication Timeout (not in RFC 2616)";

            public static readonly string Title421 = "Misdirected Request";

            public static readonly string Title422 = "Unprocessable Entity";

            public static readonly string Title423 = "Locked";

            public static readonly string Title424 = "Failed Dependency";

            public static readonly string Title425 = "Too Early";

            public static readonly string Title426 = "Upgrade Required";

            public static readonly string Title428 = "Precondition Required";

            public static readonly string Title429 = "Too Many Requests";

            public static readonly string Title431 = "Request Header Fields Too Large";

            public static readonly string Title449 = "Retry With";

            public static readonly string Title451 = "Unavailable For Legal Reasons";

            public static readonly string Title499 = "Client Closed Request";

            public static readonly string Title500 = "Public Server Error";

            public static readonly string Title501 = "Not Implemented";

            public static readonly string Title502 = "Bad Gateway";

            public static readonly string Title503 = "Service Unavailable";

            public static readonly string Title504 = "Gateway Timeout";

            public static readonly string Title505 = "HTTP Version Not Supported";

            public static readonly string Title506 = "Variant Also Negotiates";

            public static readonly string Title507 = "Insufficient Storage";

            public static readonly string Title508 = "Loop Detected";

            public static readonly string Title509 = "Bandwidth Limit Exceeded";

            public static readonly string Title510 = "Not Extended";

            public static readonly string Title511 = "Network Authentication Required";

            public static readonly string Title520 = "Unknown Error";

            public static readonly string Title521 = "Web Server Is Down";

            public static readonly string Title522 = "Connection Timed Out";

            public static readonly string Title523 = "Origin Is Unreachable";

            public static readonly string Title524 = "A Timeout Occurred";

            public static readonly string Title525 = "SSL Handshake Failed";

            public static readonly string Title526 = "Invalid SSL Certificate";

            //
            // Summary:
            //     Ошибка
            public static readonly string LevelError = "error";

            //
            // Summary:
            //     Предупреждение
            public static readonly string LevelWarning = "warning";

            //
            // Summary:
            //     Информация
            public static readonly string LevelInfo = "info";

            //
            // Summary:
            //     Успешно
            public static readonly string LevelSuccess = "success";
        }

        //
        // Summary:
        //     Код ошибки
        public string Code { get; set; }

        //
        // Summary:
        //     Код ошибки API обработки самого запроса.
        public int ActionCode { get; set; }

        //
        // Summary:
        //     Заголовок
        public string Title { get; set; }

        //
        // Summary:
        //     Описание ошибки
        public string Message { get; set; }

        //
        // Summary:
        //     Тип сообщения, влияет на внешний вид сообщения, по умолчанию error. Возможные
        //     варианты: error-ошибка, success-успех, info-информация, danger-опасность
        public string Level { get; set; }

        //
        // Summary:
        //     Должно ли сообщение само пропасть, через несколько секунд. true - зафиксированное
        //     сообщение. По умолчанию false.
        public bool Sticky { get; set; }

        public void Ok(string message = null)
        {
            Code = Const.Code200;
            Title = Const.Title200;
            Level = Const.LevelSuccess;
            Message = message;
            Sticky = false;
        }

        public void BadRequest(string message = null, bool sticky = true)
        {
            Code = Const.Code400;
            Title = Const.Title400;
            Level = Const.LevelError;
            Message = message;
            Sticky = sticky;
        }

        public void Forbidden(string message = null, bool sticky = true)
        {
            Code = Const.Code403;
            Title = Const.Title403;
            Level = Const.LevelError;
            Message = message;
            Sticky = sticky;
        }

        public void InternalError(string message = null, bool sticky = true)
        {
            Code = Const.Code500;
            Title = Const.Title500;
            Level = Const.LevelError;
            Message = message;
            Sticky = sticky;
        }

        public void Accepted(string message, bool sticky = false)
        {
            Code = Const.Code202;
            Title = Const.Title202;
            Level = Const.LevelSuccess;
            Message = message;
            Sticky = sticky;
        }

        public void ServiceUnavailable(string message = "Сервис временно недоступен", bool sticky = true)
        {
            Code = Const.Code503;
            Title = Const.Title503;
            Level = Const.LevelError;
            Message = message;
            Sticky = sticky;
        }

        public static Alert GetOk(string message = "Успешный запрос.", string title = "OK", int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code200,
                Title = title,
                ActionCode = actionCode,
                Message = message,
                Level = Const.LevelSuccess,
                Sticky = false
            };
        }

        public static Alert GetAccepted(string message = "Запрос был принят на обработку, но она не завершена. Клиенту не обязательно дожидаться окончательной передачи сообщения, так как может быть начат очень долгий процесс.", string title = "Accepted", int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code202,
                ActionCode = actionCode,
                Title = title,
                Message = message,
                Level = Const.LevelSuccess,
                Sticky = false
            };
        }

        public static Alert GetBadRequest(string message = "Сервер обнаружил в запросе клиента синтаксическую ошибку.", string title = "Bad Request", bool sticky = true, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code400,
                ActionCode = actionCode,
                Title = title,
                Message = message,
                Level = Const.LevelError,
                Sticky = sticky
            };
        }

        public static Alert GetUnauthorized(string message = "Не авторизован.", string title = "Unauthorized", bool sticky = true, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code401,
                ActionCode = actionCode,
                Title = title,
                Message = message,
                Level = Const.LevelError,
                Sticky = sticky
            };
        }

        public static Alert GetForbidden(string message = "Запрещено.", bool sticky = true, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code403,
                ActionCode = actionCode,
                Title = Const.Title403,
                Level = Const.LevelError,
                Message = message,
                Sticky = sticky
            };
        }

        public static Alert GetInternalError(string message = "Внутренняя ошибка сервера, которая не входит в рамки остальных ошибок класса.", string title = "Internal Server Error", bool sticky = true, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code500,
                ActionCode = actionCode,
                Title = title,
                Message = message,
                Level = Const.LevelError,
                Sticky = sticky
            };
        }

        public static Alert GetServiceUnavailable(string message = "Сервис временно недоступен", bool sticky = true, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code503,
                ActionCode = actionCode,
                Title = Const.Title503,
                Level = Const.LevelError,
                Message = message,
                Sticky = sticky
            };
        }

        //
        // Summary:
        //     100 Continue (Продолжай)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode100(string message = "Продолжай", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code100,
                Level = Const.LevelInfo,
                Message = message,
                Sticky = stycky,
                Title = Const.Title100,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     101 Switching Protocols (Переключение протоколов)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode101(string message = "Переключение протоколов", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code101,
                Level = Const.LevelInfo,
                Message = message,
                Sticky = stycky,
                Title = Const.Title101,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     102 Processing (Идёт обработка)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode102(string message = "Идёт обработка", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code102,
                Level = Const.LevelInfo,
                Message = message,
                Sticky = stycky,
                Title = Const.Title102,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     103 Early Hints (Ранняя метаинформация)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode103(string message = "Ранняя метаинформация", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code103,
                Level = Const.LevelInfo,
                Message = message,
                Sticky = stycky,
                Title = Const.Title103,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     200 OK (Хорошо)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode200(string message = "", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code200,
                Level = Const.LevelSuccess,
                Message = message,
                Sticky = stycky,
                Title = Const.Title200,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     201 Created (Создано)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode201(string message = "Создано", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code201,
                Level = Const.LevelSuccess,
                Message = message,
                Sticky = stycky,
                Title = Const.Title201,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     202 Accepted (Принято)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode202(string message = "Принято", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code202,
                Level = Const.LevelSuccess,
                Message = message,
                Sticky = stycky,
                Title = Const.Title202,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     203 Non-Authoritative Information (Информация не авторитетна)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode203(string message = "Информация не авторитетна", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code203,
                Level = Const.LevelSuccess,
                Message = message,
                Sticky = stycky,
                Title = Const.Title203,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     204 No Content (Нет содержимого)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode204(string message = "Нет содержимого", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code204,
                Level = Const.LevelSuccess,
                Message = message,
                Sticky = stycky,
                Title = Const.Title204,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     205 Reset Content (Сбросить содержимое)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode205(string message = "Сбросить содержимое", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code205,
                Level = Const.LevelSuccess,
                Message = message,
                Sticky = stycky,
                Title = Const.Title205,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     206 Partial Content (Частичное содержимое)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode206(string message = "Частичное содержимое", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code206,
                Level = Const.LevelSuccess,
                Message = message,
                Sticky = stycky,
                Title = Const.Title206,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     207 Multi-Status (Многостатусный)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode207(string message = "Многостатусный", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code207,
                Level = Const.LevelSuccess,
                Message = message,
                Sticky = stycky,
                Title = Const.Title207,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     208 Already Reported (Уже сообщалось)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode208(string message = "Уже сообщалось", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code208,
                Level = Const.LevelSuccess,
                Message = message,
                Sticky = stycky,
                Title = Const.Title208,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     226 IM Used (Использовано IM)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode226(string message = "Использовано IM", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code226,
                Level = Const.LevelSuccess,
                Message = message,
                Sticky = stycky,
                Title = Const.Title226,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     300 Multiple Choices (Множество выборов)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode300(string message = "Множество выборов", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code300,
                Level = Const.LevelInfo,
                Message = message,
                Sticky = stycky,
                Title = Const.Title300,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     301 Moved Permanently (Перемещено навсегда)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode301(string message = "Перемещено навсегда", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code301,
                Level = Const.LevelInfo,
                Message = message,
                Sticky = stycky,
                Title = Const.Title301,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     302 Moved Temporarily (Перемещено временно)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode302(string message = "Перемещено временно", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code302,
                Level = Const.LevelInfo,
                Message = message,
                Sticky = stycky,
                Title = Const.Title302,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     303 See Other (Смотреть другое)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode303(string message = "Смотреть другое", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code303,
                Level = Const.LevelInfo,
                Message = message,
                Sticky = stycky,
                Title = Const.Title303,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     304 Not Modified (Не изменялось)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode304(string message = "Не изменялось", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code304,
                Level = Const.LevelInfo,
                Message = message,
                Sticky = stycky,
                Title = Const.Title304,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     305 Use Proxy (Использовать прокси)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode305(string message = "Использовать прокси", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code305,
                Level = Const.LevelInfo,
                Message = message,
                Sticky = stycky,
                Title = Const.Title305,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     307 Temporary Redirect (Временное перенаправление)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode307(string message = "Временное перенаправление", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code307,
                Level = Const.LevelInfo,
                Message = message,
                Sticky = stycky,
                Title = Const.Title307,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     308 Permanent Redirect (Постоянное перенаправление)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode308(string message = "Постоянное перенаправление", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code308,
                Level = Const.LevelInfo,
                Message = message,
                Sticky = stycky,
                Title = Const.Title308,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     400 Bad Request (Неправильный, некорректный запрос)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode400(string message = "Неправильный, некорректный запрос", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code400,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title400,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     401 Unauthorized (Не авторизован)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode401(string message = "Не авторизован", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code401,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title401,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     402 Payment Required (Необходима оплата)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode402(string message = "Необходима оплата", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code402,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title402,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     403 Forbidden (Запрещено)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode403(string message = "Запрещено", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code403,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title403,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     404 Not Found (Не найдено)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode404(string message = "Не найдено", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code404,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title404,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     405 Method Not Allowed (Метод не поддерживается)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode405(string message = "Метод не поддерживается", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code405,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title405,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     406 Not Acceptable (Неприемлемо)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode406(string message = "Неприемлемо", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code406,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title406,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     407 Proxy Authentication Required (Необходима аутентификация прокси)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode407(string message = "Необходима аутентификация прокси", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code407,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title407,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     408 Request Timeout (Истекло время ожидания)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode408(string message = "Истекло время ожидания", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code408,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title408,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     409 Conflict (Конфликт)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode409(string message = "Конфликт", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code409,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title409,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     410 Gone (Удалён)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode410(string message = "Удалён", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code410,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title410,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     411 Length Required ()
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode411(string message = "", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code411,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title411,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     412 Precondition Failed (Условие ложно)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode412(string message = "Условие ложно", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code412,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title412,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     413 Payload Too Large (Полезная нагрузка слишком велика)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode413(string message = "Полезная нагрузка слишком велика", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code413,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title413,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     414 URI Too Long (URI слишком длинный)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode414(string message = "URI слишком длинный", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code414,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title414,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     415 Unsupported Media Type (Неподдерживаемый тип данных)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode415(string message = "Неподдерживаемый тип данных", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code415,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title415,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     416 Range Not Satisfiable (Диапазон не достижим)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode416(string message = "Диапазон не достижим", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code416,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title416,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     417 Expectation Failed (Ожидание не удалось)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode417(string message = "Ожидание не удалось", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code417,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title417,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     418 I’m a teapot (я — чайник)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode418(string message = "я — чайник", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code418,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title418,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     419 Authentication Timeout (not in RFC 2616) (Обычно ошибка проверки CSRF)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode419(string message = "Обычно ошибка проверки CSRF", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code419,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title419,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     421 Misdirected Request ()
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode421(string message = "", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code421,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title421,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     422 Unprocessable Entity (Необрабатываемый экземпляр)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode422(string message = "Необрабатываемый экземпляр", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code422,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title422,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     423 Locked (Заблокировано)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode423(string message = "Заблокировано", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code423,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title423,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     424 Failed Dependency (Невыполненная зависимость)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode424(string message = "Невыполненная зависимость", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code424,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title424,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     425 Too Early (Слишком рано)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode425(string message = "Слишком рано", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code425,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title425,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     426 Upgrade Required (Необходимо обновление)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode426(string message = "Необходимо обновление", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code426,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title426,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     428 Precondition Required (Необходимо предусловие)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode428(string message = "Необходимо предусловие", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code428,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title428,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     429 Too Many Requests (Слишком много запросов)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode429(string message = "Слишком много запросов", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code429,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title429,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     431 Request Header Fields Too Large (Поля заголовка запроса слишком большие)
        //
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode431(string message = "Поля заголовка запроса слишком большие", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code431,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title431,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     449 Retry With (Повторить с)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode449(string message = "Повторить с", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code449,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title449,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     451 Unavailable For Legal Reasons (Недоступно по юридическим причинам)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode451(string message = "Недоступно по юридическим причинам", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code451,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title451,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     499 Client Closed Request (Клиент закрыл соединение)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode499(string message = "Клиент закрыл соединение", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code499,
                Level = Const.LevelWarning,
                Message = message,
                Sticky = stycky,
                Title = Const.Title499,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     500 public Server Error (Внутренняя ошибка сервера)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode500(string message = "Внутренняя ошибка сервера", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code500,
                Level = Const.LevelError,
                Message = message,
                Sticky = stycky,
                Title = Const.Title500,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     501 Not Implemented (Не реализовано)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode501(string message = "Не реализовано", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code501,
                Level = Const.LevelError,
                Message = message,
                Sticky = stycky,
                Title = Const.Title501,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     502 Bad Gateway (Плохой, ошибочный шлюз)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode502(string message = "Плохой, ошибочный шлюз", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code502,
                Level = Const.LevelError,
                Message = message,
                Sticky = stycky,
                Title = Const.Title502,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     503 Service Unavailable (Сервис недоступен)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode503(string message = "Сервис недоступен", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code503,
                Level = Const.LevelError,
                Message = message,
                Sticky = stycky,
                Title = Const.Title503,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     504 Gateway Timeout (Шлюз не отвечает)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode504(string message = "Шлюз не отвечает", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code504,
                Level = Const.LevelError,
                Message = message,
                Sticky = stycky,
                Title = Const.Title504,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     505 HTTP Version Not Supported (Версия HTTP не поддерживается)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode505(string message = "Версия HTTP не поддерживается", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code505,
                Level = Const.LevelError,
                Message = message,
                Sticky = stycky,
                Title = Const.Title505,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     506 Variant Also Negotiates (Вариант тоже проводит согласование)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode506(string message = "Вариант тоже проводит согласование", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code506,
                Level = Const.LevelError,
                Message = message,
                Sticky = stycky,
                Title = Const.Title506,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     507 Insufficient Storage (Переполнение хранилища)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode507(string message = "Переполнение хранилища", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code507,
                Level = Const.LevelError,
                Message = message,
                Sticky = stycky,
                Title = Const.Title507,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     508 Loop Detected (Обнаружено бесконечное перенаправление)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode508(string message = "Обнаружено бесконечное перенаправление", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code508,
                Level = Const.LevelError,
                Message = message,
                Sticky = stycky,
                Title = Const.Title508,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     509 Bandwidth Limit Exceeded (Исчерпана пропускная ширина канала)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode509(string message = "Исчерпана пропускная ширина канала", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code509,
                Level = Const.LevelError,
                Message = message,
                Sticky = stycky,
                Title = Const.Title509,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     510 Not Extended (Не расширено)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode510(string message = "Не расширено", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code510,
                Level = Const.LevelError,
                Message = message,
                Sticky = stycky,
                Title = Const.Title510,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     511 Network Authentication Required (Требуется сетевая аутентификация)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode511(string message = "Требуется сетевая аутентификация", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code511,
                Level = Const.LevelError,
                Message = message,
                Sticky = stycky,
                Title = Const.Title511,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     520 Unknown Error (Неизвестная ошибка)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode520(string message = "Неизвестная ошибка", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code520,
                Level = Const.LevelError,
                Message = message,
                Sticky = stycky,
                Title = Const.Title520,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     521 Web Server Is Down (Веб-сервер не работает)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode521(string message = "Веб-сервер не работает", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code521,
                Level = Const.LevelError,
                Message = message,
                Sticky = stycky,
                Title = Const.Title521,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     522 Connection Timed Out (Соединение не отвечает)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode522(string message = "Соединение не отвечает", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code522,
                Level = Const.LevelError,
                Message = message,
                Sticky = stycky,
                Title = Const.Title522,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     523 Origin Is Unreachable (Источник недоступен)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode523(string message = "Источник недоступен", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code523,
                Level = Const.LevelError,
                Message = message,
                Sticky = stycky,
                Title = Const.Title523,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     524 A Timeout Occurred (Время ожидания истекло)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode524(string message = "Время ожидания истекло", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code524,
                Level = Const.LevelError,
                Message = message,
                Sticky = stycky,
                Title = Const.Title524,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     525 SSL Handshake Failed (Квитирование SSL не удалось)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode525(string message = "Квитирование SSL не удалось", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code525,
                Level = Const.LevelError,
                Message = message,
                Sticky = stycky,
                Title = Const.Title525,
                ActionCode = actionCode
            };
        }

        //
        // Summary:
        //     526 Invalid SSL Certificate (Недействительный сертификат SSL)
        //
        // Parameters:
        //   message:
        //     Текст сообщения
        //
        //   stycky:
        //     Должно ли сообщение само пропасть, через несколько секунд
        //
        //   actionCode:
        //     Код действия
        //
        // Returns:
        //     Уведомление
        public static Alert GetCode526(string message = "Недействительный сертификат SSL", bool stycky = false, int actionCode = 0)
        {
            return new Alert
            {
                Code = Const.Code526,
                Level = Const.LevelError,
                Message = message,
                Sticky = stycky,
                Title = Const.Title526,
                ActionCode = actionCode
            };
        }
    }
}
