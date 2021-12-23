using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ProjectA.ViewModel
{
    public class PlayPopupVM : TextBlock, INotifyPropertyChanged
    {
        ClassDB classDB = new ClassDB();

        DispatcherTimer timer = new DispatcherTimer();    //객체생성
        Window saveWindow = new Window();

        private bool closeCheck;
        public bool CloseCheck
        {
            get
            {
                return closeCheck;
            }
            set
            {
                closeCheck = value;
            }
        }

        private string nowPerson;
        public string NowPerson
        {
            get { return nowPerson; }
            set
            {
                nowPerson = value; OnPropertyChanged("NowPerson");
            }
        }

        private string initialPersonNum;
        public string InitialPersonNum
        {
            get { return initialPersonNum; }
            set
            {
                initialPersonNum = value; OnPropertyChanged("InitialPersonNum");
            }
        }


        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public PlayPopupVM()
        {
            if ((classDB.GetPastedTime() < 204))
                initialPersonNum = (7000 - (classDB.GetPastedTime() * classDB.GetPastedTime()) / 6).ToString();
            else
                initialPersonNum = "500";

            Clock();
        }

        public Window window    //View.PlayViewPopup의 Window를 얻기 위한 property
        {
            get { return (Window)GetValue(windowProperty); }
            set { SetValue(windowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for window.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty windowProperty =
            DependencyProperty.Register("window", typeof(Window), typeof(PlayPopupVM), new PropertyMetadata(null, Callback));

        private static void Callback(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            PlayPopupVM temp = source as PlayPopupVM;
            if (temp.window != null)
            {
                PlayPopupVM playPopupVM = new PlayPopupVM();
                playPopupVM.saveWindow = temp.window;
            }
        }

        public void ResetWindow(int inputNum)
        {
            initialPersonNum = inputNum.ToString();
            nowPerson = inputNum.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Clock()
        {
            timer = new DispatcherTimer();    //객체생성

            timer.Interval = TimeSpan.FromTicks(3000000);    //시간간격 설정
            timer.Tick += new EventHandler(timer_Tick);          //이벤트 추가

            //time[0] = DateTime.Now.Date.Add(new TimeSpan(7, 59, 57));   //시간 초기화
            NowPerson = InitialPersonNum;

            timer.Start();
        }

        public void timer_Tick(object sender, EventArgs e)          //1초마다 하는 동작
        {
            Random ran = new Random();

            int tempPerson = int.Parse(NowPerson);

            if (tempPerson > 500) {
                tempPerson = tempPerson - ran.Next(150, 500);
                NowPerson = tempPerson.ToString();
            }
            else
            {
                CloseCheck = true;
                saveWindow.Close();
            }

        }
    }
}
