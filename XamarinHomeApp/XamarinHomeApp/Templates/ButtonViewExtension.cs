﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Xaml;

namespace XamarinHomeApp.Templates
{
    public class ButtonViewExtension : IMarkupExtension     //Интерфейс для создания собственных расширений для xaml разметки
    {
        public ButtonStyle ButtonStyle { get; set; }

        /// <summary>
        /// Меняем числовое значение параметра в зависимости от переданной настройки
        /// </summary>
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            switch(ButtonStyle)
            {
                case ButtonStyle.Default: return 0;
                case ButtonStyle.SemiRound: return 15;
                case ButtonStyle.Round: return 30;
                default: return 0;
            };
        }
    }

    /// <summary>
    /// Стили кнопок
    /// </summary>
    public enum ButtonStyle
    {
        Default,
        SemiRound,
        Round
    }
}
