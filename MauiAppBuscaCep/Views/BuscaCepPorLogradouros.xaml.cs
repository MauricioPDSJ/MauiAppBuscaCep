using MauiAppBuscaCep.Models;
using MauiAppBuscaCep.Services;

namespace MauiAppBuscaCep.Views;

public partial class BuscaCepPorLogradouros : ContentPage
{
	public BuscaCepPorLogradouros()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			carregando.IsRunning = true;
			List<Cep> arr_ceps = await DataService.GetCepByLogradouros(
				txt_logradouro.Text);

			lst_ceps.ItemsSource = arr_ceps;
		}
		catch (Exception ex) 
		{
			await DisplayAlert("Ops", ex.Message, "OK");
		}
		finally
		{
			carregando.IsRunning = false;
		}


    }

}