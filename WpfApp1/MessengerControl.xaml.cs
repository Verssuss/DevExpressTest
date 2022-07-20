using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MessengerControl.xaml
    /// </summary>
    public partial class MessengerControl : UserControl, IMessenger
    {
        public MessengerControl()
        {
            InitializeComponent();
        }
        public async void ShowMessage(IMessage message)
        {
            var a = this;
            MessageControl rect = new MessageControl(message);
            rect.RenderTransform = new TransformGroup
            {
                Children = new TransformCollection
                 {
                     new TranslateTransform { X = rect.Width/2 },
                     new ScaleTransform() { }
                 }
            };
            rect.Opacity = 0;
            stackpanel.Children.Add(rect);
            rectangles.Enqueue(rect);
            var animation = new DoubleAnimation(0, TimeSpan.FromSeconds(1));
            var animation2 = new DoubleAnimation(1, TimeSpan.FromMilliseconds(300));
            animation.EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut };
            var sb = new Storyboard();
            sb.Children.Add(animation);
            sb.Children.Add(animation2);
            Storyboard.SetTarget(animation, rect);
            Storyboard.SetTarget(animation2, rect);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[0].(TranslateTransform.X)"));
            Storyboard.SetTargetProperty(animation2, new PropertyPath(OpacityProperty));
            sb.Begin();
            await Task.Delay(3000);
            if (isBusy == false)
            {
                DeleteMessage();
            }
        }

        Queue<UserControl> rectangles = new Queue<UserControl>();
        bool isBusy;
        private async void DeleteMessage()
        {
            if (rectangles.Count == 0) return;
            isBusy = true;
            var sb = new Storyboard();
            (stackpanel.Children[0] as UserControl).Height = (stackpanel.Children[0] as UserControl).ActualHeight;
            var animation = new DoubleAnimation(0, TimeSpan.FromMilliseconds(500));
            var animation2 = new DoubleAnimation(0, TimeSpan.FromMilliseconds(500));
            animation.EasingFunction = new ExponentialEase() { EasingMode = EasingMode.EaseOut };
            animation2.EasingFunction = new ExponentialEase() { EasingMode = EasingMode.EaseOut };
            sb.Children.Add(animation);
            sb.Children.Add(animation2);
            Storyboard.SetTarget(animation, stackpanel.Children[0]);
            Storyboard.SetTarget(animation2, stackpanel.Children[0]);
            Storyboard.SetTargetProperty(animation, new PropertyPath("Height"));
            Storyboard.SetTargetProperty(animation2, new PropertyPath(OpacityProperty));
            sb.Begin();

            await Task.Delay(2000);
            stackpanel.Children.Remove(rectangles.Peek());
            rectangles.Dequeue();

            isBusy = false;
            DeleteMessage();
        }


    }
}
