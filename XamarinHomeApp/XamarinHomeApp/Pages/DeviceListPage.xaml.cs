using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinHomeApp.Models;
using XamarinHomeApp.Templates;

namespace XamarinHomeApp.Pages
{
    public partial class DeviceListPage : ContentPage
    {
        //Используется для автоматического отслеживания изменений в списке и уведомления об этих изменениях в приложении
        /// <summary>
        /// Группируемая коллекция
        /// </summary>
        public ObservableCollection<Group<string, HomeDevice>> DevicesGroups { get; set; } = new ObservableCollection<Group<string, HomeDevice>>();

        /// <summary>
        /// Ссылка на выбранный объект
        /// </summary>
        private HomeDevice selectedDevice;

        public DeviceListPage()
        {
            InitializeComponent();

            // Первоначальные данные сохраняем в обычный лист
            var initialList = new List<HomeDevice>
            {
                new HomeDevice("Чайник", "Chainik.png", "LG, объем 2л.", "Кухня"),
                new HomeDevice("Стиральная машина", "StiralnayaMashina.png", "BOSCH", "Ванная"),
                new HomeDevice("Посудомоечная машина", "PosudomoechnayaMashina.png", "Gorenje", "Кухня"),
                new HomeDevice("Мультиварка", "Multivarka.png", "Philips", "Кухня")
            };

            //Сгруппируем по комнатам
            var devicesByRooms = initialList.GroupBy(d => d.Room)
                .Select(g => new Group<string, HomeDevice>(g.Key, g));

            //Сохраняем
            DevicesGroups = new ObservableCollection<Group<string, HomeDevice>>(devicesByRooms);

            BindingContext = this;
        }

        /// <summary>
        /// Обработчик нажатия
        /// </summary>
        private void DeviceList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //распаковка объекта из модели
            var device = (HomeDevice)e.Item;
            //уведомление
            DisplayAlert("Нажатие", $"Вы нажали на {device.Name}", "ОК");
        }
            

        /// <summary>
        /// Обработчик выбора
        /// </summary>
        private void DeviceList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ////распаковка объекта из модели
            //var device = (HomeDevice)e.SelectedItem;
            ////уведомление
            //DisplayAlert("Выбор", $"Вы выбрали {device.Name}, {device.Description}", "ОК");
            selectedDevice = (HomeDevice)e.SelectedItem;
        }

        /// <summary>
        /// Переход на следующую страницу - страницу нового устройства (и помещение её в стек навигации)
        /// </summary>
        private async void NewDeviceButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new NewDevicePage("Новое устройство"));

        /// <summary>
        /// Возврат на первую страницу стека навигации (корневую страницу приложения) - экран логина
        /// </summary>
        private async void LogoutButton_Clicked(object sender, EventArgs e) => await Navigation.PopAsync();

        private async void EditDeviceButton_Clicked(object sender, EventArgs e) 
        {
            // проверяем, выбрал ли пользователь устройство из списка
            if(selectedDevice == null)
            {
                await DisplayAlert(null, $"Пожалуйста, выберите устройство!", "OK");
                return;
            }
            //Переход на следующую страницу - страницу нового устройства (и помещение её в стек навигации)
            await Navigation.PushAsync(new NewDevicePage("Изменить устройство", selectedDevice));
        }

        #region ListView_ObservableCollection

        /// <summary>
        /// Обработчик добавления устройства
        /// </summary>
        //private async void AddDevice(object sender, EventArgs e)
        //{
        //    //Запрос и валидация имени устройства
        //    var newDeviceName = await DisplayPromptAsync("Новое устройство", "Введите имя устройства", "Продолжить", "Отмена");
        //    if (Devices.Any(d => d.Name.CompareTo(newDeviceName.Trim()) == 0))
        //    {
        //        await DisplayAlert("Ошибка", $"Устройство {newDeviceName} уже существует", "OK");
        //        return;
        //    }

        //    //Запрос описания устройства
        //    var newDeviceDescription = await DisplayPromptAsync(newDeviceName, "Добавьте краткое описание", "Сохранить", "Отмена");
        //    //Добавление устройства и уведомление пользователя
        //    Devices.Add(new HomeDevice(newDeviceName, description: newDeviceDescription));
        //    await DisplayAlert(null, $"Устройство {newDeviceName} успешно добавлено", "OK");
        //}

        /// <summary>
        /// Обработчик удаления устройства
        /// </summary>
        //private async void RemoveDevice(object sender, EventArgs e)
        //{
        //    //Получаем и распаковываем выбранный элемент
        //    var deviceToRemove = deviceList.SelectedItem as HomeDevice;
        //    if (deviceToRemove != null)
        //    {
        //        //Удаляем
        //        Devices.Remove(deviceToRemove);
        //        //Уведомляем пользователя
        //        await DisplayAlert(null, $"Устройство {deviceToRemove.Name} удалено", "OK");
        //    }
        //}

        #endregion
    }
}