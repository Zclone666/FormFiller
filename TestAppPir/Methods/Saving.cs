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
        public static bool SaveToFile(Fuckers trash, string fileName = null)
        {
            bool ret = false;
            try
            {
                if (trash != null)
                {
                    if (fileName == null) fileName = $@"C:\Users\cyril\source\repos\TestAppPir\TestAppPir\bin\Debug\net7.0-windows10.0.19041.0\win10-x64\{trash.SolderId}";
                    trash.filename = fileName;
                    using (FileStream fs = new FileStream(fileName, FileMode.Create))
                    {
                        string fl = System.Text.Json.JsonSerializer.Serialize(trash);
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
