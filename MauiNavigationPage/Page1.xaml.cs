namespace MauiNavigationPage;

public partial class Page1 : ContentPage
{
	public Page1()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		// propriedade só funciona se a pagina atual estiver configurada com a navigation page
		Navigation.PushAsync(new Page2());
    }
}