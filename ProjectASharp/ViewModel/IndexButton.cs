using System.Windows;
using System.Windows.Controls;

namespace ProjectA.ViewModel
{
    class IndexButton : Button
    {
        public int ButtonIndex
        {
            get { return (int)GetValue(ButtonIndexProperty); }
            set { SetValue(ButtonIndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonIndexProperty =
            DependencyProperty.Register("ButtonIndex", typeof(int), typeof(IndexButton), new PropertyMetadata(0));
    }
}
