using System.ComponentModel;

namespace ProjectA.Model
{
    public class ClassInformation : INotifyPropertyChanged
    {
        public ClassInformation(int inputCode, string inputName, string inputProfessor, string inputNum, string inputLocation, string inputTime, string inputType)
        {
            code = inputCode;
            name = inputName;
            professor = inputProfessor;
            num = inputNum;
            location = inputLocation;
            time = inputTime;
            type = inputType;
        }

        public ClassInformation()
        {
        }

        public int code;
        public int Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
                OnPropertyChanged("Code");
            }
        }

        public string type;
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }

        public string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged(Name);
            }
        }

        public string professor;
        public string Professor
        {
            get
            {
                return professor;
            }
            set
            {
                professor = value;
                OnPropertyChanged(Professor);
            }
        }

        public string num;
        public string Num
        {
            get
            {
                return num;
            }
            set
            {
                num = value;
                OnPropertyChanged(Num);
            }
        }

        public string location;
        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
                OnPropertyChanged(Location);
            }
        }

        public string time;
        public string Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
                OnPropertyChanged(Time);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void OnPropertyChanged(int propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName.ToString()));
            }
        }
    }
}
