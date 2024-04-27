using System.Net.NetworkInformation;
using TestAppPir.Consts;

namespace TestAppPir
{
    public partial class MainPage : ContentPage
    {
        public static Thread BckgrnThread;
        public static Thread UIThread;
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
            UIThread = Thread.CurrentThread;
            
        }

        public static void MainCicle(object sender, EventArgs e)
        {
            MainParams.AspectRatioWidth = Math.Round((MainApp.MainView.Width / MainApp.MainView.Height) / 2, 1);
            MainParams.AspectRatioHeight = Math.Round(MainApp.MainView.Height / MainApp.MainView.Width, 1);
            MainParams.NmbOfSquares = (uint)Math.Round((MainApp.MainView.Height * MainApp.MainView.Width) / (200 * 300));        
            UIInit();
            CheckInit();
        }

        public static void CheckInit()
        {
            BckgrnThread = new Thread(() => Methods.Pinger.ProxyBckg());
            BckgrnThread.Name = "Pinger";
            BckgrnThread.Priority= ThreadPriority.BelowNormal;
            BckgrnThread.Start();
        }


        private static void VertStLay_SizeChanged(object sender, EventArgs e)
        {
            MainParams.AspectRatioWidth = Math.Round((MainApp.MainView.Width / MainApp.MainView.Height) / 2, 1);
            MainParams.AspectRatioHeight = Math.Round(MainApp.MainView.Height / MainApp.MainView.Width, 1);
            MainParams.NmbOfSquares = (uint)Math.Round((MainApp.MainView.Height * MainApp.MainView.Width) / (200 * 300));
            MainApp.MainP.CreateGrid();
        }

        public void CreateGrid(int NumbOfBtns=6, List<string> BtnTxt=null)
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
            List<Button> Buttons = new List<Button>();
            if (BtnTxt == null && NumbOfBtns==6)
            {
                BtnTxt = new List<string>();
                for(int i = 0;i<NumbOfBtns;i++)
                {
                    BtnTxt.Add($"Open Form {((i < NumbOfBtns / 2) ? 200 : 300)}_{i & 3}");
                }
            }
            for(int i = 0; i < NumbOfBtns; i++)
            {
                var t = this.GetType().GetMethods();
                System.Reflection.MethodInfo method = this.GetType().GetMethod($"Form{((i < NumbOfBtns / 2) ? 200 : 300)}_{i & 3}_clicked");
           
                Buttons.Add(new Button()
                {
                    Text = BtnTxt[i],
                    WidthRequest = 300
                });
                object sender = Buttons[i];
                EventArgs e = new EventArgs();
                Buttons[i].Clicked += delegate { method.Invoke(this, new object[2] { sender, e }); };
                BtnGrid.Add(Buttons[i], BtnGrid.ColumnDefinitions.Count / 2, i);
            }
        }

        public static void UIInit(int PageN=0)
        {
            if (PageN == 0) 
            {
                MainApp.MainP.CreateGrid();
            }
            MainApp.VertStLay.Add(BtnGrid);
        }

        public void Form200_0_clicked(object sender, EventArgs e)
        {
            ((Button)sender).IsVisible = false;
            App.Current.OpenWindow(new Window(new TestAppPir.Form200_0()));
        //    App.Current.MainPage = new NavigationPage(new TestAppPir.Form200_0());
        }

        public void Generic_clicked(object sender, EventArgs e)
        {
            ((Button)sender).IsVisible = false;
            App.Current.OpenWindow(new Window(new TestAppPir.Form200_0()));
            //App.Current.MainPage = new NavigationPage(new TestAppPir.Form200_0());
        }

        public void Form300_0_clicked(object sender, EventArgs e)
        {
            ((Button)sender).IsVisible = false;
            App.Current.OpenWindow(new Window(new TestAppPir.Form300_0()));
            //App.Current.MainPage = new NavigationPage(new TestAppPir.Form300_0());
        }

        public  void Form200_1_clicked(object sender, EventArgs e)
        {
            ((Button)sender).IsVisible = false;
            App.Current.OpenWindow(new Window(new TestAppPir.Form200_1()));
            //App.Current.MainPage = new NavigationPage(new TestAppPir.Form200_1());
        }

        public void Form300_1_clicked(object sender, EventArgs e)
        {
            ((Button)sender).IsVisible = false;
            App.Current.OpenWindow(new Window(new TestAppPir.Form300_1()));
          //  App.Current.MainPage = new NavigationPage(new TestAppPir.Form300_1());
        }
        public void Form200_2_clicked(object sender, EventArgs e)
        {
            ((Button)sender).IsVisible = false;
            App.Current.OpenWindow(new Window(new TestAppPir.Form200_2()));
          //  App.Current.MainPage = new NavigationPage(new TestAppPir.Form200_2());
        }

        public void Form300_3_clicked(object sender, EventArgs e)
        {
            ((Button)sender).IsVisible = false;
            
            App.Current.OpenWindow(new Window(new TestAppPir.Form300_2()));

          //  App.Current.MainPage = new NavigationPage(new TestAppPir.Form300_2());
        }
    }

}
