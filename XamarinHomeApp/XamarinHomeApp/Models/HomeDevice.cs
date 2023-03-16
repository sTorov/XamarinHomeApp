using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XamarinHomeApp.Models
{
    public class HomeDevice : INotifyPropertyChanged
    {
        private string _name;
        private string _description;

        public Guid Id { get; set; }

        //Обновление этого свойства теперь получают все страницы
        public string Name 
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");  // Вызов уведомления при изменении
                }
            }
        }

        //Обновление этого свойства теперь получают все страницы
        public string Description 
        {
            get { return _description; } 
            set
            {
                if(_description != value)
                {
                    _description = value;
                    OnPropertyChanged("Description");   // Вызов уведомления при изменении
                }
            }
        }

        public string Image { get; set; }
        public string Room { get; set; }

        public HomeDevice(string name = null, string image = null, string description = null, string room = null)
        {
            Id = Guid.NewGuid();
            Name = name;
            Image = image;
            Description = description;
            Room = room;
        }

        /* Реализация интерфейса InotifyPropertyChanged для автоматического 
           обновления интерфейса во всех страницах при обновлении модели */

        /// <summary>
        /// Делегат, указывающий на метод-обработчик события PropertyChanged, возникающего при изменении свойств компонента
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Метод, вызывающий событие PropertyChanged
        /// </summary>
        private void OnPropertyChanged(string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
