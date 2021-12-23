using ProjectA.View;
using System;
using System.Windows;
using System.Windows.Input;

namespace ProjectA.ViewModel.Command
{
    public class IndexButtonCommand : ICommand
    {
        public PlayVM VM { get; set; }

        ClassDB classDB = new ClassDB();

        public IndexButtonCommand(PlayVM vm)
        {
            VM = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var temp = parameter as ClassControl;

            PlayViewPopup playViewPopup = new PlayViewPopup();
            playViewPopup.ShowDialog();
            playViewPopup.Hide();


            if (int.Parse(temp.xClassStudentNum.Text) == 40)
            {
                Random ran = new Random();

                if (ran.Next(0, 10) == 4)
                {
                    VM.ClassList.Clear();
                    VM.ClickClassButton = int.Parse(temp.xApplyButton.ButtonIndex.ToString());
                }
                else
                    MessageBox.Show("정원이 초과되었습니다.");
            }
            else
            {
                VM.ClassList.Clear();
                VM.ClickClassButton = int.Parse(temp.xApplyButton.ButtonIndex.ToString());
            }
        }
    }
}
