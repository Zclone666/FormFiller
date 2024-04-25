namespace TestAppPir;

public partial class Form300_0 : ContentPage
{
	Models.Fuckers trash = new Models.Fuckers();

    public Form300_0()
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
			WoundDate=this.WoundDate.Date.ToUniversalTime().Ticks
		};
        if (Methods.Saving.SaveToFile(trash)) this.Share.IsEnabled = true;
    }

    private void Share_Clicked(object sender, EventArgs e)
    {
		Methods.Sharing.ShareFiles(trash.filename);
    }
}