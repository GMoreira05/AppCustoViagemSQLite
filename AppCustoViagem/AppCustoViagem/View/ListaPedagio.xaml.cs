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
    public partial class ListaPedagio : ContentPage
    {
        public ListaPedagio()
        {
            InitializeComponent();
        }

        private void atualizando_Refreshing(object sender, EventArgs e)
        {

        }
    }
}