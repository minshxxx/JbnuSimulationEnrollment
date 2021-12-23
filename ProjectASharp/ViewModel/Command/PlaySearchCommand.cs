using System;
using System.Windows;
using System.Windows.Input;

namespace ProjectA.ViewModel.Command
{
    public class PlaySearchCommand : ICommand
    {
        public PlayVM VM { get; set; }

        public PlaySearchCommand(PlayVM vm)
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
            if (parameter.ToString().Length >= 2)
            {
                VM.SearchPrintClassPanel(parameter.ToString());
            }
            else
            {
                MessageBox.Show("최소 두 글자 이상 입력해야 합니다.");
            }
        }
    }
}
