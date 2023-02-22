using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHomeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoomPage : ContentPage
    {
        public const string ADD_BUTTON_TEXT = "Добавить комнату";

        public RoomPage()
        {
            InitializeComponent();
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}