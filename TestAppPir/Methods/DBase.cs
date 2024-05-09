using Microsoft.Data.Sqlite;
using Microsoft.Maui.Controls;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using TestAppPir.Models;

namespace TestAppPir.Methods
{
    public static class DBase
    {
        #region Constants
        private static readonly object locker = new object();
        /// <summary>
        /// Строка подключения к файлу БД, формируется при старте
        /// </summary>
        private static string connectionString;
        /// <summary>
        /// Путь к файлу БД
        /// </summary>
        private static string dbPath => Path.Combine(FileSystem.Current.AppDataDirectory, "data.db");

        /// <summary>
        /// Разделитель элементов в строке
        /// </summary>
        private const string delimitter = "_&_";
        private static readonly int delimitterLength = delimitter.Length;
        #endregion

        #region Utils
        /// <summary>
        /// Генерация пароля для файла БД на основе пароля пользователя и системной информации
        /// </summary>
        /// <param name="password">Пароль(пинкод) пользователя</param>
        /// <returns>Текст ошибки (null если её нет)</returns>
        private static string CreatePassword(string password)
        {
            string tmp = password;
            while (tmp.Length < 17) { tmp += tmp; }
            var bytetmp = new BitArray(Encoding.UTF8.GetBytes(tmp.Substring(0, 16)));
            tmp = "3a84309b81032b4a";
#if ANDROID
            tmp = Android.Provider.Settings.Secure.GetString(Android.App.Application.Context.ContentResolver, Android.Provider.Settings.Secure.AndroidId);
#endif
            bytetmp = bytetmp.Xor(new BitArray(Encoding.UTF8.GetBytes(tmp)));
            byte[] ret = new byte[(bytetmp.Length - 1) / 8 + 1];
            bytetmp.CopyTo(ret, 0);
            password += Convert.ToBase64String(ret).Replace("/", string.Empty).Replace("+", string.Empty).Replace("=", string.Empty);
            if (password.Length > 16) { return password.Substring(0, 16); }
            return password;
        }
        #endregion

        #region Initialization
        /// <summary>
        /// Инициализация класса для работы с БД
        /// </summary>
        /// <param name="password">Пароль(пинкод) пользователя</param>
        /// <returns>Текст ошибки (null если её нет)</returns>
        public static string Initialize(string password)
        {
            connectionString = new SqliteConnectionStringBuilder()
            {
                DataSource = dbPath,
                Mode = SqliteOpenMode.ReadWriteCreate,
                Password = CreatePassword(password),
                Cache = SqliteCacheMode.Private,
                ForeignKeys = true,
                Pooling = false
            }.ConnectionString;
            return createTable();
        }
        /// <summary>
        /// Создание таблиц если их нет (нужно при старте)
        /// </summary>
        /// <returns>Текст ошибки (null если её нет)</returns>
        private static string createTable()
        {
            if (File.Exists(dbPath)) { return null; }
            string ErrorMessage = null;
            lock (locker)
            {
                try
                {
                    using (SqliteConnection connection = new SqliteConnection(connectionString))
                    {
                        connection.Open();
                        using (SqliteCommand command = new SqliteCommand("CREATE TABLE 'personnel' ('id' INTEGER NOT NULL DEFAULT 1 UNIQUE, 'tokennumber' TEXT COLLATE NOCASE, 'callsign' TEXT COLLATE NOCASE, 'fio' TEXT COLLATE NOCASE, PRIMARY KEY('id' AUTOINCREMENT));", connection))
                        { command.ExecuteNonQuery(); }
                        using (SqliteCommand command = new SqliteCommand(@"CREATE TABLE 'facts' ('id' INTEGER NOT NULL DEFAULT 1 UNIQUE,'solderid' TEXT,'nickname' TEXT, 'fullname' TEXT,'name' TEXT,'surname' TEXT,'lastname' TEXT, 'destination' TEXT,
                                                                                                'woundtype' TEXT, 'woundclause' TEXT, 'wounddate' INTEGER, 'deathtime' INTEGER, 'helpprovided' TEXT, 'filename' TEXT, 'formid' INTEGER, 'complaints' TEXT,
                                                                                                'anamnesis' TEXT, 'objectively' TEXT, 'pharmacotherapy' TEXT, 'preliminarydiagnosis' TEXT, 'recommendations' TEXT, 'servicetype' TEXT, 'specialist' TEXT,
                                                                                                'situatedat' TEXT, 'recorddate' INTEGER, 'dateofservice' INTEGER, PRIMARY KEY('id'));", connection))
                        { command.ExecuteNonQuery(); }
                        connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }
            }
            return ErrorMessage;
        }

        #endregion

        #region Methods Facts
        private const string insertfactstring = "INSERT INTO facts(solderid, nickname, fullname, name, surname, lastname, destination, woundtype, woundclause, wounddate, deathtime, helpprovided, filename,"
                                                                        + "formid, complaints, anamnesis, objectively, pharmacotherapy, preliminarydiagnosis, recommendations, servicetype, specialist, situatedat, recorddate, dateofservice) VALUES (" +
                                                                        "@solderid, @nickname, @fullname, @name, @surname, @lastname, @destination, @woundtype, @woundclause, @wounddate, @deathtime, @helpprovided, @filename);"
                                                                        + "@formid, @complaints, @anamnesis, @objectively, @pharmacotherapy, @preliminarydiagnosis, @recommendations, @servicetype, @specialist, @situatedat, @recorddate, @dateofservice";
        /// <summary>
        /// Добавить событие в журнал
        /// </summary>
        /// <param name="casuelty">Событие</param>
        /// <returns>Текст ошибки (null если её нет)</returns>
        public static string InsertFact(Casuelty casuelty)
        {
            string ErrorMessage = null;
            string HelpProvided = string.Empty;
            if (casuelty.HelpProvided != null && casuelty.HelpProvided.Count > 0)
            {
                HelpProvided = string.Join(delimitter, casuelty.HelpProvided);
            }
            lock (locker)
            {
                try
                {
                    using (SqliteConnection connection = new SqliteConnection(connectionString))
                    {
                        connection.Open();
                        using (SqliteCommand command = new SqliteCommand(insertfactstring, connection))
                        {
                            command.Parameters.Add("@solderid", SqliteType.Text).Value = casuelty.SolderId ?? string.Empty;
                            command.Parameters.Add("@nickname", SqliteType.Text).Value = casuelty.NickName ?? string.Empty;
                            command.Parameters.Add("@fullname", SqliteType.Text).Value = casuelty.FullName ?? string.Empty;
                            command.Parameters.Add("@name", SqliteType.Text).Value = casuelty.Name ?? string.Empty;
                            command.Parameters.Add("@surname", SqliteType.Text).Value = casuelty.Surname ?? string.Empty;
                            command.Parameters.Add("@lastname", SqliteType.Text).Value = casuelty.LastName ?? string.Empty;
                            command.Parameters.Add("@destination", SqliteType.Text).Value = casuelty.Destination ?? string.Empty;
                            command.Parameters.Add("@woundtype", SqliteType.Text).Value = casuelty.WoundType ?? string.Empty;
                            command.Parameters.Add("@woundclause", SqliteType.Text).Value = casuelty.WoundClause ?? string.Empty;
                            command.Parameters.Add("@wounddate", SqliteType.Integer).Value = casuelty.WoundDate;
                            command.Parameters.Add("@deathtime", SqliteType.Integer).Value = casuelty.TimeOfDeath;
                            command.Parameters.Add("@helpprovided", SqliteType.Text).Value = HelpProvided ?? string.Empty;
                            command.Parameters.Add("@filename", SqliteType.Text).Value = casuelty.FileName ?? string.Empty;
                            command.Parameters.Add("@formid", SqliteType.Integer).Value = casuelty.FormId;
                            command.Parameters.Add("@complaints", SqliteType.Text).Value = casuelty.Complaints ?? string.Empty;
                            command.Parameters.Add("@anamnesis", SqliteType.Text).Value = casuelty.Anamnesis ?? string.Empty;
                            command.Parameters.Add("@objectively", SqliteType.Text).Value = casuelty.Objectively ?? string.Empty;
                            command.Parameters.Add("@pharmacotherapy", SqliteType.Text).Value = casuelty.Pharmacotherapy ?? string.Empty;
                            command.Parameters.Add("@preliminarydiagnosis", SqliteType.Text).Value = casuelty.Preliminary_diagnosis ?? string.Empty;
                            command.Parameters.Add("@recommendations", SqliteType.Text).Value = casuelty.Recommendations ?? string.Empty;
                            command.Parameters.Add("@servicetype", SqliteType.Text).Value = casuelty.ServiceType ?? string.Empty;
                            command.Parameters.Add("@specialist", SqliteType.Text).Value = casuelty.Specialist ?? string.Empty;
                            command.Parameters.Add("@situatedat", SqliteType.Text).Value = casuelty.SituatedAt ?? string.Empty;
                            command.Parameters.Add("@recorddate", SqliteType.Integer).Value = casuelty.RecordDate;
                            command.Parameters.Add("@dateofservice", SqliteType.Integer).Value = casuelty.DateOfService;
                            command.ExecuteNonQuery();
                        }
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }
            }
            return ErrorMessage;
        }


        /// <summary>
        /// Результат получения данных из журнала событий
        /// </summary>
        public class ArgsGetFacts
        {
            /// <summary>
            /// Текст ошибки (null если её нет)
            /// </summary>
            public string ErrorNessage;
            /// <summary>
            /// Список событий
            /// </summary>
            public List<Casuelty> results;
        }

        /// <summary>
        /// Получить все записи из журнала событий
        /// </summary>
        /// <returns>ArgsGetFacts</returns>
        public static ArgsGetFacts SelectFacts()
        {
            string ErrorMessage = null;
            List<Casuelty> results = new List<Casuelty>();
            lock (locker)
            {
                try
                {

                    using (SqliteConnection connection = new SqliteConnection(connectionString))
                    {
                        connection.Open();
                        using (SqliteCommand command = new SqliteCommand("SELECT * FROM facts;", connection)) //SELECT * FROM facts WHERE blablabla
                        {
                            connection.Open();
                            SqliteDataReader rdr = command.ExecuteReader();
                            while (rdr.Read())
                            {
                                var actions = (string)rdr["actions"];
                                List<string> HelpProvided = null;
                                if (!string.IsNullOrEmpty(actions) && actions.Length > delimitterLength)
                                {
                                    HelpProvided = actions.Split(delimitter, StringSplitOptions.RemoveEmptyEntries).ToList();
                                }

                                results.Add(new Casuelty()
                                {
                                    Id = Convert.ToInt32(rdr["id"]),
                                    SolderId = (string)rdr["solderid"],
                                    NickName = (string)rdr["nickname"],
                                    FullName = (string)rdr["fullname"],
                                    Name = (string)rdr["name"],
                                    Surname = (string)rdr["surname"],
                                    LastName = (string)rdr["lastname"],
                                    Destination = (string)rdr["destination"],
                                    WoundType = (string)rdr["woundtype"],
                                    WoundClause = (string)rdr["woundclause"],
                                    WoundDate = Convert.ToInt32(rdr["wounddate"]),
                                    TimeOfDeath = Convert.ToInt32(rdr["deathtime"]),
                                    HelpProvided = HelpProvided,
                                    FileName = (string)rdr["filename"],

                                    Anamnesis = (string)rdr["anamnesis"],
                                    Complaints = (string)rdr["complaints"],
                                    DateOfService = (int)rdr["dateofservice"],
                                    Objectively = (string)rdr["objectively"],
                                    FormId = (ushort)rdr["formid"],
                                    Pharmacotherapy = (string)rdr["pharmacotherapy"],
                                    Preliminary_diagnosis = (string)rdr["preliminarydiagnosis"],
                                    Recommendations = (string)rdr["recommendations"],
                                    RecordDate = (int)rdr["recorddate"],
                                    ServiceType = (string)rdr["servicetype"],
                                    SituatedAt = (string)rdr["situatedat"],
                                    Specialist = (string)rdr["specialist"]
                                });
                            }
                            connection.Close();
                        }
                        connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }
            }
            return new ArgsGetFacts()
            {
                ErrorNessage = ErrorMessage,
                results = results
            };
        }

        /// <summary>
        /// Удалить журнал событий
        /// </summary>
        /// <returns>Текст ошибки (null если её нет)</returns>
        public static string DropFacts()
        {
            string ErrorMessage = null;
            lock (locker)
            {
                try
                {
                    using (SqliteConnection connection = new SqliteConnection(connectionString))
                    {
                        connection.Open();
                        using (SqliteCommand command = new SqliteCommand("Delete FROM 'facts' ;", connection)) { command.ExecuteNonQuery(); }
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }
            }
            return ErrorMessage;
        }
        #endregion

        #region Methods Personnel

        /// <summary>
        /// Результат получения пациентов
        /// </summary>
        public class ArgsGetPersonnel
        {
            /// <summary>
            /// Текст ошибки (null если её нет)
            /// </summary>
            public string ErrorNessage;
            /// <summary>
            /// Список пациентов
            /// </summary>
            public List<Models.Shared.ItemPersonnel> results;
        }
        private const string insertPersonelWithId = "INSERT INTO personnel (id, tokennumber, callsign, fio) VALUES(@id, @tokennumber, @callsign, @fio) ON CONFLICT(id) DO UPDATE SET tokennumber = @tokennumber, callsign = @callsign, fio = @fio;";
        private const string insertPersonelWithoutId = "INSERT INTO personnel (tokennumber, callsign, fio) VALUES (@tokennumber, @callsign, @fio);";

        /// <summary>
        /// Добавить или обновить пациента. Добавление если id = 0.
        /// </summary>
        /// <param name="Item">Пациент</param>
        /// <returns>Текст ошибки (null если её нет)</returns>
        public static string UpsertPersonnel(Models.Shared.ItemPersonnel Item)
        {
            if (Item is null) { return null; }
            string ErrorMessage = null;
            lock (locker)
            {
                try
                {
                    string querry = insertPersonelWithoutId;
                    if (Item.Uid > 0) { querry = insertPersonelWithId; }
                    using (SqliteConnection connection = new SqliteConnection(connectionString))
                    {
                        connection.Open();
                        using (SqliteCommand command = new SqliteCommand(querry, connection))
                        {
                            if (Item.Uid > 0) { command.Parameters.Add("@id", SqliteType.Text).Value = Item.Id.ToString() ?? string.Empty; }
                            command.Parameters.Add("@tokennumber", SqliteType.Text).Value = Item.TokenNumber ?? string.Empty;
                            command.Parameters.Add("@callsign", SqliteType.Text).Value = Item.CallSign ?? string.Empty;
                            command.Parameters.Add("@fio", SqliteType.Text).Value = Item.FIO ?? string.Empty;
                            command.ExecuteNonQuery();
                        }
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }
            }
            return ErrorMessage;
        }

        /// <summary>
        /// Добавить или обновить пациентов списком. Добавление если id = 0.
        /// </summary>
        /// <param name="Items">Список пациентов</param>
        /// <returns>Текст ошибки (null если её нет)</returns>
        public static string UpsertPersonnel(List<Models.Shared.ItemPersonnel> Items)
        {
            if (Items is null || Items.Count == 0) { return null; }
            string ErrorMessage = null;
            List<Models.Shared.ItemPersonnel> itemsWithoutId = new List<Models.Shared.ItemPersonnel>();
            List<Models.Shared.ItemPersonnel> itemsWithId = new List<Models.Shared.ItemPersonnel>();
            foreach (var item in Items)
            {
                if (item.Uid > 0) { itemsWithId.Add(item); } else { itemsWithoutId.Add(item); }
            }

            lock (locker)
            {
                try
                {
                    using (SqliteConnection connection = new SqliteConnection(connectionString))
                    {
                        connection.Open();
                        using (var transaction = connection.BeginTransaction())
                        {
                            using (var command = connection.CreateCommand())
                            {
                                command.CommandText = insertPersonelWithId;

                                var idParameter = command.CreateParameter();
                                idParameter.ParameterName = "@id";
                                command.Parameters.Add(idParameter);

                                var tokennumberParameter = command.CreateParameter();
                                tokennumberParameter.ParameterName = "@tokennumber";
                                command.Parameters.Add(tokennumberParameter);

                                var callsignParameter = command.CreateParameter();
                                callsignParameter.ParameterName = "@callsign";
                                command.Parameters.Add(callsignParameter);

                                var fioParameter = command.CreateParameter();
                                fioParameter.ParameterName = "@fio";
                                command.Parameters.Add(fioParameter);

                                foreach (var item in Items)
                                {
                                    idParameter.Value = item.Uid.ToString() ?? string.Empty;
                                    callsignParameter.Value = item.CallSign.ToString() ?? string.Empty;
                                    tokennumberParameter.Value = item.TokenNumber ?? string.Empty;
                                    fioParameter.Value = item.FIO ?? string.Empty;
                                    command.ExecuteNonQuery();
                                }
                                transaction.Commit();
                            }
                        }
                        using (var transaction = connection.BeginTransaction())
                        {
                            using (var command = connection.CreateCommand())
                            {
                                command.CommandText = insertPersonelWithoutId;

                                var tokennumberParameter = command.CreateParameter();
                                tokennumberParameter.ParameterName = "@tokennumber";
                                command.Parameters.Add(tokennumberParameter);

                                var callsignParameter = command.CreateParameter();
                                callsignParameter.ParameterName = "@callsign";
                                command.Parameters.Add(callsignParameter);

                                var fioParameter = command.CreateParameter();
                                fioParameter.ParameterName = "@fio";
                                command.Parameters.Add(fioParameter);

                                foreach (var item in Items)
                                {
                                    callsignParameter.Value = item.CallSign.ToString() ?? string.Empty;
                                    tokennumberParameter.Value = item.TokenNumber ?? string.Empty;
                                    fioParameter.Value = item.FIO ?? string.Empty;
                                    command.ExecuteNonQuery();
                                }
                                transaction.Commit();
                            }
                        }

                        connection.Close();
                    }
                }
                catch (Exception ex) { 
                    ErrorMessage = ex.Message; }
            }
            return ErrorMessage;
        }

        /// <summary>
        /// Удалить всех пациентов
        /// </summary>
        /// <returns>Текст ошибки (null если её нет)</returns>
        public static string DropPersonnel()
        {
            string ErrorMessage = null;
            lock (locker)
            {
                try
                {
                    using (SqliteConnection connection = new SqliteConnection(connectionString))
                    {
                        connection.Open();
                        using (SqliteCommand command = new SqliteCommand("Delete FROM 'personnel' ;", connection)) { command.ExecuteNonQuery(); }
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }
            }
            return ErrorMessage;
        }

        /// <summary>
        /// Получить всех пациентов
        /// </summary>
        /// <returns>ArgsGetPersonnel</returns>
        public static ArgsGetPersonnel SelectPersonnel()
        {
            string ErrorMessage = null;
            List<Models.Shared.ItemPersonnel> results = new List<Models.Shared.ItemPersonnel>();
            lock (locker)
            {
                try
                {

                    using (SqliteConnection connection = new SqliteConnection(connectionString))
                    {
                        connection.Open();
                        using (SqliteCommand command = new SqliteCommand("SELECT * FROM personnel;", connection)) //SELECT * FROM facts WHERE blablabla
                        {
                            connection.Open();
                            SqliteDataReader rdr = command.ExecuteReader();
                            while (rdr.Read())
                            {
                                results.Add(new Models.Shared.ItemPersonnel()
                                {
                                    Uid = Convert.ToInt32(rdr["id"]),
                                    CallSign = (string)rdr["callsign"],
                                    FIO = (string)rdr["fio"],
                                    TokenNumber = (string)rdr["tokennumber"]
                                });
                            }
                            connection.Close();
                        }
                        connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }
            }
            return new ArgsGetPersonnel()
            {
                ErrorNessage = ErrorMessage,
                results = results
            };
        }

        /// <summary>
        /// Поучить пациента с указанным id
        /// </summary>
        /// <param name="Id">id пациента</param>
        /// <returns>ArgsGetPersonnel</returns>
        public static ArgsGetPersonnel SelectPersonnel(int Id)
        {
            string ErrorMessage = null;
            List<Models.Shared.ItemPersonnel> results = new List<Models.Shared.ItemPersonnel>();
            lock (locker)
            {
                try
                {

                    using (SqliteConnection connection = new SqliteConnection(connectionString))
                    {
                        connection.Open();
                        using (SqliteCommand command = new SqliteCommand($"SELECT * FROM personnel WHERE id = {Id};", connection))
                        {
                            connection.Open();
                            SqliteDataReader rdr = command.ExecuteReader();
                            while (rdr.Read())
                            {
                                results.Add(new Models.Shared.ItemPersonnel()
                                {
                                    Uid = Convert.ToInt32(rdr["id"]),
                                    CallSign = (string)rdr["callsign"],
                                    FIO = (string)rdr["fio"],
                                    TokenNumber = (string)rdr["tokennumber"]
                                });
                            }
                            connection.Close();
                        }
                        connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }
            }
            return new ArgsGetPersonnel()
            {
                ErrorNessage = ErrorMessage,
                results = results
            };
        }
        #endregion
    }
}
