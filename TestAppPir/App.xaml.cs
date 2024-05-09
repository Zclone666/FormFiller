namespace TestAppPir
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Methods.DBase.Initialize("666");
            var t = Consts.HardCodeLists.Specialists;
            MainPage = new AppShell();
        }
    }
}
