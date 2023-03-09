using Xamarin.Forms;

namespace XamarinHomeApp.Templates
{
    /// <summary>
    /// Действие триггера, меняющее цвет текста, пока поле заполнено неверно
    /// </summary>
    public class EmailTriggerAction : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            if(sender.IsFocused)
                sender.TextColor = sender.Text.Contains("@") && sender.Text.Contains(".")
                    ? Color.Black
                    : Color.Red;
        }
    }
}
