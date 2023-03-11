using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHomeApp.Pages
{
    public partial class VisualStateManagerPage : ContentPage
    {
        public VisualStateManagerPage()
        {
            InitializeComponent();
            AddContext();
        }

        private void AddContext()
        {
            var newEntry = new Entry
            {
                BackgroundColor = Color.AliceBlue,
                Margin = new Thickness(30, 10),
                Placeholder = "Название",
                Style = (Style)App.Current.Resources["ValidInputStyle"]
            };
            newEntry.TextChanged += (sender, e) => InputTextChanged(sender, e, newEntry);
            stackLayout.Children.Add(newEntry);

            var newEditor = new Editor
            {
                BackgroundColor = Color.AliceBlue,
                Margin = new Thickness(30, 10),
                Placeholder = "Описание",
                HeightRequest = 100,
                Style = (Style)App.Current.Resources["ValidInputStyle"]     //Назначение стиля с собственными состояниями
            };
            newEditor.TextChanged += (sender, e) => InputTextChanged(sender, e, newEditor);
            stackLayout.Children.Add(newEditor);

            //при повторном нажатии на кнопку, будет присвоено состояние Inactive (Disabled -> Inactive -> Disabled)
            button.Clicked += (sender, e) => Button_Clicked(sender, e, new View[]
            {
               entry, newEntry, newEditor
            });
        }

        /// <summary>
        /// Включение и выключение поля для ввода
        /// </summary>
        private void Button_Clicked(object sender, EventArgs e, View[] views)
        {
            foreach(var view in views)
                view.IsEnabled = !view.IsEnabled;
        }

        /// <summary>
        /// Обработчик-валидатор для текстовых полей
        /// </summary>
        private void InputTextChanged(object sender, TextChangedEventArgs e, InputView view)
        {
            //Регулярное выражение для описания специальных символов
            Regex rgx = new Regex("[^A-Za-z0-9]");
            //Не разрешаем использовать спецсимволы (простовляем Invalid)
            VisualStateManager.GoToState(view, rgx.IsMatch(view.Text)
                ? "Invalid" : "Valid");
        }

        //VisualStateManager.GoToState(element, "Focused"); - позволяет переключаться между состояниями
    }
}