using static TestAppPir.Methods.DBase;

namespace TestAppPir;

public partial class ExportScreen : ContentPage
{
	public ArgsGetFacts DbRecs=new ArgsGetFacts();
    public ExportScreen()
	{
		InitializeComponent();
		DbRecs = Methods.DBase.GetFacts();
		if(DbRecs != null)
		{
			this.DBRecords.ItemsSource=DbRecs.results.Select(x=>x.SolderId);
		}
	}
}