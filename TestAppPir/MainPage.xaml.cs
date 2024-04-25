using TestAppPir.Consts;

namespace TestAppPir
{
    public partial class MainPage : ContentPage
    {
        static Thread BckgrnThread;
        static Grid BtnGrid = new Grid();
        public static class MainApp
        {
            public static MainPage MainP;
            public static View MainView;
            public static VerticalStackLayout VertStLay;
        }
        public MainPage()
        {
            InitializeComponent();
            MainApp.MainP = this;
            MainApp.MainView=this.Content;
            MainApp.MainView.HorizontalOptions= new LayoutOptions(LayoutAlignment.Fill, true);
            MainApp.MainView.VerticalOptions = new LayoutOptions(LayoutAlignment.Fill, true);
            MainApp.VertStLay=this.VerticalStackL;
            MainApp.VertStLay.Loaded += MainCicle;
            MainApp.VertStLay.SizeChanged += VertStLay_SizeChanged;
            
        }

        public static void MainCicle(object sender, EventArgs e)
        {
            MainParams.AspectRatioWidth = Math.Round((MainApp.MainView.Width / MainApp.MainView.Height) / 2, 1);
            MainParams.AspectRatioHeight = Math.Round(MainApp.MainView.Height / MainApp.MainView.Width, 1);
            MainParams.NmbOfSquares = (uint)Math.Round((MainApp.MainView.Height * MainApp.MainView.Width) / (250 * 350));        
            UIInit();
        }

        private static void VertStLay_SizeChanged(object sender, EventArgs e)
        {
            MainParams.AspectRatioWidth = Math.Round((MainApp.MainView.Width / MainApp.MainView.Height) / 2, 1);
            MainParams.AspectRatioHeight = Math.Round(MainApp.MainView.Height / MainApp.MainView.Width, 1);
            MainParams.NmbOfSquares = (uint)Math.Round((MainApp.MainView.Height * MainApp.MainView.Width) / (250 * 350));
            CreateGrid();
        }

        public static void CreateGrid()
        {
            BtnGrid.Clear();
            Grid TmpGr = new Grid();
            for (int i = 0; i < Consts.MainParams.NmbOfSquares; i++)
            {
                TmpGr.ColumnDefinitions.Add(new ColumnDefinition(new GridLength(MainParams.SizeOfSquare * MainParams.AspectRatioWidth, GridUnitType.Absolute)));
                TmpGr.RowDefinitions.Add(new RowDefinition(MainParams.SizeOfSquare * MainParams.AspectRatioHeight));
            }
            BtnGrid.ColumnDefinitions = TmpGr.ColumnDefinitions;
            BtnGrid.RowDefinitions = TmpGr.RowDefinitions;
            Button Form200 = new Button();
            Button Form300 = new Button();
            Form200.Text = "Open Form 200";
            Form300.Text = "Open Form 300";
            Form200.Pressed += Form200_clicked;
            Form300.Pressed += Form300_clicked;
            //Form200.HeightRequest = 250;
            //Form200.WidthRequest = 350;
            //Form300.HeightRequest = 250;
            //Form300.WidthRequest = 350;
            BtnGrid.Add(Form200, BtnGrid.ColumnDefinitions.Count / 2, 0);
            BtnGrid.Add(Form300, BtnGrid.ColumnDefinitions.Count / 2, 1);
        }

        public static void UIInit(int PageN=0)
        {
            if (PageN == 0) 
            {
                CreateGrid();
            }
            MainApp.VertStLay.Add(BtnGrid);
        }

        private static void Form200_clicked(object sender, EventArgs e)
        {
            Button btn1 = (Button)sender;
            btn1.IsVisible = false;
        }

        private static void Form300_clicked(object sender, EventArgs e)
        {
            Button btn1 = (Button)sender;
            btn1.IsVisible = false;
            
            App.Current.MainPage = new NavigationPage(new TestAppPir.Form300_0());
        }
    }

}
