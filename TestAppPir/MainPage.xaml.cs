using System.Net.NetworkInformation;
using TestAppPir.Consts;
using TestAppPir.Models;

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

        internal void Fudged()
        {
            try {
                //Random rnd= new Random(20);
                //for (int i = 0;i < 10; i++)
                //{
                //    Casuelty Tmp = new Casuelty() { SolderId=rnd.Next().ToString(), NickName=rnd.Next().ToString()};
                //    Consts.MainParams.Fudged.Add(Tmp);
                //}
                Consts.MainParams.BackendDBIn = Methods.DBase.SelectPersonnel().results;
                foreach (var i in Consts.MainParams.BackendDBIn)
                {
                    Consts.MainParams.Fudged.Add(new Models.Casuelty() { FullName = i.FIO, NickName = i.CallSign, SolderId = i.TokenNumber, FileName = i.Uid.ToString() });
                }
            } catch { }
        }

        public static void MainCicle(object sender, EventArgs e)
        {
            MainParams.AspectRatioWidth = Math.Round((MainApp.MainView.Width / MainApp.MainView.Height) / 2, 1);
            MainParams.AspectRatioHeight = Math.Round(MainApp.MainView.Height / MainApp.MainView.Width, 1);
            MainParams.NmbOfSquares = (uint)Math.Round((MainApp.MainView.Height * MainApp.MainView.Width) / ((MainApp.MainView.Width /5) * (MainApp.MainView.Height /5)));
            MainApp.MainP.Fudged();
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
            MainParams.NmbOfSquares = (uint)Math.Round((MainApp.MainView.Height * MainApp.MainView.Width) / ((MainApp.MainView.Width / 5) * (MainApp.MainView.Height / 5)));
            MainApp.MainP.CreateGrid(6, new List<string>() { "Форма 200", "Форма 300", "Травма", "Заболевания", "Поделиться", "Импортировать" }, new List<string>() { "IntermediateScreen_200", "IntermediateScreen_300", "Trauma", "Injury", "ExportScreen", "ImportScreen" });
        }

        public void CreateGrid(int NumbOfBtns=6, List<string> BtnTxt=null, List<string> MthdsName=null)
        {
            try
            {
                BtnGrid.Clear();
                Grid TmpGr = new Grid();
                for (int i = 0; i < Consts.MainParams.NmbOfSquares; i++)
                {
                    TmpGr.ColumnDefinitions.Add(new ColumnDefinition(new GridLength(MainParams.SizeOfSquare * MainParams.AspectRatioWidth, GridUnitType.Auto)));
                    TmpGr.RowDefinitions.Add(new RowDefinition(MainParams.SizeOfSquare * MainParams.AspectRatioHeight));
                }
                BtnGrid.ColumnDefinitions = TmpGr.ColumnDefinitions;
                BtnGrid.RowDefinitions = TmpGr.RowDefinitions;
                BtnGrid.VerticalOptions = LayoutOptions.Center;
                BtnGrid.HorizontalOptions = LayoutOptions.Center;
                List<Button> Buttons = new List<Button>();
                if (MthdsName == null && BtnTxt == null && NumbOfBtns == 6)
                {
                    BtnTxt = new List<string>();
                    for (int i = 0; i < NumbOfBtns; i++)
                    {
                        BtnTxt.Add($"Open Form {((i < NumbOfBtns / 2) ? 200 : 300)}_{i & 3}");
                    }

                    for (int i = 0; i < NumbOfBtns; i++)
                    {
                        var t = this.GetType().GetMethods();
                        System.Reflection.MethodInfo method = this.GetType().GetMethod($"Form{((i < NumbOfBtns / 2) ? 200 : 300)}_{i & 3}_clicked");

                        Buttons.Add(new Button()
                        {
                            Text = BtnTxt[i]
                            //  WidthRequest = (MainApp.MainView.Width / 5),
                            //  HeightRequest= (MainApp.MainView.Height / 5)
                        });
                        object sender = Buttons[i];
                        EventArgs e = new EventArgs();
                        Buttons[i].Clicked += delegate { method.Invoke(this, new object[2] { sender, e }); };
                        Buttons[i].BackgroundColor = Color.FromHex("#344c11");
                        Buttons[i].TextColor = Color.FromHex("#fffff0");
                        BtnGrid.Add(Buttons[i], BtnGrid.ColumnDefinitions.Count / 2, i);
                    }
                }
                else if (MthdsName == null && NumbOfBtns == BtnTxt.Count)
                {
                    for (int i = 0; i < NumbOfBtns; i++)
                    {
                        var t = this.GetType().GetMethods();
                        System.Reflection.MethodInfo method = this.GetType().GetMethod($"{BtnTxt[i]}_clicked");

                        Buttons.Add(new Button()
                        {
                            Text = BtnTxt[i]
                        });
                        object sender = Buttons[i];
                        EventArgs e = new EventArgs();
                        Buttons[i].Clicked += delegate { method.Invoke(this, new object[2] { sender, e }); };
                        Buttons[i].BackgroundColor = Color.FromHex("#344c11");
                        Buttons[i].TextColor = Color.FromHex("#fffff0");
                        BtnGrid.Add(Buttons[i], BtnGrid.ColumnDefinitions.Count / 2, i);
                    }
                }
                else if (MthdsName != null && NumbOfBtns == BtnTxt.Count && BtnTxt.Count == MthdsName.Count && BtnTxt != null) 
                {
                    for (int i = 0; i < NumbOfBtns; i++)
                    {
                        var t = this.GetType().GetMethods();
                        System.Reflection.MethodInfo method = this.GetType().GetMethod($"{MthdsName[i]}_clicked");

                        Buttons.Add(new Button()
                        {
                            Text = BtnTxt[i]
                        });
                        object sender = Buttons[i];
                        EventArgs e = new EventArgs();
                        Buttons[i].Clicked += delegate { method.Invoke(this, new object[2] { sender, e }); };
                        Buttons[i].BackgroundColor = Color.FromHex("#344c11");
                        Buttons[i].TextColor = Color.FromHex("#fffff0");
                        BtnGrid.Add(Buttons[i], BtnGrid.ColumnDefinitions.Count / 2, i);
                    }
                }
            }catch { }
        }

        public static void UIInit(int PageN=0)
        {
            if (PageN == 0) 
            {
                MainApp.MainP.CreateGrid();
            }
            MainApp.VertStLay.Add(BtnGrid);
        }

        public void IntermediateScreen_clicked(object sender, EventArgs e)
        {
            //     ((Button)sender).IsVisible = false;
            Navigation.PushAsync(new TestAppPir.IntermediateScreen());
            // App.Current.OpenWindow(new Window(new TestAppPir.IntermediateScreen()));
            //    App.Current.MainPage = new NavigationPage(new TestAppPir.Form200_0());
        }

        public void ExportScreen_clicked(object sender, EventArgs e)
        {
            //     ((Button)sender).IsVisible = false;
            Navigation.PushAsync(new TestAppPir.ExportScreen());
            //  App.Current.OpenWindow(new Window(new TestAppPir.ExportScreen()));
            //    App.Current.MainPage = new NavigationPage(new TestAppPir.Form200_0());
        }

        public void ImportScreen_clicked(object sender, EventArgs e)
        {
            //     ((Button)sender).IsVisible = false;
            Navigation.PushAsync(new TestAppPir.ImportScreen());
            //  App.Current.OpenWindow(new Window(new TestAppPir.ExportScreen()));
            //    App.Current.MainPage = new NavigationPage(new TestAppPir.Form200_0());
        }

        public void Injury_clicked(object sender, EventArgs e)
        {
            //     ((Button)sender).IsVisible = false;
            Navigation.PushAsync(new TestAppPir.Injury());
            //  App.Current.OpenWindow(new Window(new TestAppPir.ExportScreen()));
            //    App.Current.MainPage = new NavigationPage(new TestAppPir.Form200_0());
        }
        public void Trauma_clicked(object sender, EventArgs e)
        {
            //     ((Button)sender).IsVisible = false;
            Navigation.PushAsync(new TestAppPir.Trauma());
            //  App.Current.OpenWindow(new Window(new TestAppPir.ExportScreen()));
            //    App.Current.MainPage = new NavigationPage(new TestAppPir.Form200_0());
        }

        public void IntermediateScreen_200_clicked(object sender, EventArgs e)
        {
            //     ((Button)sender).IsVisible = false;
            Navigation.PushAsync(new TestAppPir.IntermediateScreen_200());
            //    App.Current.MainPage = new NavigationPage(new TestAppPir.Form200_0());
        }

        public void IntermediateScreen_300_clicked(object sender, EventArgs e)
        {
            //     ((Button)sender).IsVisible = false;
            Navigation.PushAsync(new TestAppPir.IntermediateScreen_300());
            //    App.Current.MainPage = new NavigationPage(new TestAppPir.Form200_0());
        }



        public void Form200_0_clicked(object sender, EventArgs e)
        {
            //     ((Button)sender).IsVisible = false;
            Navigation.PushAsync(new TestAppPir.Form200_0());
            //  App.Current.OpenWindow(new Window(new TestAppPir.Form200_0(dweeb)));
            //    App.Current.MainPage = new NavigationPage(new TestAppPir.Form200_0());
        }

        public void Generic_clicked(object sender, EventArgs e)
        {
            //    ((Button)sender).IsVisible = false;
            Navigation.PushAsync(new TestAppPir.Form200_0());
            //        App.Current.OpenWindow(new Window(new TestAppPir.Form200_0(dweeb)));
            //App.Current.MainPage = new NavigationPage(new TestAppPir.Form200_0());
        }

        public void Form300_0_clicked(object sender, EventArgs e)
        {
            //      ((Button)sender).IsVisible = false;
            Navigation.PushAsync(new TestAppPir.Form300_0());
            //  App.Current.OpenWindow(new Window(new TestAppPir.Form300_0(dweeb)));
            //App.Current.MainPage = new NavigationPage(new TestAppPir.Form300_0());
        }

        public void Form200_1_clicked(object sender, EventArgs e)
        {
            //  ((Button)sender).IsVisible = false;
            Navigation.PushAsync(new TestAppPir.Form200_1());
            //App.Current.MainPage = new NavigationPage(new TestAppPir.Form200_1());
        }

        public void Form300_1_clicked(object sender, EventArgs e)
        {
            // ((Button)sender).IsVisible = false;
            Navigation.PushAsync(new TestAppPir.Form300_1());
            //        App.Current.OpenWindow(new Window(new TestAppPir.Form300_1(dweeb)));
            //  App.Current.MainPage = new NavigationPage(new TestAppPir.Form300_1());
        }
        public void Form200_2_clicked(object sender, EventArgs e)
        {
            //    ((Button)sender).IsVisible = false;
            Navigation.PushAsync(new TestAppPir.Form200_2());
            //     App.Current.OpenWindow(new Window(new TestAppPir.Form200_2(dweeb)));
            //  App.Current.MainPage = new NavigationPage(new TestAppPir.Form200_2());
        }

        public void Form300_3_clicked(object sender, EventArgs e)
        {
            //   ((Button)sender).IsVisible = false;
            Navigation.PushAsync(new TestAppPir.Form300_2());
            //        App.Current.OpenWindow(new Window(new TestAppPir.Form300_2(dweeb)));

            //  App.Current.MainPage = new NavigationPage(new TestAppPir.Form300_2());
        }
    }

}
