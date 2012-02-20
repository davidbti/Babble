using System;
using System.Windows.Interactivity;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Bti.Babble.Traffic
{
    public class TakeFocusAndSelectTextOnVisibleBehavior : TriggerAction<TextBox>
    {
        protected override void Invoke(object parameter)
        {
            Dispatcher.BeginInvoke(
                DispatcherPriority.Loaded,
                new Action(() =>
                {
                    AssociatedObject.Focus();
                    AssociatedObject.SelectAll();
                }));
        }
    } 

}
