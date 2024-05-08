using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppPir.Models.Response;
using TestAppPir.Models.Shared;

namespace TestAppPir.Methods
{
    public static class Backend
    {
        public async static Task<List<ItemPersonnel>> RequestDownload()
        {
            List<ItemPersonnel> ret = new List<ItemPersonnel>();
            ResponsePersonnelFind resp = new ResponsePersonnelFind();
            try
            {
                string tmp = await Methods.Http.Send<ResponsePersonnelFind>.HttpGet(Consts.Address.ReceiveController);
                resp=Newtonsoft.Json.JsonConvert.DeserializeObject<ResponsePersonnelFind>(tmp);
                if(resp != null && resp.Alert.Level=="success" && resp.Result.Count>0) 
                { 
                    ret=resp.Result;
                }
                for(int i=0; i<ret.Count; i++)
                {
                    ret[i].TokenNumber = Methods.Dumbcoding.TokenNumberDecrypt(ret[i].Id, ret[i].TokenNumber);
                }
            }
            catch { }
            return ret;
        }
    }
}
