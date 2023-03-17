using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinHomeApp.Models;

namespace XamarinHomeApp.Pages
{
    public partial class NewDevicePage : ContentPage
    {
        public static string PageName { get; set; }
        public static bool CreateNew { get; set; }

        //public static string DeviceName { get; set; }
        //public static string DeviceDescription { get; set; }

        //ссылка на модель
        public HomeDevice HomeDevice { get; set; }

        /// <summary>
        ///  Метод - конструктор принимает данные с предыдущей старницы
        /// </summary>
        public NewDevicePage(string pageName, HomeDevice homeDevice = null)
        {
            PageName = pageName;

            if(homeDevice != null)
            {
                HomeDevice = homeDevice;
                CreateNew = false;
                //DeviceName = homeDevice.Name;
                //DeviceDescription = homeDevice.Description;
            }
            else
            {
                HomeDevice = new HomeDevice();
                CreateNew = true;
            }

            InitializeComponent();
            OpenEditor();
        }

        private void OpenEditor()
        {
            //Создание однострочного текстового поля для названия
            var newDeviceName = new Entry
            {
                BackgroundColor = Color.AliceBlue,
                Margin = new Thickness(30, 10),
                Placeholder = "Название",
                Text = HomeDevice.Name,
                Style = (Style)App.Current.Resources["ValidInputStyle"]
            };
            newDeviceName.TextChanged += (sender, e) => InputTextChanged(sender, e, newDeviceName);
            stackLayout.Children.Add(newDeviceName);

            //Создание многострочного поля для описания
            var newDeviceDescription = new Editor
            {
                HeightRequest = 200,
                BackgroundColor = Color.AliceBlue,
                Margin = new Thickness(30, 10),
                Placeholder = "Описание",
                Text = HomeDevice.Description,
                Style = (Style)App.Current.Resources["ValidInputStyle"]

            };
            newDeviceDescription.TextChanged += (sender, e) => InputTextChanged(sender, e, newDeviceDescription);
            stackLayout.Children.Add(newDeviceDescription);

            //Выбор комнаты
            var switchRoomHeader = new Label
            {
                Text = "Выберите комнату подключения",
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(20, 25, 0, 0)
            };
            stackLayout.Children.Add(switchRoomHeader);

            var roomPicker = new Picker
            {
                Margin = new Thickness(30, 0),
                Items = { "Кухня", "Ванная", "Гостиная" }
            };
            
            roomPicker.SelectedItem = roomPicker.Items
                .FirstOrDefault(i => i == HomeDevice.Room);
            roomPicker.SelectedIndexChanged += (sender, e) =>
                RoomPicker_SelectedIndexChanged(sender, e, roomPicker);
            stackLayout.Children.Add(roomPicker);

            ////Создадим заголовок для переключателя
            //var switchHeader = new Label
            //{
            //    Text = "Не использует газ",
            //    HorizontalOptions = LayoutOptions.Center,
            //    Margin = new Thickness(0, 5, 0, 0)
            //};
            //stackLayout.Children.Add(switchHeader);

            ////Создадим переключатель
            //Switch switchControl = new Switch
            //{
            //    IsToggled = false,
            //    HorizontalOptions = LayoutOptions.Center,
            //    ThumbColor = Color.DodgerBlue,
            //    OnColor = Color.LightSteelBlue
            //};
            //stackLayout.Children.Add(switchControl);
            ////Регистрируем обработчик события переулючения Switch
            //switchControl.Toggled += (sender, e) => SwitchHandler(sender, e, switchHeader);

            //Кнопка для перехода на страницу с инструкцией
            var infoButton = new Button
            {
                Text = "Инструкция по эксплуатации",
                Margin = new Thickness(30, 10),
                BackgroundColor = Color.Silver
            };
            infoButton.Clicked += (sender, e) => ManualButtonClicked(sender, e);
            stackLayout.Children.Add(infoButton);


            //Кнопка сохранения с обработчиками
            var addButton = new Button
            {
                Text = "Сохранить",
                Margin = new Thickness(30, 10),
                BackgroundColor = Color.Silver
            };
            addButton.Clicked += (sender, e) => 
                SaveButtonClicked(sender, e, new View[] { newDeviceName, newDeviceDescription, roomPicker });
            stackLayout.Children.Add(addButton);
        }

        /// <summary>
        /// Кнопка сохранения деактивирует все контролы
        /// </summary>
        private async void SaveButtonClicked(object sender, EventArgs e, View[] views)
        {
            if (string.IsNullOrEmpty(HomeDevice.Room))
            {
                await DisplayAlert("Выберите комнату", $"Комната подключения не выбрана!", "ОК");
                return;
            }

            //деактивируем все контролы
            foreach(var view in views)
                view.IsEnabled = false;

            //HomeDevice.Name = DeviceName;
            //HomeDevice.Description = DeviceDescription;

            if (CreateNew)
            {
                // Если нужно создать новое - то сначала выполним проверку, не существует ли ещё такое.
                var existingDevices = await App.HomeDevices.GetHomeDevices();
                if(existingDevices.Any(d => d.Name == HomeDevice.Name))
                    await DisplayAlert("Ошибка", $"Устройство {HomeDevice.Name} уже подключено.\nВыберите другое имя.", "ОК");
                else
                {
                    var newDeviceDto = App.Mapper.Map<Data.Tables.HomeDevice>(HomeDevice);
                    await App.HomeDevices.AddHomeDevice(newDeviceDto);

                    // Пример другого способа навигации - с помощью удаления предыдущей страницы из стека и "вставки" (дано для демонстрации возможностей)
                    Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
                    Navigation.InsertPageBefore(new DeviceListPage(), this);
                    await Navigation.PopAsync();
                }

                return;
            }

            var updatedDevice = App.Mapper.Map<Data.Tables.HomeDevice>(HomeDevice);
            await App.HomeDevices.UpdateHomeDevice(updatedDevice);
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Обработчик переключателя
        /// </summary>
        private void SwitchHandler(object sender, ToggledEventArgs e, Label header)
        {
            if (!e.Value)
            {
                header.Text = "Не использует газ";
                return;
            }

            header.Text = "Использует газ";
        }

        private void InputTextChanged(object sender, TextChangedEventArgs e, InputView view)
        {
            if (view is Entry)
                HomeDevice.Name = view.Text;
            else
                HomeDevice.Description = view.Text;
        }

        private async void ManualButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeviceManualPage(HomeDevice.Name, HomeDevice.Id));
        }

        private void RoomPicker_SelectedIndexChanged(object sender, EventArgs e, Picker picker)
        {
            HomeDevice.Room = picker.Items[picker.SelectedIndex];
        }
    }
}