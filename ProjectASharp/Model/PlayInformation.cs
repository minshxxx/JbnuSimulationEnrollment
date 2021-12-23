using System.ComponentModel;

namespace ProjectA.Model
{
    public class PlayInformation : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public PlayInformation()
        {
            AppliedCnt = 0;
            RemainGradePoint = (6 - AppliedCnt) * 3;
            UsedGradePoint = appliedCnt * 3;
        }

        private int appliedCnt;
        public int AppliedCnt
        {
            get
            {
                return appliedCnt;
            }
            set
            {
                appliedCnt = value;
                OnPropertyChanged("AppliedCnt");
            }
        }
        private int remainGradePoint;
        public int RemainGradePoint
        {
            get
            {
                return remainGradePoint;
            }
            set
            {
                remainGradePoint = value;
                OnPropertyChanged("RemainGradePoint");
            }
        }
        private int usedGradePoint;
        public int UsedGradePoint
        {
            get
            {
                return usedGradePoint;
            }
            set
            {
                usedGradePoint = value;
                OnPropertyChanged("UsedGradePoint");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
