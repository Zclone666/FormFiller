using System.Windows.Input;
using static TestAppPir.MainPage;

namespace TestAppPir;

public partial class Form300_0 : ContentPage
{
	Models.Casuelty dweeb = new Models.Casuelty();
	List<Editor> editors = new List<Editor>();

    public Form300_0()
	{
		InitializeComponent();
		this.Share.IsEnabled = false;
		editors.Add(new Editor());
		this.HelpProvided.Add(editors[0]);
        editors[0].TextColor = Color.FromHex("#000000");
        Button AddM = new Button() { Text = "+" };
		AddM.Clicked += AddMore;
        this.HelpProvided.Add(AddM);
	}

    public Form300_0(Models.Casuelty dweeb)
    {
        InitializeComponent();
        this.dweeb = dweeb;
        this.Destination.Text = dweeb.Destination;
        this.SolderId.Text = dweeb.SolderId;
        this.FullName.Text = dweeb.FullName;
        this.WoundClause.Text = dweeb.WoundClause;
        this.WoundType.Text = dweeb.WoundType;
        this.WoundDate.Date.ToUniversalTime().AddSeconds(dweeb.WoundDate);
        this.Share.IsEnabled = false;
        editors.Add(new Editor());
        editors[0].TextColor = Color.FromHex("#000000");
        this.HelpProvided.Add(editors[0]);
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
			FullName = this.FullName.Text,
			WoundClause = this.WoundClause.Text,
			WoundType = this.WoundType.Text,
			WoundDate=this.WoundDate.Date.ToUniversalTime().Second,
            RecordDate = DateTimeOffset.UtcNow.ToUniversalTime().Second,
        };
		foreach (var editor in editors)
		{
			dweeb.HelpProvided.Add(editor.Text);
		}
        if (Methods.Saving.SaveToFile(dweeb)) this.Share.IsEnabled = true;
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