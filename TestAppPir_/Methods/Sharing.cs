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
        }

        public static async Task NFCShare(string file1)
        {
            

        }
    }
}
