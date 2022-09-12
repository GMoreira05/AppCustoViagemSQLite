using AppCustoViagem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCustoViagem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormularioPedagio : ContentPage
    {
        Viagem v;

        public FormularioPedagio()
        {
            InitializeComponent();

            v = BindingContext as Viagem;
        }

        private void Btn_SalvarPedagio_Clicked(object sender, EventArgs e)
        {
            Pedagio p = new Pedagio();
            p.Localizacao = txt_Localizacao.Text;
            p.Valor = Convert.ToDouble(txt_Valor.Text);
            p.Id_Viagem = v.Id;
        }
    }
}