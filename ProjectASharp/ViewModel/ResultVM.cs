using ProjectA.Model;
using ProjectA.View;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Media.Imaging;

namespace ProjectA.ViewModel
{

    class ResultVM
    {
        ClassDB classDB = new ClassDB();

        public ObservableCollection<ResultControl> GoalList { get; set; }
        public ObservableCollection<string> AppliedList { get; set; }

        public string UsedTime { get; set; }
        public string ResultTime { get; set; }
        public int CorrectNum { get; set; }
        public string UserName { get; set; }
        public string UserNum { get; set; }
        public string Comment { get; set; }

        public ResultVM()
        {
            classDB = new ClassDB();

            GoalList = new ObservableCollection<ResultControl>();
            AppliedList = new ObservableCollection<string>();

            UserName = classDB.GetUserName();
            ResultTime = classDB.GetResultTime();
            UserNum = classDB.GetUserStudentNum();
            UsedTime = classDB.GetUsedTime();
            CorrectNum = 0;

            int classCode1, classCode2;

            bool checkCorrected;

            for (int i = 0; i < classDB.GetAppliedIndexListLength(); i++)
            {
                classCode2 = classDB.GetAppliedIndexToCode(i);
                AppliedList.Add(classDB.PrintClassInformation2(classCode2));
            }
            for (int i = 0; i < 6; i++)
            {
                checkCorrected = false;

                classCode1 = classDB.GetGoalIndexArr(i);
                for (int j = 0; j < classDB.GetAppliedIndexListLength(); j++)
                {
                    classCode2 = classDB.GetAppliedIndexToCode(j);
                    if (classCode1 == classCode2)
                    {
                        CorrectNum++;
                        checkCorrected = true;
                    }
                }
                PrintGoalClass(i, checkCorrected);
            }

            if (CorrectNum == 0) Comment = "학교다닐 마음은 있는건가요...?";
            if (CorrectNum == 1) Comment = "그래... 하나라도 열심히 듣자";
            if (CorrectNum == 2) Comment = "두개면 뭐... 하나보다는 낫지...";
            if (CorrectNum == 3) Comment = "조금만 더 신중했더라면...ㅠㅠ";
            if (CorrectNum == 4) Comment = "두개만 더 담았더라면...";
            if (CorrectNum == 5) Comment = "하나만 더 담았더라면...";
            if (CorrectNum == 6) Comment = "6개나 담았다. 오늘 저녁은 치킨이닭";

            AddRecord(UserName, UserNum, ResultTime, UsedTime, CorrectNum);
        }

        public void PrintGoalClass(int inputindex, bool check)      //목표과목을 추가해주는 함수
        {
                int getClassCode = classDB.GetGoalIndexArr(inputindex);

                ResultControl classControl = new ResultControl();
                ClassInformation tempClass = new ClassInformation();

                tempClass = classDB.GetClassInformation(getClassCode);
                classControl.xClassName.Text = tempClass.Name;
            if (check)
                classControl.xImageBrush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/ProjectA;component/View/Resources/resultO.png"));
            GoalList.Add(classControl);
        }


        public void AddRecord(string name, string studentNum, string resultTime, string second, int right)      //결과를 txt파일에 저장하는 함수
        {
            File.AppendAllText(@"RecordRight.txt", right.ToString());
            File.AppendAllText(@"RecordRight.txt", "\n");

            File.AppendAllText(@"RecordSecond.txt", second);
            File.AppendAllText(@"RecordSecond.txt", "\n");

            File.AppendAllText(@"RecordResultTime.txt", resultTime);
            File.AppendAllText(@"RecordResultTime.txt", "\n");

            File.AppendAllText(@"RecordName.txt", name);
            File.AppendAllText(@"RecordName.txt", "\n");

            File.AppendAllText(@"RecordStudentNum.txt", studentNum);
            File.AppendAllText(@"RecordStudentNum.txt", "\n");


        }
    }
}
