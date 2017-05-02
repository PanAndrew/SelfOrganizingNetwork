using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfOrganizingNetwork
{
    public class RandomPartition
    {
        private int NumberOfCenters { get; set; }
        public FileOperation fileOp { get; }

        public List<ObservablePoint> observableList { get; private set; }
        public List<CenterPoint> centerList { get; private set; }

        public RandomPartition(int numberOfCenters)
        {
            this.NumberOfCenters = numberOfCenters;
            fileOp = new FileOperation();

            observableList = new List<ObservablePoint>();
            centerList = new List<CenterPoint>();

            fileOp.LoadCoordinates();
        }

        public void TupleToObjects()
        {
            foreach (Tuple<double, double> pair in fileOp.Coordinates)
            {
                observableList.Add(new ObservablePoint(pair.Item1, pair.Item2));
            }
        }

        public void RandCenters()
        {
            Random rnd = new Random();
            int it = 0;
            for (int i = 0; i < NumberOfCenters; i++)
            {
                it = rnd.Next(0, observableList.Count);
                centerList.Add(new CenterPoint(observableList.ElementAt(it)));
                //observableList.RemoveAt(it);  // Trzeba zdecydowac czy po przypisanu do ktoregos pkt. obser. centrum zdejmujemy go z tablicy czy nie ale raczej nie
            }
        }

        public void RandomAssignToCenters()
        {
            Random rand = new Random();
            int it = 0;
            foreach (ObservablePoint obsPoint in observableList)
            {
                it = rand.Next(0, centerList.Count);
                centerList.ElementAt(it).listOfObsPoint.Add(obsPoint);
            }
        }

        public void AssignToCenter()
        {
            List<double> values = new List<double>();
            double dist;
            int index;
            foreach (ObservablePoint obsPoint in observableList)
            {
                foreach (CenterPoint cntPoint in centerList)
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
            foreach (CenterPoint cntPoint in centerList)
            {
                if (cntPoint.X != cntPoint.PrevAvgX && cntPoint.Y != cntPoint.PrevAvgY)
                    return false;
            }

            return true;
        }
    }
}
