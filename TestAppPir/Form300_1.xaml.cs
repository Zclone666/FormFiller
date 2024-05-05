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
        this.HelpProvided.Add(editors[0]);
        Button AddM = new Button() { Text = "+" };
        AddM.Clicked += AddMore;
        this.HelpProvided.Add(AddM);
    }

    public Form300_1(Models.Casuelty dweeb)
    {
        InitializeComponent();
        this.dweeb = dweeb;
        this.Destination.Text = dweeb.Destination;
        this.SolderId.Text = dweeb.SolderId;
        this.FullName.Text = dweeb.FullName;
        this.WoundClause.Text = dweeb.WoundClause;
        this.WoundType.Text = dweeb.WoundType;
        this.WoundDate.Date.AddTicks(dweeb.WoundDate);
        editors.Add(new Editor());
        this.HelpProvided.Add(editors[0]);
        Button AddM = new Button() { Text = "+" };
        AddM.Clicked += AddMore;
        this.HelpProvided.Add(AddM);
    }

    private void AddMore(object sender, EventArgs e)
    {
        editors.Add(new Editor());
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
            WoundDate = this.WoundDate.Date.ToUniversalTime().Ticks
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
        App.Current.CloseWindow(this.Window);
    }
}