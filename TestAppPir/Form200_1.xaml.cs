namespace TestAppPir;

public partial class Form200_1 : ContentPage
{
    Models.Fuckers trash = new Models.Fuckers();
    public Form200_1()
	{
		InitializeComponent();
        this.Share.IsEnabled = false;
	}

    private void Save_Clicked(object sender, EventArgs e)
    {
        trash = new Models.Fuckers()
        {
            Destination = this.Destination.Text,
            SolderId = this.SolderId.Text,
            FullName = this.FullName.Text,
            WoundClause = this.WoundClause.Text,
            WoundType = this.WoundType.Text,
            WoundDate = this.WoundDate.Date.ToUniversalTime().Ticks,
            TimeOfDeath = this.TimeOfDeath.Date.ToUniversalTime().Ticks
        };
        if (Methods.Saving.SaveToFile(trash)) this.Share.IsEnabled = true;
    }

    private void Share_Clicked(object sender, EventArgs e)
    {
        Methods.Sharing.ShareFiles(trash.filename);
    }
}