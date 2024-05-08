namespace TestAppPir
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Methods.DBase.Initialize("666");
            MainPage = new AppShell();
        }
    }
}
