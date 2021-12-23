using System.IO;

namespace ProjectA.Text
{
    public class Normal_NaturalScience
    {
        public static int num = 48; //데이터 수

        public string[] SubName = new string[num];
        public string[] ProName = new string[num];
        public string[] SubNum = new string[num];
        public string[] Location = new string[num];
        public string[] Time = new string[num];

        public void ReadTxt()
        {
            int counter = 0;
            string line;
            int i = 0;

            StreamReader file = new StreamReader(@"Normal_NaturalScience.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (i / num == 0)
                    SubName[i] = line;
                else if (i / num == 1)
                    ProName[i - num * 1] = line;
                else if (i / num == 2)
                    SubNum[i - num * 2] = line;
                else if (i / num == 3)
                    Location[i - num * 3] = line;
                else if (i / num == 4)
                    Time[i - num * 4] = line;

                i++;
            }

            file.Close();

            System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            System.Console.ReadLine();
        }

        public string Show(int i)
        {
            return SubName[i] + ProName[i] + SubNum[i] + Location[i] + Time[i];
        }

    }
}
