using ProjectA.View;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace ProjectA.ViewModel
{
    public class ReadyVM
    {
        // 목표 과목
        private int[] goalIndexArr = new int[6];

        ClassDB classDB = new ClassDB();

        //목표 과목리스트
        public ObservableCollection<string> goalList { get; set; }
        public ObservableCollection<ReadyControl> goalControlList { get; set; }

        public ReadyVM()
        {
            classDB = new ClassDB();

            goalList = new ObservableCollection<string>();
            goalControlList = new ObservableCollection<ReadyControl>();

            classDB.SetGameGoal();

            for (int i = 0; i < 6; i++)
            {
                goalList.Add(classDB.PrintClassInformation(classDB.GetGoalIndexArr(i)));
                AddGoalControl(classDB.GetClassInformation(classDB.GetGoalIndexArr(i)).Code, i+1);
            }

        }

        public void AddGoalControl(int inputNum, int goalNum)       //목표 과목 유저컨트롤형태로 만들어주는 함수
        {
            ClassDB classDB = new ClassDB();
            ReadyControl ReadyControl = new ReadyControl();

            ReadyControl.xGoalNum.Text = goalNum.ToString();
            ReadyControl.xType.Text = classDB.GetClassInformation(inputNum).Type;
            ReadyControl.xClassName.Text = classDB.GetClassInformation(inputNum).Name + " [" + classDB.GetClassInformation(inputNum).Num + "]";
            ReadyControl.XClassProfessor.Text = classDB.GetClassInformation(inputNum).Professor;
            if (classDB.GetClassInformation(inputNum).type == "전필")
                ReadyControl.xImageBrush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/ProjectA;component/View/Resources/ReadyViewControlRed.png"));
            if (classDB.GetClassInformation(inputNum).type == "전선")
                ReadyControl.xImageBrush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/ProjectA;component/View/Resources/ReadyViewControlGreen.png"));
            goalControlList.Add(ReadyControl);
        }
    }
}
