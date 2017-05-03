using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SelfOrganizingNetwork
{
    public class FileOperation
    {
        public List<Tuple<double, double>> Coordinates { get; private set; }

        public FileOperation()
        {
            Coordinates = new List<Tuple<double, double>>();
        }

        public void LoadCoordinates()
        {
            string[] fileData = File.ReadAllLines(@"attract.txt");
            
            foreach(string line in fileData)
            {
                string[] splitedLine = line.Split(',');
                
                Coordinates.Add(new Tuple<double, double>(double.Parse(splitedLine[0].Replace('.',',')), double.Parse(splitedLine[1].Replace('.', ','))));
            }  
        }

        public void SaveCenterList(List<CenterPoint> list, string filename)
        {
            FileStream fileStream = new FileStream(filename, FileMode.Create);

            StreamWriter ostream = new StreamWriter(fileStream);
            foreach(CenterPoint cntPoint in list)
            {
                ostream.WriteLine(cntPoint.X + " " + cntPoint.Y);
            }

            ostream.Close();
            fileStream.Close();
        }

        public void SaveObservableList(List<ObservablePoint> list, string filename)
        {
            FileStream fileStream = new FileStream(filename, FileMode.Create);

            StreamWriter ostream = new StreamWriter(fileStream);
            foreach (ObservablePoint obsPoint in list)
            {
                ostream.WriteLine(obsPoint.X + " " + obsPoint.Y);
            }

            ostream.Close();
            fileStream.Close();
        }
    }
}
