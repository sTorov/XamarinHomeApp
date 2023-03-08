using Android.OS;
using Xamarin.Forms;

[assembly: Dependency(typeof(XamarinHomeApp.Droid.DeviceDetector))]
namespace XamarinHomeApp.Droid
{
    public class DeviceDetector : IDeviceDetector
    {
        public string GetDevice()
        {
            //Сообщаем строку с информацией о платформе
            return $"Запущено на устройтве {Build.Product}\nплатформа {Device.RuntimePlatform}";
        }
    }
}