using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppCustoViagem.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCustoViagem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormularioViagem : ContentPage
    {
        public FormularioViagem()
        {
            InitializeComponent();
        }

        private async void btn_lista_pedagio_Clicked(object sender, EventArgs e)
        {
            try
            {
                Viagem viagem_inserida = await App.Database.InsertViagem(new Viagem
                {
                    Origem = txt_origem.Text,
                    Destino = txt_destino.Text,
                    Distancia = Convert.ToDouble(txt_distancia.Text),
                    Consumo = Convert.ToDouble(txt_consumo.Text),
                    Valor_Litro_Combustivel = Convert.ToDouble(txt_valor_combustivel.Text)
                }).ConfigureAwait(true);

                 await Navigation.PushAsync(new ListaPedagio(viagem_inserida));
            } catch(Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
                Console.WriteLine(ex.StackTrace);
            }            
        }

        private async void btn_calcular_viagem_Clicked(object sender, EventArgs e)
        {
            Viagem v = new Viagem();
            v.Origem = txt_origem.Text;
            v.Destino = txt_destino.Text;
            v.Distancia = Convert.ToDouble(txt_distancia.Text);
            v.Consumo = Convert.ToDouble(txt_consumo.Text);
            v.Valor_Litro_Combustivel = Convert.ToDouble(txt_valor_combustivel.Text);

            Viagem viagem_inserida = await App.Database.InsertViagem(v);
            await DisplayAlert("Sucesso", "Sua Viagem Foi Salva!", "Ok");

            await Navigation.PopToRootAsync();
        }

        private void btn_limpar_viagem_Clicked(object sender, EventArgs e)
        {
            txt_origem.Text = "";
            txt_destino.Text = "";
            txt_distancia.Text = "";
            txt_consumo.Text = "";
            txt_valor_combustivel.Text = "";
        }
    }
}