using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppPir.Consts
{
    public static class HardCodeLists
    {
        public static List<JsonResources> Specialists;
        public static List<JsonResources> InstitutionsLocation;
        public static List<JsonResources> MilitaryRank;
        public static List<JsonResources> MilitaryUnit;
        public static List<JsonResources> TypeOfDirection;

        static HardCodeLists()
        {
            Specialists = Newtonsoft.Json.JsonConvert.DeserializeObject<List<JsonResources>>(Properties.Resources.Specialist);
            InstitutionsLocation = Newtonsoft.Json.JsonConvert.DeserializeObject<List<JsonResources>>(Properties.Resources.InstitutionsLocation);
            MilitaryRank = Newtonsoft.Json.JsonConvert.DeserializeObject<List<JsonResources>>(Properties.Resources.MilitaryRank);
            MilitaryUnit = Newtonsoft.Json.JsonConvert.DeserializeObject<List<JsonResources>>(Properties.Resources.MilitaryUnit);
            TypeOfDirection = Newtonsoft.Json.JsonConvert.DeserializeObject<List<JsonResources>>(Properties.Resources.TypeOfDirection);
        }


        public class JsonResources
        {
            public string id { get; set; }
            public string label { get; set; }
            public string grp {  get; set; }
        }
    }
}
