using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHomeApp.Pages
{
    public partial class Task : ContentPage
    {
        private DateTime date = DateTime.Today;
        private TimeSpan time = new TimeSpan(int.Parse(DateTime.Now.ToString("HH")), int.Parse(DateTime.Now.ToString("mm")), int.Parse(DateTime.Now.ToString("ss")));
        private double sound = 50.0;

        public Task()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик для показа климатических данных
        /// </summary>
        private void Button_Clicked(object sender, EventArgs e)
        {
            Thread.Sleep(300);

            Grid grid = new Grid
            {
                BackgroundColor = Color.Black,
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                }
            };

            SetGridWeather(grid);

            var gesture = new TapGestureRecognizer { NumberOfTapsRequired = 1 };
            gesture.Tapped += (obj, args) => InitializeComponent();

            grid.GestureRecognizers.Add(gesture);

            Content = grid;
        }

        /// <summary>
        /// Обработчик для установки будильника
        /// </summary>
        private void Alarm_Clicked(object sender, EventArgs e)
        {
            var stackLayout = new StackLayout { Padding = new Thickness(15), BackgroundColor = Color.AliceBlue };

            //Заголовок
            var title = new Label { Text = "Будильник", FontSize = 24, HorizontalOptions = LayoutOptions.Center, Margin = new Thickness(0, 10, 0, 0) };
            stackLayout.Children.Add(title);

            //Дата
            var datePickerText = new Label { Text = "Дата", Margin = new Thickness(0, 30, 0, 0)};
            var datePicker = new DatePicker
            {
                Format = "D",
                MinimumDate = date,
            };
            stackLayout.Children.Add(datePickerText);
            stackLayout.Children.Add(datePicker);

            datePicker.DateSelected += DateChangedHandler;

            //Время
            var timePickerText = new Label { Text = "Время", Margin = new Thickness(0, 30, 0, 0) };
            var timePicker = new TimePicker
            {
                Time = time,
                Format = "HH:mm"
            };
            stackLayout.Children.Add(timePickerText);
            stackLayout.Children.Add(timePicker);

            timePicker.PropertyChanged += TimeChangedHandler;

            //Громкость
            var sliderText = new Label { Text = $"Громкость: {sound:F1}", Margin = new Thickness(0, 30, 0, 0), HorizontalOptions = LayoutOptions.Center };

            var stepper = new Stepper
            {
                Maximum = 100,
                Minimum = 0,
                Value = sound,
                Increment = 10,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 15),
            };

            var slider = new Slider
            {
                Maximum = 100,
                Minimum = 0,
                Value = sound,
                ThumbColor = Color.SteelBlue,
                MinimumTrackColor = Color.SteelBlue,
                MaximumTrackColor = Color.FromHex("#555555"),
            };
            stackLayout.Children.Add(sliderText);
            stackLayout.Children.Add(stepper);
            stackLayout.Children.Add(slider);

            stepper.ValueChanged += (st, stArgs) => ValueChangedHandler(st, slider, stArgs, sliderText);
            slider.ValueChanged += (sl, slArgs) => ValueChangedHandler(sl, stepper, slArgs, sliderText);

            //Кнопки
            var saveButton = new Button { Text = "Сохранить", Margin = new Thickness(10, 10, 10, 5), HorizontalOptions = LayoutOptions.Center, Padding = new Thickness(30, 10) };
            var backButton = new Button { Text = "Назад", Margin = new Thickness(10, 0), HorizontalOptions = LayoutOptions.Center, Padding = new Thickness(30, 10) };

            stackLayout.Children.Add(saveButton);
            stackLayout.Children.Add(backButton);

            backButton.Clicked += (bb, bbArgs) =>
            {
                Thread.Sleep(300);
                InitializeComponent();
            };
            saveButton.Clicked += (sb, sbArgs) =>
            {
                Thread.Sleep(300);
                GetAlarm(datePicker, timePicker);
            };

            Content = stackLayout;
        }

        /// <summary>
        /// Обрабртчик изменения громкости
        /// </summary>
        private void ValueChangedHandler(object sender, object recipient, ValueChangedEventArgs e, Label header)
        {
            if (sender is Slider slider)
                (recipient as Stepper).Value = slider.Value;
            else if (sender is Stepper stepper)
                (recipient as Slider).Value = stepper.Value;
            else
                return;

            header.Text = $"Громкость: {e.NewValue:F1}";
            sound = e.NewValue;
        }

        /// <summary>
        /// Сохранение выбранной даты
        /// </summary>
        private void DateChangedHandler(object sender, DateChangedEventArgs e) => date = e.NewDate;

        /// <summary>
        /// Сохранение выбранного времени
        /// </summary>
        private void TimeChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Time")
                time = (sender as TimePicker).Time;
        }

        /// <summary>
        /// Получение сообщения об установленном будильнике
        /// </summary>
        private void GetAlarm(DatePicker datePicker, TimePicker timePicker)
        {
            var relativeLayout = new RelativeLayout { BackgroundColor = Color.AliceBlue };

            var label = new Label
            {
                Text = $"Будильник срабротает\n{datePicker.Date:dd.MM} в {timePicker.Time.Hours}:{(timePicker.Time.Minutes.ToString().Length == 1 ? $"0{timePicker.Time.Minutes}" : $"{timePicker.Time.Minutes}")}",
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 18,
            };
            relativeLayout.Children.Add(label,
                Xamarin.Forms.Constraint.RelativeToParent(parent => parent.Width * 0.5 - 90),
                Xamarin.Forms.Constraint.RelativeToParent(parent => parent.Height * 0.5 - 20)
                );

            var recognizer = new TapGestureRecognizer();
            recognizer.Tapped += (rec, recArgs) => Alarm_Clicked(rec, recArgs);

            relativeLayout.GestureRecognizers.Add(recognizer);

            Content = relativeLayout;
        }

        /// <summary>
        /// Заполнение контейнера Grid климатическими данными
        /// </summary>
        private void SetGridWeather(Grid grid)
        {
            //Можно было обойтись одним гридом, без StackLayout
            grid.Children.Add(new StackLayout
            {
                BackgroundColor = Color.LightSalmon,
                Children =
                {
                    new Label { Text = "Inside", FontSize = 50, Padding = new Thickness(0, 40, 0, 0), HorizontalTextAlignment = TextAlignment.Center},
                    new Label { Text = "+ 26 °C", FontSize = 100, HorizontalTextAlignment = TextAlignment.Center }
                }
            }, 0, 0);

            grid.Children.Add(new StackLayout
            {
                BackgroundColor = Color.LightBlue,
                Children =
                {
                    new Label { Text = "Outside", FontSize = 50, Padding = new Thickness(0, 40, 0, 0), HorizontalTextAlignment = TextAlignment.Center},
                    new Label { Text = "- 15 °C", FontSize = 100, HorizontalTextAlignment = TextAlignment.Center }
                }
            }, 0, 1);

            grid.Children.Add(new StackLayout
            {
                BackgroundColor = Color.LightGreen,
                Children =
                {
                    new Label { Text = "Pressure", FontSize = 50, Padding = new Thickness(0, 40, 0, 0), HorizontalTextAlignment = TextAlignment.Center},
                    new Label { Text = "760 mm", FontSize = 100, HorizontalTextAlignment = TextAlignment.Center }
                }
            }, 0, 2);

        }
    }
}