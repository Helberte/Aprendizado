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

        // permite saber a quantidade de páginas
        _ = Navigation.NavigationStack.Count;

        // também é possível obter a página em que quiser
        _ = Navigation.NavigationStack[0];

        // volta para o modal inicial
        Navigation.PopToRootAsync();

        // remove uma página especificada
        Navigation.RemovePage(Navigation.NavigationStack[3]);

        // é possível inserir uma página antes da página especificada
        Navigation.InsertPageBefore(new Page(), Navigation.NavigationStack[1]);
    }
} 