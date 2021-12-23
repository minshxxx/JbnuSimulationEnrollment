using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ProjectA.ViewModel
{
    public class IntroVM : Grid
    {
        static Window a = new Window();

        Host host = new Host();

        public IntroVM()
        {
            host.Show();
            host.Hide();
        }

        public Window window        //View.Intro의 Window를 받는 property
        {
            get { return (Window)GetValue(windowProperty); }
            set { SetValue(windowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for window.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty windowProperty =
            DependencyProperty.Register("window", typeof(Window), typeof(IntroVM), new PropertyMetadata(null, CallBack));

        private static void CallBack(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            IntroVM temp = source as IntroVM;
            a = temp.window;
            StartIntro();
        }

        static public void StartIntro()     //View.Intro의 페이지 자동종료 및 페이지 전환 함수
        {
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(4) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                var page = new Host();
                page.Show();
                a.Close();
            };
        }
    }
}