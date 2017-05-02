using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfOrganizingNetwork
{
    public class CenterPoint
    {
        public List<ObservablePoint> listOfObsPoint { get; set; }

        public CenterPoint(ObservablePoint obsPoint)
        {
            this.X = obsPoint.X;
            this.Y = obsPoint.Y;

            listOfObsPoint = new List<ObservablePoint>();

            PrevAvgX = 0;
            PrevAvgY = 0;
        }

        public double X
        {
            get;
            set;
        }

        public double Y
        {
            get;
            set;
        }

        public double PrevAvgX { get; set; }
        public double PrevAvgY { get; set; }

        public double GroupOfCenter
        {
            get;
            set;
        }
    }
}
