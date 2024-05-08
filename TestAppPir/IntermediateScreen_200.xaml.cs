using TestAppPir.Consts;
using TestAppPir.Models;

namespace TestAppPir;

public partial class IntermediateScreen_200 : ContentPage
{
	public IntermediateScreen_200()
	{
		InitializeComponent();
	}

    static Grid BtnGrid = new Grid();
    Models.Casuelty dweeb = new Models.Casuelty();
    private void Search_ID_TextChanged(object sender, TextChangedEventArgs e)
    {
        List<Casuelty> list = new List<Casuelty>();
        List<string> output = new List<string>();
        list = Consts.MainParams.Fudged.FindAll((x) => { return x.SolderId.Contains(((SearchBar)sender).Text); });
        foreach (var casuelty in list)
        {
            output.Add(casuelty.SolderId);
        }
        searchResults.ItemsSource = output;
    }

    private void searchResults_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        CreateGrid();
        this.Search_ID.Text = ((ListView)sender).SelectedItem as string;
        dweeb = MainParams.Fudged.Find((x) => x.SolderId == this.Search_ID.Text);
        this.VerticalStackL.Add(BtnGrid);
    }

    public void CreateGrid(int NumbOfBtns = 6, List<string> BtnTxt = null, List<string> MthdsName = null)
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
        }
        catch { }
    }


    public void IntermediateScreen_clicked(object sender, EventArgs e)
    {
        //     ((Button)sender).IsVisible = false;
        Navigation.PushAsync(new TestAppPir.IntermediateScreen());
       // App.Current.OpenWindow(new Window(new TestAppPir.IntermediateScreen()));
        //    App.Current.MainPage = new NavigationPage(new TestAppPir.Form200_0());
    }

    public void Form200_0_clicked(object sender, EventArgs e)
    {
        //     ((Button)sender).IsVisible = false;
        Navigation.PushAsync(new TestAppPir.Form200_0(dweeb));
      //  App.Current.OpenWindow(new Window(new TestAppPir.Form200_0(dweeb)));
        //    App.Current.MainPage = new NavigationPage(new TestAppPir.Form200_0());
    }

    public void Generic_clicked(object sender, EventArgs e)
    {
        //    ((Button)sender).IsVisible = false;
        Navigation.PushAsync(new TestAppPir.Form200_0(dweeb));
//        App.Current.OpenWindow(new Window(new TestAppPir.Form200_0(dweeb)));
        //App.Current.MainPage = new NavigationPage(new TestAppPir.Form200_0());
    }

    public void Form300_0_clicked(object sender, EventArgs e)
    {
        //      ((Button)sender).IsVisible = false;
        Navigation.PushAsync(new TestAppPir.Form300_0(dweeb));
      //  App.Current.OpenWindow(new Window(new TestAppPir.Form300_0(dweeb)));
        //App.Current.MainPage = new NavigationPage(new TestAppPir.Form300_0());
    }

    public void Form200_1_clicked(object sender, EventArgs e)
    {
        //  ((Button)sender).IsVisible = false;
        Navigation.PushAsync(new TestAppPir.Form200_1(dweeb));
        //App.Current.MainPage = new NavigationPage(new TestAppPir.Form200_1());
    }

    public void Form300_1_clicked(object sender, EventArgs e)
    {
        // ((Button)sender).IsVisible = false;
        Navigation.PushAsync(new TestAppPir.Form300_1(dweeb));
//        App.Current.OpenWindow(new Window(new TestAppPir.Form300_1(dweeb)));
        //  App.Current.MainPage = new NavigationPage(new TestAppPir.Form300_1());
    }
    public void Form200_2_clicked(object sender, EventArgs e)
    {
        //    ((Button)sender).IsVisible = false;
        Navigation.PushAsync(new TestAppPir.Form200_2(dweeb));
   //     App.Current.OpenWindow(new Window(new TestAppPir.Form200_2(dweeb)));
        //  App.Current.MainPage = new NavigationPage(new TestAppPir.Form200_2());
    }

    public void Form300_3_clicked(object sender, EventArgs e)
    {
        //   ((Button)sender).IsVisible = false;
        Navigation.PushAsync(new TestAppPir.Form300_2(dweeb));
//        App.Current.OpenWindow(new Window(new TestAppPir.Form300_2(dweeb)));

        //  App.Current.MainPage = new NavigationPage(new TestAppPir.Form300_2());
    }
}