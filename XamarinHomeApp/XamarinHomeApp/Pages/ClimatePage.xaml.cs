using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHomeApp.Pages
{
    public partial class ClimatePage : ContentPage
    {
        public ClimatePage()
        {
            InitializeComponent();
            ScanOutside();
            ScanInside();
            GetPressure();
        }

        /// <summary>
        /// Внешние датчики
        /// </summary>
        private void ScanOutside()
        {
            absLayout.Children.Add(
                //Создаём прямоугольник заданного цвета
                new BoxView { Color = Color.LightBlue },
                //Задаём его местоположение и размеры
                new Rectangle(
                    20, //Х - координата начальной точки
                    10, //У - координата начальной точки
                    100, //ширина прямоугольника
                    70  //высота
                )
            );

            absLayout.Children.Add(
                new Label
                {
                    Text = "Outside",
                    VerticalTextAlignment = TextAlignment.Start,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = 13
                },
                new Rectangle(20, 17, 100, 70)
            );

            absLayout.Children.Add(
                new Label
                {
                    Text = "-15 °C",
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = 20
                },
                new Rectangle(20, 15, 100, 70)
            );

        }

        /// <summary>
        /// Внутренние датчики
        /// </summary>
        private void ScanInside()
        {
            absLayout.Children.Add(
                new BoxView { Color = Color.LightSalmon },
                new Rectangle(130, 10, 100, 70)
             );

            absLayout.Children.Add(
                new Label
                {
                    Text = "Inside",
                    VerticalTextAlignment = TextAlignment.Start,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = 13
                },
                new Rectangle(130, 17, 100, 70)
            );

            absLayout.Children.Add(
                new Label
                {
                    Text = "+24 °C",
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = 20
                },
                new Rectangle(130, 17, 100, 70)
            );

        }

        private void GetPressure()
        {
            #region Absolute
            //Создаем новый элемент
            var pressureBox = new BoxView { Color = Color.BurlyWood };
            //Указываем позицию
            var position = new Rectangle(240, 10, 130, 70);
            //Сохраняем настройки лейаута
            AbsoluteLayout.SetLayoutBounds(pressureBox, position);
            //Устанавливаем конфигурацию (все величины абсолютные)
            AbsoluteLayout.SetLayoutFlags(pressureBox, AbsoluteLayoutFlags.None);

            //Добавляем элемент
            absLayout.Children.Add(pressureBox);
            #endregion

            #region Relative
            ////Относительные величины (диапозон величин от 0 до 1)
            //var pressureBox = new BoxView { Color = Color.BurlyWood };
            ////Величины беруться относительно контейнера компановки (родительского элемента)
            //var position = new Rectangle(0.8, 0.5, 0.25, 0.5);      //1, 1, 1, 1 - элемент во всю область лейаута
            //AbsoluteLayout.SetLayoutBounds(pressureBox, position);
            //AbsoluteLayout.SetLayoutFlags(pressureBox, AbsoluteLayoutFlags.All);

            //absLayout.Children.Add(pressureBox);
            #endregion
        }
    }
}