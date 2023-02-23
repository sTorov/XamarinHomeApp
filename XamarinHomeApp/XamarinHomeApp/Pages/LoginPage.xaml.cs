using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHomeApp.Pages
{
    public partial class LoginPage : ContentPage
    {
        //Константа для текста кнопки
        public const string BUTTON_TEXT = "Войти";
        //Переменная счетчика
        public static int loginCouner = 0;

        public LoginPage()
        {
            InitializeComponent();
        }
                
        /// <summary>
        /// По клику обрабатываем счетчик и выводим разные сообщения
        /// </summary>
        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            #region LoadingData_Example

            //Генерация во время компиляции (инфо находится в файле <ClassName>.g.cs, который находится в папке скомпилированного приложения (./obj/..))
            //loginButton.Text = "Выполняется вход...";

            //Динамическая генерация XML-кода (снижение производительности)
            //string xaml = "<Button Text=\"⌛ Выполняется вход...\" />";
            //loginButton.LoadFromXaml(xaml);

            #endregion

            if (loginCouner == 0)
                loginButton.Text = "Выполняется вход...";   //Если первая попытка - просто меняем сообщение
            else if (loginCouner > 5)
            {
                loginButton.IsEnabled = false;  //Деактивируем кнопку

                var infoMessage = (Label)stackLayout.Children.Last();   //Получаем последний элемент, используя свойство Children, после выполняем распаковку (можно просто через имя элемента)
                infoMessage.Text = "Слишком много попыток! Попробуйте позже.";     //Показываем сообщение об ошибке
            }
            else
                loginButton.Text = $"Выполняется вход... Попыток входа: {loginCouner}";     //Изменяем текст кнопки и показываем количество попыток входа

            loginCouner++;  //Увеличиваем счетчик
        }

        #region addChildrenVersion LoginButton_Clicked
        //В результате, при добавлении нового элеметра в контейнер, верхние элементы
        //будут немного смещаться вверх из-за выравнивания самого контейнера компановки
        //private void LoginButton_Clicked(object sender, EventArgs e)
        //{
        //    if (loginCouner == 0)
        //        loginButton.Text = "Выполняется вход...";   //Если первая попытка - просто меняем сообщение
        //    else if (loginCouner > 5)
        //    {
        //        loginButton.IsEnabled = false;  //Деактивируем кнопку
        //        //Добавляем элемент через свойство Children
        //        stackLayout.Children.Add(new Label
        //        {
        //            Text = "Слишком много попыток! Попробуйте позже.",
        //            TextColor = Color.Red,
        //            VerticalTextAlignment = TextAlignment.Center,
        //            HorizontalTextAlignment = TextAlignment.Center,
        //            Padding = new Thickness(10, 30, 10, 30)
        //        });
        //    }
        //    else
        //        loginButton.Text = $"Выполняется вход... Попыток входа: {loginCouner}";     //Изменяем текст кнопки и показываем количество попыток входа

        //    loginCouner++;  //Увеличиваем счетчик
        //}
        #endregion

        private async void BackButton_Clicked(object sender, EventArgs e) => await Navigation.PopAsync();
    }
}