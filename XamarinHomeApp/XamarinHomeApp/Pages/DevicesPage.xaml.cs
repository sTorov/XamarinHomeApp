using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinHomeApp.Models;

namespace XamarinHomeApp.Pages
{
    public partial class DevicesPage : ContentPage
    {
        public DevicesPage()
        {
            InitializeComponent();
            GetDevices();
        }

        private async void BackButton_Clicked(object sender, EventArgs e) => await Navigation.PopAsync();

        /// <summary>
        /// Метод для выгрузки устройств
        /// </summary>
        private void GetDevices()
        {
            //Создадим некий список устройств
            //В реальном приложении может выгружаться из базы или веб-сервиса
            var homeDevices = new List<HomeDevice>
            {
                new HomeDevice("Чайник", "kettle.jpg"),
                new HomeDevice("Стиральная машина"),
                new HomeDevice("Посудомоечная машина"),
                new HomeDevice("Мультиварка"),
                new HomeDevice("Водонагреватель"),
                new HomeDevice("Плита"),
                new HomeDevice("Микроволновая печь"),
                new HomeDevice("Духовой шкаф"),
                new HomeDevice("Холодильник"),
                new HomeDevice("Увлажнитель воздуха"),
                new HomeDevice("Телевизор"),
                new HomeDevice("Пылесос"),
                new HomeDevice("музыкальный центр"),
                new HomeDevice("Компьютер"),
                new HomeDevice("Игровая консоль")
            };

            //Создадим новый стек
            var innerStack = new StackLayout();

            //Сохраним в стек имеющиеся данные, используя свойство Children
            foreach (var device in homeDevices) 
            {
                //Создаём текстовый элемент
                var deviceLabel = new Label
                {
                    Text = $"{device.Name}",
                    FontSize = 17
                };

                //Контейнер Frame, внутри которого будет отображаться текстовый элемент
                var frame = new Frame
                {
                    BorderColor = Color.Gray,
                    BackgroundColor = Color.FromHex("#e1e1e1"),
                    CornerRadius = 4,
                    Margin = new Thickness(10, 1),

                    //Задаём содержимое контейнера Frame
                    Content = deviceLabel
                };

                //Создаём объект, отвечающий за распознание нажатий
                var gesture = new TapGestureRecognizer 
                {
                    NumberOfTapsRequired = 1,
                };

                //Устанавливаем по событию нажатия вызов обработчика
                gesture.Tapped += async (sender, e) => await ShowImage(sender, e, device.Image);
                //Добавляем настроенный распознаватель нажатий в текущий фрейм
                frame.GestureRecognizers.Add(gesture);

                //Добаляем фреймы в стек для их отображения в едином списке по порядку
                innerStack.Children.Add(frame);
            }

            //Сохраняем стек в уже имеющийся в xaml-файле блок прокручивающейся разметки
            scrollView.Content = innerStack;
        }

        private async System.Threading.Tasks.Task ShowImage(object sender, EventArgs e, string imageName)
        {
            Image image = new Image();

            //Если изображение отсутствует, показать информационное окно
            if (string.IsNullOrEmpty(imageName))
            {
                #region DisplayAlert

                //Всплывающее окно с уведомлением (DisplayPopupAsync, DisplayActionSheet)
                //await DisplayAlert("", "Изображение устройства отсутствует", "OK");

                //return;

                #endregion

                image.Source = new UriImageSource
                {
                    CachingEnabled = false,
                    Uri = new Uri("https://i.stack.imgur.com/y9DpT.jpg")
                };
                image.Aspect = Device.RuntimePlatform == Device.Android
                    ? Aspect.AspectFill
                    : Aspect.AspectFit;
            }
            else
            {
                //При наличии изображения - загружаем его по заданному пути
                image.Source = ImageSource.FromResource($"XamarinHomeApp.Images.{imageName}");
            }

            Content = image;
        }
    }
}