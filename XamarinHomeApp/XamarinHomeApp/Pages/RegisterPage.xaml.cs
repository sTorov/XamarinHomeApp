using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHomeApp.Pages
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            PlatformAdjust();
        }

        private void PlatformAdjust()
        {
            if(Device.RuntimePlatform == Device.macOS)
            {
                placeHolder.PlaceholderColor = Color.SlateGray;
                registerButton.TextColor = Color.AliceBlue;
                registerButton.Margin = new Thickness(0, 5);
                registerButton.BackgroundColor = Color.FromRgba(0, 0, 0, 100);
                registerButton.CornerRadius = 0;
            }
        }

        #region Trigger

        private void Trigger()
        {
            var passField = new Entry();

            //Опледеляем триггре для ввода поля пароля
            var passFieldTrigger = new Trigger(typeof(Entry))
            {
                Property = Entry.IsFocusedProperty,
                Value = true
            };
            //Setter
            passFieldTrigger.Setters.Add(new Setter
            {
                Property = BackgroundColorProperty,
                Value = Color.Gray
            });
            //Добавим анимацию триггера
            passFieldTrigger.EnterActions.Add(new FocusTriggerAction());    //Действия при срабатывании триггера
            passFieldTrigger.ExitActions.Add(new FocusTriggerAction());     //Действия при прекращении действия триггера
            //Добавим триггер
            passField.Triggers.Add(passFieldTrigger);

            Content = new StackLayout
            {
                Children = { passField }
            };
        }

        /// <summary>
        /// Действие триггера, добавляющее анимацию для полей в фокусе
        /// </summary>
        class FocusTriggerAction : TriggerAction<Entry>
        {
            protected override void Invoke(Entry sender)
            {
                _ = sender.IsFocused ? sender.FadeTo(1) : sender.FadeTo(0.5);
            }
        }

        #endregion
    }
}