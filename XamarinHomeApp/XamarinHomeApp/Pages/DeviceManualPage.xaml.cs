using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHomeApp.Pages
{
    public partial class DeviceManualPage : ContentPage
    {
        /// <summary>
        /// Имя устройства
        /// </summary>
        public static string DeviceName { get; set; }

        /// <summary>
        /// Путь до файла с инструкцией
        /// </summary>
        public static string FilePath { get; set; }

        public DeviceManualPage(string deviceName, Guid deviceId)
        {
            //В конструкторе сохраняем имя устройства и унмкальный путь до файла с инструкцией
            DeviceName = deviceName;
            FilePath = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData),
                $"{deviceId}.txt"
                );

            InitializeComponent();
        }

        /// <summary>
        /// При отображении экрана - загружаем текст инструкции в форму из файла
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(File.Exists(FilePath))
                deviceManualText.Text = File.ReadAllText(FilePath);
        }

        /// <summary>
        /// При сохранении - обновляем текст инструкции и возвращаемся назад
        /// </summary>
        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            File.WriteAllText(FilePath, deviceManualText.Text);
            await Navigation.PopAsync();
        }
    }
}