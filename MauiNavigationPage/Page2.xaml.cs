namespace MauiNavigationPage;

public partial class Page2 : ContentPage
{
	public Page2()
	{
		InitializeComponent();
	}

    private void OnButtonClicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Page3());
    }

    private void OnButtonClickedVoltar(object sender, EventArgs e)
    {
        Navigation.PopAsync();

        // permite saber a quantidade de p�ginas
        _ = Navigation.NavigationStack.Count;

        // tamb�m � poss�vel obter a p�gina em que quiser
        _ = Navigation.NavigationStack[0];

        // volta para o modal inicial
        Navigation.PopToRootAsync();

        // remove uma p�gina especificada
        Navigation.RemovePage(Navigation.NavigationStack[3]);

        // � poss�vel inserir uma p�gina antes da p�gina especificada
        Navigation.InsertPageBefore(new Page(), Navigation.NavigationStack[1]);
    }
} 