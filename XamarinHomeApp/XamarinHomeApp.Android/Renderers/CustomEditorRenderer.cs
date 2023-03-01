using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinHomeApp.Droid.Renderers;

[assembly: ExportRenderer(typeof(Editor), typeof(CustomEditorRenderer))]
namespace XamarinHomeApp.Droid.Renderers
{
    /// <summary>
    /// Отключаем подчёркивание по умолчанию для элементоа Editor на платформе Android
    /// </summary>
    public class CustomEditorRenderer : EditorRenderer
    {
        //Данный конструктор нужен только для платформы Android
        public CustomEditorRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
    }
}