using System.Text;

namespace TestAppPir;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            string fileName = Path.Combine(FileSystem.Current.AppDataDirectory, "PutinHuylo");
            if (File.Exists(fileName))
            {
                string LoginPass = $"{this.usernameEntry.Text}GloryToUkraine{this.passwordEntry.Text}";
                string FromFile = "";
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    byte[] flbyte = new byte[fs.Length];
                    fs.Read(flbyte, 0, flbyte.Length);
                    FromFile = Encoding.UTF8.GetString(flbyte);
                }
                if (FromFile == LoginPass) Navigation.PopToRootAsync();
                else {
                    DisplayAlert("YOU ARE (OLD AND) WRONG!", "ACCESS RESTRICTED, YOU CUNT", "OK :(");
                    //App.Current.Quit();
                        }
            }
            else
            {
                string LoginPass = $"{this.usernameEntry.Text}GloryToUkraine{this.passwordEntry.Text}";
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    byte[] flbyte = Encoding.UTF8.GetBytes(LoginPass);
                    fs.Write(flbyte, 0, flbyte.Length);
                    fs.Flush();
                }
                Navigation.PopToRootAsync();
            }
        }
        catch { }
    }
}