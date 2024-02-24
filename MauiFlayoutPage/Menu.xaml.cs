namespace MauiFlayoutPage;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
	}

    private void Button_ClickedPage01(object sender, EventArgs e)
    {
        if (App.Current is not null)
        {
            if (App.Current.MainPage is not null) 
            { 
                ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage(new Page1());
            }
        }

        
    }

    private void Button_ClickedPage02(object sender, EventArgs e)
    {
        if (App.Current is not null)
        {
            if (App.Current.MainPage is not null)
            {
                ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage(new Page2());
            }
        }
    }

    private void Button_ClickedPage03(object sender, EventArgs e)
    {
        if (App.Current is not null)
        {
            if (App.Current.MainPage is not null)
            {
                ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage(new Page3());
            }
        }
    }
}