using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static TestAppPir.MainPage;

namespace TestAppPir.Methods
{
    internal static class Pinger
    {
        internal static async void ProxyBckg()
        {
            bool Status = false;
            Ping pingProxy = new Ping();
            while (true)
            {
                PingReply reply = pingProxy.Send(Consts.Address.ProxyAddress, 10000);
                if (reply != null)
                {
                    if (reply.Status == IPStatus.Success)
                    {
                        Status = true;
                        Consts.MainParams.ConnStatus = Status;
                        Thread.Sleep(10000);
                        Consts.MainParams.BackendDBIn = Backend.RequestDownload().Result;
                        UpdateFudged();
                    }
                    else
                    {
                        Status = false;
                        Consts.MainParams.ConnStatus = Status;
                        Thread.Sleep(10000);
                    }
                }
            }
        }

        static async Task UpdateFudged()
        {
            try
            {
                if (Consts.MainParams.BackendDBIn.Count > 0)
                {
                   // Consts.MainParams.Fudged = new List<Models.Casuelty>();
                    foreach (var i in Consts.MainParams.BackendDBIn) 
                    {
                        if (!Consts.MainParams.Fudged.Exists((x)=>x.SolderId==i.TokenNumber))
                            Consts.MainParams.Fudged.Add(new Models.Casuelty() { FullName = i.FIO, NickName = i.CallSign, SolderId = i.TokenNumber, FileName = i.Uid.ToString() });
                    }
                    DBase.UpsertPersonnel(Consts.MainParams.BackendDBIn);
                }
            }
            catch { }
        }

        internal static bool Proxy()
        {
            bool Status = false;
            Ping pingProxy = new Ping();
            while (true)
            {
                PingReply reply = pingProxy.Send(Consts.Address.ProxyAddress, 1000);
                if (reply != null)
                {
                    if (reply.Status == IPStatus.Success)
                    {
                        Status = true;
                        break;
                    }
                }
            }
            return Status;
        }
    }
}
