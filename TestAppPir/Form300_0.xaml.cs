namespace TestAppPir;

public partial class Form300_0 : ContentPage
{
	Models.Casuelty dweeb = new Models.Casuelty();

    public Form300_0()
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
			WoundDate=this.WoundDate.Date.ToUniversalTime().Ticks
		};
        if (Methods.Saving.SaveToFile(dweeb)) this.Share.IsEnabled = true;
    }

    private void Share_Clicked(object sender, EventArgs e)
    {
		Methods.Sharing.ShareFiles(dweeb.filename);
    }
}