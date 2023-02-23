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
    }
}
