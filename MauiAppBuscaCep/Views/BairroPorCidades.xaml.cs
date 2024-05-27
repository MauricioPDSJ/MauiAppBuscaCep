using MauiAppBuscaCep.Models;
using MauiAppBuscaCep.Services;
using System.Collections.ObjectModel;

namespace MauiAppBuscaCep.Views;

public partial class BairroPorCidades : ContentPage
{

    ObservableCollection<Cidade> lista_cidade = new ObservableCollection<Cidade>();
    ObservableCollection<Bairro> lista_bairro = new ObservableCollection<Bairro>();
	
    public BairroPorCidades()
	{
		InitializeComponent();

        pck_cidade.ItemsSource = lista_cidade;

        lst_bairros.ItemsSource = lista_bairro;
	}

    private async void pck_estado_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Picker disparador = sender as Picker;

            string? estado_selecionado = disparador.SelectedItem as string;

            List<Cidade> arr_cidade = await DataService.GetCidadesByEstado(estado_selecionado);

            lista_cidade.Clear();

            arr_cidade.ForEach(i => lista_cidade.Add(i));
        }
        catch (Exception ex) 
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void pck_cidade_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Picker disparador = sender as Picker;

            Cidade cidade_selecionada = disparador.SelectedItem as Cidade;

            List<Bairro> arr_bairro = await DataService.GetBairrosByIdCidade(cidade_selecionada.id_cidade);

            lista_bairro.Clear();

            arr_bairro.ForEach(i => lista_bairro.Add(i));

        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }

    }
}