using ProjectA.Model;
using ProjectA.View;
using ProjectA.ViewModel.Command;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace ProjectA.ViewModel
{
    public class PlayVM : INotifyPropertyChanged
    {

        public ObservableCollection<string> ComBox2 { get; set; }
        public ObservableCollection<string> GoalIndexList { get; set; }
        public ObservableCollection<ClassControl> ClassList { get; set; }
        public ObservableCollection<AppliedControl> AppliedList { get; set; }
        public ObservableCollection<int> AppliedIndexList { get; set; }
        public ObservableCollection<PrintClassControl> GoalList { get; set; }

        public PlayInformation playInformation { get; set; }

        //기능 커맨드
        public IndexButtonCommand IndexButtonCommand { get; set; }
        public CancleButtonCommand CancleButtonCommand { get; set; }
        public PlaySearchCommand PlaySearchCommand { get; set; }

        ClassDB classDB = new ClassDB();

        Random ran = new Random();

        private int[] MovedGoalData = new int[6];

        private string nowClock;

        // 생성자
        public PlayVM()
        {
            ComBox2 = new ObservableCollection<string>();
            ClassList = new ObservableCollection<ClassControl>();
            AppliedList = new ObservableCollection<AppliedControl>();
            GoalIndexList = new ObservableCollection<string>();
            AppliedIndexList = new ObservableCollection<int>();
            playInformation = new PlayInformation();

            GoalList = new ObservableCollection<PrintClassControl>();


            nowClock = classDB.getTime();

            PrintGoalClass();
            Clock();

            UserName = classDB.GetUserName();
            UserStudentNum = classDB.GetUserStudentNum();

            IndexButtonCommand = new IndexButtonCommand(this);
            CancleButtonCommand = new CancleButtonCommand(this);
            PlaySearchCommand = new PlaySearchCommand(this);
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
            }
        }
        private string userStudentNum;
        public string UserStudentNum
        {
            get { return userStudentNum; }
            set
            {
                userStudentNum = value;
            }
        }

        public string NowClock
        {
            get { return nowClock; }
            set
            {
                nowClock = value; OnPropertyChanged(nameof(NowClock));

                int h = int.Parse(NowClock.Substring(0, 1)) - 8;
                int m = int.Parse(NowClock.ToString().Substring(2, 2));
                int s = int.Parse(NowClock.ToString().Substring(5, 2));

                int usedTime = h * 3600 + m * 60 + s;
                classDB.SetPastedTime(usedTime);
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


        // 프로퍼티
        private int clickClassButton;
        public int ClickClassButton
        {
            get
            {
                return clickClassButton;
            }
            set
            {
                clickClassButton = value;
                AddApplyClass(clickClassButton);
            }
        }


        private int cancleButtonProperty;
        public int CancleButtonProperty
        {

            get
            {
                return cancleButtonProperty;
            }
            set
            {
                cancleButtonProperty = value;
                CancleClass(cancleButtonProperty);
            }
        }

        private int selectedComBox1;
        public int SelectedCombBox1
        {
            get
            {

                return selectedComBox1;
            }
            set
            {
                selectedComBox1 = value;
                SetComBox2();
            }
        }

        private int selectedComBox2;
        public int SelectedCombBox2
        {
            get
            {
                return selectedComBox2;
            }
            set
            {
                selectedComBox2 = value;
                if (selectedComBox2 != -1)
                {
                    switch (selectedComBox1)
                    {
                        case 1:
                            switch (SelectedCombBox2)
                            {
                                case 0:
                                    break;
                                case 1:
                                    PrintClassPanel(169, 202);
                                    break;
                                case 2:
                                    PrintClassPanel(0, 32);
                                    break;
                                case 3:
                                    PrintClassPanel(33, 168);
                                    break;
                            }
                            break;
                        case 2:
                            switch (SelectedCombBox2)
                            {
                                case 0:
                                    break;
                                case 1:
                                    PrintClassPanel(719, 739);
                                    break;
                                case 2:
                                    PrintClassPanel(616, 670);
                                    break;
                                case 3:
                                    PrintClassPanel(507, 551);
                                    break;
                                case 4:
                                    PrintClassPanel(552, 615);
                                    break;
                                case 5:
                                    PrintClassPanel(671, 718);
                                    break;
                            }
                            break;
                        case 3:
                            switch (SelectedCombBox2)
                            {
                                case 0:
                                    break;
                                case 1:
                                    PrintClassPanel(463, 506);
                                    break;
                                case 2:
                                    PrintClassPanel(203, 244);
                                    break;
                                case 3:
                                    PrintClassPanel(245, 462);
                                    break;
                            }
                            break;
                    }
                }
            }
        }

        private int selectedComBox3;
        public int SelectedCombBox3
        {
            get
            {
                return selectedComBox3;
            }
            set
            {
                selectedComBox3 = value;
                switch (selectedComBox3)
                {
                    case 0:
                        break;
                    case 1:
                        PrintClassPanel(740, 744);
                        break;
                    case 2:
                        PrintClassPanel(745, 761);
                        break;
                    case 3:
                        PrintClassPanel(762, 786);
                        break;
                    case 4:
                        PrintClassPanel(787, 797);
                        break;
                }
            }
        }

        private string searchBox;
        public string SearchBox
        {
            get
            {
                return searchBox;
            }
            set
            {
                searchBox = value;
            }
        }

        // 함수
        public void SetComBox2()
        {
            ComBox2.Clear();
            ComBox2.Add("-선택-");

            switch (selectedComBox1)
            {
                case 0:
                    break;
                case 1:
                    ComBox2.Add("문해력");
                    ComBox2.Add("사고력");
                    ComBox2.Add("표현력");
                    break;
                case 2:
                    ComBox2.Add("사회과학");
                    ComBox2.Add("수리:정보");
                    ComBox2.Add("예술:체육");
                    ComBox2.Add("인문학");
                    ComBox2.Add("자연과학");
                    break;
                case 3:
                    ComBox2.Add("사회");
                    ComBox2.Add("인간");
                    ComBox2.Add("자연");
                    break;
            }
        }
        public void CancleClass(int inputindex)     //수강신청 과목 취소 함수
        {
            for (int i = 0; i < AppliedList.Count; i++)
            {
                if (AppliedList[i].xApplyButton.ButtonIndex == inputindex)
                {
                    ShowWaitPopup();
                    AppliedList.RemoveAt(i);
                    AppliedIndexList.Remove(i);
                    playInformation.AppliedCnt = playInformation.AppliedCnt - 1;
                    playInformation.RemainGradePoint = (6 - playInformation.AppliedCnt) * 3;
                    playInformation.UsedGradePoint = playInformation.AppliedCnt * 3;
                }
            }
        }
        public void AddApplyClass(int inputindex)       //수강 과목 신청 함수
        {
            if (playInformation.AppliedCnt != 6)
            {
                ClassInformation Class1 = new ClassInformation();
                ClassInformation Class2 = new ClassInformation();

                bool overlapFlag = false;


                //중복검사
                for (int i = 0; i < playInformation.AppliedCnt; i++)
                {
                    Class1 = classDB.GetClassInformation(AppliedList[i].xApplyButton.ButtonIndex);
                    Class2 = classDB.GetClassInformation(inputindex);

                    if (Class1.Name.ToString().Contains(Class2.Name.ToString()) || (Class2.Name.ToString().Contains(Class1.Name.ToString())))
                    {
                        overlapFlag = true;
                    }
                }

                if (!overlapFlag)
                {
                    AddAppliedControl(inputindex);

                    playInformation.AppliedCnt = playInformation.AppliedCnt + 1;
                    playInformation.RemainGradePoint = (6 - playInformation.AppliedCnt) * 3;
                    playInformation.UsedGradePoint = playInformation.AppliedCnt * 3;
                }
                else
                {
                    System.Windows.MessageBox.Show("이미 동일한 수업명이 신청되어 있습니다.");
                }
            }
            else
                System.Windows.MessageBox.Show("더 이상 강의를 신청할 수 없습니다.");
        }

        public void AddAppliedControl(int inputNum)     //수강신청 완료 과목 추가 함수
        {
            ClassDB classDB = new ClassDB();
            AppliedControl appliedControl = new AppliedControl();
            appliedControl.xApplyButton.ButtonIndex = inputNum;
            appliedControl.xClassName.Text = classDB.GetClassInformation(inputNum).Name;
            appliedControl.xClassProfessor.Text = classDB.GetClassInformation(inputNum).Professor;
            appliedControl.xClassNum.Text = classDB.GetClassInformation(inputNum).Num;
            appliedControl.xClassType.Text = classDB.GetClassInformation(inputNum).type;
            appliedControl.DataContext = this;
            classDB.AddAppliedIndex(inputNum);
            AppliedList.Add(appliedControl);
        }

        public ClassControl MakeUserControl(int inputNum)       //과목 데이터를 하나의 유저 컨트롤로 만들어주는 함수
        {
            ClassDB classDB = new ClassDB();
            ClassControl classControl = new ClassControl();

            classControl.xApplyButton.ButtonIndex = inputNum;
            classControl.XclassName.Text = classDB.GetClassInformation(inputNum).Name;
            classControl.xClassProfessor.Text = classDB.GetClassInformation(inputNum).Professor;
            classControl.xClassNum.Text = classDB.GetClassInformation(inputNum).Num;
            classControl.xClassLocation.Text = classDB.GetClassInformation(inputNum).Location;
            classControl.xClassTime.Text = classDB.GetClassInformation(inputNum).Time;
            classControl.xclassType.Text = classDB.GetClassInformation(inputNum).Type;
            if (inputNum > 739)
            {
                if (classDB.GetClassInformation(inputNum).Type == "전필")
                {
                    classControl.XclassName.Foreground = new SolidColorBrush(Colors.DarkRed);
                    classControl.xClassProfessor.Foreground = new SolidColorBrush(Colors.DarkRed);
                    classControl.xClassNum.Foreground = new SolidColorBrush(Colors.DarkRed);
                    classControl.xClassLocation.Foreground = new SolidColorBrush(Colors.DarkRed);
                    classControl.xClassTime.Foreground = new SolidColorBrush(Colors.DarkRed);
                    classControl.xclassType.Foreground = new SolidColorBrush(Colors.DarkRed);
                    classControl.xMaxNum.Foreground = new SolidColorBrush(Colors.DarkRed);
                    classControl.Color1.Foreground = new SolidColorBrush(Colors.DarkRed);
                    classControl.Color2.Foreground = new SolidColorBrush(Colors.DarkRed);
                    classControl.Color3.Foreground = new SolidColorBrush(Colors.DarkRed);
                    classControl.xClassStudentNum.Foreground = new SolidColorBrush(Colors.DarkRed);
                }
                if (classDB.GetClassInformation(inputNum).Type == "전선")
                {

                    classControl.XclassName.Foreground = new SolidColorBrush(Colors.DarkGreen);
                    classControl.xClassProfessor.Foreground = new SolidColorBrush(Colors.DarkGreen);
                    classControl.xClassNum.Foreground = new SolidColorBrush(Colors.DarkGreen);
                    classControl.xClassLocation.Foreground = new SolidColorBrush(Colors.DarkGreen);
                    classControl.xClassTime.Foreground = new SolidColorBrush(Colors.DarkGreen);
                    classControl.xclassType.Foreground = new SolidColorBrush(Colors.DarkGreen);
                    classControl.xMaxNum.Foreground = new SolidColorBrush(Colors.DarkGreen);
                    classControl.Color1.Foreground = new SolidColorBrush(Colors.DarkGreen);
                    classControl.Color2.Foreground = new SolidColorBrush(Colors.DarkGreen);
                    classControl.Color3.Foreground = new SolidColorBrush(Colors.DarkGreen);
                    classControl.xClassStudentNum.Foreground = new SolidColorBrush(Colors.DarkGreen);
                }

            }
            classControl.xMaxNum.Text = "40";
            classControl.DataContext = this;

            int h = int.Parse(NowClock.Substring(0, 1)) - 8;
            int m = int.Parse(NowClock.ToString().Substring(2, 2));
            int s = int.Parse(NowClock.ToString().Substring(5, 2));

            int usedTime = h * 3600 + m * 60 + s;

            if (usedTime < 10) classControl.xClassStudentNum.Text = ran.Next(0, 15).ToString();
            else if (usedTime < 30) classControl.xClassStudentNum.Text = ran.Next(13, 25).ToString();
            else if (usedTime < 45) classControl.xClassStudentNum.Text = ran.Next(22, 30).ToString();
            else if (usedTime < 60) classControl.xClassStudentNum.Text = ran.Next(30, 35).ToString();
            else if (usedTime < 90) classControl.xClassStudentNum.Text = ran.Next(35, 40).ToString();
            else if (usedTime < 120)
            {
                if (ran.Next(0, 3) == 0)
                    classControl.xClassStudentNum.Text = "39";
                else classControl.xClassStudentNum.Text = "40";
            }
            else if (usedTime < 180)
            {
                if (ran.Next(0, 5) == 0)
                    classControl.xClassStudentNum.Text = "39";
                else classControl.xClassStudentNum.Text = "40";
            }
            else
            {
                if (ran.Next(0, 7) == 0)
                    classControl.xClassStudentNum.Text = "39";
                else classControl.xClassStudentNum.Text = "40";
            }
            return classControl;
        }

        public void PrintClassPanel(int num1, int num2)         //수업목록에 과목 추가 함수
        {
            ClassControl classControl = new ClassControl();

            ShowWaitPopup();
            ClassList.Clear();
            for (int i = num1; i <= num2; i++)
            {
                classControl = MakeUserControl(i);
                if (i % 2 == 1 && num1 % 2 == 0)
                    classControl.ClassControlColor.ImageSource = new BitmapImage(new Uri("pack://application:,,,/ProjectA;component/View/Resources/ClassList2.png"));
                if (i % 2 == 0 && num1 % 2 == 1)
                    classControl.ClassControlColor.ImageSource = new BitmapImage(new Uri("pack://application:,,,/ProjectA;component/View/Resources/ClassList2.png"));
                ClassList.Add(classControl);
            }
        }
        public void SearchPrintClassPanel(string searchString)  //검색 과목 추가 함수
        {
            ClassInformation tempClass = new ClassInformation();
            ClassControl classControl = new ClassControl();

            bool checkColor = false;

            ShowWaitPopup();
            ClassList.Clear();

            for (int i = 0; i < 740; i++)
            {
                tempClass = classDB.GetClassInformation(i);

                if (tempClass.Name.ToString().Contains(searchString))
                {
                    classControl = MakeUserControl(i);
                    if (checkColor)
                    {
                        classControl.ClassControlColor.ImageSource = new BitmapImage(new Uri("pack://application:,,,/ProjectA;component/View/Resources/ClassList2.png"));
                        checkColor = false;
                    }
                    else
                    {
                        checkColor = true;
                    }
                    ClassList.Add(classControl);
                }
            }
        }
        public void Clock()     //타이머 함수
        {
            DispatcherTimer timer = new DispatcherTimer();    //객체생성

            timer.Interval = TimeSpan.FromTicks(10000000);    //시간간격 설정
            timer.Tick += new EventHandler(timer_Tick);          //이벤트 추가

            int h = int.Parse(classDB.getTime().Substring(0, 1));
            int m = int.Parse(classDB.getTime().Substring(2, 2));
            int s = int.Parse(classDB.getTime().Substring(5, 2));

            time[0] = DateTime.Now.Date.Add(new TimeSpan(h, m, s));   //시간 초기화

            timer.Start();
        }
        public void timer_Tick(object sender, EventArgs e)          //1초마다 하는 동작
        {
            time[ClockCount] = time[ClockCount - 1].AddSeconds(1);  //1초씩 증가
            NowClock = time[ClockCount].ToLongTimeString().Substring(3);
            ClockCount++;
        }
        public void ShowWaitPopup()     //팝업창 보여주고 닫는 함수
        {
            PlayViewPopup playViewPopup = new PlayViewPopup();
            playViewPopup.ShowDialog();
            playViewPopup.Hide();
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
    }

}
