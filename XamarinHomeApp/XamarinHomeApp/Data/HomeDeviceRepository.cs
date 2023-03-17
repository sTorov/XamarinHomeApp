using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinHomeApp.Data.Tables;

namespace XamarinHomeApp.Data
{
    public class HomeDeviceRepository
    {
        //асинхронное подключение к базе данных
        private readonly SQLiteAsyncConnection connection;

        public HomeDeviceRepository(string dbPath)
        {
            //Создаём подключение в методе конструкторе
            connection = new SQLiteAsyncConnection(dbPath);
        }

        /// <summary>
        /// Проверяем на наличие таблицы и создаем в случае необходимости
        /// </summary>
        public async Task InitDatabase() =>
            await connection.CreateTableAsync<HomeDevice>();

        /// <summary>
        /// Получение всех устройств
        /// </summary>
        public async Task<HomeDevice[]> GetHomeDevices() =>
            await connection.Table<HomeDevice>().ToArrayAsync();

        /// <summary>
        /// Поиск устройства по идентификатору
        /// </summary>
        public async Task<HomeDevice> GetHomeDevice(int id) => 
            await connection.GetAsync<HomeDevice>(id);

        /// <summary>
        /// Удаление устройства
        /// </summary>
        public async Task<int> DeleteHomeDevice(HomeDevice homeDevice) =>
            await connection.DeleteAsync(homeDevice);

        /// <summary>
        /// Добавление устройства
        /// </summary>
        public async Task<int> AddHomeDevice(HomeDevice homeDevice) =>
            await connection.InsertAsync(homeDevice);

        /// <summary>
        /// Обновление устройства
        /// </summary>
        public async Task<int> UpdateHomeDevice(HomeDevice homeDevice) =>
            await connection.UpdateAsync(homeDevice);

    }
}
