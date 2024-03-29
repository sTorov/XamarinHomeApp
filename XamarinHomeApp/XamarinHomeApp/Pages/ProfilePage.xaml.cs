﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using XamarinHomeApp.Models;
using System.Diagnostics.Tracing;

namespace XamarinHomeApp.Pages
{
    public partial class ProfilePage : ContentPage
    {
        /// <summary>
        /// Модель пользовательских данных
        /// </summary>
        public UserInfo UserInfo { get; set; }

        public ProfilePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Вызывается до того, как элемент становится видимым
        /// </summary>
        protected override void OnAppearing()
        {
            //Проверяем, есть ли в словаре значение
            if(App.Current.Properties.TryGetValue("CurrentUser", out object user))
            {
                UserInfo = user as UserInfo;
                loginEntry.Text = UserInfo.Name;
                emailEntry.Text = UserInfo.Email;
            }
            else   //добавляем, если нет
            {
                UserInfo = new UserInfo();
                App.Current.Properties.Add("CurrentUser", UserInfo);
            }

            // Получим значения ползунков из Preferences.
            // Если значений нет - установим значения по умолчанию (false)
            gasSwitch.On = Preferences.Get("gasState", false);
            climateSwitch.On = Preferences.Get("climateState", false);
            electroSwitch.On = Preferences.Get("electroState", false);

            base.OnAppearing();
        }

        private void NotifyUser(object sender, ToggledEventArgs e)
        {
            //Покажем уведомление с предупреждение, если пользователь выдаст сразу все доступы
            if (climateSwitch.On && gasSwitch.On && electroSwitch.On)
                DisplayAlert("Внимание!!!", "Пользователь получит полный доступ ко всем системам", "ОК");
        }

        /// <summary>
        /// Сохраняем информацию о пользователе
        /// </summary>
        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            UserInfo.Name = loginEntry.Text;
            UserInfo.Email = emailEntry.Text;

            //Сохранение значения полщунков в настройки
            Preferences.Set("gasState", gasSwitch.On);
            Preferences.Set("climateState", climateSwitch.On);
            Preferences.Set("electroState", electroSwitch.On);

            //Возврат на предыдущую страницу
            await Navigation.PopAsync();
        }
    }
}