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
    public partial class FormularioViagem : ContentPage
    {
        public FormularioViagem()
        {
            InitializeComponent();
        }

        private void btn_lista_pedagio_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaPedagio());
        }
    }
}