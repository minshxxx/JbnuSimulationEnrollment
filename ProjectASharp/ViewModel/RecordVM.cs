using ProjectA.Model;
using ProjectA.View;
using System.Collections.ObjectModel;
using System.IO;

namespace ProjectA.ViewModel
{
	public class RecordVM
	{
		public ObservableCollection<RecordInformation> Record { get; set; }
		public ObservableCollection<RecordControl> RecordList { get; set; }

		public RecordVM()
		{
			Record = new ObservableCollection<RecordInformation>();
			RecordList = new ObservableCollection<RecordControl>();
			
			ReadTxt();
			SortRecord(Record);
		}

		public void ReadTxt()	//저장된 결과 txt파일 읽어오는 함수
		{
			int counter = 0;
			string line1, line2, line3, line4, line5;
			int i = 0;

			StreamReader file1 = new StreamReader(@"RecordName.txt");
			StreamReader file2 = new StreamReader(@"RecordStudentNum.txt");
			StreamReader file3 = new StreamReader(@"RecordResultTime.txt");
			StreamReader file4 = new StreamReader(@"RecordSecond.txt");
			StreamReader file5 = new StreamReader(@"RecordRight.txt");

			while ((line1 = file1.ReadLine()) != null)
			{
				line2 = file2.ReadLine();
				line3 = file3.ReadLine();
				line4 = file4.ReadLine();
				line5 = file5.ReadLine();

				RecordInformation recordInformation = new RecordInformation(line1, line2, line3, int.Parse(line4), int.Parse(line5));
				Record.Add(recordInformation);
			}

			file1.Close();
			file2.Close();
			file3.Close();
			file4.Close();
			file5.Close();

			System.Console.WriteLine("There were {0} lines.", counter);
			// Suspend the screen.  
			System.Console.ReadLine();
		}
		public void SortRecord(ObservableCollection<RecordInformation> Record)		//저장된 결과를 순위로 Sorting해주는 함수
		{
			int length = Record.Count;

			RecordInformation tempRecord = new RecordInformation();

			for (int i=0; i<length; i++)
            {
				for(int j=i+1; j<length; j++)
                {
					if(Record[i].Right < Record[j].Right)
                    {
						tempRecord = Record[j];
						Record[j] = Record[i];
						Record[i] = tempRecord;
					}
					else if(Record[i].Right == Record[j].Right)
                    {
						if(Record[i].Second > Record[j].Second)
                        {
							tempRecord = Record[j];
							Record[j] = Record[i];
							Record[i] = tempRecord;
						}
                    }
                }
			}

			for (int i = 0; i < length; i++)
			{
				RecordControl recordControl = new RecordControl();
				recordControl.xName.Text = Record[i].Name;
				recordControl.xStudentNum.Text = Record[i].StudentNum;
				recordControl.xTime.Text = Record[i].ResultTime;
				recordControl.xRight.Text = Record[i].Right.ToString();
				string tempString = Record[i].Right.ToString() + "개";
				recordControl.xRank.Text = tempString;
				if (i == 0) recordControl.xRank.Text = "1st";
				else if (i == 1) recordControl.xRank.Text = "2nd";
				else if (i == 2) recordControl.xRank.Text = "3rd";
				else if (i == 3) recordControl.xRank.Text = "4th";
				else if (i == 4) recordControl.xRank.Text = "5th";
				else if (i == 5) recordControl.xRank.Text = "6th";
				else if (i == 6) recordControl.xRank.Text = "7th";
				else if (i == 7) recordControl.xRank.Text = "8th";
				RecordList.Add(recordControl);
			}
		}
	}
}
