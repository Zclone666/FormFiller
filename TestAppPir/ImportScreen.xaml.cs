using Microsoft.Maui.Storage;
using System.Text;
using TestAppPir.Models;

namespace TestAppPir;

public partial class ImportScreen : ContentPage
{
	public ImportScreen()
	{
		InitializeComponent();
	}

	private async void Import_Clicked(object sender, EventArgs e)
	{
		FileResult fileResult=await FilePicker.PickAsync();
        if (fileResult != null)
        {
            try
			{
                using (Stream fs = await fileResult.OpenReadAsync())
                {

                    byte[] flbyte = new byte[fs.Length];
                    fs.Read(flbyte);
                    string fl=Encoding.UTF8.GetString(flbyte);
                    Consts.MainParams.Fudged = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Casuelty>>(fl);
                    Methods.DBase.InsertFact(Consts.MainParams.Fudged);
                }
            }
			catch { }
		}
	}
}