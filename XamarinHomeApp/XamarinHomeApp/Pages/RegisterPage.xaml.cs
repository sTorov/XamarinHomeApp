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
            if(Device.RuntimePlatform == Device.UWP)
            {
                placeHolder.PlaceholderColor = Color.SlateGray;
                registerButton.TextColor = Color.AliceBlue;
                registerButton.Margin = new Thickness(0, 5);
                registerButton.BackgroundColor = Color.FromRgba(0, 0, 0, 100);
                registerButton.CornerRadius = 0;
            }
        }
    }
}