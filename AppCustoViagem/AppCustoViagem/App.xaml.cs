using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCustoViagem.View;

namespace AppCustoViagem
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListaViagem());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
