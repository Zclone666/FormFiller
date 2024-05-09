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
        this.SolderId.Text=dweeb.SolderId;
        this.FullName.Text=dweeb.FullName;
        if (dweeb.RecordDate != 0 && dweeb.RecordDate > (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 86400)
        {
            this.WoundClause.Text = dweeb.WoundClause;
            this.WoundType.Text = dweeb.WoundType;
            this.WoundDate.Date= DateTimeOffset.FromUnixTimeSeconds(dweeb.WoundDate).LocalDateTime;
            this.TimeOfDeath.Date = DateTimeOffset.FromUnixTimeSeconds(dweeb.TimeOfDeath).LocalDateTime;
            this.Destination.Text = dweeb.Destination;
        }
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
            WoundDate=(int)this.WoundDate.Date.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
            TimeOfDeath = (int)this.TimeOfDeath.Date.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
            RecordDate = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
            FormId=200
        };
        if(Methods.Saving.SaveToFile(dweeb))this.Share.IsEnabled=true;
        Navigation.PopToRootAsync();
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