using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppCustoViagem.Model;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCustoViagem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaViagem : ContentPage
    {
        ObservableCollection<Viagem> viagens = new ObservableCollection<Viagem>();

        public ListaViagem()
        {
            InitializeComponent();

            lst_viagens.ItemsSource = viagens;
        }

        private void Btn_NovaViagem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FormularioViagem());
        }

        protected override void OnAppearing()
        {
            if (viagens.Count == 0)
            {
                System.Threading.Tasks.Task.Run(async () =>
                {
                    List<Viagem> temp = await App.Database.GetAllViagens();

                    foreach (Viagem item in temp)
                    {
                        viagens.Add(item);
                    }
                });

                lst_viagens.ItemsSource = viagens;
            }
            atualizando.IsRefreshing = false;
        }

        private async void atualizando_Refreshing(object sender, EventArgs e)
        {
            try
            {
                List<Viagem> temp = await App.Database.GetAllViagens();

                viagens = new ObservableCollection<Viagem>();

                foreach (Viagem item in temp)
                {
                    viagens.Add(item);
                }
                atualizando.IsRefreshing = false;
            }
            catch(Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "Ok");
            }
        }
    }
}