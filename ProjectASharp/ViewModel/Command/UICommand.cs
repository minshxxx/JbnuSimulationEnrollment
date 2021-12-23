using ProjectA.View;
using System;
using System.Windows.Input;

namespace ProjectA.ViewModel.Command
{
    public class UICommand : ICommand
    {
        ClassDB classDB = new ClassDB();
        public UICommand() { }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var values = (object[])parameter;
            var thisPageName = (string)values[0];
            var thisPage = values[1];

            if ((thisPage.GetType().ToString().Equals("ProjectA.View.WaitViewPopUp") && thisPageName.Equals("ToExit")))  //종료 버튼 클릭
            {
                var thisPopUp = thisPage as WaitViewPopUp;

                thisPopUp.Close();
            }
            else if(thisPageName.Equals("ToExit"))  //종료 버튼 클릭
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }

            if (thisPage.GetType().ToString().Equals("ProjectA.View.HomeView") && thisPageName.Equals("ToReady"))   //홈에서 레디 페이지 이동버튼 클릭
            {
                var PreviousPage = thisPage as HomeView;

                var newPage = new ReadyView();
                PreviousPage.NavigationService.Navigate(newPage);
            }

            if (thisPage.GetType().ToString().Equals("ProjectA.View.HomeView") && thisPageName.Equals("ToRecord"))  //홈에서 기록 페이지 이동버튼 클릭
            {
                var PreviousPage = thisPage as HomeView;

                var newPage = new RecordView();
                PreviousPage.NavigationService.Navigate(newPage);
            }

            if (thisPage.GetType().ToString().Equals("ProjectA.View.RecordView") && thisPageName.Equals("ToReady")) //기록에서 레디 페이지 이동버튼 클릭
            {
                var PreviousPage = thisPage as RecordView;

                var newPage = new ReadyView();
                PreviousPage.NavigationService.Navigate(newPage);
            }

            if (thisPage.GetType().ToString().Equals("ProjectA.View.ReadyView") && thisPageName.Equals("ToRecord")) //레디에서 기록 페이지 이동버튼 클릭
            {
                var PreviousPage = thisPage as ReadyView;

                var newPage = new RecordView();
                PreviousPage.NavigationService.Navigate(newPage);
            }
            if (thisPage.GetType().ToString().Equals("ProjectA.View.ReadyView") && thisPageName.Equals("ToWait"))   //레디에서 대기 페이지 이동버튼 클릭
            {
                var PreviousPage = thisPage as ReadyView;

                int StudentNum;

                if (PreviousPage.xNameTxtBox.Text == "" || PreviousPage.xStudentNumTxtBox.Text == "")
                    System.Windows.MessageBox.Show("빈 칸을 입력해주세요.");
                else
                {
                    if (int.TryParse(PreviousPage.xStudentNumTxtBox.Text, out StudentNum))
                    {
                        if (PreviousPage.xStudentNumTxtBox.Text.Length == 9)
                        {
                            var newPage = new WaitView();

                            newPage.xUserName.Text = PreviousPage.xNameTxtBox.Text;
                            classDB.SetUserName(PreviousPage.xNameTxtBox.Text);
                            classDB.SetUserStudentNum(PreviousPage.xStudentNumTxtBox.Text);
                            PreviousPage.NavigationService.Navigate(newPage);
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("9자리의 학번이 필요합니다");
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("학번은 숫자로 입력해야 합니다");
                    }
                }
            }

            if (thisPage.GetType().ToString().Equals("ProjectA.View.WaitView") && thisPageName.Equals("ToPlay"))    //대기에서 플레이 페이지 이동버튼 클릭
            {
                var PreviousPage = thisPage as WaitView;

                int h = int.Parse(PreviousPage.lblTime.Content.ToString().Substring(0, 1));

                if (h < 8)
                {
                    WaitViewPopUp WaitViewPopup = new WaitViewPopUp();
                    WaitViewPopup.Show();
                }
                else
                {
                    classDB.setTime(PreviousPage.lblTime.Content.ToString());
                    var newPage = new PlayView();
                    newPage.xUserName.Text = PreviousPage.xUserName.Text;

                    PreviousPage.NavigationService.Navigate(newPage);
                }
            }

            if (thisPage.GetType().ToString().Equals("ProjectA.View.PlayView") && thisPageName.Equals("ToResult"))  //플레이에서 결과 페이지 이동버튼 클릭
            {
                var PreviousPage = thisPage as PlayView;

                int h = int.Parse(PreviousPage.lblTime.Content.ToString().Substring(0, 1)) - 8;
                int m = int.Parse(PreviousPage.lblTime.Content.ToString().Substring(2, 2));
                int s = int.Parse(PreviousPage.lblTime.Content.ToString().Substring(5, 2));

                int usedTime = h * 3600 + m * 60 + s;
                classDB.SetUsedTime(usedTime.ToString());
                classDB.SetResultTime(PreviousPage.lblTime.Content.ToString());

                var newPage = new ResultView();
                PreviousPage.NavigationService.Navigate(newPage);
            }

            if (thisPage.GetType().ToString().Equals("ProjectA.View.ResultView") && thisPageName.Equals("ToRecord"))    //결과에서 기록 페이지 이동버튼 클릭
            {
                var PreviousPage = thisPage as ResultView;

                var newPage = new RecordView();
                PreviousPage.NavigationService.Navigate(newPage);
            }
            if (thisPage.GetType().ToString().Equals("ProjectA.View.ResultView") && thisPageName.Equals("ToReady"))     //결과에서 준비 페이지 이동버튼 클릭
            {
                var PreviousPage = thisPage as ResultView;

                var newPage = new ReadyView();
                PreviousPage.NavigationService.Navigate(newPage);
            }
        }
    }
}
