using TestAppPir.Models;
using static TestAppPir.Consts.HardCodeLists;

namespace TestAppPir;

public partial class Injury : ContentPage
{
    Models.Casuelty dweeb = new Models.Casuelty();
    public Injury()
	{
		InitializeComponent();
        this.FullName.IsVisible = false;
	}

    public Injury(Casuelty dweeb)
    {
        InitializeComponent();
        this.dweeb = dweeb;
        this.SolderId.Text = dweeb.SolderId;
        this.NickName.Text = dweeb.NickName;
        this.Name.Text = dweeb.Name;
        this.Surname.Text = dweeb.Surname;
        this.LastName.Text = dweeb.LastName;
        this.FullName.Text = dweeb.FullName;
        this.LastName.IsVisible = false;
        this.LastName.IsVisible = false;
        this.Name.IsVisible = false;
    }

private void Save_Clicked(object sender, EventArgs e)
    {
        dweeb = new Models.Casuelty()
        {
            Anamnesis = this.Anamnesis.Text,
            SolderId = this.SolderId.Text,
            NickName = this.NickName.Text,
            Name = this.Name.Text,
            Surname = this.Surname.Text,
            LastName = this.LastName.Text,
            Objectively = this.Objectively.Text,
            Complaints = this.Complaints.Text,
            DateOfService = this.DateOfService.Date.ToUniversalTime().Second,
            Pharmacotherapy=this.Pharmacotherapy.Text,
            Preliminary_diagnosis=this.Preliminary_diagnosis.Text,
            Specialist = this.Specialist.Text,
            ServiceType = this.ServiceType.Text,
            SituatedAt = this.SituatedAt.Text,
            Recommendations = this.Recommendations.Text,
            RecordDate=DateTimeOffset.UtcNow.ToUniversalTime().Second,
            FormId = 500
        };

        Methods.Saving.SaveToFile(dweeb);
        Navigation.PopToRootAsync();
    }
    private void Back_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void EstabSearch_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        this.SituatedAt.Text = ((ListView)sender).SelectedItem as string;
        ((ListView)sender).IsVisible = false;
    }

    private void SituatedAt_TextChanged(object sender, TextChangedEventArgs e)
    {
        this.EstabSearch.IsVisible = true;
        List<JsonResources> list = new List<JsonResources>();
        List<string> output = new List<string>();
        list = Consts.HardCodeLists.InstitutionsLocation.FindAll((x) => { return x.label.Contains(((Editor)sender).Text); });
        foreach (var casuelty in list)
        {
            output.Add(casuelty.label);
        }
        EstabSearch.ItemsSource = output;
    }

    private void SpecialistSearch_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        this.Specialist.Text = ((ListView)sender).SelectedItem as string;
        ((ListView)sender).IsVisible = false;
    }

    private void Specialist_TextChanged(object sender, TextChangedEventArgs e)
    {
        this.SpecialistSearch.IsVisible = true;
        List<JsonResources> list = new List<JsonResources>();
        List<string> output = new List<string>();
        list = Consts.HardCodeLists.Specialists.FindAll((x) => { return x.label.Contains(((Editor)sender).Text); });
        foreach (var casuelty in list)
        {
            output.Add(casuelty.label);
        }
        SpecialistSearch.ItemsSource = output;
    }

    private void ServiceSearch_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        this.ServiceType.Text = ((ListView)sender).SelectedItem as string;
        ((ListView)sender).IsVisible = false;
    }

    private void ServiceType_TextChanged(object sender, TextChangedEventArgs e)
    {
        this.ServiceSearch.IsVisible = true;
        List<JsonResources> list = new List<JsonResources>();
        List<string> output = new List<string>();
        list = Consts.HardCodeLists.TypeOfDirection.FindAll((x) => { return x.label.Contains(((Editor)sender).Text); });
        foreach (var casuelty in list)
        {
            output.Add(casuelty.label);
        }
        ServiceSearch.ItemsSource = output;
    }
}