using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppPir.Methods
{
    public static class Sharing
    {
        public static async Task ShareFiles(string file1)
        {
            await Share.Default.RequestAsync(new ShareMultipleFilesRequest
            {
                Title = "Share file",
                Files = new List<ShareFile> { new ShareFile(file1)}
            });
            Methods.DBase.DropFacts();
            Consts.MainParams.Fudged = new List<Models.Casuelty>();
            foreach (var i in Methods.DBase.SelectPersonnel().results)
            {
                if (!Consts.MainParams.Fudged.Exists((x) => x.SolderId == i.TokenNumber))
                    Consts.MainParams.Fudged.Add(new Models.Casuelty() { FullName = i.FIO, NickName = i.CallSign, SolderId = i.TokenNumber, FileName = i.Uid.ToString() });
            }
        }

        public static async Task NFCShare(string file1)
        {
            

        }
    }
}
