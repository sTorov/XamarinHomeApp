using AutoMapper;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinHomeApp.Data;
using XamarinHomeApp.Pages;

namespace XamarinHomeApp
{
    public partial class App : Application
    {
        //Инициализация репозитория
        public static HomeDeviceRepository HomeDevices = new HomeDeviceRepository(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    $"homedevices.db"));
        public IMapper Mapper { get; set; }

        public App()
        {
            Mapper = CreateMapper();

            //Инициализация интерфейса
            InitializeComponent();
            //Инициализация главного экрана и стека навигации
            MainPage = new NavigationPage(new MainPage()); /*Для просмотра задания - new Task()*/  /*для просмотра урока - new NavigationPage(new MainPage())*/
        }

        /// <summary>
        /// Создаём автомаппер для преобразования сущностей
        /// </summary>
        private IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Data.Tables.HomeDevice, Models.HomeDevice>();
                cfg.CreateMap<Models.HomeDevice, Data.Tables.HomeDevice>();
            });

            return config.CreateMapper();
        }

        protected override async void OnStart()
        {
            await HomeDevices.InitDatabase();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
