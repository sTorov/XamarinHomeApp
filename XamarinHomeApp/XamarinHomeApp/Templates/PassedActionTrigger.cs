using Xamarin.Forms;

namespace XamarinHomeApp.Templates
{
    /// <summary>
    /// Действие триггера, добавляющее анимацию для нажатой кнопки
    /// </summary>
    public class PassedActionTrigger : TriggerAction<Button>
    {
        protected override void Invoke(Button sender)
        {
            _ = sender.IsPressed ? sender.FadeTo(1, 300) : sender.FadeTo(0.8, 300);
        }
    }
}
