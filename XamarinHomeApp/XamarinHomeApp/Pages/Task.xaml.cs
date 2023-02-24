using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHomeApp.Pages
{
    public partial class Task : ContentPage
    {
        public Task()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
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

            SetGrid(grid);

            Content = grid;
        }

        private void SetGrid(Grid grid)
        {
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