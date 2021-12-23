using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Model
{
    public class RecordInformation
    {
        public RecordInformation (string inputName, string inputStudent, string inputResultTime, int inputSecond, int inputRight){
            Name = inputName;
            StudentNum = inputStudent;
            ResultTime = inputResultTime;
            Second = inputSecond;
            right = inputRight;
        }
        public RecordInformation()
        {
            Name = "";
            StudentNum = "";
            ResultTime = "";
            Second = 0;
            right = 0;
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        private string studentNum;
        public string StudentNum
        {
            get
            {
                return studentNum;
            }
            set
            {
                studentNum = value;
            }
        }
        private string resultTime;
        public string ResultTime
        {
            get
            {
                return resultTime;
            }
            set
            {
                resultTime = value;
            }
        }
        private int second;
        public int Second
        {
            get
            {
                return second;
            }
            set
            {
                second = value;
            }
        }
        private int right;
        public int Right
{
            get
            {
                return right;
            }
            set
            {
                right = value;
            }
        }
    }
}
