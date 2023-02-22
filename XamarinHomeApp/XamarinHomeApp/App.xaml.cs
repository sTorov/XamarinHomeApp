using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHomeApp
{
    public partial class App : Application
    {
        public App()
        {
            //Инициализация интерфейса
            InitializeComponent();
            //Инициализация главного экрана
            MainPage = new LoadingPage();  //new MainPage()
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
