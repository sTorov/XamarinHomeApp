using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHomeApp.Pages
{
    public partial class DeviceControlPage : ContentPage
    {
        public DeviceControlPage()
        {
            InitializeComponent();
            GetContent();
        }

        private void GetContent()
        {
            //Создаём виджет выбора даты
            var datePicker = new DatePicker
            {
                Format = "D",
                //Диапозон дат (+/- неделя)
                MaximumDate = DateTime.Now.AddDays(7),
                MinimumDate = DateTime.Now.AddDays(-7)
            };

            var datePickerText = new Label
            {
                Text = "Дата запуска",
                Margin = new Thickness(0, 20, 0, 0)
            };

            //Добаляем всё на страницу
            stackLayout.Children.Add(new Label { Text = "Устройство" });
            stackLayout.Children.Add(new Entry 
            { 
                BackgroundColor = Color.AliceBlue,
                Text = "Холодильник"
            });
            stackLayout.Children.Add(datePickerText);
            stackLayout.Children.Add(datePicker);
            stackLayout.Children.Add(new Button
            {
                Text = "Сохранить",
                BackgroundColor = Color.Silver,
                Margin = new Thickness(0, 5, 0, 0)
            });

            //Регистрируем обработчик события выбора даты
            datePicker.DateSelected += (sender, e) => DateSelectedHandler(sender, e, datePickerText);
        }

        private void DateSelectedHandler(object sender, DateChangedEventArgs e, Label datePickerText)
        {
            //При срабатывании выбора будет меняться информационное сообщение
            datePickerText.Text = "Запустится " + e.NewDate.ToString("dd/MM/yyyy");
        }
    }
}
