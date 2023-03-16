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
        private static int loginCouner = 0;
        //Создаем объект, возвращающий свойства устройства
        private readonly IDeviceDetector detector = DependencyService.Get<IDeviceDetector>();

        public LoginPage()
        {
            InitializeComponent();

            //Изменение внешнего вида кнопки для Windows
            if (Device.RuntimePlatform == Device.UWP)
            {
                loginButton.CornerRadius = 0;
                loginButton.BackgroundColor = Color.LightGray;
            }

            //Изменение внешнего вида кнопки для Desktop-версии
            if (Device.Idiom == TargetIdiom.Desktop)
            {
                backButton.CornerRadius = 10;
                backButton.BackgroundColor = Color.Black;
                backButton.TextColor = Color.White;
            }

            //Передаем информацию о платформе на экран
            runningDevice.Text = detector.GetDevice();

            //Установим динамический ресурс при помощи специального метода (у кода приоритет над разметкой)
            cube.SetDynamicResource(BoxView.BackgroundColorProperty, "commonColor");
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

                #region Color

                //Задание цвета текста при помощи статического метода Color.FromRGB()
                //При определении цвета одновременно в C#-коде и XAML, приоритет выше будет у C#-кода
                //infoMessage.TextColor = Color.FromRgb(255, 0, 0);

                #endregion

                #region Resources

                //Добавление цвета в ресурсы страницы
                //var warningColor = Color.FromHex("#ffa500");    //переменная для сохранения в ресурсы
                //Resources.Add("warningColor", warningColor);    //сохранение значения в ресурсы (Remove("key") - удаление значения из словаря)

                //т.к. в словаре все значения хранится в виде объектов - для их использования необходимо явно приводить их к нужному типу
                //infoMessage.TextColor = (Color)Resources["warningColor"];   //применение значения из словаря ресурсов

                #endregion

                //Использование статических ресурсов, являющихся общими для приложения
                infoMessage.TextColor = (Color)Application.Current.Resources["commonColor"];
                Resources["commonColor"] = Color.FromHex("#e70d4f");     //Обновление динамического ресурса
            }
            else
            {
                loginButton.Text = $"Выполняется вход... Попыток входа: {loginCouner}";     //Изменяем текст кнопки и показываем количество попыток входа
                Resources["commonColor"] = Color.FromHex("#ff8e00");
            }

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

        private async void Enter_Clicked(object sender, EventArgs e)
        {
            loginButton.Text = "Выполняется вход...";
            //Имитация задержки
            await System.Threading.Tasks.Task.Delay(1000);
            //Переход на следующую страницу (страницу списка устройств)
            await Navigation.PushAsync(new DeviceListPage());
            //Восстановим первоначальный текст на кнопке, на случае  если пользователь вернётся на страницу для повторного входа
            loginButton.Text = BUTTON_TEXT;
        }
    }
}