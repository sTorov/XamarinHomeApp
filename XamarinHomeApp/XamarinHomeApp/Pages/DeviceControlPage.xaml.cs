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

            //Виджет выбота времени
            var timePickerText = new Label 
            { 
                Text = "Время запуска",
                Margin = new Thickness(0, 20, 0, 0)
            };
            var timePicker = new TimePicker
            {
                Time = new TimeSpan(13, 0, 0)
            };

            stackLayout.Children.Add(timePickerText);
            stackLayout.Children.Add(timePicker);

            //Создаём меню выбора в виде выпадающего списка с текстовым заголовком
            var pickerText = new Label 
            { 
                Text = "Напряжение сети, В",
                Margin = new Thickness(0, 20, 0, 0)
            };
            var picker = new Picker
            {
                Title = "Выберите напряжение сети",
            };
            picker.Items.Add("220");
            picker.Items.Add("120");
            //Добавряем элементы на страницу
            stackLayout.Children.Add(pickerText);
            stackLayout.Children.Add(picker);

            //Установим текст текущего переключателя Stepper
            var stepperText = new Label
            {
                Text = "Теипература: 5.0 °C",
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 30, 0, 0)
            };
            //Установим сам переключатель
            Stepper stepper = new Stepper
            {
                Maximum = 30,
                Minimum = -30,
                Increment = 1,
                Value = 5,
                HorizontalOptions = LayoutOptions.Center,
                //VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            //Добавим в разметку
            stackLayout.Children.Add(stepperText);
            stackLayout.Children.Add(stepper);

            //Добавим Slider
            Slider slider = new Slider
            {
                Maximum = 30,
                Minimum = -30,
                Value = 5.0,
                ThumbColor = Color.DodgerBlue,
                MinimumTrackColor = Color.DodgerBlue,
                MaximumTrackColor = Color.Gray
            };
            stackLayout.Children.Add(slider);


            stackLayout.Children.Add(new Button
            {
                Text = "Сохранить",
                BackgroundColor = Color.Silver,
                Margin = new Thickness(0, 15, 0, 0)
            });


            //Регистрируем обработчик события выбора даты
            datePicker.DateSelected += (sender, e) => DateSelectedHandler(sender, e, datePickerText);
            //Регистрируем обработчик собития выбора времени
            timePicker.PropertyChanged += (sender, e) => TimeChangedHandler(sender, e, timePickerText, timePicker);
            //Регистрируем обработчик события выбора температуры
            stepper.ValueChanged += (sender, e) => TempChangedHandler(sender, slider, e, stepperText);
            slider.ValueChanged += (sender, e) => TempChangedHandler(sender, stepper, e, stepperText);

        }

        private void DateSelectedHandler(object sender, DateChangedEventArgs e, Label datePickerText)
        {
            //При срабатывании выбора будет меняться информационное сообщение
            datePickerText.Text = "Запустится " + e.NewDate.ToString("dd/MM/yyyy");
        }

        private void TimeChangedHandler(object sender, PropertyChangedEventArgs e, Label timePickerText, TimePicker timePicker)
        {
            //Обновляем текст сообщения, когда появляется новое значение времени
            if (e.PropertyName == "Time")
                timePickerText.Text = "В " + timePicker.Time;
        }

        private void TempChangedHandler(object sender, object recipient, ValueChangedEventArgs e, Label header)
        {
            if(sender is Stepper stepper)
                (recipient as Slider).Value = stepper.Value;
            else if (sender is Slider slider)
                (recipient as Stepper).Value = slider.Value;

            //((Slider)recipient).Value;

            header.Text = $"Теипература: {e.NewValue:F1}°C";
            //header.Text = string.Format("Теипература: {0:F1}°C", e.NewValue);
        }
    }
}
