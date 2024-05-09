using static TestAppPir.MainPage;

namespace TestAppPir;

public partial class Form200_0 : ContentPage
{
    Models.Casuelty dweeb = new Models.Casuelty();
    public Form200_0()
	{
		InitializeComponent();
        this.Share.IsEnabled = false;
    }

    public Form200_0(Models.Casuelty dweeb)
    {
        InitializeComponent();
        this.dweeb = dweeb;
        this.Destination.Text=dweeb.Destination;
        this.SolderId.Text=dweeb.SolderId;
        this.FullName.Text=dweeb.FullName;
        this.WoundClause.Text=dweeb.WoundClause;
        this.WoundType.Text=dweeb.WoundType;
        this.WoundDate.Date.ToUniversalTime().AddSeconds(dweeb.WoundDate);
        this.TimeOfDeath.Date.ToUniversalTime().AddSeconds(dweeb.TimeOfDeath);
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
            WoundDate = this.WoundDate.Date.ToUniversalTime().Second,
            TimeOfDeath = this.TimeOfDeath.Date.ToUniversalTime().Second,
            RecordDate = DateTimeOffset.UtcNow.ToUniversalTime().Second,
            FormId=200
        };
        if(Methods.Saving.SaveToFile(dweeb))this.Share.IsEnabled=true;
    }

    private void Share_Clicked(object sender, EventArgs e)
    {
        Methods.Sharing.ShareFiles(dweeb.FileName);
    }

    private void Back_Clicked(object sender, EventArgs e)
    {
         Navigation.PopAsync();
    }
}