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
        private const string insertfactstring = "INSERT INTO facts("
                    + "solderid, nickname, fullname, name, surname, lastname, destination, woundtype, woundclause, wounddate, deathtime, helpprovided, filename, formid, complaints, anamnesis, objectively, pharmacotherapy, preliminarydiagnosis, recommendations, servicetype, specialist, situatedat, recorddate, dateofservice" +
                    ") VALUES ("
                    + "@solderid, @nickname, @fullname, @name, @surname, @lastname, @destination, @woundtype, @woundclause, @wounddate, @deathtime, @helpprovided, @filename, @formid, @complaints, @anamnesis, @objectively, @pharmacotherapy, @preliminarydiagnosis, @recommendations, @servicetype, @specialist, @situatedat, @recorddate, @dateofservice);";
        /// <summary>
        /// Добавить событие в журнал
        /// </summary>
        /// <param name="casuelty">Событие</param>
        /// <returns>Текст ошибки (null если её нет)</returns>
        public static string InsertFact(Casuelty casuelty)
        {
            if (casuelty is null) { return null; }
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
        /// Добавить события в журнал
        /// </summary>
        /// <param name="casuelty">Список событий, алгоритм операции (не обязательно)</param>
        /// <returns>Текст ошибки (null если её нет)</returns>
        public static string InsertFact(List<Casuelty> Casuelty, bool Isolate = false)
        {
            if (Casuelty is null || Casuelty.Count == 0) { return null; }
            if (Casuelty.Count == 1) { return InsertFact(Casuelty[0]); }
            if (Isolate) { return (InsertFactIsolate(Casuelty)); } else { return InsertFactMerging(Casuelty); }
        }

        /// <summary>
        /// Добавить события в журнал (без транзакции списком команд)
        /// </summary>
        /// <param name="casuelty">Список событий</param>
        /// <returns>Текст ошибки (null если её нет)</returns>
        private static string InsertFactIsolate(List<Casuelty> Casuelty)
        {
            string ErrorMessage = null;

            lock (locker)
            {
                try
                {
                    using (SqliteConnection connection = new SqliteConnection(connectionString))
                    {
                        connection.Open();
                        foreach (var casuelty in Casuelty)
                        {
                            string HelpProvided = string.Empty;
                            if (casuelty.HelpProvided != null && casuelty.HelpProvided.Count > 0)
                            {
                                HelpProvided = string.Join(delimitter, casuelty.HelpProvided);
                            }
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
        /// Добавить события в журнал (одной транзакцией через список параметров)
        /// </summary>
        /// <param name="casuelty">Список событий</param>
        /// <returns>Текст ошибки (null если её нет)</returns>
        private static string InsertFactMerging(List<Casuelty> Casuelty)
        {
            string ErrorMessage = null;
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
                                command.CommandText = insertfactstring;

                                #region создание параметров
                                var solderidParameter = command.CreateParameter();
                                solderidParameter.ParameterName = "@solderid";
                                solderidParameter.DbType = System.Data.DbType.String;
                                command.Parameters.Add(solderidParameter);

                                var nicknameParameter = command.CreateParameter();
                                nicknameParameter.ParameterName = "@nickname";
                                nicknameParameter.DbType = System.Data.DbType.String;
                                command.Parameters.Add(nicknameParameter);

                                var fullnameParameter = command.CreateParameter();
                                fullnameParameter.ParameterName = "@fullname";
                                fullnameParameter.DbType = System.Data.DbType.String;
                                command.Parameters.Add(fullnameParameter);

                                var nameParameter = command.CreateParameter();
                                nameParameter.DbType = System.Data.DbType.String;
                                nameParameter.ParameterName = "@name";
                                command.Parameters.Add(nameParameter);

                                var surnameParameter = command.CreateParameter();
                                surnameParameter.ParameterName = "@surname";
                                surnameParameter.DbType = System.Data.DbType.String;
                                command.Parameters.Add(surnameParameter);

                                var lastnameParameter = command.CreateParameter();
                                lastnameParameter.ParameterName = "@lastname";
                                lastnameParameter.DbType = System.Data.DbType.String;
                                command.Parameters.Add(lastnameParameter);

                                var destinationParameter = command.CreateParameter();
                                destinationParameter.ParameterName = "@destination";
                                destinationParameter.DbType = System.Data.DbType.String;
                                command.Parameters.Add(destinationParameter);

                                var woundtypeParameter = command.CreateParameter();
                                woundtypeParameter.ParameterName = "@woundtype";
                                woundtypeParameter.DbType = System.Data.DbType.String;
                                command.Parameters.Add(woundtypeParameter);

                                var woundclauseParameter = command.CreateParameter();
                                woundclauseParameter.ParameterName = "@woundclause";
                                woundclauseParameter.DbType = System.Data.DbType.String;
                                command.Parameters.Add(woundclauseParameter);

                                var wounddateParameter = command.CreateParameter();
                                wounddateParameter.ParameterName = "@wounddate";
                                wounddateParameter.DbType = System.Data.DbType.Int32;
                                command.Parameters.Add(wounddateParameter);

                                var deathtimeParameter = command.CreateParameter();
                                deathtimeParameter.ParameterName = "@deathtime";
                                deathtimeParameter.DbType = System.Data.DbType.Int32;
                                command.Parameters.Add(deathtimeParameter);

                                var helpprovidedParameter = command.CreateParameter();
                                helpprovidedParameter.ParameterName = "@helpprovided";
                                helpprovidedParameter.DbType = System.Data.DbType.String;
                                command.Parameters.Add(helpprovidedParameter);

                                var filenameParameter = command.CreateParameter();
                                filenameParameter.ParameterName = "@filename";
                                filenameParameter.DbType = System.Data.DbType.String;
                                command.Parameters.Add(filenameParameter);

                                var formidParameter = command.CreateParameter();
                                formidParameter.ParameterName = "@formid";
                                formidParameter.DbType = System.Data.DbType.UInt16;
                                command.Parameters.Add(formidParameter);

                                var complaintsParameter = command.CreateParameter();
                                complaintsParameter.ParameterName = "@complaints";
                                complaintsParameter.DbType = System.Data.DbType.String;
                                command.Parameters.Add(complaintsParameter);

                                var anamnesisParameter = command.CreateParameter();
                                anamnesisParameter.ParameterName = "@anamnesis";
                                anamnesisParameter.DbType = System.Data.DbType.String;
                                command.Parameters.Add(anamnesisParameter);

                                var objectivelyParameter = command.CreateParameter();
                                objectivelyParameter.ParameterName = "@objectively";
                                objectivelyParameter.DbType = System.Data.DbType.String;
                                command.Parameters.Add(objectivelyParameter);

                                var pharmacotherapyParameter = command.CreateParameter();
                                pharmacotherapyParameter.ParameterName = "@pharmacotherapy";
                                pharmacotherapyParameter.DbType = System.Data.DbType.String;
                                command.Parameters.Add(pharmacotherapyParameter);

                                var preliminarydiagnosisParameter = command.CreateParameter();
                                preliminarydiagnosisParameter.ParameterName = "@preliminarydiagnosis";
                                preliminarydiagnosisParameter.DbType = System.Data.DbType.String;
                                command.Parameters.Add(preliminarydiagnosisParameter);

                                var recommendationsParameter = command.CreateParameter();
                                recommendationsParameter.ParameterName = "@recommendations";
                                recommendationsParameter.DbType = System.Data.DbType.String;
                                command.Parameters.Add(recommendationsParameter);

                                var servicetypeParameter = command.CreateParameter();
                                servicetypeParameter.ParameterName = "@servicetype";
                                servicetypeParameter.DbType = System.Data.DbType.String;
                                command.Parameters.Add(servicetypeParameter);


                                var specialistParameter = command.CreateParameter();
                                specialistParameter.ParameterName = "@specialist";
                                specialistParameter.DbType = System.Data.DbType.String;
                                command.Parameters.Add(specialistParameter);


                                var situatedatParameter = command.CreateParameter();
                                situatedatParameter.ParameterName = "@situatedat";
                                situatedatParameter.DbType = System.Data.DbType.String;
                                command.Parameters.Add(situatedatParameter);


                                var recorddateParameter = command.CreateParameter();
                                recorddateParameter.ParameterName = "@recorddate";
                                recorddateParameter.DbType = System.Data.DbType.Int32;
                                command.Parameters.Add(recorddateParameter);


                                var dateofserviceParameter = command.CreateParameter();
                                dateofserviceParameter.ParameterName = "@dateofservice";
                                dateofserviceParameter.DbType = System.Data.DbType.Int32;
                                command.Parameters.Add(dateofserviceParameter);
                                #endregion

                                foreach (var casuelty in Casuelty)
                                {
                                    string HelpProvided = string.Empty;
                                    if (casuelty.HelpProvided != null && casuelty.HelpProvided.Count > 0)
                                    {
                                        HelpProvided = string.Join(delimitter, casuelty.HelpProvided);
                                    }

                                    solderidParameter.Value = casuelty.SolderId ?? string.Empty;
                                    nicknameParameter.Value = casuelty.NickName ?? string.Empty;
                                    fullnameParameter.Value = casuelty.FullName ?? string.Empty;
                                    nameParameter.Value = casuelty.Name ?? string.Empty;
                                    surnameParameter.Value = casuelty.Surname ?? string.Empty;
                                    lastnameParameter.Value = casuelty.LastName ?? string.Empty;
                                    destinationParameter.Value = casuelty.Destination ?? string.Empty;
                                    woundtypeParameter.Value = casuelty.WoundType ?? string.Empty;
                                    woundclauseParameter.Value = casuelty.WoundClause ?? string.Empty;
                                    wounddateParameter.Value = casuelty.WoundDate;
                                    deathtimeParameter.Value = casuelty.TimeOfDeath;
                                    helpprovidedParameter.Value = HelpProvided ?? string.Empty;
                                    filenameParameter.Value = casuelty.FileName ?? string.Empty;
                                    formidParameter.Value = casuelty.FormId;
                                    complaintsParameter.Value = casuelty.Complaints ?? string.Empty;
                                    anamnesisParameter.Value = casuelty.Anamnesis ?? string.Empty;
                                    objectivelyParameter.Value = casuelty.Objectively ?? string.Empty;
                                    pharmacotherapyParameter.Value = casuelty.Pharmacotherapy ?? string.Empty;
                                    preliminarydiagnosisParameter.Value = casuelty.Preliminary_diagnosis ?? string.Empty;
                                    recommendationsParameter.Value = casuelty.Recommendations ?? string.Empty;
                                    servicetypeParameter.Value = casuelty.ServiceType ?? string.Empty;
                                    specialistParameter.Value = casuelty.Specialist ?? string.Empty;
                                    situatedatParameter.Value = casuelty.SituatedAt ?? string.Empty;
                                    recorddateParameter.Value = casuelty.RecordDate;
                                    dateofserviceParameter.Value = casuelty.DateOfService;
                                    command.ExecuteNonQuery();
                                }
                                transaction.Commit();
                            }
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
                                    WoundDate = (int)rdr["wounddate"],
                                    TimeOfDeath = (int)rdr["deathtime"],
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
            if (Items.Count == 1) { return UpsertPersonnel(Items[0]); }
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
                        if (itemsWithId.Count > 0)
                        {
                            using (var transaction = connection.BeginTransaction())
                            {
                                using (var command = connection.CreateCommand())
                                {
                                    command.CommandText = insertPersonelWithId;

                                    var idParameter = command.CreateParameter();
                                    idParameter.ParameterName = "@id";
                                    idParameter.DbType = System.Data.DbType.Int32;
                                    command.Parameters.Add(idParameter);

                                    var tokennumberParameter = command.CreateParameter();
                                    tokennumberParameter.ParameterName = "@tokennumber";
                                    tokennumberParameter.DbType = System.Data.DbType.String;
                                    command.Parameters.Add(tokennumberParameter);

                                    var callsignParameter = command.CreateParameter();
                                    callsignParameter.ParameterName = "@callsign";
                                    callsignParameter.DbType = System.Data.DbType.String;
                                    command.Parameters.Add(callsignParameter);

                                    var fioParameter = command.CreateParameter();
                                    fioParameter.ParameterName = "@fio";
                                    fioParameter.DbType = System.Data.DbType.String;
                                    command.Parameters.Add(fioParameter);

                                    foreach (var item in itemsWithId)
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
                        }
                        if (itemsWithoutId.Count > 0)
                        {
                            using (var transaction = connection.BeginTransaction())
                            {
                                using (var command = connection.CreateCommand())
                                {
                                    command.CommandText = insertPersonelWithoutId;

                                    var tokennumberParameter = command.CreateParameter();
                                    tokennumberParameter.ParameterName = "@tokennumber";
                                    tokennumberParameter.DbType = System.Data.DbType.String;
                                    command.Parameters.Add(tokennumberParameter);

                                    var callsignParameter = command.CreateParameter();
                                    callsignParameter.ParameterName = "@callsign";
                                    callsignParameter.DbType = System.Data.DbType.String;
                                    command.Parameters.Add(callsignParameter);

                                    var fioParameter = command.CreateParameter();
                                    fioParameter.ParameterName = "@fio";
                                    fioParameter.DbType = System.Data.DbType.String;
                                    command.Parameters.Add(fioParameter);

                                    foreach (var item in itemsWithoutId)
                                    {
                                        callsignParameter.Value = item.CallSign.ToString() ?? string.Empty;
                                        tokennumberParameter.Value = item.TokenNumber ?? string.Empty;
                                        fioParameter.Value = item.FIO ?? string.Empty;
                                        command.ExecuteNonQuery();
                                    }
                                    transaction.Commit();
                                }
                            }
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
