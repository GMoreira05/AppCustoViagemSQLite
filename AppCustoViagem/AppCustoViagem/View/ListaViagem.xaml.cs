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
    public partial class ListaViagem : ContentPage
    {
        public ListaViagem()
        {
            InitializeComponent();
        }

        private void Btn_NovaViagem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FormularioViagem());
        }
    }
}