using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinHomeApp.Models;

namespace XamarinHomeApp.Pages
{
    public partial class DeviceListPage : ContentPage
    {
        //Используется для автоматического отслеживания изменений в списке и уведомления об этих изменениях в приложении
        public ObservableCollection<HomeDevice> Devices { get; set; } = new ObservableCollection<HomeDevice>();

        public DeviceListPage()
        {
            InitializeComponent();
            //this 
            // Заполняем список устройств
            Devices.Add(new HomeDevice("Чайник", description: "LG, объем 2л.", image: "Chainik.png"));
            Devices.Add(new HomeDevice("Стиральная машина", description: "BOSCH", image: "StiralnayaMashina.png"));
            Devices.Add(new HomeDevice("Посудомоечная машина", description: "Gorenje", image: "PosudomoechnayaMashina.png"));
            Devices.Add(new HomeDevice("Мультиварка", description: "Philips", image: "Multivarka.png"));

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
            //распаковка объекта из модели
            var device = (HomeDevice)e.SelectedItem;
            //уведомление
            DisplayAlert("Выбор", $"Вы выбрали {device.Name}, {device.Description}", "ОК");
        }

        /// <summary>
        /// Обработчик добавления устройства
        /// </summary>
        private async void AddDevice(object sender, EventArgs e)
        {
            //Запрос и валидация имени устройства
            var newDeviceName = await DisplayPromptAsync("Новое устройство", "Введите имя устройства", "Продолжить", "Отмена");
            if (Devices.Any(d => d.Name.CompareTo(newDeviceName.Trim()) == 0))
            {
                await DisplayAlert("Ошибка", $"Устройство {newDeviceName} уже существует", "OK");
                return;
            }

            //Запрос описания устройства
            var newDeviceDescription = await DisplayPromptAsync(newDeviceName, "Добавьте краткое описание", "Сохранить", "Отмена");
            //Добавление устройства и уведомление пользователя
            Devices.Add(new HomeDevice(newDeviceName, description: newDeviceDescription));
            await DisplayAlert(null, $"Устройство {newDeviceName} успешно добавлено", "OK");
        }

        /// <summary>
        /// Обработчик удаления устройства
        /// </summary>
        private async void RemoveDevice(object sender, EventArgs e)
        {
            //Получаем и распаковываем выбранный элемент
            var deviceToRemove = deviceList.SelectedItem as HomeDevice;
            if (deviceToRemove != null)
            {
                //Удаляем
                Devices.Remove(deviceToRemove);
                //Уведомляем пользователя
                await DisplayAlert(null, $"Устройство {deviceToRemove.Name} удалено", "OK");
            }
        }
    }
}