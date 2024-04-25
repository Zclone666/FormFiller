namespace TestAppPir;

public partial class Form300_1 : ContentPage
{
    Models.Fuckers trash = new Models.Fuckers();
    public Form300_1()
	{
		InitializeComponent();
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
            WoundDate = this.WoundDate.Date.ToUniversalTime().Ticks
        };
        Methods.Saving.SaveToFile(trash);
    }

    private void Share_Clicked(object sender, EventArgs e)
    {
        Methods.Sharing.ShareFiles(trash.filename);
    }
}