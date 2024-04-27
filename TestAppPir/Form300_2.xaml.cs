using static TestAppPir.MainPage;

namespace TestAppPir;

public partial class Form300_2 : ContentPage
{
    List<Editor> editors = new List<Editor>();
    Models.Casuelty dweeb = new Models.Casuelty();
    public Form300_2()
	{
		InitializeComponent();
        this.Share.IsEnabled = false;
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
            Name = this.Name.Text,
            Surname = this.Surname.Text,
            LastName = this.LastName.Text,
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
        Methods.Sharing.ShareFiles(dweeb.filename);
    }

    private void Back_Clicked(object sender, EventArgs e)
    {
        App.Current.CloseWindow(this.Window);
    }
}