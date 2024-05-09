using static TestAppPir.Methods.DBase;

namespace TestAppPir;

public partial class ExportScreen : ContentPage
{
	public ArgsGetFacts DbRecs=new ArgsGetFacts();
    public ExportScreen()
	{
		InitializeComponent();
		if (Consts.MainParams.Fudged.Count == 0)
		{
			DbRecs = Methods.DBase.SelectFacts();
			DbRecs.results = DbRecs.results.Where(x => x.RecordDate != 0).ToList();
			if (DbRecs != null)
			{
				this.DBRecords.ItemsSource = DbRecs.results.Select(x => x.SolderId);
			}
		}
		else
		{
			DbRecs = new ArgsGetFacts() { results = Consts.MainParams.Fudged.Where(x => x.RecordDate != 0).ToList() };
            if (DbRecs != null)
            {
                this.DBRecords.ItemsSource = DbRecs.results.Select(x => x.SolderId);
            }
        }
	}

    private void Share_Clicked(object sender, EventArgs e)
    {
		try
		{
			if (DbRecs != null)
			{
				if (Methods.Saving.SaveToFileFromDB(DbRecs.results))
				{
					Methods.Sharing.ShareFiles(DbRecs.results[0].FileName).RunSynchronously();
				}
			}
		}
		catch { }
    }
}