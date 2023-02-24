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
    public partial class GridPage : ContentPage
    {
        public GridPage()
        {
            InitializeComponent();

            Grid grid = new Grid
            {
                //Набор строк
                RowDefinitions =
                {
                    new RowDefinition{ Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition{ Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition{ Height = new GridLength(1, GridUnitType.Star) },
                },

                //Набор столцов
                ColumnDefinitions =
                {
                    new ColumnDefinition{ Width = new GridLength (0.5, GridUnitType.Star) },    //0.5 - доля занимаемого пространства
                    new ColumnDefinition{ Width = new GridLength (1, GridUnitType.Star) },      //если везде 1, то пространство рапределяется равномерно между колонками или строками
                    new ColumnDefinition{ Width = new GridLength (1, GridUnitType.Star) },
                },

                //Отступы между элементами
                ColumnSpacing = 20,
                RowSpacing = 20,
            };

            //PopulateGrid(grid);
            MergeColumns(grid);

            Content = grid;
        }

        #region Заполнение Grid (ColumnSpan)
        /// <summary>
        /// Заполнение Grid, объединение ячеек
        /// </summary>
        //private void PopulateGrid(Grid grid)
        //{
        //    //Добавляем элементы по определённым позициям
        //    grid.Children.Add(new BoxView { Color = Color.FromRgb(250, 253, 255) }, 0 /*Позиция слева*/ , 0 /*Позиция сверху*/);


        //    //Сохранение элемента перед добавлением, чтобы потом модифицировать
        //    var mergedRow = new BoxView { Color = Color.FromRgb(196, 232, 255) };
        //    //Добавляем в Grid
        //    grid.Children.Add(mergedRow, 0, 1);
        //    //Устанавливаем свойство ColumnSpan, чтобы расширить элемент на 3 ячейки
        //    Grid.SetColumnSpan(mergedRow, 3);


        //    grid.Children.Add(new BoxView { Color = Color.FromRgb(133, 207, 255) }, 0, 2);

        //    grid.Children.Add(new BoxView { Color = Color.FromRgb(87, 189, 255) }, 1, 0);
        //    //grid.Children.Add(new BoxView { Color = Color.FromRgb(43, 172, 255) }, 1, 1);
        //    grid.Children.Add(new BoxView { Color = Color.FromRgb(23, 164, 255) }, 1, 2);

        //    grid.Children.Add(new BoxView { Color = Color.FromRgb(0, 121, 199) }, 2, 0);
        //    //grid.Children.Add(new BoxView { Color = Color.FromRgb(0, 76, 199) }, 2, 1);
        //    grid.Children.Add(new BoxView { Color = Color.FromRgb(0, 44, 199) }, 2, 2);
        //}
        #endregion

        private void MergeColumns(Grid grid)
        {
            var mergedRow1 = new BoxView { Color = Color.FromRgb(87, 189, 255) };
            grid.Children.Add(mergedRow1, 0, 0);
            Grid.SetRowSpan(mergedRow1, 3);

            var mergedRow2 = new BoxView { Color = Color.FromRgb(87, 189, 255) };
            grid.Children.Add(mergedRow2, 2, 0);
            Grid.SetRowSpan(mergedRow2, 3);

            grid.Children.Add(new BoxView { Color = Color.FromRgb(0, 121, 199) }, 1, 0);
            grid.Children.Add(new BoxView { Color = Color.FromRgb(0, 76, 199) }, 1, 1);
            grid.Children.Add(new BoxView { Color = Color.FromRgb(0, 44, 199) }, 1, 2);
        }
    }
}