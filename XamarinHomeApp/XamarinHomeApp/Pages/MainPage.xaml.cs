using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinHomeApp.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        #region Practice

        /*
         <Label FontSize="16" Padding="30,24,30,0">
           <Label.FormattedText>
               <FormattedString>
                   <FormattedString.Spans>
                       <Span Text="Learn more at "/>
                       <Span Text="https://aka.ms/xamarin-quickstart" FontAttributes="Bold"/>
                   </FormattedString.Spans>
               </FormattedString>
            </Label.FormattedText>
        </Label>
         */

        ////Practice (Инициализация контента при помощи C#)
        //Label text = new Label
        //{
        //    FontSize = 16,
        //    Padding = new Thickness(30, 24, 30, 0),
        //    FormattedText = new FormattedString
        //    {
        //        Spans =
        //        {
        //            new Span() { Text = "Learn more at " },
        //            new Span() { Text = "https://aka.ms/xamarin-quickstart", FontAttributes = FontAttributes.Bold }
        //        }
        //    }
        //};

        ////Добавление контенте на страницу
        //this.Content = text;

        #endregion

        private async void LoginButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new LoginPage());

        private async void RegButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new RegisterPage());

        private async void RoomButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new RoomPage());

        private async void DevicesButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new DevicesPage());

        private async void ClimateButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new ClimatePage());

        private async void AboutButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new AboutPage());

        private async void GridButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new GridPage());

        private async void XamlButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new MergeGridPage());

        private async void TaskButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new Task());

        private async void NewDeviceButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new NewDevicePage("ToMainPage"));

        private async void ControlDeviceButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new DeviceControlPage());

        private async void ProfileButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new ProfilePage());

        private async void WebButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new WebPage());

        private async void VisualStateManagerButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new VisualStateManagerPage());

        private async void TaskStyleButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new TaskStyle());

        private async void BindingButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new BindingPage());

        private async void BindingModeButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new BindingModePage());

        private async void DeviceListButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new DeviceListPage());
    }
}
