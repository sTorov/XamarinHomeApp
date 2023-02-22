using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace XamarinHomeApp.Templates
{
    internal class ColorViewExtension : IMarkupExtension
    {
        private int red;
        public int R 
        {
            get { return red; }
            set
            {
                int val;
                val = value < 0 ? 0 : value > 255 ? 255 : value;
                red = val;
            }
        }

        private int green;
        public int G
        {
            get { return green; }
            set
            {
                int val;
                val = value < 0 ? 0 : value > 255 ? 255 : value;
                green = val;
            }
        }

        private int blue;
        public int B
        {
            get { return blue; }
            set
            {
                int val;
                val = value < 0 ? 0 : value > 255 ? 255 : value;
                blue = val;
            }
        }

        public object ProvideValue(IServiceProvider serviceProvider) =>
            Color.FromRgb(R, G, B);
    }
}
