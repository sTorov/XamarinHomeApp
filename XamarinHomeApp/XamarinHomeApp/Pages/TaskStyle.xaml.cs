using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHomeApp.Pages
{
    public partial class TaskStyle : ContentPage
    {
        private static double? sound;

        public static DateTime dateValue = DateTime.Today;
        public static TimeSpan timeValue = GetCurrentTime();

        public TaskStyle()
        {
            InitializeComponent();

            if (sound == null) sound = slider.Maximum / 2;
            slider.Value = (double)sound;

            SetState(date: true, time: true);
        }

        private static TimeSpan GetCurrentTime() => new TimeSpan(int.Parse(DateTime.Now.ToString("hh")), int.Parse(DateTime.Now.ToString("mm")), int.Parse(DateTime.Now.ToString("ss")));
        
        private void SetState(bool date = false, bool time = false)
        {
            _ = date && VisualStateManager.GoToState(this.date, dateValue > DateTime.Today ? "Invalid" : "Valid");
            _ = time && VisualStateManager.GoToState(this.time, timeValue > GetCurrentTime() ? "Invalid" : "Valid");
            //if (date) VisualStateManager.GoToState(this.date, dateValue > DateTime.Today ? "Invalid" : "Valid");
            //if (time) VisualStateManager.GoToState(this.time, timeValue > GetCurrentTime() ? "Invalid" : "Valid");
        }

        private void Data_DateSelected(object sender, DateChangedEventArgs e) 
        {
            dateValue = e.NewDate;
            SetState(date: true);
        } 

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e) => sound = e.NewValue;

        private void Time_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(sender is TimePicker picker && e.PropertyName == "Time")
            {
                timeValue = picker.Time;
                SetState(time: true);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (date.BackgroundColor != Color.FromHex("#22ff0000") && time.BackgroundColor != Color.FromHex("#22ff0000"))
            {
                messageText.Text = $"Будильник установлен на {dateValue:dd.MM}, {timeValue.Hours}:" +
                    $"{(timeValue.Minutes.ToString().Length == 1 ? $"0{timeValue.Minutes}" : $"{timeValue.Minutes}") }";
                VisualStateManager.GoToState(date, "Disabled");
                VisualStateManager.GoToState(time, "Disabled");
            }
            else
                messageText.Text = "Введите корректные данные!";
        }
    }
}