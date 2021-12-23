using System;
using System.Windows.Input;

namespace ProjectA.ViewModel.Command
{
    public class CancleButtonCommand : ICommand
    {
        public PlayVM VM { get; set; }

        ClassDB classDB = new ClassDB();

        public CancleButtonCommand(PlayVM vm)
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
            VM.CancleButtonProperty = int.Parse(parameter.ToString());
        }
    }
}
