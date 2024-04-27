using static TestAppPir.MainPage;

namespace TestAppPir;

public partial class Form200_2 : ContentPage
{
    Models.Casuelty dweeb = new Models.Casuelty();
    public Form200_2()
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
            NickName = this.NickName.Text,
            Name = this.Name.Text,
            Surname = this.Surname.Text,
            LastName = this.LastName.Text,
            WoundClause = this.WoundClause.Text,
            WoundType = this.WoundType.Text,
            WoundDate = this.WoundDate.Date.ToUniversalTime().Ticks,
            TimeOfDeath = this.TimeOfDeath.Date.ToUniversalTime().Ticks
        };
        if (Methods.Saving.SaveToFile(dweeb)) this.Share.IsEnabled = true;
    }

    private void Share_Clicked(object sender, EventArgs e)
    {
        Methods.Sharing.ShareFiles(dweeb.filename);
    }

    private void Back_Clicked(object sender, EventArgs e)
    {
        App.Current.CloseWindow(this.Window);
    }
}