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
            Viagem v = new Viagem();
            v.Origem = txt_origem.Text;
            v.Destino = txt_destino.Text;
            v.Distancia = Convert.ToDouble(txt_distancia.Text);
            v.Consumo = Convert.ToDouble(txt_consumo.Text);
            v.Valor_Litro_Combustivel = Convert.ToDouble(txt_valor_combustivel.Text);

            Viagem viagem_inserida = await App.Database.InsertViagem(v);

            Navigation.PushAsync(new ListaPedagio
            {
                BindingContext = viagem_inserida
            });
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

            /*await Navigation.PushAsync(new FormularioPedagio
            {
                BindingContext = viagem_inserida
            });
            */

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