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
    public partial class ListaPedagio : ContentPage
    {
        ObservableCollection<Pedagio> pedagios = new ObservableCollection<Pedagio>();

        Viagem v;

        public ListaPedagio()
        {
            InitializeComponent();

            lst_pedagios.ItemsSource = pedagios;

            v = BindingContext as Viagem;
        }

        protected override void OnAppearing()
        {
            if (pedagios.Count == 0)
            {
                System.Threading.Tasks.Task.Run(async () =>
                {
                    List<Pedagio> temp = await App.Database.GetAllPedagios(v.Id);

                    foreach (Pedagio item in temp)
                    {
                        pedagios.Add(item);
                    }
                });

                lst_pedagios.ItemsSource = pedagios;
            }
            atualizando.IsRefreshing = false;
        }

        private async void atualizando_Refreshing(object sender, EventArgs e)
        {
            try
            {
                List<Pedagio> temp = await App.Database.GetAllPedagios(v.Id);

                pedagios = new ObservableCollection<Pedagio>();

                foreach (Pedagio item in temp)
                {
                    pedagios.Add(item);
                }
                atualizando.IsRefreshing = false;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        private void Btn_NovoPedagio_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FormularioPedagio
            {
                BindingContext = v
            });
        }
    }
}