using Microsoft.Data.Sqlite;
using System.Collections;
using System.Text;
using TestAppPir.Models;

namespace TestAppPir.Methods
{
    public static class DBase
    {
        #region Constants
        static string connectionString;
        private static string dbPath => Path.Combine(FileSystem.Current.AppDataDirectory, "data.db");
        private static readonly object locker = new object();
        private const string delimitter = "_&_";
        private static readonly int delimitterLength = delimitter.Length;

        //private const string dbName = "data.db";
        //static string path = $"{AppDomain.CurrentDomain.BaseDirectory}/data.dat";
        //private static string cacheDir = FileSystem.Current.CacheDirectory;
        //private static string appDataDirectory = FileSystem.Current.AppDataDirectory;
        #endregion

        #region Utils
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
        public static string Initialize(string password)
        {
            //"666BVcOAgUGD1QOBwYFBFQCV" "666BVcOAgUGD1QOB"
            //var tmp = CreatePassword(password);
            connectionString = new SqliteConnectionStringBuilder()
            {
                DataSource = dbPath,
                Mode = SqliteOpenMode.ReadWriteCreate,
                Password = CreatePassword(password),
                Cache = SqliteCacheMode.Private,
                ForeignKeys = true,
                Pooling = false
            }.ConnectionString;
            if (!File.Exists(dbPath)) { return createTable(); }
            return null;
        }

        private static string createTable()
        {
            string ErrorMessage = null;
            lock (locker)
            {
                try
                {

                    //if (File.Exists(DbPath)) { File.Delete(DbPath); }
                    using (SqliteConnection connection = new SqliteConnection(connectionString))
                    {
                        connection.Open();
                        using (SqliteCommand command = new SqliteCommand("CREATE TABLE  'personnel' ('uid ' INTEGER NOT NULL DEFAULT 1 UNIQUE,'id ' TEXT  COLLATE NOCASE, 'tokennumber ' TEXT  COLLATE NOCASE, 'callsign ' TEXT  COLLATE NOCASE, 'surname ' TEXT  COLLATE NOCASE, 'name ' TEXT  COLLATE NOCASE, 'patronymic' TEXT  COLLATE NOCASE, PRIMARY KEY( 'uid ' AUTOINCREMENT));", connection))
                        { command.ExecuteNonQuery(); }
                        using (SqliteCommand command = new SqliteCommand("CREATE TABLE 'facts' ('id' INTEGER NOT NULL DEFAULT 1 UNIQUE,'solderid' TEXT,'nickname' TEXT,'fullname' TEXT,'name' TEXT,'surname' TEXT,'lastname' TEXT, 'destination' TEXT, 'woundtype' TEXT, 'woundclause' TEXT, 'wounddate' INTEGER, 'deathtime' INTEGER, 'helpprovided' TEXT, 'filename' TEXT, PRIMARY KEY('id'));", connection))
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

        public static string AddFact(Casuelty casuelty)
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
                        using (SqliteCommand command = new SqliteCommand("INSERT INTO facts(solderid, nickname, fullname, name, surname, lastname, destination, woundtype, woundclause, wounddate, deathtime, helpprovided, filename) VALUES (@solderid, @nickname, @fullname, @name, @surname, @lastname, @destination, @woundtype, @woundclause, @wounddate, @deathtime, @helpprovided, @filename);", connection))
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



        public class ArgsGetFacts
        {
            public string ErrorNessage;
            public List<Casuelty> results;
        }

        public static ArgsGetFacts GetFacts()
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
                                    FileName = (string)rdr["filename"]
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
        public static string InsertPersonnel(Models.Shared.ItemPersonnel Item)
        {
            string ErrorMessage = null;
            lock (locker)
            {
                try
                {
                    using (SqliteConnection connection = new SqliteConnection(connectionString))
                    {
                        connection.Open();
                        using (SqliteCommand command = new SqliteCommand("INSERT INTO facts(id, tokennumber, callsign, surname, name, patronymic VALUES (@id, @tokennumber, @callsign, @surname, @name, @patronymic);", connection))
                        {
                            command.Parameters.Add("@id", SqliteType.Text).Value = Item.Id.ToString() ?? string.Empty;
                            command.Parameters.Add("@tokennumber", SqliteType.Text).Value = Item.TokenNumber ?? string.Empty;
                            command.Parameters.Add("@callsign", SqliteType.Text).Value = Item.CallSign ?? string.Empty;
                            command.Parameters.Add("@surname", SqliteType.Text).Value = Item.Surname ?? string.Empty;
                            command.Parameters.Add("@name", SqliteType.Text).Value = Item.Name ?? string.Empty;
                            command.Parameters.Add("@patronymic", SqliteType.Text).Value = Item.Patronymic ?? string.Empty;
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

        public static string InsertPersonnel(List<Models.Shared.ItemPersonnel> Items)
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
                                command.CommandText = "INSERT INTO contact(id, tokennumber, surname, name, patronymic) VALUES(@id, @tokennumber, @surname, @name, @patronymic);";

                                var idParameter = command.CreateParameter();
                                idParameter.ParameterName = "@id";
                                command.Parameters.Add(idParameter);

                                var tokennumberParameter = command.CreateParameter();
                                tokennumberParameter.ParameterName = "@tokennumber";
                                command.Parameters.Add(tokennumberParameter);

                                var surnameParameter = command.CreateParameter();
                                surnameParameter.ParameterName = "@surname";
                                command.Parameters.Add(surnameParameter);

                                var nameParameter = command.CreateParameter();
                                nameParameter.ParameterName = "@name";
                                command.Parameters.Add(nameParameter);

                                var patronymicParameter = command.CreateParameter();
                                patronymicParameter.ParameterName = "@patronymic";
                                command.Parameters.Add(patronymicParameter);

                                foreach (var item in Items)
                                {
                                    idParameter.Value = item.Id.ToString() ?? string.Empty;
                                    tokennumberParameter.Value = item.TokenNumber ?? string.Empty;
                                    surnameParameter.Value = item.Surname ?? string.Empty;
                                    nameParameter.Value = item.Name ?? string.Empty;
                                    patronymicParameter.Value = item.Patronymic ?? string.Empty;
                                    command.ExecuteNonQuery();
                                }

                                transaction.Commit();
                            }
                        }
                        connection.Close();
                    }
                }
                catch (Exception ex){ErrorMessage = ex.Message;}
            }
            return ErrorMessage;
        }


        #endregion
    }
}
