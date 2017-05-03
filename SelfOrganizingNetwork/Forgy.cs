using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfOrganizingNetwork
{
    public class Forgy
    {
        private int NumberOfCenters { get; set; }
        public FileOperation fileOp { get; }

        public List<ObservablePoint> observableList { get; private set; }
        public List<CenterPoint> centerList { get; private set; }

        public List<double> mseValues { get; private set; }

        public Forgy(int numberOfCenters)
        {
            this.NumberOfCenters = numberOfCenters;
            fileOp = new FileOperation();

            observableList = new List<ObservablePoint>();
            centerList = new List<CenterPoint>();
            mseValues = new List<double>();

            fileOp.LoadCoordinates();
        }

        public void TupleToObjects()
        {
            foreach(Tuple<double,double> pair in fileOp.Coordinates)
            {
                observableList.Add(new ObservablePoint(pair.Item1, pair.Item2));
            }
        }

        public void RandCenters()
        {
            Random rnd = new Random();
            int it=0;
            for(int i =0; i<NumberOfCenters;i++)
            {
                it = rnd.Next(0, observableList.Count);
                centerList.Add(new CenterPoint(observableList.ElementAt(it)));
                //observableList.RemoveAt(it);  // Trzeba zdecydowac czy po przypisanu do ktoregos pkt. obser. centrum zdejmujemy go z tablicy czy nie
            }
        }

        public void AssignToCenter()
        {
            List<double> values = new List<double>();
            double dist;
            int index;
            foreach(ObservablePoint obsPoint in observableList)
            {
                foreach(CenterPoint cntPoint in centerList)
                {
                    dist = DistanceCalculation(cntPoint, obsPoint);
                    values.Add(dist);
                }

                index = values.IndexOf(values.Min());
                centerList.ElementAt(index).listOfObsPoint.Add(obsPoint);
                values.Clear();
            }
        }


        public double DistanceCalculation(CenterPoint cntPoint, ObservablePoint obsPoint)
        {
            double distance = 0;
            distance = Math.Sqrt(Math.Pow((cntPoint.X - obsPoint.X), 2) + Math.Pow((cntPoint.Y - obsPoint.Y), 2));

            return distance;
        }
        
        public void CentreCoordinatesCorrection()
        {
            double arythAvrgOfX;
            double arythAvrgOfY;
            foreach (CenterPoint cntPoint in centerList)
            {
                arythAvrgOfX = 0;
                arythAvrgOfY = 0;

                cntPoint.PrevAvgX = cntPoint.X;
                cntPoint.PrevAvgY = cntPoint.Y;

                foreach (ObservablePoint obsPoint in cntPoint.listOfObsPoint)
                {
                    arythAvrgOfX += obsPoint.X;
                    arythAvrgOfY += obsPoint.Y; 
                }
                arythAvrgOfX /= cntPoint.listOfObsPoint.Count;
                arythAvrgOfY /= cntPoint.listOfObsPoint.Count;

                cntPoint.X = arythAvrgOfX;
                cntPoint.Y = arythAvrgOfY;

                cntPoint.listOfObsPoint.Clear();
            }
        }

        public bool CheckTheDiff()
        {
            foreach(CenterPoint cntPoint in centerList)
            {
                if (cntPoint.X != cntPoint.PrevAvgX && cntPoint.Y != cntPoint.PrevAvgY)
                    return false;
            }

            return true;
        }

        public void MSECalculation()
        {
            List<double> values = new List<double>();
            double mseEpochValue = 0;
            double dist;

            foreach (ObservablePoint obsPoint in observableList)
            {
                foreach (CenterPoint cntPoint in centerList)
                {
                    dist = DistanceCalculation(cntPoint, obsPoint);
                    values.Add(dist);
                }

                mseEpochValue += values.Min();
                values.Clear();
            }

            mseEpochValue /= observableList.Count;
            mseValues.Add(mseEpochValue);
        }

    }
}
