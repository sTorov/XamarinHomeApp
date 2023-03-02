using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHomeApp.Pages
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private void NotifyUser(object sender, ToggledEventArgs e)
        {
            //Покажем уведомление с предупреждение, если пользователь выдаст сразу все доступы
            if (climateSwitch.On && gasSwitch.On && electroSwitch.On)
                DisplayAlert("Внимание!!!", "Пользователь получит полный доступ ко всем системам", "ОК");
        }
    }
}