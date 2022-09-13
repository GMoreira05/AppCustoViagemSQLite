using AppCustoViagem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppCustoViagem.Helper;
using AppCustoViagem.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCustoViagem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormularioPedagio : ContentPage
    {
        Viagem v;

        public FormularioPedagio(Viagem viagem_selecionada)
        {
            InitializeComponent();

            v = viagem_selecionada;
        }

        private async void Btn_SalvarPedagio_Clicked(object sender, EventArgs e)
        {
            Pedagio p = new Pedagio();
            p.Localizacao = txt_Localizacao.Text;
            p.Valor = Convert.ToDouble(txt_Valor.Text);
            p.Id_Viagem = v.Id;

            await App.Database.InsertPedagio(p);
            await Navigation.PopAsync();
        }
    }
}