using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppPir.Models;

namespace TestAppPir.Methods
{
    public static class Saving
    {
        public static bool SaveToFile(Casuelty dweeb, string fileName = null)
        {
            bool ret = false;
            try
            {
                if (dweeb != null)
                {
                    if (fileName == null) fileName = Path.Combine(FileSystem.Current.AppDataDirectory, dweeb.SolderId);
                    dweeb.FileName = fileName;
                    using (FileStream fs = new FileStream(fileName, FileMode.Create))
                    {
                        string fl = System.Text.Json.JsonSerializer.Serialize(dweeb);
                        byte[] flbyte = Encoding.UTF8.GetBytes(fl);
                        fs.Write(flbyte, 0, flbyte.Length);
                        fs.Flush();
                    }
                    Consts.MainParams.Fudged.Add(dweeb);
                    DBase.InsertFact(dweeb);
                    ret = true;
                }
            }
            catch { }
            return ret;
        }

        public static bool SaveToFileFromDB(List<Casuelty> dweeb, string fileName = null)
        {
            bool ret = false;
            try
            {
                if (dweeb != null)
                {
                    if (fileName == null) fileName = Path.Combine(FileSystem.Current.AppDataDirectory, dweeb[0].SolderId);
                    dweeb[0].FileName = fileName;
                    using (FileStream fs = new FileStream(fileName, FileMode.Create))
                    {
                        string fl = System.Text.Json.JsonSerializer.Serialize(dweeb);
                        byte[] flbyte = Encoding.UTF8.GetBytes(fl);
                        fs.Write(flbyte, 0, flbyte.Length);
                        fs.Flush();
                    }

                    ret = true;
                }
            }
            catch { }
            return ret;
        }
    }
}
