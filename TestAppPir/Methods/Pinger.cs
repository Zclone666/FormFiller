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
        internal static void ProxyBckg()
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
