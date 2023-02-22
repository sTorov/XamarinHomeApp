using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinHomeApp.Pages;

namespace XamarinHomeApp
{
    public partial class App : Application
    {
        public App()
        {
            //Инициализация интерфейса
            InitializeComponent();
            //Инициализация главного экрана
            MainPage = new RegisterPage();  //new MainPage() || new LoadingPage() || new LoginPage()
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
