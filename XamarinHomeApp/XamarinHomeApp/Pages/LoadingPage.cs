using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinHomeApp.Pages
{
    public class LoadingPage : ContentPage
    {
        public LoadingPage()
        {
            //Объявляем новый текстовый элемент
            Label header = new Label()
            {
                Text = $"Запуск вашего первого приложения\nна Xamarin..."
            };

            //Здесь можно сразу установить стили
            header.Opacity = 0;
            header.HorizontalTextAlignment = TextAlignment.Center;
            header.VerticalTextAlignment = TextAlignment.Center;
            header.FontSize = 21;
            //Анимация
            header.FadeTo(1, 3000);

            //Инициализация свойства Content новым элементом
            Content = header;
        }
    }
}
