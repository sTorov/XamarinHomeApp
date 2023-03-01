using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            var homeDevices = new List<string>()
            {
                "Чайник",
                "Стиральная машина",
                "Посудомоечная машина",
                "Мультиварка",
                "Водонагреватель",
                "Плита",
                "Микроволновая печь",
                "Духовой шкаф",
                "Холодильник",
                "Увлажнитель воздуха",
                "Телевизор",
                "Пылесос",
                "Музыкальный центр",
                "Компьютер",
                "Игровая консоль"
            };

            //Создадим новый стек
            var innerStack = new StackLayout();

            //Сохраним в стек имеющиеся данные, используя свойство Children
            foreach (var device in homeDevices) 
            {
                //Создаём текстовый элемент
                var deviceLabel = new Label
                {
                    Text = $"{device}",
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

                //Добаляем фреймы в стек для их отображения в едином списке по порядку
                innerStack.Children.Add(frame);
            }

            //Сохраняем стек в уже имеющийся в xaml-файле блок прокручивающейся разметки
            scrollView.Content = innerStack;
        }
    }
}