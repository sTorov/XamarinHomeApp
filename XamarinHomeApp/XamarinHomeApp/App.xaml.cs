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
            //Инициализация главного экрана и стека навигации
            MainPage = new NavigationPage(new MainPage()); /*Для просмотра задания - new Task()*/  /*для просмотра урока - new NavigationPage(new MainPage())*/
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
