using ProjectA.Model;
using ProjectA.View;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace ProjectA.ViewModel
{
    class WaitVM : INotifyPropertyChanged
    {
        // 목표 과목
        private int[] goalIndexArr = new int[6];

        ClassDB classDB = new ClassDB();

        public ObservableCollection<PrintClassControl> GoalList { get; set; }

        private int[] MovedGoalData = new int[6];

        private int count = 0;

        private string nowClock = "7:59:45";
        public string NowClock
        {
            get { return nowClock; }
            set
            {
                nowClock = value; OnPropertyChanged(nameof(NowClock));
            }
        }

        DateTime[] time = new DateTime[1000];
        int ClockCount = 1;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public WaitVM()
        {
            GoalList = new ObservableCollection<PrintClassControl>();

            PrintGoalClass();

            Clock();
        }

        public void PrintGoalClass()        //목표과목을 추가해주는 함수
        {

            for (int i = 0; i < 6; i++)
            {
                int getClassCode = classDB.GetGoalIndexArr(i);

                PrintClassControl classControl = new PrintClassControl();
                ClassInformation tempClass = new ClassInformation();

                tempClass = classDB.GetClassInformation(getClassCode);
                classControl.xClassName.Text = tempClass.Name;
                classControl.xClassProfessor.Text = tempClass.Professor;
                classControl.xClassNum.Text = "[" + tempClass.Num + "]";

                if (classDB.GetClassInformation(getClassCode).type == "전필")
                    classControl.xImageBrush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/ProjectA;component/View/Resources/ClassControlNewRed.png"));
                if (classDB.GetClassInformation(getClassCode).type == "전선")
                    classControl.xImageBrush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/ProjectA;component/View/Resources/ClassControlNewGreen.png"));

                GoalList.Add(classControl);
            }
        }

        public void Clock()     //타이머 함수
        {  
            DispatcherTimer timer = new DispatcherTimer();    //객체생성

            timer.Interval = TimeSpan.FromTicks(10000000);    //시간간격 설정
            timer.Tick += new EventHandler(timer_Tick);          //이벤트 추가

            time[0] = DateTime.Now.Date.Add(new TimeSpan(7, 59, 45));   //시간 초기화

            timer.Start();
        }

        public void timer_Tick(object sender, EventArgs e)          //1초마다 하는 동작
        {
            time[ClockCount] = time[ClockCount - 1].AddSeconds(1);  //1초씩 증가
            NowClock = time[ClockCount].ToLongTimeString().Substring(3);
            ClockCount++;
        }
    }
}
