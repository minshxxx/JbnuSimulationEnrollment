using ProjectA.Model;
using ProjectA.Text;
using System;
using System.Collections.ObjectModel;

namespace ProjectA.ViewModel
{
    public class ClassDB
    {
        ClassInformation classInformation = new ClassInformation();

        private static ObservableCollection<int> AppliedIndexList = new ObservableCollection<int>();
        private static int[] goalIndexArr = new int[6];                                                 //목표 리스트 고유번호 배열

        // result 창으로 넘겨주는 필드
        private static string currentTime;
        private static string resultTime;
        private static string usedTime;
        private static string userName;
        private static string userStudentNum;

        private static int pastedTime;

        public void SetPastedTime(int inputInt)
        {
            pastedTime = inputInt;
        }
        public int GetPastedTime()
        {
            return pastedTime;
        }

        public PlayVM VM { get; set; }

        public ClassDB()
        {
        }

        public void setTime(string clockString)
        {
            currentTime = clockString;
        }
        public string getTime()
        {
            return currentTime;
        }

        public void SetUsedTime(string input)
        {
            usedTime = input;
        }
        public string GetUsedTime()
        {
            return usedTime;
        }

        public void SetResultTime(string input)
        {
            resultTime = input;
        }
        public string GetResultTime()
        {
            return resultTime;
        }

        public void SetUserName(string input)
        {
            userName = input;
        }
        public string GetUserName()
        {
            return userName;
        }

        public void SetUserStudentNum(string input)
        {
            userStudentNum = input;
        }
        public string GetUserStudentNum()
        {
            return userStudentNum;
        }


        public int GetGoalIndexArr(int inputindex)
        {
            return goalIndexArr[inputindex];
        }

        public int GetAppliedIndexToCode(int inputindex)
        {
            return AppliedIndexList[inputindex];
        }
        public void AddAppliedIndex(int inputindex)
        {
            AppliedIndexList.Add(inputindex);
        }
        public void CancleAppliedIndex(int inputindex)
        {
            AppliedIndexList.Remove(inputindex);
        }
        public int GetAppliedIndexListLength()
        {
            return AppliedIndexList.Count;
        }

        public void SetGameGoal()
        {
            Random r = new Random();
            ClassInformation Class1 = new ClassInformation();
            ClassInformation Class2 = new ClassInformation();

            for (int j = 0; j < 6; j++)
            {
                if (j > 1)
                {
                    goalIndexArr[j] = r.Next(0, 739);
                }
                else
                {
                    goalIndexArr[j] = r.Next(740, 798);
                }

                bool overlapFlag = false;

                for (int i = 0; i < j; i++)
                {
                    Class1 = GetClassInformation(goalIndexArr[i]);
                    Class2 = GetClassInformation(goalIndexArr[j]);

                    if (Class1.Name.ToString().Contains(Class2.Name.ToString()) || (Class2.Name.ToString().Contains(Class1.Name.ToString())))
                    {
                        overlapFlag = true;
                    }
                }
                if (overlapFlag)
                    j--;
            }
        }

        public ClassInformation GetClassInformation(int inputIndex)     //과목 정보 찾기
        {

            int classCode = inputIndex;

            int count = 0;
            if (inputIndex < 33)
            {
                Basic_Cogitation BC = new Basic_Cogitation();
                BC.ReadTxt();
                classInformation = new ClassInformation(classCode, BC.SubName[inputIndex - count], BC.ProName[inputIndex - count], BC.SubNum[inputIndex - count], BC.Location[inputIndex - count], BC.Time[inputIndex - count], "교양");
            }

            count += 33;
            if (count <= inputIndex && inputIndex < count + 136)
            {
                Basic_Expressive BE = new Basic_Expressive();
                BE.ReadTxt();
                classInformation = new ClassInformation(classCode, BE.SubName[inputIndex - count], BE.ProName[inputIndex - count], BE.SubNum[inputIndex - count], BE.Location[inputIndex - count], BE.Time[inputIndex - count], "교양");
            }

            count += 136;
            if (count <= inputIndex && inputIndex < count + 34)
            {
                Basic_Literacy BL = new Basic_Literacy();
                BL.ReadTxt();
                classInformation = new ClassInformation(classCode, BL.SubName[inputIndex - count], BL.ProName[inputIndex - count], BL.SubNum[inputIndex - count], BL.Location[inputIndex - count], BL.Time[inputIndex - count], "교양");
            }

            count += 34;
            if (count <= inputIndex && inputIndex < count + 42)
            {
                Core_Human CH = new Core_Human();
                CH.ReadTxt();
                classInformation = new ClassInformation(classCode, CH.SubName[inputIndex - count], CH.ProName[inputIndex - count], CH.SubNum[inputIndex - count], CH.Location[inputIndex - count], CH.Time[inputIndex - count], "교양");
            }

            count += 42;
            if (count <= inputIndex && inputIndex < count + 218)
            {
                Core_Science CSc = new Core_Science();
                CSc.ReadTxt();
                classInformation = new ClassInformation(classCode, CSc.SubName[inputIndex - count], CSc.ProName[inputIndex - count], CSc.SubNum[inputIndex - count], CSc.Location[inputIndex - count], CSc.Time[inputIndex - count], "교양");
            }

            count += 218;
            if (count <= inputIndex && inputIndex < count + 44)
            {
                Core_Social CSo = new Core_Social();
                CSo.ReadTxt();
                classInformation = new ClassInformation(classCode, CSo.SubName[inputIndex - count], CSo.ProName[inputIndex - count], CSo.SubNum[inputIndex - count], CSo.Location[inputIndex - count], CSo.Time[inputIndex - count], "교양");
            }
            count += 44;
            if (count <= inputIndex && inputIndex < count + 45)
            {
                Normal_ArtPhysicalEducation NA = new Normal_ArtPhysicalEducation();
                NA.ReadTxt();
                classInformation = new ClassInformation(classCode, NA.SubName[inputIndex - count], NA.ProName[inputIndex - count], NA.SubNum[inputIndex - count], NA.Location[inputIndex - count], NA.Time[inputIndex - count], "교양");
            }
            count += 45;
            if (count <= inputIndex && inputIndex < count + 64)
            {
                Normal_Humanities NH = new Normal_Humanities();
                NH.ReadTxt();
                classInformation = new ClassInformation(classCode, NH.SubName[inputIndex - count], NH.ProName[inputIndex - count], NH.SubNum[inputIndex - count], NH.Location[inputIndex - count], NH.Time[inputIndex - count], "교양");
            }
            count += 64;
            if (count <= inputIndex && inputIndex < count + 55)
            {
                Normal_MathInformation NM = new Normal_MathInformation();
                NM.ReadTxt();
                classInformation = new ClassInformation(classCode, NM.SubName[inputIndex - count], NM.ProName[inputIndex - count], NM.SubNum[inputIndex - count], NM.Location[inputIndex - count], NM.Time[inputIndex - count], "교양");
            }
            count += 55;
            if (count <= inputIndex && inputIndex < count + 48)
            {
                Normal_NaturalScience NN = new Normal_NaturalScience();
                NN.ReadTxt();
                classInformation = new ClassInformation(classCode, NN.SubName[inputIndex - count], NN.ProName[inputIndex - count], NN.SubNum[inputIndex - count], NN.Location[inputIndex - count], NN.Time[inputIndex - count], "교양");
            }
            count += 48;
            if (count <= inputIndex && inputIndex < count + 21)
            {
                Normal_SocialScience NS = new Normal_SocialScience();
                NS.ReadTxt();
                classInformation = new ClassInformation(classCode, NS.SubName[inputIndex - count], NS.ProName[inputIndex - count], NS.SubNum[inputIndex - count], NS.Location[inputIndex - count], NS.Time[inputIndex - count], "교양");
            }
            count += 21;
            if (count <= inputIndex && inputIndex < count + 58)
            {
                Major MJ = new Major();
                MJ.ReadTxt();
                if(classCode >= 755 && classCode <= 759)
                    classInformation = new ClassInformation(classCode, MJ.SubName[inputIndex - count], MJ.ProName[inputIndex - count], MJ.SubNum[inputIndex - count], MJ.Location[inputIndex - count], MJ.Time[inputIndex - count], "전필");
                else if (classCode >= 765 && classCode <= 769)
                    classInformation = new ClassInformation(classCode, MJ.SubName[inputIndex - count], MJ.ProName[inputIndex - count], MJ.SubNum[inputIndex - count], MJ.Location[inputIndex - count], MJ.Time[inputIndex - count], "전필");
                else if (classCode >= 772 && classCode <= 774)
                    classInformation = new ClassInformation(classCode, MJ.SubName[inputIndex - count], MJ.ProName[inputIndex - count], MJ.SubNum[inputIndex - count], MJ.Location[inputIndex - count], MJ.Time[inputIndex - count], "전필");
                else if (classCode >= 778 && classCode <= 779)
                    classInformation = new ClassInformation(classCode, MJ.SubName[inputIndex - count], MJ.ProName[inputIndex - count], MJ.SubNum[inputIndex - count], MJ.Location[inputIndex - count], MJ.Time[inputIndex - count], "전필");
                else
                    classInformation = new ClassInformation(classCode, MJ.SubName[inputIndex - count], MJ.ProName[inputIndex - count], MJ.SubNum[inputIndex - count], MJ.Location[inputIndex - count], MJ.Time[inputIndex - count], "전선");
          }
            return classInformation;
        }

        public string PrintClassInformation(int inputCode)      //과목 데이터 반환 함수1
        {
            ClassInformation classInformation = new ClassInformation();
            classInformation = GetClassInformation(inputCode);

            return "CODE:" + classInformation.Code.ToString() + " " + classInformation.Name + " " + classInformation.Professor + " "
                + classInformation.Num + " " + classInformation.Location + " \n" + classInformation.Time;
        }
        public string PrintClassInformation2(int inputCode)     //과목 데이터 반환 함수2
        {
            ClassInformation classInformation = new ClassInformation();
            classInformation = GetClassInformation(inputCode);

            return "[강의명] " + classInformation.Name + "[" + classInformation.Num + "]" + "\n[교수명] " + classInformation.Professor + "\n[장　소] " + classInformation.Location + "\n[시　간] " + classInformation.Time + "\n";
        }
    }
}
