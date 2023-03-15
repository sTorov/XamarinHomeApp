using System;
using System.Collections.Generic;
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
        public List<HomeDevice> Devices { get; set; } = new List<HomeDevice>();

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
    }
}