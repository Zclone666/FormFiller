using static TestAppPir.MainPage;

namespace TestAppPir;

public partial class Form200_1 : ContentPage
{
    Models.Casuelty dweeb = new Models.Casuelty();
    public Form200_1()
	{
		InitializeComponent();
        this.Share.IsEnabled = false;
	}

    private void Save_Clicked(object sender, EventArgs e)
    {
        dweeb = new Models.Casuelty()
        {
            Destination = this.Destination.Text,
            SolderId = this.SolderId.Text,
            FullName = this.FullName.Text,
            WoundClause = this.WoundClause.Text,
            WoundType = this.WoundType.Text,
            WoundDate = this.WoundDate.Date.ToUniversalTime().Ticks,
            TimeOfDeath = this.TimeOfDeath.Date.ToUniversalTime().Ticks
        };
        if (Methods.Saving.SaveToFile(dweeb)) this.Share.IsEnabled = true;
    }

    private void Share_Clicked(object sender, EventArgs e)
    {
        Methods.Sharing.ShareFiles(dweeb.FileName);
    }

    private void Back_Clicked(object sender, EventArgs e)
    {
        App.Current.CloseWindow(this.Window);
    }
}