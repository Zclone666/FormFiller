namespace TestAppPir;

public partial class Form200_2 : ContentPage
{
    Models.Fuckers trash = new Models.Fuckers();
    public Form200_2()
	{
		InitializeComponent();
	}

    private void Save_Clicked(object sender, EventArgs e)
    {
        trash = new Models.Fuckers()
        {
            Destination = this.Destination.Text,
            SolderId = this.SolderId.Text,
            Name = this.Name.Text,
            Surname = this.Surname.Text,
            LastName = this.LastName.Text,
            WoundClause = this.WoundClause.Text,
            WoundType = this.WoundType.Text,
            WoundDate = this.WoundDate.Date.ToUniversalTime().Ticks,
            TimeOfDeath = this.TimeOfDeath.Date.ToUniversalTime().Ticks
        };
        Methods.Saving.SaveToFile(trash);
    }

    private void Share_Clicked(object sender, EventArgs e)
    {
        Methods.Sharing.ShareFiles(trash.filename);
    }
}