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
            MainParams.NmbOfSquares = (uint)Math.Round((MainApp.MainView.Height * MainApp.MainView.Width) / (200 * 300));        
            UIInit();
        }

        private static void VertStLay_SizeChanged(object sender, EventArgs e)
        {
            MainParams.AspectRatioWidth = Math.Round((MainApp.MainView.Width / MainApp.MainView.Height) / 2, 1);
            MainParams.AspectRatioHeight = Math.Round(MainApp.MainView.Height / MainApp.MainView.Width, 1);
            MainParams.NmbOfSquares = (uint)Math.Round((MainApp.MainView.Height * MainApp.MainView.Width) / (200 * 300));
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
            Button Form200_0 = new Button();
            Button Form300_0 = new Button();
            Form200_0.Text = "Open Form 200_0";
            Form300_0.Text = "Open Form 300_0";
            Form200_0.Pressed += Form200_0_clicked;
            Form300_0.Pressed += Form300_0_clicked;
            Button Form200_1 = new Button();
            Button Form300_1 = new Button();
            Form200_1.Text = "Open Form 200_1";
            Form300_1.Text = "Open Form 300_1";
            Form200_1.Pressed += Form200_1_clicked;
            Form300_1.Pressed += Form300_1_clicked;
            Button Form200_2 = new Button();
            Button Form300_2 = new Button();
            Form200_2.Text = "Open Form 200_2";
            Form300_2.Text = "Open Form 300_2";
            Form200_2.Pressed += Form200_2_clicked;
            Form300_2.Pressed += Form300_2_clicked;
            //Form200.HeightRequest = 250;
            //Form200.WidthRequest = 350;
            //Form300.HeightRequest = 250;
            //Form300.WidthRequest = 350;
            BtnGrid.Add(Form200_0, BtnGrid.ColumnDefinitions.Count / 2, 0);
            BtnGrid.Add(Form300_0, BtnGrid.ColumnDefinitions.Count / 2, 1);
            BtnGrid.Add(Form200_1, BtnGrid.ColumnDefinitions.Count / 2, 2);
            BtnGrid.Add(Form300_1, BtnGrid.ColumnDefinitions.Count / 2, 3);
            BtnGrid.Add(Form200_2, BtnGrid.ColumnDefinitions.Count / 2, 4);
            BtnGrid.Add(Form300_2, BtnGrid.ColumnDefinitions.Count / 2, 5);
        }

        public static void UIInit(int PageN=0)
        {
            if (PageN == 0) 
            {
                CreateGrid();
            }
            MainApp.VertStLay.Add(BtnGrid);
        }

        private static void Form200_0_clicked(object sender, EventArgs e)
        {
            ((Button)sender).IsVisible = false;

            App.Current.MainPage = new NavigationPage(new TestAppPir.Form200_0());
        }

        private static void Form300_0_clicked(object sender, EventArgs e)
        {
            ((Button)sender).IsVisible = false;
            
            App.Current.MainPage = new NavigationPage(new TestAppPir.Form300_0());
        }

        private static void Form200_1_clicked(object sender, EventArgs e)
        {
            ((Button)sender).IsVisible = false;

            App.Current.MainPage = new NavigationPage(new TestAppPir.Form200_1());
        }

        private static void Form300_1_clicked(object sender, EventArgs e)
        {
            ((Button)sender).IsVisible = false;

            App.Current.MainPage = new NavigationPage(new TestAppPir.Form300_1());
        }
        private static void Form200_2_clicked(object sender, EventArgs e)
        {
            ((Button)sender).IsVisible = false;

            App.Current.MainPage = new NavigationPage(new TestAppPir.Form200_2());
        }

        private static void Form300_2_clicked(object sender, EventArgs e)
        {
            ((Button)sender).IsVisible = false;

            App.Current.MainPage = new NavigationPage(new TestAppPir.Form300_2());
        }
    }

}
