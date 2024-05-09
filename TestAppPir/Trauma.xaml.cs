namespace TestAppPir;

public partial class Trauma : ContentPage
{
    Models.Casuelty dweeb = new Models.Casuelty();
    public Trauma()
	{
		InitializeComponent();
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
            Pharmacotherapy = this.Pharmacotherapy.Text,
            Preliminary_diagnosis = this.Preliminary_diagnosis.Text,
            Specialist = this.Specialist.Text,
            ServiceType = this.ServiceType.Text,
            SituatedAt = this.SituatedAt.Text,
            Recommendations = this.Recommendations.Text,
            RecordDate = DateTimeOffset.UtcNow.ToUniversalTime().Second,
        };

        Methods.Saving.SaveToFile(dweeb);
    }
    private void Back_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }


    private void EstabSearch_ItemTapped(object sender, ItemTappedEventArgs e)
    {

    }

}