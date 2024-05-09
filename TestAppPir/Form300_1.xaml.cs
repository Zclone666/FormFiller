using static TestAppPir.MainPage;

namespace TestAppPir;

public partial class Form300_1 : ContentPage
{
    List<Editor> editors = new List<Editor>();
    Models.Casuelty dweeb = new Models.Casuelty();
    public Form300_1()
	{
		InitializeComponent();
        this.Share.IsEnabled = false;
        editors.Add(new Editor());
        editors[0].TextColor = Color.FromHex("#000000");
        this.HelpProvided.Add(editors[0]);
        Button AddM = new Button() { Text = "+" };
        AddM.Clicked += AddMore;
        this.HelpProvided.Add(AddM);
    }

    public Form300_1(Models.Casuelty dweeb)
    {
        InitializeComponent();
        this.dweeb = dweeb;
        this.SolderId.Text = dweeb.SolderId;
        this.FullName.Text = dweeb.FullName;
        if (dweeb.RecordDate != 0 && dweeb.RecordDate > (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 86400)
        {
            this.Destination.Text = dweeb.Destination;
            this.WoundClause.Text = dweeb.WoundClause;
            this.WoundType.Text = dweeb.WoundType;
            this.WoundDate.Date= DateTimeOffset.FromUnixTimeSeconds(dweeb.WoundDate).LocalDateTime;
            if (dweeb.HelpProvided != null && dweeb.HelpProvided.Count > 0)
            {
                foreach (var i in dweeb.HelpProvided)
                {
                    editors.Add(new Editor() { Text = i, TextColor = Color.FromHex("#000000") });
                    this.HelpProvided.Add(editors.Last());
                }
            }
        }
        else
        {
            editors.Add(new Editor());
            editors[0].TextColor = Color.FromHex("#000000");
            this.HelpProvided.Add(editors[0]);
        }
        Button AddM = new Button() { Text = "+" };
        AddM.Clicked += AddMore;
        this.HelpProvided.Add(AddM);
    }

    private void AddMore(object sender, EventArgs e)
    {
        editors.Add(new Editor());
        editors.Last().TextColor = Color.FromHex("#000000");
        this.HelpProvided.Add(editors.Last());
        Button AddM = new Button() { Text = "+" };
        AddM.Clicked += AddMore;
        this.HelpProvided.Add(AddM);
    }

    private void Save_Clicked(object sender, EventArgs e)
    {
        dweeb = new Models.Casuelty()
        {
            Destination = this.Destination.Text,
            SolderId = this.SolderId.Text,
            NickName=this.Nickname.Text,
            FullName = this.FullName.Text,
            WoundClause = this.WoundClause.Text,
            WoundType = this.WoundType.Text,
            WoundDate=(int)this.WoundDate.Date.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
            RecordDate = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
            FormId = 300
        };
        foreach (var editor in editors)
        {
            dweeb.HelpProvided.Add(editor.Text);
        }
        if (Methods.Saving.SaveToFile(dweeb)) this.Share.IsEnabled = true;
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