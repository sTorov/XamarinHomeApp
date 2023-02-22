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
                errorMessage.Text = "Слишком много попыток! Попробуйте позже.";     //Показываем сообщение об ошибке
            }
            else
                loginButton.Text = $"Выполняется вход... Попыток входа: {loginCouner}";     //Изменяем текст кнопки и показываем количество попыток входа

            loginCouner++;  //Увеличиваем счетчик
        }
    }
}