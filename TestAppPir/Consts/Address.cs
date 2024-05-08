using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppPir.Consts
{
    public static class Address
    {
//#if DEBUG
//        public static readonly string Ending = "dev";
//#else
        public static readonly string Ending = "com";
//#endif
        public const string ProxyAddress = "194.87.46.187";
        public static string ReceiveController = $"https://service.socmedica.{Ending}:9108/Api/Mobile/Personnels";
    }
}
